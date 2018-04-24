using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace pessoa
{

    /**
    * Cria relação para cadastro das pessoas a serem cadastrados pelo programa.
     */
    public class Pessoa
    {
        int tableId = 0;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;

        /**
         * Classe com todos os atributos de uma pessoa.
         */
        public class Pessoas
        {
            public int idPessoa;
            public string nomePessoa, sexo, dataNascimento, telefone1, telefone2;
            public Pessoas (){}
            public Pessoas (int id, string nome, string s, string d, string t1, string t2)
            {
                this.idPessoa = id;
                this.nomePessoa = nome;
                this.sexo = s;
                this.dataNascimento = d;
                this.telefone1 = t1;
                this.telefone2 = t2;
            }
        }

        /**
         * Cria a relação para pessoas, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public Pessoa(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PESSOA (idPessoa INTEGER primary key AUTOINCREMENT,nomePessoa VARCHAR (30) not null,sexo CHAR (1) not null,dataNascimento DATE not null,telefone1 VARCHAR (11) not null,telefone2 VARCHAR (11));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que insere dados na tabela de pessoas.
         */
        public void Insert(
            string nomePessoa,
            string sexo,
            string dataNascimento,
            string telefone1,
            string telefone2)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PESSOA (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", nomePessoa,
                    sexo,
                    dataNascimento,
                    telefone1,
                    telefone2);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que atualiza dados já cadastrados anteriormente na relação de pessoas.
         */
        public void Update(int id,
            string nomePessoa,
            string sexo,
            string dataNascimento,
            string telefone1,
            string telefone2)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], nomePessoa);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], sexo);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], dataNascimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[4], telefone1);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[5], telefone2);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que retorna dados já cadastrados anteriormente na relação de pessoas.
         */
        public List<Pessoas> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM PESSOA";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
                List<Pessoas> p = new List<Pessoas>();

                while (reader.Read())
                {
                    int idPessoa = 0;
                    string nomePessoa = "null";
                    string sexo = "null";
                    string dataNascimento = "null";
                    string telefone1 = "null";
                    string telefone2 = "null";
                    if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) nomePessoa = reader.GetString(1);
                    if (!reader.IsDBNull(2)) sexo = reader.GetString(2);
                    if (!reader.IsDBNull(3)) dataNascimento = reader.GetString(3);
                    if (!reader.IsDBNull(4)) telefone1 = reader.GetString(4);
                    if (!reader.IsDBNull(5)) telefone2 = reader.GetString(5);
                    Pessoas x = new Pessoas(idPessoa, nomePessoa, sexo, dataNascimento, telefone1, telefone2);
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


        public Pessoas ReadValue (int id)
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

                Pessoas x = new Pessoas();

                while (reader.Read())
                {
                    int idPessoa = 0;
                    string nomePessoa = "null";
                    string sexo = "null";
                    string dataNascimento = "null";
                    string telefone1 = "null";
                    string telefone2 = "null";

                    if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) nomePessoa = reader.GetString(1);
                    if (!reader.IsDBNull(2)) sexo = reader.GetString(2);
                    if (!reader.IsDBNull(3)) dataNascimento = reader.GetString(3);
                    if (!reader.IsDBNull(4)) telefone1 = reader.GetString(4);
                    if (!reader.IsDBNull(5)) telefone2 = reader.GetString(5);
                    
                    x = new Pessoas(idPessoa, nomePessoa, sexo, dataNascimento, telefone1, telefone2);
                }

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
        * Função que deleta dados cadastrados anteriormente na relação de pessoas.
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
        * Função que apaga a relação de pessoas inteira de uma vez.
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
