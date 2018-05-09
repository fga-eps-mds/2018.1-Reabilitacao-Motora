using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using pessoa;
using fisioterapeuta;
using paciente;
using musculo;
using movimento;
using sessao;
using exercicio;
using movimentomusculo;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

public class GlobalController : MonoBehaviour 
{
	public static GlobalController instance;

	private Fisioterapeuta Admin;
	private Paciente User;
	private Movimento Movement;
	private Sessao Session;
	private Exercicio Exercise;
	private EventSystem system;
	public string path;

	void Awake () 
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			string pathEx = "Assets\\Exercicios";
			string pathMv = "Assets\\Movimentos";

			Directory.CreateDirectory(pathEx);
			Directory.CreateDirectory(pathMv);

			instance = this;
			DontDestroyOnLoad(gameObject);
			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
			Initialize();
		}
	}

	void Initialize()
	{
		Pessoa.Create();
		Fisioterapeuta.Create();
		Paciente.Create();
		Musculo.Create();
		Movimento.Create();
		Sessao.Create();
		Exercicio.Create();
		MovimentoMusculo.Create();
		PontosRotuloPaciente.Create();
		PontosRotuloFisioterapeuta.Create();
	}

	void Start ()
	{
		system = EventSystem.current;
	}

	/**
	 * Permite usar tab para transitar entre os input fields.
	 */
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

			if (next != null) 
			{

				InputField inputfield = next.GetComponent<InputField>();
				if (inputfield != null) 
				{
					inputfield.OnPointerClick(new PointerEventData(system));
				}

				system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
			}
		}
	}

	public Fisioterapeuta admin
	{
		get
		{
			return Admin;
		}
		set
		{
			Admin = value;
		}
	}

	public Paciente user
	{
		get
		{
			return User;
		}
		set
		{
			User = value;
		}
	}

	public Movimento movement
	{
		get
		{
			return Movement;
		}
		set
		{
			Movement = value;
		}
	}

	public Sessao session
	{
		get
		{
			return Session;
		}
		set
		{
			Session = value;
		}
	}

	public Exercicio exercise
	{
		get
		{
			return Exercise;
		}
		set
		{
			Exercise = value;
		}
	}
}
