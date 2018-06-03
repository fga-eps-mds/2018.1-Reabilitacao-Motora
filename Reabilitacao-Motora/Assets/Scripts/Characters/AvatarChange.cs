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
            man1Avatar.SetActive(true);
            man1Avatar.GetComponent<Renderer>().enabled = true;
        }
        else if (GlobalController.choiceAvatar==2)
        {
            man2Avatar.SetActive(true);
            man2Avatar.GetComponent<Renderer>().enabled = true;
        }
        else if (GlobalController.choiceAvatar==3)
        {
            man3Avatar.SetActive(true);
            man3Avatar.GetComponent<Renderer>().enabled = true;
        }
        else if (GlobalController.choiceAvatar==4)
        {
            woman1Avatar.SetActive(true);
            woman1Avatar.GetComponent<Renderer>().enabled = true;
        }
        else if (GlobalController.choiceAvatar==5)
        {
            woman2Avatar.SetActive(true);
            woman2Avatar.GetComponent<Renderer>().enabled = true;
        }
    }
}
