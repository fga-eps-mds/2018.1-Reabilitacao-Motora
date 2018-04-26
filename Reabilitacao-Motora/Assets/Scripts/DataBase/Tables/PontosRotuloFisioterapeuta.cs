using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;

namespace pontosrotulofisioterapeuta
{

    /**
    * Cria relação para cadastro dos pontosrotulofisioterapeuta a serem cadastrados pelo programa.
     */
    public class PontosRotuloFisioterapeuta
    {
        private static int tableId = 9;
        public int idRotuloFisioterapeuta, idMovimento;
        public double tempoInicial, tempoFinal;
        public string estagioMovimentoFisio;

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

        /**
        * Cria a relação para pontosrotulofisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public static void Create()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOFISIOTERAPEUTA (idRotuloFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,estagioMovimentoFisio VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
        * Função que insere dados na tabela de pontosrotulofisioterapeuta.
         */
        public static void Insert(int idMovimento,
            string estagioMovimentoFisio,
            double tempo,
            double anguloDeJunta)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "insert into PONTOSROTULOFISIOTERAPEUTA (";

                int tableSize = TablesManager.instance.Tables[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    GlobalController.instance.sqlQuery += (TablesManager.instance.Tables[tableId].colName[i] + aux);
                }

                GlobalController.instance.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                    estagioMovimentoFisio,
                    tempo,
                    anguloDeJunta);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
        * Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
         */
        public static void Update(int id,
            int idMovimento,
            string estagioMovimentoFisio,
            double tempo,
            double anguloDeJunta)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[1], idMovimento);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[2], estagioMovimentoFisio);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[3], tempo);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.instance.Tables[tableId].colName[4], anguloDeJunta);

                GlobalController.instance.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
        * Função que lê dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
         */
        public static List<PontosRotuloFisioterapeuta> Read()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                IDataReader reader = GlobalController.instance.cmd.ExecuteReader();

                List<PontosRotuloFisioterapeuta> prf = new List<PontosRotuloFisioterapeuta>();

                while (reader.Read())
                {
                    int idRotuloFisioterapeuta = 0;
                    int idMovimento = 0;
                    string estagioMovimentoFisio = "null";
                    double tempoInicial = 0;
                    double tempoFinal = 0;

                    if (!reader.IsDBNull(0)) idRotuloFisioterapeuta = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) estagioMovimentoFisio = reader.GetString(2);
                    if (!reader.IsDBNull(3)) tempoInicial = reader.GetDouble(3);
                    if (!reader.IsDBNull(4)) tempoFinal = reader.GetDouble(4);

                    PontosRotuloFisioterapeuta x = new PontosRotuloFisioterapeuta(idRotuloFisioterapeuta,idMovimento,tempoInicial,tempoFinal,estagioMovimentoFisio);
                    prf.Add(x);
                }
                reader.Close();
                reader = null;
                GlobalController.instance.cmd.Dispose();
                GlobalController.instance.cmd = null;
                GlobalController.instance.conn.Close();
                GlobalController.instance.conn = null;
                return prf;
            }
        }

        public static PontosRotuloFisioterapeuta ReadValue (int id)
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

                int idRotuloFisioterapeuta = 0;
                int idMovimento = 0;
                string estagioMovimentoFisio = "null";
                double tempoInicial = 0;
                double tempoFinal = 0;

                if (!reader.IsDBNull(0)) idRotuloFisioterapeuta = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) estagioMovimentoFisio = reader.GetString(2);
                if (!reader.IsDBNull(3)) tempoInicial = reader.GetDouble(3);
                if (!reader.IsDBNull(4)) tempoFinal = reader.GetDouble(4);

                PontosRotuloFisioterapeuta x = new PontosRotuloFisioterapeuta (idRotuloFisioterapeuta,idMovimento,tempoInicial,tempoFinal,estagioMovimentoFisio);

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
        * Função que deleta dados cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
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
        * Função que apaga a relação de pontosrotulofisioterapeuta inteira de uma vez.
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
