using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SensorChoice : MonoBehaviour {

    Dropdown m_Dropdown;
    string choicePath;

    void Start()
    {
        m_Dropdown = GetComponent<Dropdown>();

        StringBuilder path = new StringBuilder();
			path.Append("sensor.choice");
        
        choicePath = path.ToString();

        if (File.Exists(choicePath))
        {
            
            string line = File.ReadAllText(choicePath);
            int fileValue = Convert.ToInt32(line);
            
            if ( fileValue.Equals(0) )
            {
                m_Dropdown.value = 0;
                GlobalController.Sensor = false;
            }
            else if ( fileValue.Equals(1) )
            {
                m_Dropdown.value = 1;
                GlobalController.Sensor = true;
            }
        }
        else 
        {
            string text = Convert.ToString(m_Dropdown.value);
            File.WriteAllText(choicePath, text);
        }
    }

    public void Select()
    {

        if ( m_Dropdown.value.Equals(0) ) // Kinect selected
        {
            GlobalController.Sensor = false;
        }
        else // UDP selected
        {
            GlobalController.Sensor = true;
        }

        string text = Convert.ToString(m_Dropdown.value);
        File.Delete(choicePath);
        File.WriteAllText(choicePath, text);
    }

}
