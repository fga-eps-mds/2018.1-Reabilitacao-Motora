using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour
{
    public GameObject PopUpPrefab;

    public void Spawner()
    {
        PopUpPrefab.SetActive(true);
    }

    public void Eraser()
    {
        PopUpPrefab.SetActive(false);
    }
}
