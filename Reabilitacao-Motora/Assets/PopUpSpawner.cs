using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour {

    public GameObject PopUpPrefab;

    public void Spawner()
    {
        GameObject jo = Instantiate(PopUpPrefab, transform);
    }
}
