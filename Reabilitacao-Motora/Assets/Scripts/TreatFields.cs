using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public static class TreatFields
{

	public static string NameField (string name)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[a-zA-Z ]*$");
		string result = "";

		int count = 0;
		foreach (char c in name)
		{
			if (c == ' ')
			{
				count++;
			}
		}

		if(!normalString.IsMatch(name))
		{
			result += "Nome deve conter apenas letras!|";
		}

		if (name.Length < 8 || count == 0)
		{
			result += "Insira nome e sobrenome!|";
		}

		result += EmptyField (name);

		return result;
	}

	public static string DateField (string date)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[0-9/]*$");

		if(!normalString.IsMatch(date))
		{
			return "Data deve conter apenas números!|";
		}

		var trip = date.Split('/');

		int dia = Int32.Parse(trip[0]), mes = Int32.Parse(trip[1]), ano = Int32.Parse(trip[2]);

		int currentMonth = DateTime.Now.Month;
		int currentYear = DateTime.Now.Year;

		string result = "";

		int count = 0;
		foreach (char c in date)
		{
			if (c == '/')
			{
				count++;
			}
		}

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
			result += "Ano inválido!|";
		}
		if (count != 2 || date.Length != 10)
		{
			result += "Insira uma data válida! Formato dia/mes/ano|";
		}

		result += EmptyField (date);

		return result;
	}

	public static string EmptyField (string field)
	{
		string result = "";

		if (field.Length == 0)
		{
			result += "Campo Obrigatório!|";
		}

		return result;
	}

	public static string PhoneField (string phone)
	{
		string result = "";
		var normalString = new System.Text.RegularExpressions.Regex("^[0-9 -]*$");
		if (!normalString.IsMatch(phone))
		{
			result += "Apenas números e/ou hífens!|";
		}

		if (phone.Length < 8)
		{
			result += "Insira um número válido!|";
		}

		result += EmptyField (phone);

		return result;
	}

	public static string CrefitoField (string crefito)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[0-9 ]*$");
		string result = "";

		if (!normalString.IsMatch(crefito))
		{
			result += "Insira apenas 6 dígitos/números!|";
		}

		if (crefito.Length != 6)
		{
			result += "Insira exatamente 6 dígitos/números!|";
		}

		result += EmptyField (crefito);

		return result;
	}

	public static string LoginField (string login)
	{
		var normalString = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 ]*$");
		string result = "";

		if(!normalString.IsMatch(login))
		{
			result += "Login deve conter apenas letras e/ou números!|";
		}

		if (login.Length < 6)
		{
			result += "Login deve ter no mínimo 6 caractéres.|";
		}

		result += EmptyField (login);

		return result;
	}

	public static string PasswordField (string password)
	{
		string result = "";

		if(password.Length < 8)
		{
			result += "A senha deve possuir no mínimo 8 caractéres!|";
		}

		result += EmptyField (password);

		return result;
	}

	public static string RegionField (string region)
	{
		string result = "";

		if(region.Length != 2)
		{
			result += "Insira uma região válida!|";
		}

		var normalString = new System.Text.RegularExpressions.Regex("^[A-Z ]*$");

		if(!normalString.IsMatch(region))
		{
			result += "Região deve conter apenas letras maiúsculas!|";
		}

		result += EmptyField (region);

		return result;
	}

	public static string ConfirmPasswordField (string password, string confirm)
	{
		string result = "";

		if(password != confirm)
		{
			result += "As senhas não condizem!|";
		}

		result += EmptyField (confirm);

		return result;
	}

	public static string SexField (bool male, bool female)
	{
		if (male == female)
		{
			return "Selecione um, e apenas um, sexo!|";
		}
		else
		{
			return "";
		}
	}
	}
