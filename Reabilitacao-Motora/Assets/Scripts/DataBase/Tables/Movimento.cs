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
		 * Cria a relação para movimento, contendo um id gerado automaticamente pelo DataBase como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,pontosMovimento VARCHAR (150) not null,descricaoMovimento VARCHAR (150),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";
			DataBase.Create(query);
		}

		/**
		 * Função que insere dados necessários para cadastro de movimentos na relação movimento.
		 */
		public static void Insert(int idFisioterapeuta,
			string nomeMovimento,
			string pontosMovimento,
			string descricaoMovimento)
		{
			Object[] columns = new Object[] {idFisioterapeuta, nomeMovimento, pontosMovimento, descricaoMovimento};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
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
			Object[] columns = new Object[] {id, idFisioterapeuta, nomeMovimento, pontosMovimento, descricaoMovimento};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação movimento.
		 */
		public static List<Movimento> Read()
		{
			Object[] columns = new Object[] {0, 0, "", "", ""};

			List<Movimento> movements = DataBase.Read<Movimento>(TablesManager.Tables[tableId].tableName, columns);

			return movements;
		}


		public static Movimento ReadValue (int id)
		{
			Object[] columns = new Object[] {0, 0, "", "", ""};

			Movimento movement = DataBase.ReadValue<Movimento>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return movement;
		}

		public static Movimento GetLast ()
		{
			Object[] columns = new Object[] {0, 0, "", "", ""};

			Movimento movement = DataBase.GetLast<Movimento>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], columns);

			return movement;
		}

		public static List<Movimento> MultiSpecificSelect(string query)
		{
			Object[] columns = new Object[] {0, 0, "", "", ""};

			List<Movimento> movements = DataBase.MultiSpecificSelect<Movimento>(TablesManager.Tables[tableId].tableName, columns, query);

			return movements;
		}

		public static Movimento SingleSpecificSelect(string query)
		{
			Object[] columns = new Object[] {0, 0, "", "", ""};

			Movimento movements = DataBase.SingleSpecificSelect<Movimento>(TablesManager.Tables[tableId].tableName, columns, query);

			return movements;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação movimento.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação movimento inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
