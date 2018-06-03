using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;
using exercicio;

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
        private Exercicio Exer;

		public int idRotuloPaciente { get { return IdRotuloPaciente; } set { IdRotuloPaciente = value; }}
		public int idExercicio { get { return IdExercicio; } set { IdExercicio = value; }}
		public string estagioMovimentoPaciente { get { return EstagioMovimentoPaciente; } set { EstagioMovimentoPaciente = value; }}		
		public float tempoInicial { get { return TempoInicial; } set { TempoInicial = value; }}
		public float tempoFinal { get { return TempoFinal; } set { TempoFinal = value; }}
        public Exercicio exer { get { return Exer; } set { Exer = value; } }


		/**
		 * Classe com todos os atributos de um pontosrotulopaciente.
		 */
		public PontosRotuloPaciente(Object[] columns)
		{
			this.idRotuloPaciente = (int)columns[0];
			this.idExercicio = (int)columns[1];
			this.estagioMovimentoPaciente = (string)columns[2];
			this.tempoInicial = (float)columns[3];
			this.tempoFinal = (float)columns[4];
            this.exer = Exercicio.ReadValue((int)columns[1]);
		}

		/**
		* Cria a relação para pontosrotulopaciente, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";
			DataBase.Create(query);
		}

		/**
		* Função que insere dados na tabela de pontosrotulopaciente.
		 */
		public static void Insert(int idExercicio,
			string estagioMovimentoPaciente,
			float tempoInicial,
			float tempoFinal)
		{
			Object[] columns = new Object[] {idExercicio, estagioMovimentoPaciente, tempoInicial, tempoFinal};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
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
			Object[] columns = new Object[] {id, idExercicio, estagioMovimentoPaciente, tempoInicial, tempoFinal};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		* Função que lê dados já cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static List<PontosRotuloPaciente> Read()
		{
			Object[] columns = new Object[] {0, 0, "", 0.00f, 0.00f};

			List<PontosRotuloPaciente> patientLabelPoints = DataBase.Read<PontosRotuloPaciente>(TablesManager.Tables[tableId].tableName, columns);

			return patientLabelPoints;
		}


		public static PontosRotuloPaciente ReadValue (int id)
		{
			Object[] columns = new Object[] {0, 0, "", 0.00f, 0.00f};

			PontosRotuloPaciente patientLabelPoint = DataBase.ReadValue<PontosRotuloPaciente>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return patientLabelPoint;
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pontosrotulopaciente.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		* Função que apaga a relação de pontosrotulopaciente inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
