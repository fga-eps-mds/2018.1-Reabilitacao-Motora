using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorChoice : MonoBehaviour {

    public void Select()
    {
        GlobalController.Sensor = !GlobalController.Sensor;
    }

}
