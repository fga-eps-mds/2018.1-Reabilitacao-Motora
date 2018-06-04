using UnityEngine;
using UnityEngine.UI;

public class HelpBt : MonoBehaviour
{
    [SerializeField]
    protected Button nextPage;

    public void Awake()
    {
        nextPage.onClick.AddListener(delegate { Flow.StaticHelp(); });
    }
}