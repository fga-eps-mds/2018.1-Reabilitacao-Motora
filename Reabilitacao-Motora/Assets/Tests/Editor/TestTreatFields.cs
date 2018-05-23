using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using fisioterapeuta;
using pessoa;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
namespace Tests
{
	public static class TestTreatFields
	{
		[Test]
		public static void TestNameField ()
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
		public static void TestDateField ()
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

		[Test]
		public static void TestEmptyField ()
		{
			var test_empty = TreatFields.EmptyField ("");
			var test_filled = TreatFields.EmptyField("abc");
			
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual(test_empty, empty);
			Assert.AreEqual(test_filled, "");
		}

		[Test]
		public static void TestPhoneField ()
		{
			var test_empty = TreatFields.PhoneField ("");
			var test_unformated = TreatFields.PhoneField ("(+55) 61 9997-0123");
			var test_nonnumeric = TreatFields.PhoneField ("auahsuhasuhs");
			var test_short = TreatFields.PhoneField ("9998777");
			var test_shortNonNumeric = TreatFields.PhoneField("sadh");
			var test_good = TreatFields.PhoneField("61 9969-0107");

			string empty = "Campo Obrigatório!|";
			string unformated = "Apenas números e/ou hífens!|";
			string shorty = "Insira um número válido!|";

			Assert.AreEqual(test_empty, shorty+empty);
			Assert.AreEqual(test_unformated, unformated);
			Assert.AreEqual(test_nonnumeric, unformated);
			Assert.AreEqual(test_short, shorty);
			Assert.AreEqual(test_shortNonNumeric, unformated+shorty);
			Assert.AreEqual(test_good, "");
		}

		[Test]
		public static void TestCrefitoField ()
		{
			var test_empty = TreatFields.CrefitoField ("");
			var test_nonNumeric = TreatFields.CrefitoField ("12718b");
			var test_nonNumericShort = TreatFields.CrefitoField ("asd65");
			var test_nonNumericBig = TreatFields.CrefitoField ("12718bda8sg8");
			var test_good = TreatFields.CrefitoField ("123456");
			var test_short = TreatFields.CrefitoField ("1234");
			var test_big = TreatFields.CrefitoField ("123456789");

			string nonNumeric = "Insira apenas 6 dígitos/números!|";
			string shortbig = "Insira exatamente 6 dígitos/números!|";
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual(test_empty, shortbig+empty);
			Assert.AreEqual(test_nonNumeric, nonNumeric);
			Assert.AreEqual(test_nonNumericShort, nonNumeric+shortbig);
			Assert.AreEqual(test_nonNumericBig, nonNumeric+shortbig);
			Assert.AreEqual(test_good, "");
			Assert.AreEqual(test_short, shortbig);
			Assert.AreEqual(test_big, shortbig);
		}

		[Test]
		public static void TestRegionField ()
		{
			var test_empty = TreatFields.RegionField ("");
			var test_good = TreatFields.RegionField ("DF");
			var test_short = TreatFields.RegionField ("D");
			var test_big = TreatFields.RegionField ("DEEFF");
			var test_shortNonAlpha = TreatFields.RegionField ("1");
			var test_bigNonAlpha = TreatFields.RegionField ("123");
			var test_nonAlpha = TreatFields.RegionField ("12");
			var test_unCaps = TreatFields.RegionField ("df");
			var test_shortUnCaps = TreatFields.RegionField ("d");
			var test_bigUnCaps = TreatFields.RegionField ("deeff");

			string shortbig = "Insira uma região válida!|";
			string unformated = "Região deve conter apenas letras maiúsculas!|";
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual(test_empty, shortbig+empty);
			Assert.AreEqual(test_good, "");
			Assert.AreEqual(test_short, shortbig);
			Assert.AreEqual(test_big, shortbig);
			Assert.AreEqual(test_shortNonAlpha, shortbig+unformated);
			Assert.AreEqual(test_bigNonAlpha, shortbig+unformated);
			Assert.AreEqual(test_nonAlpha, unformated);
			Assert.AreEqual(test_unCaps, unformated);
			Assert.AreEqual(test_shortUnCaps, shortbig+unformated);
			Assert.AreEqual(test_bigUnCaps, shortbig+unformated);
		}

		[Test]
		public static void TestLoginField ()
		{
			var test_empty = TreatFields.LoginField ("");
			var test_shortNonAlphaNumeric = TreatFields.LoginField ("@#k4");
			var test_nonAlphaNumeric = TreatFields.LoginField ("k$%k4@1%s");
			var test_short = TreatFields.LoginField ("alpe");
			var test_good = TreatFields.LoginField ("joaozinho2");
			
			string nonAlphaNumeric = "Login deve conter apenas letras e/ou números!|";
			string shorty = "Login deve ter no mínimo 6 caractéres.|";
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual (test_empty, shorty+empty);
			Assert.AreEqual (test_shortNonAlphaNumeric, nonAlphaNumeric+shorty);
			Assert.AreEqual (test_nonAlphaNumeric, nonAlphaNumeric);
			Assert.AreEqual (test_short, shorty);
			Assert.AreEqual (test_good, "");
		}

		[Test]
		public static void TestPasswordField ()
		{
			var test_empty = TreatFields.PasswordField ("");
			var test_shorty = TreatFields.PasswordField ("abc12");
			var test_good = TreatFields.PasswordField ("abcdh$!24jfnsaf!@$5");

			string shorty = "A senha deve possuir no mínimo 8 caractéres!|";
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual (test_empty, shorty+empty);
			Assert.AreEqual (test_shorty, shorty); 
			Assert.AreEqual (test_good, "");
		}

		[Test]
		public static void TestConfirmPasswordField ()
		{
			var test_oneEmpty = TreatFields.ConfirmPasswordField ("", "abcdefghj1");
			var test_secondEmpty = TreatFields.ConfirmPasswordField ("abcdefghj1", "");
			var test_bothEmpty = TreatFields.ConfirmPasswordField ("", "");
			var test_unEqual = TreatFields.ConfirmPasswordField ("ausdihasifj4", "14j1o2hui124");
			var test_good = TreatFields.ConfirmPasswordField ("abracadabra", "abracadabra");

			string unequal = "As senhas não condizem!|";
			string empty = "Campo Obrigatório!|";

			Assert.AreEqual (test_oneEmpty, unequal);
			Assert.AreEqual (test_secondEmpty, unequal+empty);
			Assert.AreEqual (test_bothEmpty, empty);
			Assert.AreEqual (test_unEqual, unequal);
			Assert.AreEqual (test_good, "");
		}

		[Test]
		public static void TestSexField ()
		{
			var test_wrongMinus = TreatFields.SexField (false, false);
			var test_wrongPlus = TreatFields.SexField (true, true);
			var test_goodMale = TreatFields.SexField (true, false);
			var test_goodFemale = TreatFields.SexField (false, true);

			var wrong = "Selecione um, e apenas um, sexo!|";

			Assert.AreEqual (test_wrongMinus, wrong);
			Assert.AreEqual (test_wrongPlus, wrong);
			Assert.AreEqual (test_goodMale, "");
			Assert.AreEqual (test_goodFemale, "");
		}

		[Test]
		public static void TestUniqueCrefitoRegion ()
		{
			GlobalController.Initialize();

			Pessoa.Insert("fake name", "m", "1930-01-01", "61235235", null);
			List<Pessoa> pessoas = Pessoa.Read();
			var idPessoa = pessoas[pessoas.Count - 1].idPessoa;
			Fisioterapeuta.Insert(idPessoa, "abcdefghj1", "asuihasiudh11829", "DF", "123456");
			List<Fisioterapeuta> allPhysios = Fisioterapeuta.Read();
			var idFisio = allPhysios[allPhysios.Count - 1].idFisioterapeuta;

			var test_exists = TreatFields.UniqueCrefitoRegion ("123456", "DF");
			var test_dontRegion = TreatFields.UniqueCrefitoRegion ("123456", "PE");
			var test_dontCrefito = TreatFields.UniqueCrefitoRegion ("613752", "DF");
			var test_dont = TreatFields.UniqueCrefitoRegion ("516523", "SL");
			
			Fisioterapeuta.DeleteValue(idFisio);
			Pessoa.DeleteValue(idPessoa);

			string exists = "Regiao + Crefito inválidos! (já cadastrados)";

			Assert.AreEqual (test_exists, exists);
			Assert.AreEqual (test_dontRegion, "");
			Assert.AreEqual (test_dontCrefito, "");
			Assert.AreEqual (test_dont, "");
		}

		[Test]
		public static void TestUniqueLoginPassword ()
		{
			GlobalController.Initialize();

			Pessoa.Insert("fake name", "m", "1930-01-01", "61235235", null);
			List<Pessoa> pessoas = Pessoa.Read();
			var idPessoa = pessoas[pessoas.Count - 1].idPessoa;
			Fisioterapeuta.Insert(idPessoa, "abcdefghj1", "asuihasiudh11829", "DF", "123456");
			List<Fisioterapeuta> allPhysios = Fisioterapeuta.Read();
			var idFisio = allPhysios[allPhysios.Count - 1].idFisioterapeuta;

			var test_exists = TreatFields.UniqueLoginPassword ("abcdefghj1");
			var test_dontexist = TreatFields.UniqueLoginPassword ("oaijfo3u4194j12");

			string exists = "Login inválido! (já cadastrado)";

			Fisioterapeuta.DeleteValue(idFisio);
			Pessoa.DeleteValue(idPessoa);

			Assert.AreEqual (test_exists, exists);
			Assert.AreEqual (test_dontexist, "");
		}
	}
}