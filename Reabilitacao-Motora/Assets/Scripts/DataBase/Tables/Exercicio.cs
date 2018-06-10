using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace exercicio
{
	/**
	 * Cria relação para cadastro dos exercicios a serem cadastrados pelo programa.
	 */
	public class Exercicio
	{
		private const int tableId = 6;
		
		private int IdExercicio;
		private int IdPaciente;
		private int IdMovimento;
		private int IdSessao;
		private string PontosExercicio;
		private string DescricaoExercicio;

		public int idExercicio { get { return IdExercicio; } set { IdExercicio = value; }}
		public int idPaciente { get { return IdPaciente; } set { IdPaciente = value; }}
		public int idMovimento { get { return IdMovimento; } set { IdMovimento = value; }}
		public int idSessao { get { return IdSessao; } set { IdSessao = value; }}
		public string pontosExercicio { get { return PontosExercicio; } set { PontosExercicio = value; }}
		public string descricaoExercicio { get { return DescricaoExercicio; } set { DescricaoExercicio = value; }}


		/**
		 * Classe com todos os atributos de um exercicio.
		 */
		public Exercicio (Object[] columns)
		{
			this.idExercicio = (int)columns[0];
			this.idPaciente = (int)columns[1];
			this.idMovimento = (int)columns[2];
			this.idSessao = (int)columns[3];
			this.pontosExercicio = (string)columns[4];
			this.descricaoExercicio = (string)columns[5];
		}

		/**
		 * Cria a relação para exercicios, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS EXERCICIO (idExercicio INTEGER primary key AUTOINCREMENT,idPaciente INTEGER not null,idMovimento INTEGER not null,idSessao INTEGER not null,pontosExercicio VARCHAR (150) not null,descricaoExercicio VARCHAR (150),foreign key (idSessao) references SESSAO (idSessao),foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idPaciente) references PACIENTE (idPaciente));";
			DataBase.Create(query);
		}

		/**
		 * Função que insere dados na tabela de exercicios.
		 */
		public static void Insert(int idPaciente,
			int idMovimento,
			int idSessao,
			string pontosExercicio,
			string descricaoExercicio)
		{
			Object[] columns = new Object[] {idPaciente, idMovimento, idSessao, pontosExercicio, descricaoExercicio};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);	
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação de exercicios.
		 */
		public static void Update(int id,
			int idPaciente,
			int idMovimento,
			int idSessao,
			string pontosExercicio,
			string descricaoExercicio)
		{
			Object[] columns = new Object[] {id, idPaciente, idMovimento, idSessao, pontosExercicio, descricaoExercicio};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação de exercicios.
		 */
		public static List<Exercicio> Read()
		{
			Object[] columns = new Object[] {0, 0, 0, 0, "", ""};
			List<Exercicio> exerciseList = DataBase.Read<Exercicio>(TablesManager.Tables[tableId].tableName, columns);

			return exerciseList;
		}


		public static Exercicio ReadValue(int id)
		{
			Object[] columns = new Object[] {0, 0, 0, 0, "", ""};
			Exercicio exercise = DataBase.ReadValue<Exercicio>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return exercise;
		}

		public static Exercicio GetLast()
		{
			Object[] columns = new Object[] {0, 0, 0, 0, "", ""};
			Exercicio exercise = DataBase.GetLast<Exercicio>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], columns);

			return exercise;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação de exercicios.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação de exercicios inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
