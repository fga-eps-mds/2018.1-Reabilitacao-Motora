using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace pessoa
{

	/**
	* Cria relação para cadastro das pessoas a serem cadastrados pelo programa.
	 */
	public class Pessoa
	{
		private const int tableId = 0;
		private int IdPessoa;
		private string NomePessoa;
		private string Sexo;
		private string DataNascimento;
		private string Telefone1;
		private string Telefone2;

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

		public string nomePessoa 
		{ 
			get 
			{ 
				return NomePessoa; 
			}
			set 
			{ 
				NomePessoa = value; 
			}
		}

		public string sexo 
		{ 
			get 
			{ 
				return Sexo; 
			}
			set 
			{ 
				Sexo = value; 
			}
		}

		public string dataNascimento 
		{ 
			get 
			{ 
				return DataNascimento; 
			}
			set 
			{ 
				DataNascimento = value; 
			}
		}

		public string telefone1 
		{ 
			get 
			{ 
				return Telefone1; 
			}
			set 
			{ 
				Telefone1 = value; 
			}
		}

		public string telefone2 
		{ 
			get 
			{ 
				return Telefone2; 
			}
			set 
			{ 
				Telefone2 = value; 
			}
		}


		public Pessoa(){}


		/**
		 * Classe com todos os atributos de uma pessoa.
		 */
		public Pessoa(int id, string nome, string s, string d, string t1, string t2)
		{
			this.idPessoa = id;
			this.nomePessoa = nome;
			this.sexo = s;
			this.dataNascimento = d;
			this.telefone1 = t1;
			this.telefone2 = t2;
			
		}

		/**
		 * Cria a relação para pessoas, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PESSOA (idPessoa INTEGER primary key AUTOINCREMENT,nomePessoa VARCHAR (30) not null,sexo CHAR (1) not null,dataNascimento DATE not null,telefone1 VARCHAR (11) not null,telefone2 VARCHAR (11));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que insere dados na tabela de pessoas.
		 */
		public static void Insert(
			string nomePessoa,
			string sexo,
			string dataNascimento,
			string telefone1,
			string telefone2)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into PESSOA (";

				int tableSize = TablesManager.Tables[tableId].colName.Count;

				for (int i = 1; i < tableSize; ++i) 
				{
					string aux = (i+1 == tableSize) ? (")") : (",");
					banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", nomePessoa,
					sexo,
					dataNascimento,
					telefone1,
					telefone2);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de pessoas.
		 */
		public static void Update(int id,
			string nomePessoa,
			string sexo,
			string dataNascimento,
			string telefone1,
			string telefone2)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], nomePessoa);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], sexo);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], dataNascimento);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[4], telefone1);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[5], telefone2);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		* Função que retorna dados já cadastrados anteriormente na relação de pessoas.
		 */
		public static List<Pessoa> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM PESSOA";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();
				List<Pessoa> p = new List<Pessoa>();

				while (reader.Read())
				{
					int idPessoaTemp = 0;
					string nomePessoaTemp = "null";
					string sexoTemp = "null";
					string dataNascimentoTemp = "null";
					string telefone1Temp = "null";
					string telefone2Temp = "null";
					if (!reader.IsDBNull(0))
					{
						idPessoaTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						nomePessoaTemp = reader.GetString(1);
					}
					if (!reader.IsDBNull(2))
					{
						sexoTemp = reader.GetString(2);
					}
					if (!reader.IsDBNull(3))
					{
						dataNascimentoTemp = reader.GetString(3);
					}
					if (!reader.IsDBNull(4))
					{
						telefone1Temp = reader.GetString(4);
					}
					if (!reader.IsDBNull(5))
					{
						telefone2Temp = reader.GetString(5);
					}
					Pessoa x = new Pessoa(idPessoaTemp, nomePessoaTemp, sexoTemp, dataNascimentoTemp, telefone1Temp, telefone2Temp);
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


		public static Pessoa ReadValue (int id)
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

				Pessoa x = new Pessoa();

				while (reader.Read())
				{
					int idPessoaTemp = 0;
					string nomePessoaTemp = "null";
					string sexoTemp = "null";
					string dataNascimentoTemp = "null";
					string telefone1Temp = "null";
					string telefone2Temp = "null";

					if (!reader.IsDBNull(0))
					{
						idPessoaTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						nomePessoaTemp = reader.GetString(1);
					}
					if (!reader.IsDBNull(2))
					{
						sexoTemp = reader.GetString(2);
					}
					if (!reader.IsDBNull(3))
					{
						dataNascimentoTemp = reader.GetString(3);
					}
					if (!reader.IsDBNull(4))
					{
						telefone1Temp = reader.GetString(4);
					}
					if (!reader.IsDBNull(5))
					{
						telefone2Temp = reader.GetString(5);
					}
					
					x = new Pessoa(idPessoaTemp, nomePessoaTemp, sexoTemp, dataNascimentoTemp, telefone1Temp, telefone2Temp);
				}

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
		* Função que deleta dados cadastrados anteriormente na relação de pessoas.
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
		* Função que apaga a relação de pessoas inteira de uma vez.
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
