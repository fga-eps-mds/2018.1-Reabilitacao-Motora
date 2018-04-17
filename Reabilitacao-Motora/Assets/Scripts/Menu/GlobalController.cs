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

	public Pessoa.Pessoas personPhysio;
	public Pessoa.Pessoas personPatient;
	public Telefone.Telefones phone;
	public Fisioterapeuta.Fisioterapeutas admin;
	public Paciente.Pacientes user;
	public Movimento.Movimentos movement;
	public Sessao.Sessoes session;
	public Exercicio.Exercicios exercise;
	public PontosRotuloFisioterapeuta.PontosRotuloFisioterapeutas labelPhysioPoints;
	public PontosRotuloPaciente.PontosRotuloPacientes labelPatientPoints;
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
			instance.path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
