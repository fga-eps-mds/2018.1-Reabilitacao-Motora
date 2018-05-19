using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

using cryptpw;

using pessoa;
using fisioterapeuta;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class TreatFields : MonoBehaviour 
{
	[SerializeField]
	protected InputField namePhysio, date, phone1, phone2, crefito, regiao, login, pass, confirmPass;

	[SerializeField]
	protected Toggle male, female;

	public static string NameField (string name)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[a-zA-Z ]*$");
		if(!normalString.IsMatch(name))
		{
			return "Nome deve conter apenas letras!";
		}
		else
		{
			return "";
		}
	}

	public static string DateField (string date)
	{
		var trip = date.Split('/');
		int dia = Int32.Parse(trip[0]), mes = Int32.Parse(trip[1]), ano = Int32.Parse(trip[2]);

		string currentMonth = DateTime.Now.Month.ToString();
		string currentYear = DateTime.Now.Year.ToString();

		string result = "";

		if (dia > 31 || (dia > 28 && mes == 2) || dia < 0)
		{
			result += "Dia inválido!|";
		}
		if (mes < 0 || mes > 12 || (mes > currentMonth && ano == currentYear))
		{
			result += "Mês inválido!|";
		}
		if (ano < 1910 || ano > currentYear)
		{
			result += "Ano inválido!";
		}

		return result;
	}

	public static string EmptyField (string field)
	{
		string result = "";

		if (field.Length == 0)
		{
			result += "Campo Obrigatório!";
		}

		return result;
	}

	public static string PhoneField (string phone)
	{
		if (phone.Length < 8)
		{
			return "Insira um número válido!";
		}
		else
		{
			return "";
		}
	}

	public static string CrefitoField (string crefito)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[0-9 ]*$");
		if (!normalString.IsMatch(crefito))
		{
			return "Insira apenas 6 dígitos/números!";
		}
		else
		{
			return "";
		}
	}


}
