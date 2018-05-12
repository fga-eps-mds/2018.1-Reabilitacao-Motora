using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace sessao
{
  /**
  * Cria relação para cadastro dos sessão a serem cadastrados pelo programa.
   */
	public class Sessao
	{
		private const int tableId = 5;
		private int IdSessao;
		private int IdFisioterapeuta;
		private int IdPaciente;
		private string DataSessao;
		private string ObservacaoSessao;

		public int idSessao 
		{
			get 
			{
				return IdSessao; 
			} 
			set 
			{
				IdSessao = value; 
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

		public int idPaciente 
		{
			get 
			{
				return IdPaciente; 
			} 
			set 
			{
				IdPaciente = value; 
			}
		}

		public string dataSessao 
		{
			get 
			{
				return DataSessao; 
			} 
			set 
			{
				DataSessao = value; 
			}
		}

		public string observacaoSessao 
		{
			get 
			{
				return ObservacaoSessao; 
			} 
			set 
			{
				ObservacaoSessao = value; 
			}
		}


		/**
		 * Classe com todos os atributos de uma sessao.
		 */
		public Sessao(int ids, int idf, int idp, string ds, string os)
		{
				this.idSessao = ids;
				this.idFisioterapeuta = idf;
				this.idPaciente = idp;
				this.dataSessao = ds;
				this.observacaoSessao = os;
		}

		/**
		* Cria a relação para sessão, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS SESSAO (idSessao INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,idPaciente INTEGER not null,dataSessao DATE not null,observacaoSessao VARCHAR (300),foreign key (idPaciente) references PACIENTE (idPaciente),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		* Função que insere dados na tabela de sessão.
		 */
		public static void Insert(int idFisioterapeuta,
			int idPaciente,
			string dataSessao,
			string observacaoSessao)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into SESSAO (";

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
					idPaciente,
					dataSessao,
					observacaoSessao);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		* Função que insere dados na tabela de sessão (sem observacao).
		 */
		public static void Insert(int idFisioterapeuta,
			int idPaciente,
			string dataSessao)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into SESSAO (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;
				const int INDEX_COL_OBSERVACAO = 4;

				for (int i = 1; i < tableSize; ++i) 
				{
					if (i != INDEX_COL_OBSERVACAO)
					{
						string aux;

						if (i + 2 == tableSize)
						{
							aux = ")";
						}
						else
						{
							aux = ",";
						}

						banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
					}
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idFisioterapeuta,
					idPaciente,
					dataSessao);
				
				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de sessão.
		 */
		public static void Update(int id,
			int idFisioterapeuta,
			int idPaciente,
			string dataSessao,
			string observacaoSessao)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idFisioterapeuta);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], idPaciente);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], dataSessao);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[4], observacaoSessao);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de sessão.
		 */
		public static List<Sessao> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM SESSAO";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<Sessao> sessions = new List<Sessao>();

				while (reader.Read())
				{
					int idSessaoTemp = 0;
					int idFisioterapeutaTemp = 0;
					int idPacienteTemp = 0;
					string dataSessaoTemp = "";
					string observacaoSessaoTemp = "";

					if (!reader.IsDBNull(0))
					{
						idSessaoTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idFisioterapeutaTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2))
					{
						idPacienteTemp = reader.GetInt32(2);
					}
					if (!reader.IsDBNull(3))
					{
						dataSessaoTemp = reader.GetString(3);
					}
					if (!reader.IsDBNull(4))
					{
						observacaoSessaoTemp = reader.GetString(4);
					}

					Sessao session = new Sessao (idSessaoTemp, idFisioterapeutaTemp, idPacienteTemp, dataSessaoTemp, observacaoSessaoTemp);
					sessions.Add(session);
				}
				
				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return sessions;
			}
		}


		public static Sessao ReadValue (int id)
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

				int idSessaoTemp = 0;
				int idFisioterapeutaTemp = 0;
				int idPacienteTemp = 0;
				string dataSessaoTemp = "";
				string observacaoSessaoTemp = "";

				if (!reader.IsDBNull(0))
				{
					idSessaoTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					idFisioterapeutaTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2))
				{
					idPacienteTemp = reader.GetInt32(2);
				}
				if (!reader.IsDBNull(3))
				{
					dataSessaoTemp = reader.GetString(3);
				}
				if (!reader.IsDBNull(4))
				{
					observacaoSessaoTemp = reader.GetString(4);
				}

				Sessao session = new Sessao (idSessaoTemp, idFisioterapeutaTemp, idPacienteTemp, dataSessaoTemp, observacaoSessaoTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return session;
			}
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de sessão.
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
		* Função que apaga a relação de sessão inteira de uma vez.
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
