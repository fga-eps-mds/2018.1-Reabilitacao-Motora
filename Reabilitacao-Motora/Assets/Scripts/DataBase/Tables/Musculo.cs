using System;
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

		public int idMusculo { get { return IdMusculo; } set { IdMusculo = value; }}
		public string nomeMusculo { get { return NomeMusculo; } set { NomeMusculo = value; }}

		/**
		 * Classe com todos os atributos de um musculo.
		 */
		public Musculo(Object[] columns)
		{
			this.idMusculo = (int)columns[0];
			this.nomeMusculo = (string)columns[1];
		}

		/**
		 * Cria a relação para musculo, contendo um id gerado automaticamente pelo DataBase como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS MUSCULO (idMusculo INTEGER primary key AUTOINCREMENT,nomeMusculo VARCHAR (20) not null, constraint musculo UNIQUE (nomeMusculo));";
			DataBase.Create(query);	
		}

		/**
		 * Função que insere dados necessários para cadastro de musculos na relação musculo.
		 */
		public static void Insert(string nomeMusculo)
		{
			Object[] columns = new Object[] {nomeMusculo};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação musculo.
		 */
		public static void Update(int id,
			string nomeMusculo)
		{
			Object[] columns = new Object[] {id, nomeMusculo};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação musculo.
		 */
		public static List<Musculo> Read()
		{
			Object[] columns = new Object[] {0, ""};

			List<Musculo> muscles = DataBase.Read<Musculo>(TablesManager.Tables[tableId].tableName, columns);

			return muscles;
		}

		public static Musculo ReadValue (int id)
		{
			Object[] columns = new Object[] {0, ""};

			Musculo muscle = DataBase.ReadValue<Musculo>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return muscle;
		}

		public static Musculo GetLast ()
		{
			Object[] columns = new Object[] {0, ""};

			Musculo muscle = DataBase.GetLast<Musculo>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], columns);

			return muscle;
		}

		public static Musculo SingleSpecificSelect(string query)
		{
			Object[] columns = new Object[] {0, ""};

			Musculo mus = DataBase.SingleSpecificSelect<Musculo>(TablesManager.Tables[tableId].tableName, columns, query);

			return mus;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação musculo.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação musculo inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
