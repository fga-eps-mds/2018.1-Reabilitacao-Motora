using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 *  Classe de animação do personagem.
 */
public class CharacterAnimation : MonoBehaviour 
{
	private Animator anim;
	/** 
     * Inicia o componente de animação do personagem.
     */
	void Start () 
	{
		anim = this.GetComponent<Animator>();
	}
	
	/** 
     *  Anima o personagem conforme pressionamento de teclas.
     */
	void Update () 
	{
		if(Input.GetKey(KeyCode.W)) 
		{
			anim.SetBool("Pointing", true);
		}
		if(Input.GetKeyUp(KeyCode.W)) 
		{
			anim.SetBool("Pointing", false);
		}
	}
}
