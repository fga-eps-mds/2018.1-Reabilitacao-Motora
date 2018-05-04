using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;
using DataBaseAttributes;

namespace paciente
{
  /**
   * Classe que cria relação para cadastro de Pacientes a serem registrados pelo sistema.
   */
	public class Paciente
	{
		private const int tableId = 2;
		private int IdPaciente;
		private int IdPessoa;
		private string Observacoes;
		private Pessoa Persona;

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

		public int idPessoa 
		{ 
			get 
			{ 
				return IdPessoa; 
			} 
			set 
			{ 
				IdPessoa = value; 
			}
		}

		public string observacoes 
		{ 
			get 
			{ 
				return Observacoes; 
			} 
			set 
			{ 
				Observacoes = value; 
			}
		}

		public Pessoa persona 
		{ 
			get 
			{ 
				return Persona; 
			} 
			set 
			{ 
				Persona = value; 
			}
		} 


		/**
		 * Classe com todos os atributos de um paciente.
		 */
		public Paciente(int idpa, int idpe, string obs)
		{
			this.idPaciente = idpa;
			this.idPessoa = idpe;
			this.observacoes = obs;
			this.persona = Pessoa.ReadValue (idpe);
		}

		/**
		 * Cria a relação para paciente, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PACIENTE (idPaciente INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,observacoes VARCHAR (300),foreign key (idPessoa) references PESSOA (idPessoa));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro de pacientes na relação musculo.
		 */
		public static void Insert(int idPessoa,
			string observacoes)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into PACIENTE (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 1; i < tableSize; ++i) 
				{
					string aux = (i+1 == tableSize) ? (")") : (",");
					banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
					observacoes);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação paciente.
		 */
		public static void Update(int id,
			int idPessoa,
			string observacoes)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idPessoa);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[2], observacoes);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação paciente.
		 */
		public static List<Paciente> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM PACIENTE";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				List<Paciente> p = new List<Paciente>();

				while (reader.Read())
				{
					int idPacienteTemp = 0;
					int idPessoaTemp = 0;
					string observacoesTemp = "null";

					if (!reader.IsDBNull(0))
					{
						idPacienteTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idPessoaTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2))
					{
						observacoesTemp = reader.GetString(2);
					}

					Paciente x = new Paciente(idPacienteTemp, idPessoaTemp, observacoesTemp);
					p.Add(x);
				}
				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return p;
			}
		}

		public static Paciente ReadValue (int id)
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

				int idPacienteTemp = 0;
				int idPessoaTemp = 0;
				string observacoesTemp = "null";

				if (!reader.IsDBNull(0))
				{
					idPacienteTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					idPessoaTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2))
				{
					observacoesTemp = reader.GetString(2);
				}

				Paciente x = new Paciente (idPacienteTemp,idPessoaTemp,observacoesTemp);

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
		 * Função que deleta dados cadastrados anteriormente na relação paciente.
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
		 * Função que apaga a relação paciente inteira de uma vez.
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
