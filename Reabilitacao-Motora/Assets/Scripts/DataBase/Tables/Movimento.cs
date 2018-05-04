using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

namespace movimento
{
  /**
   * Classe que cria relação para cadastro de movimentos a serem cadastrados pelo programa.
   */
    public class Movimento
    {

        private static int tableId = 5;
        public int idMovimento, idFisioterapeuta;
        public string nomeMovimento, descricaoMovimento, pontosMovimento;

        public Movimento(){}

        /**
         * Classe com todos os atributos de um movimento.
         */
        public Movimento(int idm, int idf, string nm, string dm, string pm)
        {
            this.idMovimento = idm;
            this.idFisioterapeuta = idf;
            this.nomeMovimento = nm;
            this.descricaoMovimento = dm;
            this.pontosMovimento = pm;
        }

        /**
         * Cria a relação para movimento, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public static void Create()
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,descricaoMovimento VARCHAR (150),pontosMovimento VARCHAR (150) not null,foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro de movimentos na relação movimento.
         */
        public static void Insert(int idFisioterapeuta,
            string nomeMovimento,
            string descricaoFisioterapeuta,
            string pontosMovimento)
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into MOVIMENTO (";

                int tableSize = TablesManager.Tables[tableId].colName.Count;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idFisioterapeuta,
                    nomeMovimento,
                    descricaoFisioterapeuta,
                    pontosMovimento);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação movimento.
         */
        public static void Update(int id,
            int idFisioterapeuta,
            string nomeMovimento,
            string descricaoFisioterapeuta,
            string pontosMovimento)
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idFisioterapeuta);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], nomeMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], descricaoFisioterapeuta);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[4], pontosMovimento);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação movimento.
         */
        public static List<Movimento> Read()
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM MOVIMENTO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<Movimento> m = new List<Movimento>();
                while (reader.Read())
                {
                    int idMovimento = 0;
                    int idFisioterapeuta = 0;
                    string nomeMovimento = "null";
                    string descricaoFisioterapeuta = "null";
                    string pontosMovimento = "null";

                    if (!reader.IsDBNull(0)) idMovimento = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) nomeMovimento = reader.GetString(2);
                    if (!reader.IsDBNull(3)) descricaoFisioterapeuta = reader.GetString(3);
                    if (!reader.IsDBNull(4)) pontosMovimento = reader.GetString(4);

                    Movimento x = new Movimento(idMovimento, idFisioterapeuta, nomeMovimento, descricaoFisioterapeuta, pontosMovimento);
                    m.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return m;
            }
        }

        public static Movimento ReadValue (int id)
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", TablesManager.Tables[tableId].tableName, 
                    TablesManager.Tables[tableId].colName[0], 
                    id);
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                int idMovimento = 0;
                int idFisioterapeuta = 0;
                string nomeMovimento = "null";
                string descricaoMovimento = "null";
                string pontosMovimento = "null";

                if (!reader.IsDBNull(0)) idMovimento = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) nomeMovimento = reader.GetString(2);
                if (!reader.IsDBNull(3)) descricaoMovimento = reader.GetString(3);
                if (!reader.IsDBNull(4)) pontosMovimento = reader.GetString(4);

                Movimento x = new Movimento (idMovimento,idFisioterapeuta,nomeMovimento,descricaoMovimento,pontosMovimento);

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
         * Função que deleta dados cadastrados anteriormente na relação movimento.
         */
        public static void DeleteValue(int id)
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.Tables[tableId].tableName, TablesManager.Tables[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que apaga a relação movimento inteira de uma vez.
         */
        public static void Drop()
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.Tables[tableId].tableName);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }
    }
}
