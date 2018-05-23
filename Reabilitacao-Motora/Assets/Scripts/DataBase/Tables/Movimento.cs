using System;
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

		public Movimento(Object[] columns)
		{
			this.idMovimento = (int)columns[0];
			this.idFisioterapeuta = (int)columns[1];
			this.nomeMovimento = (string)columns[2];
			this.descricaoMovimento = (string)columns[3];
			this.pontosMovimento = (string)columns[4];
		}

		/**
		 * Cria a relação para movimento, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			string query = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,descricaoMovimento VARCHAR (150),pontosMovimento VARCHAR (150) not null,foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";
			banco.Create(GlobalController.path, query);	
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
			Object[] columns = new Object[] {idFisioterapeuta, nomeMovimento, descricaoMovimento, pontosMovimento};
			banco.Insert(GlobalController.path, columns, TablesManager.Tables[tableId].tableName, tableId);
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
			Object[] columns = new Object[] {id, idFisioterapeuta, nomeMovimento, descricaoMovimento, pontosMovimento};
			banco.Update(GlobalController.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação movimento.
		 */
		public static List<Movimento> Read()
		{
			DataBase banco = new DataBase();
			int idMovimentoTemp = 0;
			int idFisioterapeutaTemp = 0;
			string nomeMovimentoTemp = "";
			string descricaoMovimentoTemp = "";
			string pontosMovimentoTemp = "";

			Object[] columns = new Object[] {idMovimentoTemp,idFisioterapeutaTemp,nomeMovimentoTemp,descricaoMovimentoTemp,pontosMovimentoTemp};

			List<Movimento> movements = banco.Read<Movimento>(GlobalController.path, TablesManager.Tables[tableId].tableName, columns);

			return movements;
		}


		public static Movimento ReadValue (int id)
		{
			DataBase banco = new DataBase();
			int idMovimentoTemp = 0;
			int idFisioterapeutaTemp = 0;
			string nomeMovimentoTemp = "";
			string descricaoMovimentoTemp = "";
			string pontosMovimentoTemp = "";

			Object[] columns = new Object[] {idMovimentoTemp,idFisioterapeutaTemp,nomeMovimentoTemp,descricaoMovimentoTemp,pontosMovimentoTemp};

			Movimento movement = banco.ReadValue<Movimento>(GlobalController.path, TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return movement;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação movimento.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			banco.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação movimento inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			banco.Drop (tableId);
		}
	}
}
