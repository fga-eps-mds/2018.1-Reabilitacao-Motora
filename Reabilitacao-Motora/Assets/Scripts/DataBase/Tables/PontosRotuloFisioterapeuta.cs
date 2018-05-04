using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using DataBaseAttributes;

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
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOFISIOTERAPEUTA (idRotuloFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,estagioMovimentoFisio VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
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
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PONTOSROTULOFISIOTERAPEUTA (";

                int tableSize = TablesManager.Tables[tableId].colName.Count;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (TablesManager.Tables[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                    estagioMovimentoFisio,
                    tempo,
                    anguloDeJunta);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
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
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.Tables[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[1], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[2], estagioMovimentoFisio);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.Tables[tableId].colName[3], tempo);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.Tables[tableId].colName[4], anguloDeJunta);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que lê dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
         */
        public static List<PontosRotuloFisioterapeuta> Read()
        {
            DataBase banco = new DataBase();
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

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
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return prf;
            }
        }

        public static PontosRotuloFisioterapeuta ReadValue (int id)
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
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return x;
            }
        }

        /**
        * Função que deleta dados cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
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
        * Função que apaga a relação de pontosrotulofisioterapeuta inteira de uma vez.
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
