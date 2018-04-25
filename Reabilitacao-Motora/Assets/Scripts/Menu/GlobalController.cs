using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using pessoa;
using telefone;
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

	public Telefone phone;
	public Fisioterapeuta admin;
	public Paciente user;
	public Movimento movement;
	public Sessao session;
	public Exercicio exercise;
	public PontosRotuloFisioterapeuta labelPhysioPoints;
	public PontosRotuloPaciente labelPatientPoints;
	public string path;

	// Use this for initialization
	void Awake () {
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
			Initialize();
			instance.path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
		}
	}
	
	void Initialize()
    {
        tablePessoa.Create();
        tableTel.Create();
        tableFisio.Create();
        tablePaciente.Create();
        tableMusculo.Create();
        tableMovimento.Create();
        tableSessao.Create();
        tableExercicio.Create();
        tableMovimentoMusculo.Create();
        tablePRF.Create();
        tablePRP.Create();
    }

	// Update is called once per frame
	void Update () 
	{
		
	}
}
