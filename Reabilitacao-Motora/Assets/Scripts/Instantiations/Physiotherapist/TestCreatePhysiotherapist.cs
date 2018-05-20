using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using pessoa;
using fisioterapeuta;

namespace Tests
{
	public static class TestCreatePhysiotherapist
	{
		[UnityTest]
		public static IEnumerator TestPhysioManagerInputFields()
		{
			Flow.StaticLogin();
			Flow.StaticNewPhysiotherapist();

			yield return null;

			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			Assert.AreNotEqual(null, physioManager.GetMemberValue("namePhysio"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("date"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("phone1"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("phone2"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("crefito"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("regiao"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("login"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("pass"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("confirmPass"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("male"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("female"));
			
		}


		[UnityTest]
		public static IEnumerator TestSaveButton()
		{
			Flow.StaticLogin();
			Flow.StaticNewPhysiotherapist();

			yield return null;
			
			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			var objectButton = GameObject.Find("Canvas/PanelPhysiotherapist/SaveBt");
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
	}
}
