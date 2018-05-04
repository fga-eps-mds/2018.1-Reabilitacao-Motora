using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
* Essa classe nomeia as colunas da relação
*/
public class TablesManager : MonoBehaviour
{
	public static TablesManager instance;

	public class Table 
	{
		public string tableName;
		public string[] colName;
		public int Length 
		{
			get 
			{
				return colName.Length;
			}
		}
	}

	public Table[] Tables = new Table[11];

	/**
	* Cada coluna da relação recebe um respectivo nome.
	*/
	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
			Initialize();
		}

	}

	void Initialize()
	{
		Tables[0] = new Table();
		Tables[0].colName = new string[6];
		Tables[0].tableName = "PESSOA";
		Tables[0].colName[0] = "idPessoa";
		Tables[0].colName[1] = "nomePessoa";
		Tables[0].colName[2] = "sexo";
		Tables[0].colName[3] = "dataNascimento";
		Tables[0].colName[4] = "telefone1";
		Tables[0].colName[5] = "telefone2";

		Tables[1] = new Table();
		Tables[1].colName = new string[2];
		Tables[1].tableName = "TELEFONE";
		Tables[1].colName[0] = "idPessoa";
		Tables[1].colName[1] = "telefone";

		Tables[2] = new Table();
		Tables[2].colName = new string[6];
		Tables[2].tableName = "FISIOTERAPEUTA";
		Tables[2].colName[0] = "idFisioterapeuta";
		Tables[2].colName[1] = "idPessoa";
		Tables[2].colName[2] = "login";
		Tables[2].colName[3] = "senha";
		Tables[2].colName[4] = "regiao";
		Tables[2].colName[5] = "crefito";

		Tables[3] = new Table();
		Tables[3].colName = new string[3];
		Tables[3].tableName = "PACIENTE";
		Tables[3].colName[0] = "idPaciente";
		Tables[3].colName[1] = "idPessoa";
		Tables[3].colName[2] = "observacoes";

		Tables[4] = new Table();
		Tables[4].colName = new string[2];
		Tables[4].tableName = "MUSCULO";
		Tables[4].colName[0] = "idMusculo";
		Tables[4].colName[1] = "nomeMusculo";

		Tables[5] = new Table();
		Tables[5].colName = new string[5];
		Tables[5].tableName = "MOVIMENTO";
		Tables[5].colName[0] = "idMovimento";
		Tables[5].colName[1] = "idFisioterapeuta";
		Tables[5].colName[2] = "nomeMovimento";
		Tables[5].colName[3] = "descricaoMovimento";
		Tables[5].colName[4] = "pontosMovimento";

		Tables[6] = new Table();
		Tables[6].colName = new string[5];
		Tables[6].tableName = "SESSAO";
		Tables[6].colName[0] = "idSessao";
		Tables[6].colName[1] = "idFisioterapeuta";
		Tables[6].colName[2] = "idPaciente";
		Tables[6].colName[3] = "dataSessao";
		Tables[6].colName[4] = "observacaoSessao";

		Tables[7] = new Table();
		Tables[7].colName = new string[6];
		Tables[7].tableName = "EXERCICIO";
		Tables[7].colName[0] = "idExercicio";
		Tables[7].colName[1] = "idPaciente";
		Tables[7].colName[2] = "idMovimento";
		Tables[7].colName[3] = "idSessao";
		Tables[7].colName[4] = "descricaoExercicio";
		Tables[7].colName[5] = "pontosExercicio";

		Tables[8] = new Table();
		Tables[8].colName = new string[2];
		Tables[8].tableName = "MOVIMENTOMUSCULO";
		Tables[8].colName[0] = "idMusculo";
		Tables[8].colName[1] = "idMovimento";

		Tables[9] = new Table();
		Tables[9].colName = new string[5];
		Tables[9].tableName = "PONTOSROTULOFISIOTERAPEUTA";
		Tables[9].colName[0] = "idRotuloFisioterapeuta";
		Tables[9].colName[1] = "idMovimento";
		Tables[9].colName[2] = "estagioMovimentoFisio";
		Tables[9].colName[3] = "tempoInicial";
		Tables[9].colName[4] = "tempoFinal";

		Tables[10] = new Table();
		Tables[10].colName = new string[5];
		Tables[10].tableName = "PONTOSROTULOPACIENTE";
		Tables[10].colName[0] = "idRotuloPaciente";
		Tables[10].colName[1] = "idExercicio";
		Tables[10].colName[2] = "estagioMovimentoPaciente";
		Tables[10].colName[3] = "tempoInicial";
		Tables[10].colName[4] = "tempoFinal";
	}
}

