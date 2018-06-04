using UnityEngine;
using UnityEngine.UI;

public class HelpUpdateBt : MonoBehaviour
{
    [SerializeField]
    protected Button nextPage;

    public void Awake()
    {
        nextPage.onClick.AddListener(delegate { Flow.StaticHelpUpdate(); });
    }
}