using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPopUpManagerNote : MonoBehaviour
{

    [SerializeField]
    protected Button noteButton;

    // Use this for initialization
    public void Start()
    {
        var popUpManager = GameObject.Find("/PopUp Manager Note");
        PopUpSpawner script = popUpManager.GetComponent(typeof(PopUpSpawner)) as PopUpSpawner;
        noteButton.onClick.AddListener(script.Spawner);
    }

}
