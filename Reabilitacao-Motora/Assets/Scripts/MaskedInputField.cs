using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MaskedInputField : MonoBehaviour
{
    public InputField mainInputField;
    public Text TextOutput;

    public void Start()
    {
        //Adds a listener to the main input field and invokes a method when the value changes.
        mainInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        int index = 0 ;
        string format = "##/##/####" ;
        string output = format;
        string input;

        input = mainInputField.text;
        
        for( int i = 0 ; i < input.Length ; ++i )
        {
            index = output.IndexOf("#");
            if (index < 0)
            {
                break ;
            }
            if (index == 0)
            {
                output = input[i] + output.Substring ( 1 );
            }
            else if (index == output.Length - 1)
            {
                output = output.Substring ( 0, index ) + input[i] ;
            }
            else
            {
                output = output.Substring ( 0, index ) + input[i] + output.Substring ( index + 1 );
            }
        }

        if ( index >= 0 )
        {
            output = output.Substring( 0, index + 1 );
        }

        if(output=="#") 
        {
            TextOutput.text = "";
        }
        else
        {
            TextOutput.text = output;
        }

        Debug.Log( output ); // Will output 95/3
    }
}