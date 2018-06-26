using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Text;
using DataBaseAttributes;
using musculo;
using movimentomusculo;
using movimento;

/**
* Cria um novo paciente no banco de dados.
*/
public class createMovement : MonoBehaviour
{
	[SerializeField]
	protected InputField nomeMovimento, musculos, descricao;
	/**
	* Salva o Movimento no banco.
	*/
	public void saveMovement()
	{
		List<InputField> allInputs = new List<InputField>();

		allInputs.Add(nomeMovimento);
		allInputs.Add(musculos);
		allInputs.Add(descricao);

		if (ValidInput (allInputs))
		{
			foreach (var x in allInputs)
			{
				ApplyColor (x, 1);
			}

			var muscles = GetWords(musculos.text);

			string movunderscored = (nomeMovimento.text).Replace(' ', '_');
			string physiounderscored = (GlobalController.instance.admin.persona.nomePessoa).Replace(' ', '_');

			StringBuilder path = new StringBuilder();
			path.Append(GlobalController.instance.admin.idPessoa + "-");
			path.Append(physiounderscored + "/");
			path.Append(movunderscored + "-");
			path.Append(DateTime.Now.ToString("HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
			path.Append(".points");

			string pathSave = path.ToString();

			Movimento.Insert (GlobalController.instance.admin.idFisioterapeuta,
															nomeMovimento.text, 
																	  pathSave, 
															    descricao.text);

			var lastMovement = Movimento.GetLast();
			GlobalController.instance.movement = lastMovement;

			foreach (var muscle in muscles)
			{
				if (!checkMuscle(muscle))
				{
					Musculo.Insert(muscle);
					Musculo lastMusculo = Musculo.GetLast();
					MovimentoMusculo.Insert(lastMusculo.idMusculo, lastMovement.idMovimento);
				} else {
					Musculo musculoExistente = presentMuscle(muscle);
					MovimentoMusculo.Insert(musculoExistente.idMusculo, lastMovement.idMovimento);
				}
			}

			GlobalController.patientOrPhysio = true;

			
			// Checks the sensor choice from the file

			StringBuilder sensorPath = new StringBuilder();
			sensorPath.Append("sensor.choice");
        
        	string choicePath = sensorPath.ToString();

			if (File.Exists(choicePath)) // User has already chosen a sensor
        	{
				string line = File.ReadAllText(choicePath);
				int fileValue = Convert.ToInt32(line);
				
				if ( fileValue.Equals(0) ) // Kinect selected
				{
					GlobalController.Sensor = false;
				}
				else if ( fileValue.Equals(1) ) // UDP selected
				{
					GlobalController.Sensor = true;
				}
        	}
			else // Kinect is default value
			{
				GlobalController.Sensor = false;
			}

			// Redirects user to correct scene

			if(GlobalController.Sensor == false)
			{
				Flow.StaticRealtimeGraphKinectPhysio();
			}
			else
			{
				Flow.StaticRealtimeGraphUDPPhysio();				
			
			}
		}
	}

	static bool checkMuscle (string name)
	{
		var query = string.Format("SELECT count(*) FROM MUSCULO WHERE \"nomeMusculo\"=\"{0}\";", name);
		int count = DataBase.CountRead(query);
		Debug.Log(count);
		return (count != 0);
	}

	static Musculo presentMuscle (string name)
	{
		var query = string.Format("SELECT * FROM MUSCULO WHERE \"nomeMusculo\"=\"{0}\";", name);
		Musculo mus = Musculo.SingleSpecificSelect(query);
		
		return mus;
	}

	public static bool ValidInput (List<InputField> inputs)
	{
		bool valid = true;

		string treatName = TreatFields.NameField (inputs[0].text);

		if (treatName != "")
		{
			var splitBar = treatName.Split('|');
			foreach (var erro in splitBar)
			{
				print (erro);
			}

			ApplyColor (inputs[0], 0);
			valid = false;
		}
		else
		{
			ApplyColor (inputs[0], 2);
		}

		return valid;
	}

	public static void ApplyColor (InputField input, int ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}
	
	public static List<string> GetWords (string input)
	{
		MatchCollection m = new Regex(@"[\p{L}\s]+").Matches(input);
		List<string> words = new List<string>();
		foreach (Match item in m)
		{
			Debug.Log(item.Value);
		    words.Add(item.Value);
		}

		return words;
	}
}
