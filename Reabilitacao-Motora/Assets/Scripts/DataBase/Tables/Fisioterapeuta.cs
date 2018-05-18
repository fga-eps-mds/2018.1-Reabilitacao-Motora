using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;
using DataBaseAttributes;

namespace fisioterapeuta
{
  /**
   * Cria relação para cadastro dos fisioterapeutas a serem cadastrados pelo programa.
   */
	public class Fisioterapeuta
	{
		private const int tableId = 1;
		private int IdFisioterapeuta;
		private int IdPessoa;
		private string Login;
		private string Senha;
		private string Regiao;
		private string Crefito;
		private Pessoa Persona;

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

		public string login 
		{
			get 
			{
				return Login; 
			} 
			set 
			{
				Login = value; 
			}
		}

		public string senha 
		{
			get 
			{
				return Senha; 
			} 
			set 
			{
				Senha = value; 
			}
		}

		public string regiao 
		{
			get 
			{
				return Regiao; 
			} 
			set 
			{
				Regiao = value; 
			}
		}

		public string crefito 
		{
			get 
			{
				return Crefito; 
			} 
			set 
			{
				Crefito = value; 
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
		 * Classe com todos os atributos de um fisioterapeuta.
		 */
		public Fisioterapeuta(int idf, int idp, string l, string s, string r, string c)
		{
			this.idFisioterapeuta = idf;
			this.idPessoa = idp;
			this.login = l;
			this.senha = s;
			this.regiao = r;
			this.crefito = c;
			this.persona = Pessoa.ReadValue(idp);
			
		}

		/**
		 * Cria a relação para fisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = "CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (idFisioterapeuta INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,login VARCHAR (255) not null,senha VARCHAR (255) not null,regiao VARCHAR (2),crefito VARCHAR (10),foreign key (idPessoa) references PESSOA (idPessoa),constraint crefito_regiao UNIQUE (crefito, regiao), constraint login_senha UNIQUE (login, senha));";

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro dos fisioterapeutas na relação fisioterapeuta.
		 */
		public static void Insert(int idPessoa, string login, string senha)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into FISIOTERAPEUTA (";

				int tableSize =	 TablesManager.Tables[tableId].colName.Count;

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
					
					banco.sqlQuery += ( TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idPessoa,
					login,
					senha);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que insere dados necessários para cadastro dos pacientes do fisioterapeuta na relação fisioterapeuta.
		 */
		public static void Insert(int idPessoa,
			string login,
			string senha,
			string regiao,
			string crefito)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "insert into FISIOTERAPEUTA (";

				int tableSize =	 TablesManager.Tables[tableId].colName.Count;

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
					
					banco.sqlQuery += ( TablesManager.Tables[tableId].colName[i] + aux);
				}

				banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\", \"{4}\")", idPessoa,
					login,
					senha,
					regiao,
					crefito);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
		 */
		public static void Update(int id,
			int idPessoa,
			string senha)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ",  TablesManager.Tables[tableId].tableName);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",",	 TablesManager.Tables[tableId].colName[1], idPessoa);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",	 TablesManager.Tables[tableId].colName[3], senha);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"",	TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}


		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
		 */
		public static void Update(int id,
			int idPessoa,
			string senha,
			string regiao,
			string crefito)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("UPDATE \"{0}\" set ",  TablesManager.Tables[tableId].tableName);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",",	 TablesManager.Tables[tableId].colName[1], idPessoa);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",",	 TablesManager.Tables[tableId].colName[4], regiao);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",	 TablesManager.Tables[tableId].colName[5], crefito);
				banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",	 TablesManager.Tables[tableId].colName[3], senha);

				banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"",	TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação fisioterapeuta.
		 */
		public static List<Fisioterapeuta> Read()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + "FROM FISIOTERAPEUTA";
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();
				List<Fisioterapeuta> physiotherapeuts = new List<Fisioterapeuta>();

				while (reader.Read())
				{
					int idFisioterapeutaTemp = 0;
					int idPessoaTemp = 0;
					string loginTemp = "null";
					string senhaTemp = "null";
					string regiaoTemp = "null";
					string crefitoTemp = "null";

					if (!reader.IsDBNull(0))
					{
						idFisioterapeutaTemp = reader.GetInt32(0);
					}
					if (!reader.IsDBNull(1))
					{
						idPessoaTemp = reader.GetInt32(1);
					}
					if (!reader.IsDBNull(2))
					{
						loginTemp = reader.GetString(2);
					}
					if (!reader.IsDBNull(3))
					{
						senhaTemp = reader.GetString(3);
					}
					if (!reader.IsDBNull(4))
					{
						regiaoTemp = reader.GetString(4);
					}
					if (!reader.IsDBNull(5))
					{
						crefitoTemp = reader.GetString(5);
					}

					Fisioterapeuta physiotherapeut = new Fisioterapeuta (idFisioterapeutaTemp, idPessoaTemp, loginTemp, senhaTemp, regiaoTemp, crefitoTemp);
					physiotherapeuts.Add(physiotherapeut);
				}

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return physiotherapeuts;
			}
		}

		public static Fisioterapeuta ReadValue (int id)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();
				banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";",  TablesManager.Tables[tableId].tableName, 
					 TablesManager.Tables[tableId].colName[0], 
					id);
				banco.cmd.CommandText = banco.sqlQuery;
				IDataReader reader = banco.cmd.ExecuteReader();

				reader.Read();

				int idFisioterapeutaTemp = 0;
				int idPessoaTemp = 0;
				string loginTemp = "null";
				string senhaTemp = "null";
				string regiaoTemp = "null";
				string crefitoTemp = "null";

				if (!reader.IsDBNull(0))
				{
					idFisioterapeutaTemp = reader.GetInt32(0);
				}
				if (!reader.IsDBNull(1))
				{
					idPessoaTemp = reader.GetInt32(1);
				}
				if (!reader.IsDBNull(2))
				{
					loginTemp = reader.GetString(2);
				}
				if (!reader.IsDBNull(3))
				{
					senhaTemp = reader.GetString(3);
				}
				if (!reader.IsDBNull(4))
				{
					regiaoTemp = reader.GetString(4);
				}
				if (!reader.IsDBNull(5))
				{
					crefitoTemp = reader.GetString(5);
				}

				Fisioterapeuta physiotherapeut = new Fisioterapeuta (idFisioterapeutaTemp,idPessoaTemp,loginTemp,senhaTemp,regiaoTemp,crefitoTemp);

				reader.Close();
				reader = null;
				banco.cmd.Dispose();
				banco.cmd = null;
				banco.conn.Close();
				banco.conn = null;
				return physiotherapeut;
			}
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação fisioterapeuta.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"",  TablesManager.Tables[tableId].tableName,	 TablesManager.Tables[tableId].colName[0], id);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}

		/**
		 * Função que apaga a relação fisioterapeuta inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			using (banco.conn = new SqliteConnection(GlobalController.instance.path))
			{
				banco.conn.Open();
				banco.cmd = banco.conn.CreateCommand();

				banco.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"",	TablesManager.Tables[tableId].tableName);

				banco.cmd.CommandText = banco.sqlQuery;
				banco.cmd.ExecuteScalar();
				banco.conn.Close();
			}
		}
	}
}
