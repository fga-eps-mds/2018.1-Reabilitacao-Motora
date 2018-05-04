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
		public string tableName;
		public List<string> colName;
	}

	private static Table Pessoa =
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

	private static Table Fisioterapeuta =
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

	private static Table Paciente =
	new Table 
	{
		tableName = "PACIENTE", 
		colName = new List<string>{
			"idPaciente",
			"idPessoa",
			"observacoes"
		}
	};

	private static Table Musculo =
	new Table 
	{
		tableName = "MUSCULO", 
		colName = new List<string>{
			"idMusculo",
			"nomeMusculo"
		}
	};

	private static Table Movimento =
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

	private static Table Sessao =
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

	private static Table Exercicio =
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

	private static Table MovimentoMusculo =
	new Table 
	{
		tableName = "MOVIMENTOMUSCULO", 
		colName = new List<string>{
			"idMusculo",
			"idMovimento"
		}
	};

	private static Table PRF =
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

	private static Table PRP =
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

	public static List<Table> Tables = new List<Table>{
		Pessoa, Fisioterapeuta, Paciente, Musculo,
		Movimento, Sessao, Exercicio, MovimentoMusculo,
		PRF, PRP
	};
}

