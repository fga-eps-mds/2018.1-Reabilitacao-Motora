using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChart : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab;
	protected Transform mao, ombro, cotovelo, braco;

	[SerializeField]
	protected GameObject popUpLabel, pers1, pers2, pers3, pers4, pers5;

	[System.Serializable]
	public class NecessaryJoints
	{
		public Transform ombroAux, bracoAux, cotoveloAux, maoAux;
	}

	[SerializeField]
	protected NecessaryJoints[] joints;

	// [SerializeField]
	// protected Transform maoAux2, ombroAux2, cotoveloAux2, bracoAux2;

	// [SerializeField]
	// protected Transform maoAux3, ombroAux3, cotoveloAux3, bracoAux3;

	// [SerializeField]
	// protected Transform maoAux4, ombroAux4, cotoveloAux4, bracoAux4;

	// [SerializeField]
	// protected Transform maoAux5, ombroAux5, cotoveloAux5, bracoAux5;

	List <float> current_time;
	List <Vector3> f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot;

	LineRenderer lineRenderer;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;
	private static readonly Color c3 = Color.blue;

	int choiceAvatar;
	bool t;
	bool drawed;

	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void LoadData(string[] lines)
	{
		bool got_sensor = false;
		foreach (var line in lines)
		{
			if (!got_sensor)
			{
				Debug.Log(line);
				choiceAvatar = int.Parse(line);
				got_sensor = true;
			}
			else
			{
				var pair = line.Split(' ');
				float x = (float.Parse(pair[0]));
				current_time.Add(x);

				float a = (float.Parse(pair[1]));
				float b = (float.Parse(pair[2]));
				float c = (float.Parse(pair[3]));
				f_mao_pos.Add(new Vector3 (a, b, c));
				a = (float.Parse(pair[4]));
				b = (float.Parse(pair[5]));
				c = (float.Parse(pair[6]));
				f_mao_rot.Add(new Vector3 (a, b, c));

				a = (float.Parse(pair[7]));
				b = (float.Parse(pair[8]));
				c = (float.Parse(pair[9]));
				f_cotovelo_pos.Add(new Vector3 (a, b, c));
				a = (float.Parse(pair[10]));
				b = (float.Parse(pair[11]));
				c = (float.Parse(pair[12]));
				f_cotovelo_rot.Add(new Vector3 (a, b, c));

				a = (float.Parse(pair[13]));
				b = (float.Parse(pair[14]));
				c = (float.Parse(pair[15]));
				f_ombro_pos.Add(new Vector3 (a, b, c));
				a = (float.Parse(pair[16]));
				b = (float.Parse(pair[17]));
				c = (float.Parse(pair[18]));
				f_ombro_rot.Add(new Vector3 (a, b, c));

				a = (float.Parse(pair[19]));
				b = (float.Parse(pair[20]));
				c = (float.Parse(pair[21]));
				f_braco_pos.Add(new Vector3 (a, b, c));
				a = (float.Parse(pair[22]));
				b = (float.Parse(pair[23]));
				c = (float.Parse(pair[24]));
				f_braco_rot.Add(new Vector3 (a, b, c));
			}
		}
	}
	
	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Start()
	{
		if(GlobalController.instance != null && 
		   GlobalController.instance.movement != null)
		{
			t = false;
			drawed = false;

			current_time = new List<float>();
			f_mao_pos = new List<Vector3>();
			f_mao_rot = new List<Vector3>();
			f_ombro_pos = new List<Vector3>();
			f_ombro_rot = new List<Vector3>();
			f_cotovelo_pos = new List<Vector3>();
			f_cotovelo_rot = new List<Vector3>();
			f_braco_pos = new List<Vector3>();
			f_braco_rot = new List<Vector3>();
			
			var currentscene = SceneManager.GetActiveScene().name;
			var go = gameObject;
			
			if (currentscene == "GraphsMovimentoPhysio")
			{
				string file = Application.dataPath + "/Movimentos/" + GlobalController.instance.movement.pontosMovimento;
				string[] p1 = System.IO.File.ReadAllLines(file);
				LoadData (p1);
				Assign();
				GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
			}
			else
			{
				if (transform.root.gameObject.name == "Grafico Fisio")
				{
					string file = Application.dataPath + "/Movimentos/" + GlobalController.instance.movement.pontosMovimento;
					string[] p1 = System.IO.File.ReadAllLines(file);
					LoadData (p1);
					Assign();
					GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
				}
				else
				{
					string file = Application.dataPath + "/Exercicios/" + GlobalController.instance.exercise.pontosExercicio;
					string[] p1 = System.IO.File.ReadAllLines(file);
					LoadData (p1);
					Assign();
					GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c3);
				}
			}
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}
		
	}

	public void Assign ()
	{
		if (choiceAvatar == 1)
		{
			ombro = joints[0].ombroAux;
			braco = joints[0].bracoAux;
			cotovelo = joints[0].cotoveloAux;
			mao = joints[0].maoAux;
			pers1.SetActive(true);
		}
		else if (choiceAvatar == 2)
		{
			ombro = joints[1].ombroAux;
			braco = joints[1].bracoAux;
			cotovelo = joints[1].cotoveloAux;
			mao = joints[1].maoAux;
			pers2.SetActive(true);
		}
		else if (choiceAvatar == 3)
		{
			ombro = joints[2].ombroAux;
			braco = joints[2].bracoAux;
			cotovelo = joints[2].cotoveloAux;
			mao = joints[2].maoAux;
			pers3.SetActive(true);
		}
		else if (choiceAvatar == 4)
		{
			ombro = joints[3].ombroAux;
			braco = joints[3].bracoAux;
			cotovelo = joints[3].cotoveloAux;
			mao = joints[3].maoAux;
			pers4.SetActive(true);
		}
		else if (choiceAvatar == 5)
		{
			ombro = joints[4].ombroAux;
			braco = joints[4].bracoAux;
			cotovelo = joints[4].cotoveloAux;
			mao = joints[4].maoAux;
			pers5.SetActive(true);
		}
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Update () 
	{
		if (popUpLabel.activeSelf == false && Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
			if (t == true && drawed == false) 
			{
				StartCoroutine("drawGraphic");
				StartCoroutine("Playback");
				drawed = true;
			}
		}
	}

	public IEnumerator Playback ()
	{  
		for (int i = 0; i < current_time.Count; i++) 
		{	
			ombro.localPosition = f_ombro_pos[i];
			ombro.localEulerAngles = f_ombro_rot[i];

			braco.localPosition = f_braco_pos[i];
			braco.localEulerAngles = f_braco_rot[i];

			cotovelo.localPosition = f_cotovelo_pos[i];
			cotovelo.localEulerAngles = f_cotovelo_rot[i];

			mao.localPosition = f_mao_pos[i];
			mao.localEulerAngles = f_mao_rot[i];

			yield return new WaitForSeconds(0.025f);        
		} 
	}

	public IEnumerator drawGraphic ()
	{
		for (int j = 0; j < current_time.Count; ++j) 
		{
			GetMovementPoints.graphSpawner(transform, pointPrefab, mao, cotovelo, ombro, current_time[j], ref lineRenderer);
			yield return new WaitForSeconds(0.025f);
		}
	}
}
