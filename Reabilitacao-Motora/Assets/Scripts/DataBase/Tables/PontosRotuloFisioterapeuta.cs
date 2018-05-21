using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace pontosrotulofisioterapeuta
{

	/**
	* Cria relação para cadastro dos pontosrotulofisioterapeuta a serem cadastrados pelo programa.
	 */
	public class PontosRotuloFisioterapeuta
	{
		private const int tableId = 8;
		private int IdRotuloFisioterapeuta;
		private int IdMovimento;
		private string EstagioMovimentoFisio;
		private float TempoInicial;
		private float TempoFinal;

		public int idRotuloFisioterapeuta 
		{
			get 
			{
				return IdRotuloFisioterapeuta; 
			} 
			set 
			{
				IdRotuloFisioterapeuta = value; 
			}
		}

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

		public string estagioMovimentoFisio 
		{
			get 
			{
				return EstagioMovimentoFisio; 
			} 
			set 
			{
				EstagioMovimentoFisio = value; 
			}
		}

		public float tempoInicial 
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

		public float tempoFinal 
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

		
		/**
		 * Classe com todos os atributos de um pontosrotulofisioterapeuta.
		 */
		public PontosRotuloFisioterapeuta(int idrf, int idm, float ti, float tf, string e)
		{
				this.idRotuloFisioterapeuta = idrf;
				this.idMovimento = idm;
				this.estagioMovimentoFisio = e;
				this.tempoInicial = ti;
				this.tempoFinal = tf;
		}

		public PontosRotuloFisioterapeuta(Object[] columns)
		{
				this.idRotuloFisioterapeuta = (int)columns[0];
				this.idMovimento = (int)columns[1];
				this.estagioMovimentoFisio = (string)columns[2];
				this.tempoInicial = (float)columns[3];
				this.tempoFinal = (float)columns[4];
		}

		/**
		* Cria a relação para pontosrotulofisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			string query = "CREATE TABLE IF NOT EXISTS PONTOSROTULOFISIOTERAPEUTA (idRotuloFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,estagioMovimentoFisio VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";
			banco.Create(GlobalController.instance.path, query);
		}

		/**
		* Função que insere dados na tabela de pontosrotulofisioterapeuta.
		 */
		public static void Insert(int idMovimento,
			string estagioMovimentoFisio,
			float tempoInicial,
			float tempoFinal)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {idMovimento, estagioMovimentoFisio, tempoInicial, tempoFinal};
			banco.Insert(GlobalController.instance.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static void Update(int id,
			int idMovimento,
			string estagioMovimentoFisio,
			float tempoInicial,
			float tempoFinal)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {id, idMovimento, estagioMovimentoFisio, tempoInicial, tempoFinal};
			banco.Update(GlobalController.instance.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static List<PontosRotuloFisioterapeuta> Read()
		{
			DataBase banco = new DataBase();

			int idRotuloFisioterapeutaTemp = 0;
			int idMovimentoTemp = 0;
			string estagioMovimentoFisioTemp = "";
			float tempoInicialTemp = 0;
			float tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloFisioterapeutaTemp,idMovimentoTemp,estagioMovimentoFisioTemp,tempoInicialTemp,tempoFinalTemp};

			List<PontosRotuloFisioterapeuta> physioLabelPoints = banco.Read<PontosRotuloFisioterapeuta>(GlobalController.instance.path, TablesManager.Tables[tableId].tableName, columns);

			return physioLabelPoints;
		}

		public static PontosRotuloFisioterapeuta ReadValue (int id)
		{
			DataBase banco = new DataBase();

			int idRotuloFisioterapeutaTemp = 0;
			int idMovimentoTemp = 0;
			string estagioMovimentoFisioTemp = "";
			float tempoInicialTemp = 0;
			float tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloFisioterapeutaTemp,idMovimentoTemp,estagioMovimentoFisioTemp,tempoInicialTemp,tempoFinalTemp};

			PontosRotuloFisioterapeuta physioLabelPoint = banco.ReadValue<PontosRotuloFisioterapeuta>(GlobalController.instance.path, TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return physioLabelPoint;
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			banco.DeleteValue (tableId, id);
		}

		/**
		* Função que apaga a relação de pontosrotulofisioterapeuta inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			banco.Drop (tableId);
		}
	}
}
