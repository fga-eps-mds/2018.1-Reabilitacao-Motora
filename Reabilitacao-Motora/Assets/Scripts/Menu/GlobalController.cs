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
	private PontosRotuloPaciente Prp;
	private PontosRotuloFisioterapeuta Prf;
	public string path;
	public static bool Sensor;


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

	public PontosRotuloFisioterapeuta prf
	{
		get
		{
			return Prf;
		}
		set
		{
			Prf = value;
		}
	}

	public PontosRotuloPaciente prp
	{
		get
		{
			return Prp;
		}
		set
		{
			Prp = value;
		}
	}

	public void Awake ()
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

	private static void Initialize()
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
		Sensor = true;
	}
}
