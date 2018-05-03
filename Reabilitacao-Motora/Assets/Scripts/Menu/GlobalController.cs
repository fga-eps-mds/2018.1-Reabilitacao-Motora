using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

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

public class GlobalController : MonoBehaviour {

	public static GlobalController instance;
    public string sqlQuery = "";
    public IDbConnection conn;
    public IDbCommand cmd;

	public Fisioterapeuta admin;
	public Paciente user;
	public Movimento movement;
	public Sessao session;
	public Exercicio exercise;
	public PontosRotuloFisioterapeuta labelPhysioPoints;
	public PontosRotuloPaciente labelPatientPoints;
	public string path;
	public string pathEx;
	public string pathMv;
	// Use this for initialization
	void Awake () {
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
	        pathEx = "Assets\\Exercicios";
	        pathMv = "Assets\\Movimentos";

	        Directory.CreateDirectory(pathEx);
	        Directory.CreateDirectory(pathMv);

			instance = this;
			DontDestroyOnLoad(gameObject);
			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
			Initialize();
			instance.path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
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

	// Update is called once per frame
	void Update () 
	{
		
	}
}
