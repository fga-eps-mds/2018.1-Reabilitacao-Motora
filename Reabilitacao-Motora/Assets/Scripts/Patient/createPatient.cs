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

	public InputField namePatient;
	public InputField date;
	public InputField phone1;
	public InputField phone2;
	public InputField notes;
	public Toggle male;
	public Toggle female;

	public Text validationName;
	public Text validationDate;
	public Text validationSex;
	public Text validationPhone;

	/**
 	 * Salva o paciente no banco.
 	 */
	public void savePatient()
	{
<<<<<<< HEAD
		if(name.text == "" || date.text == "" || phone1.text == "" || (male.isOn == false && female.isOn == false)) {
			if (name.text == "") {
				validationName.text = "Campo obrigatório!";
			}
			if (date.text == "") {
				validationDate.text = "Campo obrigatório!";
			}
			if (phone1.text == "") {
				validationPhone.text = "Campo obrigatório!";
			}
			if (male.isOn == false && female.isOn == false) {
				validationSex.text = "Deve haver um selecionado!";
			}
=======
		if(namePatient.text == "" || date.text == "" || phone1.text == "") {
			
>>>>>>> ad243b0691178f51cae726d3c06616e25baf4ea8
		} else {
			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
		
			tablePessoa = new Pessoa(path);
			tablePaciente = new Paciente(path);
			if (male.isOn)
				tablePessoa.Insert(namePatient.text, "m", dateFormate, phone1.text, phone2.text);
			else if(female.isOn)
				tablePessoa.Insert(namePatient.text, "f", dateFormate, phone1.text, phone2.text);

			List<Pessoa.Pessoas> p = tablePessoa.Read();
			
			tablePaciente.Insert(p[p.Count -1].idPessoa, notes.text);
			//tableTelefone.Insert(p[p.Count -1].idPessoa, phone.text);
		}
	}
}
