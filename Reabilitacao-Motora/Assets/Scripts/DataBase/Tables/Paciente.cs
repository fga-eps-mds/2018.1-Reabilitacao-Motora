using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;

namespace paciente
{
  /**
   * Classe que cria relação para cadastro de Pacientes a serem registrados pelo sistema.
   */
    public class Paciente
    {
        int tableId = 3;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;

        /**
         * Classe com todos os atributos de um paciente.
         */
        public class Pacientes
        {
            public int idPaciente, idPessoa;
            public string observacoes;
            public Pessoa.Pessoas persona;
            public Pessoa temp;
            public Pacientes (int idpa, int idpe, string obs)
            {
                this.idPaciente = idpa;
                this.idPessoa = idpe;
                this.observacoes = obs;
                this.persona = temp.ReadValue (idpe);
            }
        }

        /**
         * Cria a relação para paciente, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public Paciente(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PACIENTE (idPaciente INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,observacoes VARCHAR (300),foreign key (idPessoa) references PESSOA (idPessoa));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro de pacientes na relação musculo.
         */
        public void Insert(int idPessoa,
            string observacoes)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PACIENTE (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                    observacoes);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação paciente.
         */
        public void Update(int id,
            int idPessoa,
            string observacoes)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idPessoa);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[2], observacoes);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação paciente.
         */
        public List<Pacientes> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM PACIENTE";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<Pacientes> p = new List<Pacientes>();

                while (reader.Read())
                {
                    int idPaciente = 0;
                    int idPessoa = 0;
                    string observacoes = "null";

                    if (!reader.IsDBNull(0)) idPaciente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) observacoes = reader.GetString(2);

                    Pacientes x = new Pacientes(idPaciente, idPessoa, observacoes);
                    p.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return p;
            }
        }

        public Pacientes ReadValue (int id)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", tt.TABLES[tableId].tableName, 
                    tt.TABLES[tableId].colName[0], 
                    id);
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                int idPaciente = 0;
                int idPessoa = 0;
                string observacoes = "null";

                if (!reader.IsDBNull(0)) idPaciente = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) observacoes = reader.GetString(2);

                Pacientes x = new Pacientes (idPaciente,idPessoa,observacoes);

                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return x;
            }
        }

        /**
         * Função que deleta dados cadastrados anteriormente na relação paciente.
         */
        public void DeleteValue(int id)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", tt.TABLES[tableId].tableName, tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que apaga a relação paciente inteira de uma vez.
         */
        public void Drop()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", tt.TABLES[tableId].tableName);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }
    }
}
