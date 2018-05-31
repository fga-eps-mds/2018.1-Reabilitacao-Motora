using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 *  Classe de animação do personagem.
 */
public class AvatarChange : MonoBehaviour 
{
    public GameObject MaleModel;
    public Avatar MaleAvatar;
    public GameObject FemaleModel;
    public Avatar FemaleAvatar;
    public GameObject Player;

    GameObject model;
    // Use this for initialization
    void Start () {
        int boy = 1;

        if (boy != 0) {
            model = Instantiate(MaleModel);
            Player.GetComponent<Animator>().avatar = MaleAvatar;
        } else {
            model = Instantiate(FemaleModel);
            Player.GetComponent<Animator>().avatar = FemaleAvatar;
        }

        model.transform.SetParent (Player.transform);
        model.transform.localPosition = new Vector3 (0, 0, 0);
        Player.GetComponent<Animator>().Rebind();
    }
}