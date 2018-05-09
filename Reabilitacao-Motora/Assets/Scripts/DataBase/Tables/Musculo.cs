using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;


namespace musculo
{
  /**
   * Classe que cria relação para cadastro de musculos a serem cadastrados pelo programa.
   */
	public class Musculo
	{
		private const int tableId = 3;
		private int IdMusculo;
		private string NomeMusculo;

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

		public string nomeMusculo 
		{
			get 
			{
				return NomeMusculo; 
			} 
			set 
			{
				NomeMusculo = value; 
			}
		}


		/**
		 * Classe com todos os atributos de um musculo.
		 */
		public Musculo(int idm, string nm)
		{
				this.idMusculo = idm;
				this.nomeMusculo = nm;
		}

		/**
		 * Cria a relação para musculo, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MUSCULO (idMusculo INTEGER primary key AUTOINCREMENT,nomeMusculo VARCHAR (20) not null, constraint musculo UNIQUE (nomeMusculo));";
				
				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro de musculos na relação musculo.
		 */
		public static void Insert(string nomeMusculo)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into MUSCULO (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 1; i < tableSize; ++i) 
				{
					string aux;

					if (i + 1 == tableSize)
					{
						aux = ")";
					}
					else
					{
						aux = ",";
					}

					banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\")", nomeMusculo);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação musculo.
		 */
		public static void Update(int id,
			string nomeMusculo)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[1], nomeMusculo);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação musculo.
		 */
		public static List<Musculo> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM MUSCULO";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<Musculo> muscles = new List<Musculo>();

				while (reader.Read())
				{
					int idMusculoTemp = 0;
					string nomeMusculoTemp = "null";

					if (!reader.IsDBNull(0))
					{
						idMusculoTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						nomeMusculoTemp = reader.GetString(1);
					}

					Musculo muscle = new Musculo (idMusculoTemp, nomeMusculoTemp);
					muscles.Add(muscle);
				}

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return muscles;
			}
		}

		public static Musculo ReadValue (int id)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", TablesManager.Tables[tableId].tableName, 
					TablesManager.Tables[tableId].colName[0], 
					id);
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				reader.Read();

				int idMusculoTemp = 0;
				string nomeMusculoTemp = "null";

				if (!reader.IsDBNull(0))
				{
					idMusculoTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					nomeMusculoTemp = reader.GetString(1);
				}

				Musculo muscle = new Musculo (idMusculoTemp,nomeMusculoTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return muscle;
			}
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação musculo.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.Tables[tableId].tableName, TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que apaga a relação musculo inteira de uma vez.
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
