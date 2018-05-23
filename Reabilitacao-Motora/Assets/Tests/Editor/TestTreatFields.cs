using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
namespace Tests
{
	public static class TestTreatFields
	{
		[Test]
		public static void NameField ()
		{
			var test_empty = TreatFields.NameField ("");
			var test_nonAlpha = TreatFields.NameField ("asdu98792kl$# lpl´~çpo");
			var test_goodName = TreatFields.NameField ("John Does");
			var test_shortName = TreatFields.NameField ("aha");
			var test_shortNonAlpha = TreatFields.NameField("a#h");
			var test_nonAlphaWithoutSpaces = TreatFields.NameField("a#hk7%1kfa@");

			var nonalpha = "Nome deve conter apenas letras!|";
			var shortname = "Insira nome e sobrenome!|";
			var empty = "Campo Obrigatório!|";

			Assert.AreEqual(test_empty, shortname+empty);
			Assert.AreEqual(test_nonAlpha, nonalpha);
			Assert.AreEqual(test_goodName, "");
			Assert.AreEqual(test_shortName, shortname);
			Assert.AreEqual(test_shortNonAlpha, nonalpha+shortname);
			Assert.AreEqual(test_nonAlphaWithoutSpaces, nonalpha+shortname);
		}

		[Test]
		public static void DateField ()
		{
			int currentDay = System.DateTime.Now.Day;
			int currentMonth = System.DateTime.Now.Month;
			int currentYear = System.DateTime.Now.Year;

			var MonthLeadingZero = Regex.Replace((currentMonth+1).ToString(), @"\d+", m => m.Value.PadLeft(2, '0'));
			var DayLeadingZero = Regex.Replace((currentDay+1).ToString(), @"\d+", m => m.Value.PadLeft(2, '0'));
			var currentMonthStr = Regex.Replace((currentMonth).ToString(), @"\d+", m => m.Value.PadLeft(2, '0'));
			var currentDayStr = Regex.Replace((currentDay).ToString(), @"\d+", m => m.Value.PadLeft(2, '0'));

			var test_nonNumber = TreatFields.DateField ("aa/bb/19cD");
			var test_impossibleOld = TreatFields.DateField ("01/01/1500");
			var test_terminatorMcFly = TreatFields.DateField (string.Format("01/01/{0}", (currentYear+1)));
			var test_carnivalTillEndOfYear = TreatFields.DateField ("29/02/2018");
			var test_whatMonth = TreatFields.DateField ("01/13/1930");
			var test_whatDay = TreatFields.DateField ("32/01/1930");
			var test_negativeDay = TreatFields.DateField ("-01/01/1930");
			var test_negativeMonth = TreatFields.DateField ("01/-2/1930");
			var test_negativeYear = TreatFields.DateField ("01/01/-1930");
			var test_shortenedDate = TreatFields.DateField ("01/1930");
			var test_extendedDate = TreatFields.DateField ("101/01/1930");
			var test_emptyDate = TreatFields.DateField ("");
			var test_monthAhead = TreatFields.DateField (string.Format("01/{0}/{1}", MonthLeadingZero, currentYear));
			var test_neutralDayMonth = TreatFields.DateField ("00/00/2015");
			var test_dayAhead = TreatFields.DateField (string.Format("{0}/{1}/{2}", DayLeadingZero, currentMonthStr, currentYear));
			var test_Today = TreatFields.DateField (string.Format("{0}/{1}/{2}", currentDayStr, currentMonthStr, currentYear));
			var test_Normal = TreatFields.DateField("01/04/1997");

			var nonNumeric = "Data deve conter apenas números!|";
			var invalidDay = "Dia inválido!|";
			var invalidMonth = "Mês inválido!|";
			var invalidYear = "Ano inválido!|";
			var wrongFormat = "Insira uma data válida! Formato dia/mes/ano|";

			Assert.AreEqual(test_nonNumber, nonNumeric);
			Assert.AreEqual(test_impossibleOld, invalidYear);
			Assert.AreEqual(test_terminatorMcFly, invalidYear);
			Assert.AreEqual(test_carnivalTillEndOfYear, invalidDay);
			Assert.AreEqual(test_whatMonth, invalidMonth);
			Assert.AreEqual(test_whatDay, invalidDay);
			Assert.AreEqual(test_negativeDay, nonNumeric);
			Assert.AreEqual(test_negativeMonth, nonNumeric);
			Assert.AreEqual(test_negativeYear, nonNumeric);
			Assert.AreEqual(test_shortenedDate, wrongFormat);
			Assert.AreEqual(test_extendedDate, wrongFormat);
			Assert.AreEqual(test_emptyDate, wrongFormat);
			Assert.AreEqual(test_monthAhead, invalidMonth);
			Assert.AreEqual(test_dayAhead, invalidDay);
			Assert.AreEqual(test_Today, "");
			Assert.AreEqual(test_neutralDayMonth, invalidDay+invalidMonth);
			Assert.AreEqual(test_Normal, "");
		}
	}
}