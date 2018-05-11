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
		private double TempoInicial;
		private double TempoFinal;
		private string EstagioMovimentoFisio;

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

		public double tempoInicial 
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

		public double tempoFinal 
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
		
		/**
		 * Classe com todos os atributos de um pontosrotulofisioterapeuta.
		 */
		public PontosRotuloFisioterapeuta(int idrf, int idm, double ti, double tf, string e)
		{
				this.idRotuloFisioterapeuta = idrf;
				this.idMovimento = idm;
				this.tempoInicial = ti;
				this.tempoFinal = tf;
				this.estagioMovimentoFisio = e;
		}

		public PontosRotuloFisioterapeuta(Object[] columns)
		{
				this.idRotuloFisioterapeuta = (int)columns[0];
				this.idMovimento = (int)columns[1];
				this.tempoInicial = (double)columns[2];
				this.tempoFinal = (double)columns[3];
				this.estagioMovimentoFisio = (string)columns[4];
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
			double tempoInicial,
			double tempoFinal)
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
			double tempoInicial,
			double tempoFinal)
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
			string estagioMovimentoFisioTemp = "null";
			double tempoInicialTemp = 0;
			double tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloFisioterapeutaTemp,idMovimentoTemp,tempoInicialTemp,tempoFinalTemp,estagioMovimentoFisioTemp};

			List<PontosRotuloFisioterapeuta> physioLabelPoints = banco.Read<PontosRotuloFisioterapeuta>(GlobalController.instance.path, TablesManager.Tables[tableId].tableName, columns);

			return physioLabelPoints;
		}

		public static PontosRotuloFisioterapeuta ReadValue (int id)
		{
			DataBase banco = new DataBase();

			int idRotuloFisioterapeutaTemp = 0;
			int idMovimentoTemp = 0;
			string estagioMovimentoFisioTemp = "null";
			double tempoInicialTemp = 0;
			double tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloFisioterapeutaTemp,idMovimentoTemp,tempoInicialTemp,tempoFinalTemp,estagioMovimentoFisioTemp};

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
