using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace telefone
{
    /**
     * Cria relação para cadastro dos telefone a serem cadastrados pelo programa.
     */
    public class Telefone
    {
        int tableId = 0;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;

        /**
         * Classe com todos os atributos de um telefone.
         */
        public class Telefones
        {
            public int idPessoa;
            public string telefone;
            public Telefones (int idp, string tel)
            {
                this.idPessoa = idp;
                this.telefone = tel;
            }
        }

        /**
         * Cria a relação para telefone, sendo a chave primária composta pelo telefone e a chave estrangeira advinda de Pessoa.
         */
        public Telefone(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS TELEFONE (idPessoa INTEGER not null,telefone VARCHAR (18) not null,foreign key (idPessoa) references PESSOA (idPessoa));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados na tabela de telefone.
         */
        public void Insert(int idPessoa,
            string telefone)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into TELEFONE (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 0; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                    telefone);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação de telefone.
         */
        public void Update(int idPessoa, string telefone)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" SET ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[0], idPessoa);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[1], telefone);

                banco.sqlQuery += string.Format("WHERE \"{0}\"=\"{1}\" AND \"{2}\"=\"{3}\"", tt.TABLES[tableId].colName[0], idPessoa, tt.TABLES[tableId].colName[1], telefone);

                //update TELEFONE set idPessoa = 5, telefone = '+55 44 0000 1234' WHERE (idPessoa = 5, telefone = '+55 44 9998 1717'

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação de telefone.
         */
        public List<Telefones> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM TELEFONE";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<Telefones> t = new List<Telefones>();

                while (reader.Read())
                {
                    int idPessoa = 0;
                    string telefone = "null";

                    if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) telefone = reader.GetString(1);

                    Telefones x = new Telefones(idPessoa, telefone);
                    t.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return t;
            }
        }

        public Telefones ReadValue (int id)
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

                int idPessoa = 0;
                string telefone = "null";

                if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) telefone = reader.GetString(1);

                Telefones x = new Telefones(idPessoa, telefone);

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
         * Função que deleta dados cadastrados anteriormente na relação de telefone.
         */
        public void DeleteValue(int id1, string id2)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\" AND \"{3}\" = \"{4}\"", tt.TABLES[tableId].tableName, tt.TABLES[tableId].colName[0], id1, tt.TABLES[tableId].colName[1], id2);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que apaga a relação de telefone inteira de uma vez.
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
