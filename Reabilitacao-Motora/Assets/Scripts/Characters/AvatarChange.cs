using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 *  Classe de customização do personagem.
 */
public class AvatarChange : MonoBehaviour 
{
    public GameObject manAvatar;
    public GameObject womanAvatar;

    /** 
     *  Esta função permite a escolha do personagem que será apresentado na tela.
     */
    void Start () 
    {
        int boy = 1;

        if(boy==1) 
        {
            manAvatar.SetActive(false);
            manAvatar.GetComponent<Renderer>().enabled = false;
        } else {
            womanAvatar.SetActive(false);
            womanAvatar.GetComponent<Renderer>().enabled = false;
        }
    }
}