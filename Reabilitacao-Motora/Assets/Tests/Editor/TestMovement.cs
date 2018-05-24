using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using musculo;
using movimentomusculo;
using movimento;

/**
 * Esta classe testa os métodos referentes aos Movimentos.
 */
namespace Tests
{
	public static class TestMovement
	{
    /*
    [Test]
    public static void TestValidInput ()
    {
        InputField nomeMovimento = new InputField ();
        InputField musculos = new InputField ();

        List<InputField> inputs = new List<InputField>();

        nomeMovimento.text = "Movimentação do Braço Esquerdo";
        musculos.text = "Deltóide";

        inputs.Add(nomeMovimento);
        inputs.Add(musculos);

        bool response = createMovement.ValidInput(inputs);

        Assert.AreEqual(response, true);
    }
    
    [Test]
    public static void TestSaveMovement()
    {

        Flow.StaticNewMovement();

        yield return null;

        var objectMovement = GameObject.Find("Movement Manager");
        var MovementManager = objectMovement.GetComponentInChildren<createMovement>();

        var objectButton = GameObject.Find("Canvas/PanelShowMovement/SaveBt");
        var button = objectButton.GetComponentInChildren<Button>();

        InputField aux = (InputField)MovementManager.GetMemberValue("nomeMovimento");
        aux.text = "Movimento Inexistente";
        MovementManager.SetMemberValue("nomeMovimento", aux);

        InputField aux1 = (InputField)MovementManager.GetMemberValue("musculos");
        aux1.text = "Musculo Inexistente";
        MovementManager.SetMemberValue("musculos", aux1);

        button.OnPointerClick(new PointerEventData(EventSystem.current));

        int idMovimento = GlobalController.instance.admin.idMovimento;
        int idMusculo = GlobalController.instance.admin.idMusculo;
        Movimento.DeleteValue(idMovimento);
        Musculo.DeleteValue(idMusculo);

        yield return new WaitForSeconds(0.5f);

        var currentscene = SceneManager.GetActiveScene().nomeMovimento;
        var expectedscene = "NewMovement";

        Assert.AreEqual(expectedscene, currentscene);
    }
    */
  }
}
