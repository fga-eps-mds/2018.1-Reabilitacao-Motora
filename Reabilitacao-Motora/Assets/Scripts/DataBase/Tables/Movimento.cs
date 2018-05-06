using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace movimento
{
  /**
   * Classe que cria relação para cadastro de movimentos a serem cadastrados pelo programa.
   */
	public class Movimento
	{

		private const int tableId = 4;
		private int IdMovimento;
		private int IdFisioterapeuta;
		private string NomeMovimento;
		private string DescricaoMovimento;
		private string PontosMovimento;

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

		public int idFisioterapeuta 
		{ 
			get 
			{ 
				return IdFisioterapeuta; 
			} 
			set 
			{ 
				IdFisioterapeuta = value; 
			}
		}

		public string nomeMovimento 
		{ 
			get 
			{ 
				return NomeMovimento; 
			} 
			set 
			{ 
				NomeMovimento = value; 
			}
		}

		public string descricaoMovimento 
		{ 
			get 
			{ 
				return DescricaoMovimento; 
			} 
			set 
			{ 
				DescricaoMovimento = value; 
			}
		}

		public string pontosMovimento 
		{ 
			get 
			{ 
				return PontosMovimento; 
			} 
			set 
			{ 
				PontosMovimento = value; 
			}
		}

		
		public Movimento(){}

		/**
		 * Classe com todos os atributos de um movimento.
		 */
		public Movimento(int idm, int idf, string nm, string dm, string pm)
		{
			this.idMovimento = idm;
			this.idFisioterapeuta = idf;
			this.nomeMovimento = nm;
			this.descricaoMovimento = dm;
			this.pontosMovimento = pm;
		}

		/**
		 * Cria a relação para movimento, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,descricaoMovimento VARCHAR (150),pontosMovimento VARCHAR (150) not null,foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro de movimentos na relação movimento.
		 */
		public static void Insert(int idFisioterapeuta,
			string nomeMovimento,
			string descricaoMovimento,
			string pontosMovimento)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into MOVIMENTO (";

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

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idFisioterapeuta,
					nomeMovimento,
					descricaoMovimento,
					pontosMovimento);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação movimento.
		 */
		public static void Update(int id,
			int idFisioterapeuta,
			string nomeMovimento,
			string descricaoMovimento,
			string pontosMovimento)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idFisioterapeuta);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], nomeMovimento);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], descricaoMovimento);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[4], pontosMovimento);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação movimento.
		 */
		public static List<Movimento> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM MOVIMENTO";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<Movimento> movements = new List<Movimento>();
				while (reader.Read())
				{
					int idMovimentoTemp = 0;
					int idFisioterapeutaTemp = 0;
					string nomeMovimentoTemp = "null";
					string descricaoMovimentoTemp = "null";
					string pontosMovimentoTemp = "null";

					if (!reader.IsDBNull(0))
					{
						idMovimentoTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idFisioterapeutaTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2))
					{
						nomeMovimentoTemp = reader.GetString(2);
					}
					if (!reader.IsDBNull(3))
					{
						descricaoMovimentoTemp = reader.GetString(3);
					}
					if (!reader.IsDBNull(4))
					{
						pontosMovimentoTemp = reader.GetString(4);
					}

					Movimento movement = new Movimento(idMovimentoTemp, idFisioterapeutaTemp, nomeMovimentoTemp, descricaoMovimentoTemp, pontosMovimentoTemp);
					movements.Add(movement);
				}
				
				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return movements;
			}
		}

		public static Movimento ReadValue (int id)
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

				int idMovimentoTemp = 0;
				int idFisioterapeutaTemp = 0;
				string nomeMovimentoTemp = "null";
				string descricaoMovimentoTemp = "null";
				string pontosMovimentoTemp = "null";

				if (!reader.IsDBNull(0))
				{
					idMovimentoTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					idFisioterapeutaTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2))
				{
					nomeMovimentoTemp = reader.GetString(2);
				}
				if (!reader.IsDBNull(3))
				{
					descricaoMovimentoTemp = reader.GetString(3);
				}
				if (!reader.IsDBNull(4))
				{
					pontosMovimentoTemp = reader.GetString(4);
				}

				Movimento movement = new Movimento (idMovimentoTemp,idFisioterapeutaTemp,nomeMovimentoTemp,descricaoMovimentoTemp,pontosMovimentoTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return movement;
			}
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação movimento.
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
		 * Função que apaga a relação movimento inteira de uma vez.
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
