using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;
using movimento;
using pessoa;
using fisioterapeuta;

namespace pontosrotulofisioterapeuta
{

	/**
	* Cria relação para cadastro dos pontosrotulofisioterapeuta a serem cadastrados pelo programa.
	 */
	public class PontosRotuloFisioterapeuta
	{
		private const int tableId = 8;
		private int IdRotuloFisioterapeuta;
		private int IdMovimento;
		private string EstagioMovimentoFisio;
		private float TempoInicial;
		private float TempoFinal;
        private Movimento Moves;

		public int idRotuloFisioterapeuta { get { return IdRotuloFisioterapeuta; } set { IdRotuloFisioterapeuta = value; }}
		public int idMovimento { get { return IdMovimento; } set { IdMovimento = value; }}
		public string estagioMovimentoFisio { get { return EstagioMovimentoFisio; } set { EstagioMovimentoFisio = value; }}
		public float tempoInicial { get { return TempoInicial; } set { TempoInicial = value; }}
		public float tempoFinal { get { return TempoFinal; } set { TempoFinal = value; }}
		public Movimento moves { get { return Moves; } set { Moves = value; } }
		/**
		 * Classe com todos os atributos de um pontosrotulofisioterapeuta.
		 */
		public PontosRotuloFisioterapeuta(Object[] columns)
		{
			this.idRotuloFisioterapeuta = (int)columns[0];
			this.idMovimento = (int)columns[1];
			this.estagioMovimentoFisio = (string)columns[2];
			this.tempoInicial = (float)columns[3];
			this.tempoFinal = (float)columns[4];
            this.moves = Movimento.ReadValue((int) columns[1]);
          }

		/**
		* Cria a relação para pontosrotulofisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS PONTOSROTULOFISIOTERAPEUTA (idRotuloFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,estagioMovimentoFisio VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";
			DataBase.Create(query);
		}

		/**
		* Função que insere dados na tabela de pontosrotulofisioterapeuta.
		 */
		public static void Insert(int idMovimento,
			string estagioMovimentoFisio,
			float tempoInicial,
			float tempoFinal)
		{
			Object[] columns = new Object[] {idMovimento, estagioMovimentoFisio, tempoInicial, tempoFinal};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static void Update(int id,
			int idMovimento,
			string estagioMovimentoFisio,
			float tempoInicial,
			float tempoFinal)
		{
			Object[] columns = new Object[] {id, idMovimento, estagioMovimentoFisio, tempoInicial, tempoFinal};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static List<PontosRotuloFisioterapeuta> Read()
		{
			Object[] columns = new Object[] {0, 0, "", 0.00f, 0.00f};

			List<PontosRotuloFisioterapeuta> physioLabelPoints = DataBase.Read<PontosRotuloFisioterapeuta>(TablesManager.Tables[tableId].tableName, columns);

			return physioLabelPoints;
		}

		public static PontosRotuloFisioterapeuta ReadValue (int id)
		{
			Object[] columns = new Object[] {0, 0, "", 0.00f, 0.00f};

			PontosRotuloFisioterapeuta physioLabelPoint = DataBase.ReadValue<PontosRotuloFisioterapeuta>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return physioLabelPoint;
		}

		public static PontosRotuloFisioterapeuta GetLast ()
		{
			Object[] columns = new Object[] {0, 0, "", 0.00f, 0.00f};

			PontosRotuloFisioterapeuta physioLabelPoint = DataBase.GetLast<PontosRotuloFisioterapeuta>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], columns);

			return physioLabelPoint;
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		* Função que apaga a relação de pontosrotulofisioterapeuta inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
