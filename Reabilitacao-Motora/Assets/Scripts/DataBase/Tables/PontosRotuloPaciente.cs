using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace pontosrotulopaciente {

	/**
	* Cria relação para cadastro dos pontosrotulopaciente a serem cadastrados pelo programa.
	 */
	public class PontosRotuloPaciente
	{
		private const int tableId = 9;
		private int IdRotuloPaciente;
		private int IdExercicio;
		private double TempoInicial;
		private double TempoFinal;
		private string EstagioMovimentoPaciente;

		public int idRotuloPaciente 
		{ 
			get 
			{ 
				return IdRotuloPaciente; 
			} 
			set 
			{ 
				IdRotuloPaciente = value; 
			}
		}

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

		public double tempoInicial 
		{ 
			get 
			{ 
				return TempoInicial; 
			} 
			set 
			{ 
				TempoInicial = value; 
			}
		}

		public double tempoFinal 
		{ 
			get 
			{ 
				return TempoFinal; 
			} 
			set 
			{ 
				TempoFinal = value; 
			}
		}

		public string estagioMovimentoPaciente 
		{ 
			get 
			{ 
				return EstagioMovimentoPaciente; 
			} 
			set 
			{ 
				EstagioMovimentoPaciente = value; 
			}
		}


		/**
		 * Classe com todos os atributos de um pontosrotulopaciente.
		 */
		public PontosRotuloPaciente(int idrp, int ide, double ti, double tf, string e)
		{
				this.idRotuloPaciente = idrp;
				this.idExercicio = ide;
				this.tempoInicial = ti;
				this.tempoFinal = tf;
				this.estagioMovimentoPaciente = e;
		}

		/**
		* Cria a relação para pontosrotulopaciente, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que insere dados na tabela de pontosrotulopaciente.
		 */
		public static void Insert(int idMovimento,
			string estagioMovimentoPaciente,
			double tempoInicial,
			double tempoFinal)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into PONTOSROTULOPACIENTE (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 1; i < tableSize; ++i) 
				{
					string aux = (i+1 == tableSize) ? (")") : (",");
					banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
					estagioMovimentoPaciente,
					tempoInicial,
					tempoFinal);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static void Update(int id,
			int idMovimento,
			string estagioMovimentoPaciente,
			double tempoInicial,
			double tempoFinal)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idMovimento);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], estagioMovimentoPaciente);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], tempoInicial);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[4], tempoFinal);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static List<PontosRotuloPaciente> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<PontosRotuloPaciente> prp = new List<PontosRotuloPaciente>();

				while (reader.Read())
				{
					int idRotuloPacienteTemp = 0;
					int idExercicioTemp = 0;
					string estagioMovimentoPacienteTemp = "null";
					double tempoInicialTemp = 0;
					double tempoFinalTemp = 0;

					if (!reader.IsDBNull(0))
					{
						idRotuloPacienteTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idExercicioTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2))
					{
						estagioMovimentoPacienteTemp = reader.GetString(2);
					}
					if (!reader.IsDBNull(3))
					{
						tempoInicialTemp = reader.GetDouble(3);
					}
					if (!reader.IsDBNull(4))
					{
						tempoFinalTemp = reader.GetDouble(4);
					}

					PontosRotuloPaciente x = new PontosRotuloPaciente(idRotuloPacienteTemp,idExercicioTemp,tempoInicialTemp,tempoFinalTemp,estagioMovimentoPacienteTemp);
					prp.Add(x);
				}
				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return prp;
			}
		}


		public static PontosRotuloPaciente ReadValue (int id)
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

				int idRotuloPacienteTemp = 0;
				int idExercicioTemp = 0;
				string estagioMovimentoPacienteTemp = "null";
				double tempoInicialTemp = 0;
				double tempoFinalTemp = 0;

				if (!reader.IsDBNull(0))
				{
					idRotuloPacienteTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					idExercicioTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2))
				{
					estagioMovimentoPacienteTemp = reader.GetString(2);
				}
				if (!reader.IsDBNull(3))
				{
					tempoInicialTemp = reader.GetDouble(3);
				}
				if (!reader.IsDBNull(4))
				{
					tempoFinalTemp = reader.GetDouble(4);
				}

				PontosRotuloPaciente x = new PontosRotuloPaciente (idRotuloPacienteTemp,idExercicioTemp,tempoInicialTemp,tempoFinalTemp,estagioMovimentoPacienteTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return x;
			}
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pontosrotulopaciente.
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
		* Função que apaga a relação de pontosrotulopaciente inteira de uma vez.
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
