using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;

namespace musculo
{
  /**
   * Classe que cria relação para cadastro de musculos a serem cadastrados pelo programa.
   */
    public class Musculo
    {
        private static int tableId = 4;
        public int idMusculo;
        public string nomeMusculo;


        /**
         * Classe com todos os atributos de um musculo.
         */
        public Musculo(int idm, string nm)
        {
                this.idMusculo = idm;
                this.nomeMusculo = nm;
        }

        /**
         * Cria a relação para musculo, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public static void Create()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = "CREATE TABLE IF NOT EXISTS MUSCULO (idMusculo INTEGER primary key AUTOINCREMENT,nomeMusculo VARCHAR (20) not null, constraint musculo UNIQUE (nomeMusculo));";
                
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro de musculos na relação musculo.
         */
        public static void Insert(string nomeMusculo)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "insert into MUSCULO (";

                int tableSize = TablesManager.instance.Tables[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    GlobalController.instance.sqlQuery += (TablesManager.instance.Tables[tableId].colName[i] + aux);
                }

                GlobalController.instance.sqlQuery += string.Format(" values (\"{0}\")", nomeMusculo);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação musculo.
         */
        public static void Update(int id,
            string nomeMusculo)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.instance.Tables[tableId].colName[1], nomeMusculo);

                GlobalController.instance.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação musculo.
         */
        public static List<Musculo> Read()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "SELECT * " + "FROM MUSCULO";
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                IDataReader reader = GlobalController.instance.cmd.ExecuteReader();

                List<Musculo> m = new List<Musculo>();

                while (reader.Read())
                {
                    int idMusculo = 0;
                    string nomeMusculo = "null";

                    if (!reader.IsDBNull(0)) idMusculo = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) nomeMusculo = reader.GetString(1);

                    Musculo x = new Musculo (idMusculo, nomeMusculo);
                    m.Add(x);
                }
                reader.Close();
                reader = null;
                GlobalController.instance.cmd.Dispose();
                GlobalController.instance.cmd = null;
                GlobalController.instance.conn.Close();
                GlobalController.instance.conn = null;
                return m;
            }
        }

        public static Musculo ReadValue (int id)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", TablesManager.instance.Tables[tableId].tableName, 
                    TablesManager.instance.Tables[tableId].colName[0], 
                    id);
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                IDataReader reader = GlobalController.instance.cmd.ExecuteReader();

                int idMusculo = 0;
                string nomeMusculo = "null";

                if (!reader.IsDBNull(0)) idMusculo = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) nomeMusculo = reader.GetString(1);

                Musculo x = new Musculo (idMusculo,nomeMusculo);

                reader.Close();
                reader = null;
                GlobalController.instance.cmd.Dispose();
                GlobalController.instance.cmd = null;
                GlobalController.instance.conn.Close();
                GlobalController.instance.conn = null;
                return x;
            }
        }

        /**
         * Função que deleta dados cadastrados anteriormente na relação musculo.
         */
        public static void DeleteValue(int id)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.instance.Tables[tableId].tableName, TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que apaga a relação musculo inteira de uma vez.
         */
        public static void Drop()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }
    }
}
