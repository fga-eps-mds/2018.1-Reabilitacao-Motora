using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace exercicio
{
	/**
	 * Cria relação para cadastro dos exercicios a serem cadastrados pelo programa.
	 */
	public class Exercicio
	{
		private const int tableId = 6;
		private int IdExercicio;
		private int IdPaciente;
		private int IdMovimento;
		private int IdSessao;
		private string DescricaoExercicio;
		private string PontosExercicio;

		public int idExercicio 
		{ 
			get 
			{ 
				return IdExercicio; 
			} 
			set 
			{ 
				IdExercicio = value; 
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

		public string descricaoExercicio 
		{ 
			get 
			{ 
				return DescricaoExercicio; 
			} 
			set 
			{ 
				DescricaoExercicio = value; 
			}
		}

		public string pontosExercicio 
		{ 
			get 
			{ 
				return PontosExercicio; 
			} 
			set 
			{ 
				PontosExercicio = value; 
			}
		}


		/**
		 * Classe com todos os atributos de um exercicio.
		 */
		public Exercicio(int ide, int idp, int idm, int ids, string de, string pe)
		{
			this.idExercicio = ide;
			this.idPaciente = idp;
			this.idMovimento = idm;
			this.idSessao = ids;
			this.descricaoExercicio = de;
			this.pontosExercicio = pe;
		}

		/**
		 * Cria a relação para exercicios, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();   
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS EXERCICIO (idExercicio INTEGER primary key AUTOINCREMENT,idPaciente INTEGER not null,idMovimento INTEGER not null,idSessao INTEGER not null,descricaoExercicio VARCHAR (150),pontosExercicio VARCHAR (150) not null,foreign key (idSessao) references SESSAO (idSessao),foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idPaciente) references PACIENTE (idPaciente));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados na tabela de exercicios.
		 */
		public static void Insert(int idPaciente,
			int idMovimento,
			int idSessao,
			string descricaoExercicio,
			string pontosExercicio)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into EXERCICIO (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 0; i < tableSize; ++i)
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

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", idPaciente,
					idMovimento,
					idSessao,
					descricaoExercicio,
					pontosExercicio);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		 * Função que insere dados na tabela de exercicios (sem a descrição).
		 */
		public static void Insert(int idPaciente,
			int idMovimento,
			int idSessao,
			string pontosExercicio)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into EXERCICIO (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;
				const int INDEX_COL_DESCRICAO = 4;

				for (int i = 0; i < tableSize; ++i)
				{
					if (i != INDEX_COL_DESCRICAO)
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
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idPaciente,
					idMovimento,
					idSessao,
					pontosExercicio);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação de exercicios.
		 */
		public static void Update(int id,
			int idPaciente,
			int idMovimento,
			int idSessao,
			string descricaoExercicio,
			string pontosExercicio)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idPaciente);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], idMovimento);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], idSessao);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[4], descricaoExercicio);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[5], pontosExercicio);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação de exercicios.
		 */
		public static List<Exercicio> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM EXERCICIO";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<Exercicio> exercises = new List<Exercicio>();

				while (reader.Read())
				{
					int idExercicioTemp = 0;
					int idPacienteTemp = 0;
					int idMovimentoTemp = 0;
					int idSessaoTemp = 0;
					string descricaoExercicioTemp = "null";
					string pontosExercicioTemp = "null";

					if (!reader.IsDBNull(0)) 
					{
						idExercicioTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1)) 
					{
						idPacienteTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2)) 
					{
						idMovimentoTemp = reader.GetInt32(2);
					}
					if (!reader.IsDBNull(3)) 
					{
						idSessaoTemp = reader.GetInt32(3);
					}
					if (!reader.IsDBNull(4)) 
					{
						descricaoExercicioTemp = reader.GetString(4);
					}
					if (!reader.IsDBNull(5)) 
					{
						pontosExercicioTemp = reader.GetString(5);
					}

					Exercicio exercise = new Exercicio(idExercicioTemp, idPacienteTemp, idMovimentoTemp, idSessaoTemp, descricaoExercicioTemp, pontosExercicioTemp);
					exercises.Add(exercise);
				}

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return exercises;
			}
		}

		public static Exercicio ReadValue(int id)
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

				int idExercicioTemp = 0;
				int idPacienteTemp = 0;
				int idMovimentoTemp = 0;
				int idSessaoTemp = 0;
				string descricaoExercicioTemp = "null";
				string pontosExercicioTemp = "null";

				if (!reader.IsDBNull(0)) 
				{
					idExercicioTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1)) 
				{
					idPacienteTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2)) 
				{
					idMovimentoTemp = reader.GetInt32(2);
				}
				if (!reader.IsDBNull(3)) 
				{
					idSessaoTemp = reader.GetInt32(3);
				}
				if (!reader.IsDBNull(4)) 
				{
					descricaoExercicioTemp = reader.GetString(4);
				}
				if (!reader.IsDBNull(5)) 
				{
					pontosExercicioTemp = reader.GetString(5);
				}

				Exercicio exercise = new Exercicio(idExercicioTemp, idPacienteTemp, idMovimentoTemp, idSessaoTemp, descricaoExercicioTemp, pontosExercicioTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return exercise;
			}
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação de exercicios.
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
		 * Função que apaga a relação de exercicios inteira de uma vez.
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
