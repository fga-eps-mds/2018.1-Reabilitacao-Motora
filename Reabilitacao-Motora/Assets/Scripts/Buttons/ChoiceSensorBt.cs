using UnityEngine;
using UnityEngine.UI;


public class ChoiceSensorBt : MonoBehaviour {

    [SerializeField]
    protected Button nextPage;

    public void Awake()
    {
        nextPage.onClick.AddListener(delegate{Flow.ChoiceSensor();});
    }
}
