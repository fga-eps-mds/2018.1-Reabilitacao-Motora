using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
* Essa classe nomeia as colunas da relação
*/
public static class TablesManager
{
	public class Table 
	{
		private string TableName;
		private List<string> ColName;

		public string tableName
		{
			get
			{
				return TableName;
			}
			set
			{
				TableName = value;
			}
		}

		public List<string> colName
		{
			get
			{
				return ColName;
			}
			set
			{
				ColName = value;
			}
		}

	}

	private static readonly Table Pessoa =
	new Table 
	{
		tableName = "PESSOA", 
		colName = new List<string>{
			"idPessoa",
			"nomePessoa",
			"sexo",
			"dataNascimento",
			"telefone1",
			"telefone2"
		}
	};

	private static readonly Table Fisioterapeuta =
	new Table 
	{
		tableName = "FISIOTERAPEUTA", 
		colName = new List<string>{
			"idFisioterapeuta",
			"idPessoa",
			"login",
			"senha",
			"regiao",
			"crefito"
		}
	};

	private static readonly Table Paciente =
	new Table 
	{
		tableName = "PACIENTE", 
		colName = new List<string>{
			"idPaciente",
			"idPessoa",
			"observacoes"
		}
	};

	private static readonly Table Musculo =
	new Table 
	{
		tableName = "MUSCULO", 
		colName = new List<string>{
			"idMusculo",
			"nomeMusculo"
		}
	};

	private static readonly Table Movimento =
	new Table 
	{
		tableName = "MOVIMENTO", 
		colName = new List<string>{
			"idMovimento",
			"idFisioterapeuta",
			"nomeMovimento",
			"descricaoMovimento",
			"pontosMovimento"
		}
	};

	private static readonly Table Sessao =
	new Table 
	{
		tableName = "SESSAO", 
		colName = new List<string>{
			"idSessao",
			"idFisioterapeuta",
			"idPaciente",
			"dataSessao",
			"observacaoSessao"
		}
	};

	private static readonly Table Exercicio =
	new Table 
	{
		tableName = "EXERCICIO", 
		colName = new List<string>{
			"idExercicio",
			"idPaciente",
			"idMovimento",
			"idSessao",
			"descricaoExercicio",
			"pontosExercicio"
		}
	};

	private static readonly Table MovimentoMusculo =
	new Table 
	{
		tableName = "MOVIMENTOMUSCULO", 
		colName = new List<string>{
			"idMusculo",
			"idMovimento"
		}
	};

	private static readonly Table PRF =
	new Table 
	{
		tableName = "PONTOSROTULOFISIOTERAPEUTA", 
		colName = new List<string>{
			"idRotuloFisioterapeuta",
			"idMovimento",
			"estagioMovimentoFisio",
			"tempoInicial",
			"tempoFinal"
		}
	};

	private static readonly Table PRP =
	new Table 
	{
		tableName = "PONTOSROTULOPACIENTE", 
		colName = new List<string>{
			"idRotuloPaciente",
			"idExercicio",
			"estagioMovimentoPaciente",
			"tempoInicial",
			"tempoFinal"
		}
	};

	public static readonly Table[] Tables = new []{
		Pessoa, Fisioterapeuta, Paciente, Musculo,
		Movimento, Sessao, Exercicio, MovimentoMusculo,
		PRF, PRP
	};
}