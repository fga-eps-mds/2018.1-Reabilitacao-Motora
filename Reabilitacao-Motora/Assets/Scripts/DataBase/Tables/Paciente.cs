using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;
using DataBaseAttributes;

namespace paciente
{
  /**
   * Classe que cria relação para cadastro de Pacientes a serem registrados pelo sistema.
   */
	public class Paciente
	{
		private const int tableId = 2;
		private int IdPaciente;
		private int IdPessoa;
		private string Observacoes;
		private Pessoa Persona;

		public int idPaciente { get { return IdPaciente; } set { IdPaciente = value; }}
		public int idPessoa { get { return IdPessoa; } set { IdPessoa = value; }}
		public string observacoes { get { return Observacoes; } set { Observacoes = value; }}
		public Pessoa persona { get { return Persona; } set { Persona = value; }}

		/**
		 * Classe com todos os atributos de um paciente.
		 */
		public Paciente(Object[] columns)
		{
			this.idPaciente = (int)columns[0];
			this.idPessoa = (int)columns[1];
			this.observacoes = (string)columns[2];
			this.persona = Pessoa.ReadValue ((int)columns[1]);
		}

		/**
		 * Cria a relação para paciente, contendo um id gerado automaticamente pelo banco como chave primária.
		 */
		public static void Create()
		{
			string query = "CREATE TABLE IF NOT EXISTS PACIENTE (idPaciente INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,observacoes VARCHAR (300),foreign key (idPessoa) references PESSOA (idPessoa));";
			DataBase.Create(query);	
		}

		/**
		 * Função que insere dados necessários para cadastro de pacientes na relação musculo.
		 */
		public static void Insert(int idPessoa,
			string observacoes)
		{
			Object[] columns = new Object[] {idPessoa, observacoes};
			DataBase.Insert(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que atualiza dados já cadastrados anteriormente na relação paciente.
		 */
		public static void Update(int id,
			int idPessoa,
			string observacoes)
		{
			Object[] columns = new Object[] {id, idPessoa, observacoes};
			DataBase.Update(columns, TablesManager.Tables[tableId].tableName, tableId);
		}

		/**
		 * Função que lê dados já cadastrados anteriormente na relação paciente.
		 */
		public static List<Paciente> Read()
		{
			Object[] columns = new Object[] {0, 0, ""};

			List<Paciente> patients = DataBase.Read<Paciente>(TablesManager.Tables[tableId].tableName, columns);

			return patients;
		}

		public static Paciente ReadValue (int id)
		{
			Object[] columns = new Object[] {0, 0, ""};

			Paciente patient = DataBase.ReadValue<Paciente>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], id, columns);

			return patient;
		}

		public static Paciente GetLast ()
		{
			Object[] columns = new Object[] {0, 0, ""};

			Paciente patient = DataBase.GetLast<Paciente>(TablesManager.Tables[tableId].tableName,
				TablesManager.Tables[tableId].colName[0], columns);

			return patient;
		}

		/**
		 * Função que deleta dados cadastrados anteriormente na relação paciente.
		 */
		public static void DeleteValue(int id)
		{
			DataBase.DeleteValue (tableId, id);
		}

		/**
		 * Função que apaga a relação paciente inteira de uma vez.
		 */
		public static void Drop()
		{
			DataBase.Drop (tableId);
		}
	}
}
