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

			Assert.AreNotEqual(null, physioManager.namePhysio);
			Assert.AreNotEqual(null, physioManager.date);
			Assert.AreNotEqual(null, physioManager.phone1);
			Assert.AreNotEqual(null, physioManager.phone2);
			Assert.AreNotEqual(null, physioManager.crefito);
			Assert.AreNotEqual(null, physioManager.regiao);
			Assert.AreNotEqual(null, physioManager.login);
			Assert.AreNotEqual(null, physioManager.pass);
			Assert.AreNotEqual(null, physioManager.confirmPass);
			Assert.AreNotEqual(null, physioManager.male);
			Assert.AreNotEqual(null, physioManager.female);
			
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

			physioManager.namePhysio.text = "fake_name";
			physioManager.date.text = "01/01/1900";
			physioManager.phone1.text = "61999999";
			physioManager.phone2.text = "61999950";
			physioManager.crefito.text = "123712";
			physioManager.regiao.text = "df";
			physioManager.login.text = "fake_login";
			physioManager.pass.text = "fake_pass";
			physioManager.confirmPass.text = "fake_pass";
			physioManager.male.isOn = true;
			physioManager.female.isOn = false;

			button.OnPointerClick(new PointerEventData(EventSystem.current));


			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(currentscene, expectedscene);

			if (currentscene == expectedscene)
			{
				int IdFisioterapeuta = GlobalController.instance.admin.idFisioterapeuta;
				int IdPessoa = GlobalController.instance.admin.persona.idPessoa;
				Fisioterapeuta.DeleteValue(IdFisioterapeuta);
				Pessoa.DeleteValue(IdPessoa);
			}
		}
	}
}