using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;


namespace movimentomusculo
{
  /**
   * Cria relação para cadastro de movimentos dos musculos a serem cadastrados pelo programa.
   */
	public class MovimentoMusculo
	{
		private const int tableId = 7;
		private int IdMusculo;
		private int IdMovimento;

		public int idMusculo 
		{ 
			get 
			{ 
				return IdMusculo; 
			} 
			set 
			{ 
				IdMusculo = value; 
			}
		}
		
		public int idMovimento 
		{ 
			get 
			{ 
				return IdMovimento; 
			} 
			set 
			{ 
				IdMovimento = value; 
			}
		}
		

		/**
		 * Classe com todos os atributos de um movimentomusculo.
		 */
		public MovimentoMusculo (int idmu, int idmo)
		{
				this.idMusculo = idmu;
				this.idMovimento = idmo;
		}

		/**
		 * Cria a relação para cadastro dos movimento do musculo, contendo um id que vem da relação de outra tabela (musculo) como chave primária e estrangeira, assim como idMovimento, que vem da relação movimento.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (idMusculo INTEGER not null,idMovimento INTEGER not null, foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idMusculo) references MUSCULO (idMusculo),primary key (idMusculo, idMovimento));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro de movimentos dos musculos na relação MovimentoMusculo.
		 */
		public static void Insert(int idMusculo,
			int idMovimento)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into MOVIMENTOMUSCULO (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 0; i < tableSize; ++i) 
				{
					string aux = (i+1 == tableSize) ? (")") : (",");
					banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idMusculo,
					idMovimento);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação MovimentoMusculo.
		 */
		public static void Update(int idMusculo, int idMovimento)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[0], idMusculo);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[1], idMovimento);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\", \"{2}\" = \"{3}\"", TablesManager.Tables[tableId].colName[0], idMusculo, TablesManager.Tables[tableId].colName[1], idMusculo);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação MovimentoMusculo.
		 */
		public static List<MovimentoMusculo> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM MOVIMENTOMUSCULO";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<MovimentoMusculo> mm = new List<MovimentoMusculo>();

				while (reader.Read())
				{
					int idMusculoTemp = 0;
					int idMovimentoTemp = 0;

					if (!reader.IsDBNull(0))
					{
						idMusculoTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idMovimentoTemp = reader.GetInt32(1);
					}

					MovimentoMusculo x = new MovimentoMusculo(idMusculoTemp,idMovimentoTemp);
					mm.Add(x);
				}
				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return mm;
			}
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação MovimentoMusculo.
		 */
		public static void DeleteValue(int id1, int id2)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\" AND \"{3}\" = \"{4}\"", TablesManager.Tables[tableId].tableName, TablesManager.Tables[tableId].colName[0], id1, TablesManager.Tables[tableId].colName[1], id2);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que apaga a relação MovimentoMusculo inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.Tables[tableId].tableName);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}
	}
}
