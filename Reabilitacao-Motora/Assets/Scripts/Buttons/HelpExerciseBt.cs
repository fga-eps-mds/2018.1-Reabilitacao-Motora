using UnityEngine;
using UnityEngine.UI;

public class HelpExerciseBt : MonoBehaviour
{
    [SerializeField]
    protected Button nextPage;

    public void Awake()
    {
        nextPage.onClick.AddListener(delegate { Flow.StaticHelpExercise(); });
    }
}