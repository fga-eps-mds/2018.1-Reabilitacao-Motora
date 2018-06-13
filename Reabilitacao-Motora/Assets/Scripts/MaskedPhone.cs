using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

/*
 * Esta classe cria a máscara de telefone.
 */
public class MaskedPhone : MonoBehaviour
{
    public InputField phoneInputField;
	public Text textOutput;

    public void Start()
    {
        /*
         * Trata de ouvir as modificacoes no campo.
         */
        phoneInputField.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    /*
     * Esta funcao eh chamada quando se alteram os valores do campo.
     */
    public void ValueChangeCheck()
    {
		int index = 0 ;
        string format = "(##) #####-####" ;
        string output = format;

        string input = phoneInputField.text;
        
        for( int i = 0 ; i < input.Length ; ++i )
        {
            index = output.IndexOf("#");
            if( index < 0 )
            {
                break ;
            }
            if( index == 0 )
            {
                output = input[i] + output.Substring ( 1 );
            }
            else if( index == output.Length - 1 )
            {
                output = output.Substring ( 0, index ) + input[i] ;
            }
            else
            {
                output = output.Substring ( 0, index ) + input[i] + output.Substring ( index + 1 );
            }
        }
        if( index >= 0 )
        {
            output = output.Substring( 0, index + 1 );
        }
		if(output=="(") 
        {
            textOutput.text = "";
        }
        else
        {
            textOutput.text = output;
        }
    }
}