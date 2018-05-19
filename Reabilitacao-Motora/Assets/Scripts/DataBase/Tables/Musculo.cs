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

		public Musculo(Object[] columns)
		{
			this.idMusculo = (int)columns[0];
			this.nomeMusculo = (string)columns[1];
		}

		/**
		 * Cria a relação para musculo, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			string query = "CREATE TABLE IF NOT EXISTS MUSCULO (idMusculo INTEGER primary key AUTOINCREMENT,nomeMusculo VARCHAR (20) not null, constraint musculo UNIQUE (nomeMusculo));";
			banco.Create(GlobalController.instance.path, query);	
		}

		/**
		 * Função que insere dados necessários para cadastro de musculos na relação musculo.
		 */
		public static void Insert(string nomeMusculo)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {nomeMusculo};
			banco.Insert(GlobalController.instance.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação musculo.
		 */
		public static void Update(int id,
			string nomeMusculo)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {id, nomeMusculo};
			banco.Update(GlobalController.instance.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação musculo.
		 */
		public static List<Musculo> Read()
		{
			DataBase banco = new DataBase();

			int idMusculoTemp = 0;
			string nomeMusculoTemp = "";

			Object[] columns = new Object[] {idMusculoTemp, nomeMusculoTemp};

			List<Musculo> muscles = banco.Read<Musculo>(GlobalController.instance.path, TablesManager.Tables[tableId].tableName, columns);

			return muscles;
		}

		public static Musculo ReadValue (int id)
		{
			DataBase banco = new DataBase();
			int idMusculoTemp = 0;
			string nomeMusculoTemp = "";

			Object[] columns = new Object[] {idMusculoTemp, nomeMusculoTemp};

			Musculo muscle = banco.ReadValue<Musculo>(GlobalController.instance.path, TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return muscle;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação musculo.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			banco.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação musculo inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			banco.Drop (tableId);
		}
	}
}
