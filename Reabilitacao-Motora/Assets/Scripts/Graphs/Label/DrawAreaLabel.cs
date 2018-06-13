using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;
using UnityEngine.EventSystems;

public class DrawAreaLabel : MonoBehaviour
{
	[SerializeField]
	protected Camera Cam;
	[SerializeField]
	protected GameObject labelPrefab, popUp, canvas;
	[SerializeField]
	protected Transform originGrafico;
	[SerializeField]
	protected InputField textField;
	[SerializeField]
	protected Image ImagemSelecao;

	protected Vector3 PosMinMouse, PosMaxMouse, PosIniMouse, origin;
	// protected RaycastHit R;
	bool patientOrPhysio;
	float maxgraph;

	public void Start ()
	{
		var currentscene = SceneManager.GetActiveScene().name;
		if (currentscene.Substring(currentscene.Length-5, 4) == "ient")
		{
			patientOrPhysio = false;
		}
		else
		{
			patientOrPhysio = true;		
		}

		origin = Cam.WorldToScreenPoint(originGrafico.position);
		maxgraph = Screen.width - origin.x;
	}

	public bool ValidClick (Vector2 pos)
	{
		if (pos.x >= origin.x && pos.y >= origin.y)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void ScreenToWorld ()
	{
		float minCurrent = PosMinMouse.x - origin.x;
		float maxCurrent = PosMaxMouse.x - origin.x;
		PosMinMouse = new Vector3((16*minCurrent)/maxgraph, PosMinMouse.y, PosMinMouse.z);
		PosMaxMouse = new Vector3((16*maxCurrent)/maxgraph, PosMaxMouse.y, PosMaxMouse.z);
	}

	public void Update ()
	{	
		if (ValidClick(Input.mousePosition))
		{
			if(Input.GetMouseButtonDown(1))
			{
				PosMinMouse = Input.mousePosition;
				PosIniMouse = Input.mousePosition;
			}

			if(Input.GetMouseButton(1))
			{
				if (Input.mousePosition.x >= PosIniMouse.x)
				{
					PosMaxMouse.x = Input.mousePosition.x;   
				}
				else
				{
					PosMaxMouse.x = PosIniMouse.x;
					PosMinMouse.x = Input.mousePosition.x; 
				}
				
				var max = new Vector2((PosMaxMouse.x - origin.x) / maxgraph, 1f);
				var min = new Vector2((PosMinMouse.x - origin.x) / maxgraph, 0f);

				ImagemSelecao.rectTransform.anchorMax = max;
				ImagemSelecao.rectTransform.anchorMin = min; 
			}

			if(Input.GetMouseButtonUp(1))
			{
				ScreenToWorld();
				Debug.Log(PosMinMouse);
				Debug.Log(PosMaxMouse);

				popUp.SetActive(true);
				DesactivateCanvas();

				ImagemSelecao.rectTransform.anchorMax = new Vector2(0,0);
				ImagemSelecao.rectTransform.anchorMin = new Vector2(0,0);
			}
		}
	}

	public void displayGraph ()
	{
		GameObject go = Instantiate (labelPrefab) as GameObject;

		go.transform.localPosition = new Vector3 (0f, 0f, 0f);
		go.transform.parent = gameObject.transform.parent;

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();
		
		scriptInitial.InitialX = PosMinMouse.x;
		scriptFinal.FinalX = PosMaxMouse.x;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = textField.text;

		if (patientOrPhysio)
		{
			PontosRotuloFisioterapeuta.Insert(GlobalController.instance.movement.idMovimento, textField.text, PosMinMouse.x, PosMaxMouse.x);
			var dbPrfObject = go.GetComponentInChildren<SetLabelPhysio>();
			dbPrfObject.Prf = PontosRotuloFisioterapeuta.GetLast();
		}
		else
		{
			PontosRotuloPaciente.Insert(GlobalController.instance.exercise.idExercicio, textField.text, PosMinMouse.x, PosMaxMouse.x);
			var dbPrpObject = go.GetComponentInChildren<SetLabelPatient>();
			dbPrpObject.Prp = PontosRotuloPaciente.GetLast();
		}

	}

	public void DesactivateCanvas ()
	{
		canvas.SetActive(false);
	}

	public void ActivateCanvas ()
	{
		canvas.SetActive(true);
	}
}