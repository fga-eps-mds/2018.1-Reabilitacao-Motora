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

			var empty = "Campo Obrigatório!|";
			var nonalpha = "Nome deve conter apenas letras!|";
			var shortname = "Insira nome e sobrenome!|";

			Assert.AreEqual(test_empty, shortname+empty);
			Assert.AreEqual(test_nonAlpha, nonalpha);
			Assert.AreEqual(test_goodName, "");
			Assert.AreEqual(test_shortName, shortname);
			Assert.AreEqual(test_shortNonAlpha, nonalpha+shortname);
			Assert.AreEqual(test_nonAlphaWithoutSpaces, nonalpha+shortname);
		}
	}
}