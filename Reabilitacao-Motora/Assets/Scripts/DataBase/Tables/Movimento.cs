using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;
using fisioterapeuta;
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
		private string PontosMovimento;
		private string DescricaoMovimento;
		private Fisioterapeuta Physio;

		public int idMovimento { get { return IdMovimento; } set { IdMovimento = value; }}
		public int idFisioterapeuta { get { return IdFisioterapeuta; } set { IdFisioterapeuta = value; }}
		public string nomeMovimento { get { return NomeMovimento; } set { NomeMovimento = value; }}
		public string pontosMovimento { get { return PontosMovimento; } set { PontosMovimento = value; }}
		public string descricaoMovimento { get { return DescricaoMovimento; } set { DescricaoMovimento = value; }}
		public Fisioterapeuta physio { get { return Physio; } set { Physio = value; }}

		/**
		 * Classe com todos os atributos de um movimento.
		 */
		public Movimento(Object[] columns)
		{
			this.idMovimento = (int)columns[0];
			this.idFisioterapeuta = (int)columns[1];
			this.nomeMovimento = (string)columns[2];
			this.pontosMovimento = (string)columns[3];
			this.descricaoMovimento = (string)columns[4];
			this.physio = Fisioterapeuta.ReadValue((int)columns[1]);
		}

		/**
		 * Cria a relação para movimento, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			string query = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,pontosMovimento VARCHAR (150) not null,descricaoMovimento VARCHAR (150),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";
			banco.Create(query);
		}

		/**
		 * Função que insere dados necessários para cadastro de movimentos na relação movimento.
		 */
		public static void Insert(int idFisioterapeuta,
			string nomeMovimento,
			string pontosMovimento,
			string descricaoMovimento)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {idFisioterapeuta, nomeMovimento, pontosMovimento, descricaoMovimento};
			banco.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação movimento.
		 */
		public static void Update(int id,
			int idFisioterapeuta,
			string nomeMovimento,
			string pontosMovimento,
			string descricaoMovimento)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {id, idFisioterapeuta, nomeMovimento, pontosMovimento, descricaoMovimento};
			banco.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação movimento.
		 */
		public static List<Movimento> Read()
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {0, 0, "", "", ""};

			List<Movimento> movements = banco.Read<Movimento>(TablesManager.Tables[tableId].tableName, columns);

			return movements;
		}


		public static Movimento ReadValue (int id)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {0, 0, "", "", ""};

			Movimento movement = banco.ReadValue<Movimento>(TablesManager.Tables[tableId].tableName,
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
