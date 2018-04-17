using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;
using telefone;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createPatient : MonoBehaviour 
{
	string path;
	Pessoa tablePessoa;
	Paciente tablePaciente;
	Telefone tableTelefone;

	public InputField namePatient;
	public InputField date;
	public InputField phone;
	public InputField notes;

	/**
 	 * Salva o paciente no banco.
 	 */
	public void savePatient()
	{
		path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

		var trip = date.text.Split('/');
		var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
		
		tablePessoa = new Pessoa(path);
		tablePaciente = new Paciente(path);
		tablePessoa.Insert(namePatient.text, "f", dateFormate);

		List<Pessoa.Pessoas> p = tablePessoa.Read();
		
		tablePaciente.Insert(p[p.Count -1].idPessoa, notes.text);
		// tableTelefone.Insert(p[p.Count -1].idPessoa, phone.text);
	}
}
