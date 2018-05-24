using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using paciente;
using pessoa;

/**
 * Esta classe testa os métodos referentes a paciente.
 */
namespace Tests
{
	public static class TestPatient
	{
        /** 
         * Este método testa a função de mudar a cor de um inputfield.
         */
        /* 
        [Test]
		public static void TestApplyColor ()
		{
            InputField inputResponse = null;
            InputField inputExpeted = null;

            inputExpeted.colors = ColorManager.SetColor(inputExpeted.colors, true);

            createPatient.ApplyColor(inputResponse, true);
            
            Assert.AreEqual(inputExpeted.colors, inputResponse.colors);
        }
        */

        /* 
        [Test]
        public static void TestValidInput ()
        {
            InputField name = new InputField ();
            InputField date = new InputField ();
            InputField phone1 = new InputField ();
            Toggle masc = new Toggle ();
            Toggle fem = new Toggle ();

            List<InputField> inputs = new List<InputField>();
            List<Toggle> toggles = new List<Toggle>();

            masc.isOn = true;
            name.text = "Izabella Ribeiro";
            date.text = "15/10/1998";
            phone1.text = "61992960111";

            inputs.Add(name);
            inputs.Add(date);
            inputs.Add(phone1);
            toggles.Add(masc);
            toggles.Add(fem);

            bool response = createPatient.ValidInput(inputs, toggles);

            Assert.AreEqual(response, true);
        }
        */

        /*
        [Test]
        public static void TestSavePatient ()
        {
            Flow.StaticLogin();
			Flow.StaticNewPatient();

			yield return null;
			
			var objectPatient = GameObject.Find("Patient Manager");
			var PatientManager = objectPatient.GetComponentInChildren<createPatient>();

			var objectButton = GameObject.Find("Canvas/PanelPatient/SaveBt");
			var button = objectButton.GetComponentInChildren<Button>();

			InputField aux = (InputField)physioManager.GetMemberValue("namePhysio");
			aux.text = "Fake Name";
			physioManager.SetMemberValue("namePhysio", aux);

			InputField aux1 = (InputField)physioManager.GetMemberValue("date");
			aux1.text = "01/01/1920";
			physioManager.SetMemberValue("date", aux1);
			
			InputField aux3 = (InputField)physioManager.GetMemberValue("phone1");
			aux3.text = "61999999";
			physioManager.SetMemberValue("phone1", aux3);

			InputField aux7 = (InputField)physioManager.GetMemberValue("login");
			aux7.text = "fake_login";
			physioManager.SetMemberValue("login", aux7);

			InputField aux8 = (InputField)physioManager.GetMemberValue("pass");
			aux8.text = "fake_pass";
			physioManager.SetMemberValue("pass", aux8);

			InputField aux9 = (InputField)physioManager.GetMemberValue("confirmPass");
			aux9.text = "fake_pass";
			physioManager.SetMemberValue("confirmPass", aux9);

			Toggle aux2 = (Toggle)physioManager.GetMemberValue("male");
			aux2.isOn = true;
			physioManager.SetMemberValue("male", aux2);

			Toggle aux0 = (Toggle)physioManager.GetMemberValue("female");
			aux0.isOn = false;
			physioManager.SetMemberValue("female", aux0);

			button.OnPointerClick(new PointerEventData(EventSystem.current));

			int IdFisioterapeuta = GlobalController.instance.admin.idFisioterapeuta;
			int IdPessoa = GlobalController.instance.admin.persona.idPessoa;
			Fisioterapeuta.DeleteValue(IdFisioterapeuta);
			Pessoa.DeleteValue(IdPessoa);

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(expectedscene, currentscene);
        }
        */
    }
}