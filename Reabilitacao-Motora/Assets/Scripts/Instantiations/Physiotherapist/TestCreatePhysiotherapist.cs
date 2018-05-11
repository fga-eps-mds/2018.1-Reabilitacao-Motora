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

			physioManager.SetMemberValue("namePhysio.text", "fake_name");
			physioManager.SetMemberValue("date.text", "01/01/1900");
			physioManager.SetMemberValue("phone1.text", "61999999");
			physioManager.SetMemberValue("phone2.text", "61999950");
			physioManager.SetMemberValue("crefito.text", "123712");
			physioManager.SetMemberValue("regiao.text", "df");
			physioManager.SetMemberValue("login.text", "fake_login");
			physioManager.SetMemberValue("pass.text", "fake_pass");
			physioManager.SetMemberValue("confirmPass.text", "fake_pass");
			physioManager.SetMemberValue("male.isOn", true);
			physioManager.SetMemberValue("female.isOn", false);

			button.OnPointerClick(new PointerEventData(EventSystem.current));

			int IdFisioterapeuta = GlobalController.instance.admin.idFisioterapeuta;
			int IdPessoa = GlobalController.instance.admin.persona.idPessoa;
			Fisioterapeuta.DeleteValue(IdFisioterapeuta);
			Pessoa.DeleteValue(IdPessoa);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(expectedscene, currentscene);
		}
	}
}
