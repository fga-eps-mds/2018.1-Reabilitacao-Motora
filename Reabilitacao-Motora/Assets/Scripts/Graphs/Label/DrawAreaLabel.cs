using UnityEngine.UI;
using UnityEngine;
using pontosrotulofisioterapeuta;

public class DrawAreaLabel : MonoBehaviour
{
	[SerializeField]
	protected Camera Cam;
	[SerializeField]
	protected GameObject labelPrefab, popUp;
	[SerializeField]
	protected Transform originGrafico;
	[SerializeField]
	protected InputField textField;
	[SerializeField]
	protected Image ImagemSelecao;

	protected Vector3 PosMinMouse, PosMaxMouse, PosIniMouse, origin;
	protected RaycastHit R;

	public void Start ()
	{
		origin = Cam.WorldToScreenPoint(originGrafico.position);
	}

	public void Update ()
	{	
		if(Input.GetMouseButtonDown(0))
		{
			if (Input.mousePosition.x <= origin.x)
			{
				PosMinMouse = origin;
				PosIniMouse = origin;
			} 
			else
			{
				PosMinMouse = Input.mousePosition;
				PosIniMouse = Input.mousePosition;
			}
		}

		if(Input.GetMouseButton(0))
		{
			if (Input.mousePosition.x >= PosIniMouse.x)
			{
				PosMaxMouse.x = Input.mousePosition.x;   
			}
			else if (Input.mousePosition.x >= origin.x)
			{
				PosMaxMouse.x = PosIniMouse.x;
				PosMinMouse.x = Input.mousePosition.x; 
			}
			else
			{
				PosMaxMouse.x = PosIniMouse.x;
				PosMinMouse.x = origin.x; 
			}
			Debug.Log(PosMinMouse.x);
			Debug.Log(origin.x);
			Debug.Log(Screen.width);
			Debug.Log((PosMinMouse.x - origin.x) / Screen.width);
			var max = new Vector2(((PosMaxMouse.x - origin.x) / Screen.width), 1f);
			var min = new Vector2(((PosMinMouse.x - origin.x) / Screen.width), 0f);
			ImagemSelecao.rectTransform.anchorMax = max;
			ImagemSelecao.rectTransform.anchorMin = min; 
		}

		if(Input.GetMouseButtonUp(0))
		{
			Physics.Raycast(Cam.ScreenPointToRay(PosMinMouse), out R);
			PosMinMouse = R.point;

			Physics.Raycast(Cam.ScreenPointToRay(PosMaxMouse), out R);
			PosMaxMouse = R.point;

			popUp.SetActive(true);
			
			ImagemSelecao.rectTransform.anchorMax = new Vector2(0,0);
			ImagemSelecao.rectTransform.anchorMin = new Vector2(0,0);
		}
	}

	public void displayGraph(string label, Vector2 val)
	{
		GameObject go = Instantiate (labelPrefab) as GameObject;

		go.transform.localPosition = new Vector3 (0f, 0f, 0f);
		go.transform.SetParent (transform, false);

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();
		var dbPrfObject = go.GetComponentInChildren<SetLabelPhysio>();

		scriptInitial.InitialX = val.x;
		scriptFinal.FinalX = val.y;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = label;

		PontosRotuloFisioterapeuta.Insert(GlobalController.instance.movement.idMovimento, label, val.x, val.y);

		dbPrfObject.Prf = PontosRotuloFisioterapeuta.GetLast();
	}
}