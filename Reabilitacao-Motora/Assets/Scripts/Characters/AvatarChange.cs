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
    void Awake ()
    {
        if (GlobalController.choiceAvatar==1)
        {
            man1Avatar.transform.SetSiblingIndex(man1Avatar.transform.childCount - 1);
            man1Avatar.SetActive(true);
        }
        else if (GlobalController.choiceAvatar==2)
        {
            man2Avatar.transform.SetSiblingIndex(man2Avatar.transform.childCount - 1);
            man2Avatar.SetActive(true);
        }
        else if (GlobalController.choiceAvatar==3)
        {
            man3Avatar.transform.SetSiblingIndex(man3Avatar.transform.childCount - 1);
            man3Avatar.SetActive(true);
        }
        else if (GlobalController.choiceAvatar==4)
        {
            woman1Avatar.transform.SetSiblingIndex(woman1Avatar.transform.childCount - 1);
            woman1Avatar.SetActive(true);
        }
        else if (GlobalController.choiceAvatar==5)
        {
            woman2Avatar.transform.SetSiblingIndex(woman2Avatar.transform.childCount - 1);
            woman2Avatar.SetActive(true);
        }
    }
}
