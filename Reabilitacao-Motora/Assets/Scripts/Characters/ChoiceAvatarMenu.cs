using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** 
 *  Classe que seta o valor da escolha do boneco.
 */
public class ChoiceAvatarMenu : MonoBehaviour 
{   
	[SerializeField]
	protected Button nextPage;

    /** 
     *  Estas função seleciona o personagem boy1.
     */
    public void boy1 () 
    {
        GlobalController.choiceAvatar = 1;
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
    }

    /** 
     *  Estas função seleciona o personagem boy2.
     */
    public void boy2 () 
    {
        GlobalController.choiceAvatar = 2;
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
    }

    /** 
     *  Estas função seleciona o personagem boy3.
     */
    public void boy3 () 
    {
        GlobalController.choiceAvatar = 3;
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
    }

    /** 
     *  Estas função seleciona o personagem girl1.
     */
    public void girl1 () 
    {
        GlobalController.choiceAvatar = 4;
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
    }

    /** 
     *  Estas função seleciona o personagem girl2.
     */
    public void girl2 () 
    {
        GlobalController.choiceAvatar = 5;
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
    }
}