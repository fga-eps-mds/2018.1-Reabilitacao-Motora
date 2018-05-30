using UnityEngine;
using UnityEngine.UI;

public class HelpPatientBt : MonoBehaviour
{
    [SerializeField]
    protected Button nextPage;

    public void Awake()
    {
        nextPage.onClick.AddListener(delegate { Flow.StaticHelpPatient(); });
    }
}