using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 *  Classe de customização do personagem.
 */
public class AvatarChange : MonoBehaviour 
{
    public GameObject man1Avatar;
    public GameObject man2Avatar;
    public GameObject man3Avatar;
    public GameObject woman1Avatar;
    public GameObject woman2Avatar;

    /** 
     *  Esta função permite a escolha do personagem que será apresentado na tela.
     */
    void Start () 
    {
        if(GlobalController.choiceAvatar==1) 
        {
            man1Avatar.SetActive(false);
            man1Avatar.GetComponent<Renderer>().enabled = false;
        } 
        else if (GlobalController.choiceAvatar==2) 
        {
            man2Avatar.SetActive(false);
            man2Avatar.GetComponent<Renderer>().enabled = false;
        }
        else if (GlobalController.choiceAvatar==3)
        {
            man3Avatar.SetActive(false);
            man3Avatar.GetComponent<Renderer>().enabled = false;
        } 
        else if (GlobalController.choiceAvatar==4)
        {
            woman1Avatar.SetActive(false);
            woman1Avatar.GetComponent<Renderer>().enabled = false;
        }
        else if (GlobalController.choiceAvatar==5)
        {
            woman2Avatar.SetActive(false);
            woman2Avatar.GetComponent<Renderer>().enabled = false;
        }
    }
}