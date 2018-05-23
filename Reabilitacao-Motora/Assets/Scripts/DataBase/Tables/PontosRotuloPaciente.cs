using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace pontosrotulopaciente
{

	/**
	* Cria relação para cadastro dos pontosrotulopaciente a serem cadastrados pelo programa.
	 */
	public class PontosRotuloPaciente
	{
		private const int tableId = 9;
		private int IdRotuloPaciente;
		private int IdExercicio;
		private string EstagioMovimentoPaciente;
		private float TempoInicial;
		private float TempoFinal;

		public int idRotuloPaciente 
		{
			get 
			{
				return IdRotuloPaciente; 
			} 
			set 
			{
				IdRotuloPaciente = value; 
			}
		}

		public int idExercicio 
		{
			get 
			{
				return IdExercicio; 
			} 
			set 
			{
				IdExercicio = value; 
			}
		}

		public string estagioMovimentoPaciente 
		{
			get 
			{
				return EstagioMovimentoPaciente; 
			} 
			set 
			{
				EstagioMovimentoPaciente = value; 
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
		 * Classe com todos os atributos de um pontosrotulopaciente.
		 */
		public PontosRotuloPaciente(int idrp, int ide, string e, float ti, float tf)
		{
				this.idRotuloPaciente = idrp;
				this.idExercicio = ide;
				this.estagioMovimentoPaciente = e;
				this.tempoInicial = ti;
				this.tempoFinal = tf;
		}

		public PontosRotuloPaciente(Object[] columns)
		{
				this.idRotuloPaciente = (int)columns[0];
				this.idExercicio = (int)columns[1];
				this.estagioMovimentoPaciente = (string)columns[2];
				this.tempoInicial = (float)columns[3];
				this.tempoFinal = (float)columns[4];
		}

		/**
		* Cria a relação para pontosrotulopaciente, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			DataBase banco = new DataBase();
			string query = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";
			banco.Create(GlobalController.path, query);
		}

		/**
		* Função que insere dados na tabela de pontosrotulopaciente.
		 */
		public static void Insert(int idExercicio,
			string estagioMovimentoPaciente,
			float tempoInicial,
			float tempoFinal)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {idExercicio, estagioMovimentoPaciente, tempoInicial, tempoFinal};
			banco.Insert(GlobalController.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static void Update(int id,
			int idExercicio,
			string estagioMovimentoPaciente,
			float tempoInicial,
			float tempoFinal)
		{
			DataBase banco = new DataBase();
			Object[] columns = new Object[] {id, idExercicio, estagioMovimentoPaciente, tempoInicial, tempoFinal};
			banco.Update(GlobalController.path, columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static List<PontosRotuloPaciente> Read()
		{
			DataBase banco = new DataBase();

			int idRotuloPacienteTemp = 0;
			int idExercicioTemp = 0;
			string estagioMovimentoPacienteTemp = "";
			float tempoInicialTemp = 0;
			float tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloPacienteTemp,idExercicioTemp,estagioMovimentoPacienteTemp,tempoInicialTemp,tempoFinalTemp};

			List<PontosRotuloPaciente> patientLabelPoints = banco.Read<PontosRotuloPaciente>(GlobalController.path, TablesManager.Tables[tableId].tableName, columns);

			return patientLabelPoints;
		}


		public static PontosRotuloPaciente ReadValue (int id)
		{
			DataBase banco = new DataBase();

			int idRotuloPacienteTemp = 0;
			int idExercicioTemp = 0;
			string estagioMovimentoPacienteTemp = "";
			float tempoInicialTemp = 0;
			float tempoFinalTemp = 0;

			Object[] columns = new Object[] {idRotuloPacienteTemp,idExercicioTemp,estagioMovimentoPacienteTemp,tempoInicialTemp,tempoFinalTemp};

			PontosRotuloPaciente patientLabelPoint = banco.ReadValue<PontosRotuloPaciente>(GlobalController.path, TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return patientLabelPoint;
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static void DeleteValue(int id)
		{
			DataBase banco = new DataBase();
			banco.DeleteValue (tableId, id);
		}

		/**
		* Função que apaga a relação de pontosrotulopaciente inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase banco = new DataBase();
			banco.Drop (tableId);
		}
	}
}
