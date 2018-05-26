using System;
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

		public int idPessoa { get { return IdPessoa; } set { IdPessoa = value; }}
		public string nomePessoa { get { return NomePessoa; } set { NomePessoa = value; }}
		public string sexo { get { return Sexo; } set { Sexo = value; }}
		public string dataNascimento { get { return DataNascimento; } set { DataNascimento = value; }}
		public string telefone1 { get { return Telefone1; } set { Telefone1 = value; }}
		public string telefone2 { get { return Telefone2; } set { Telefone2 = value; }}

		/**
		 * Classe com todos os atributos de uma pessoa.
		 */

		public Pessoa (Object[] columns)
		{
			this.idPessoa = (int)columns[0];
			this.nomePessoa = (string)columns[1];
			this.sexo = (string)columns[2];
			this.dataNascimento = (string)columns[3];
			this.telefone1 = (string)columns[4];
			this.telefone2 = (string)columns[5];	
		}

		/**
		 * Cria a relação para pessoas, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS PESSOA (idPessoa INTEGER primary key AUTOINCREMENT,nomePessoa VARCHAR (30) not null,sexo CHAR (1) not null,dataNascimento DATE not null,telefone1 VARCHAR (11) not null,telefone2 VARCHAR (11));";
			DataBase.Create(query);
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
			Object[] columns = new Object[] {nomePessoa, sexo, dataNascimento, telefone1, telefone2};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);	
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
			Object[] columns = new Object[] {id, nomePessoa, sexo, dataNascimento, telefone1, telefone2};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que retorna dados já cadastrados anteriormente na relação de pessoas.
		 */
		public static List<Pessoa> Read()
		{
			Object[] columns = new Object[] {0, "", "", "", "", ""};
			List<Pessoa> personList = DataBase.Read<Pessoa>(TablesManager.Tables[tableId].tableName, columns);

			return personList;		
		}

		public static Pessoa ReadValue(int id)
		{
			Object[] columns = new Object[] {0, "", "", "", "", ""};
			Pessoa person = DataBase.ReadValue<Pessoa>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return person;
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pessoas.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		* Função que apaga a relação de pessoas inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
