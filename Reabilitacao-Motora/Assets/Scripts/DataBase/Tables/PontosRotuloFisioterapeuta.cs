using UnityEngine;
using System.Collections;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace pontosrotulofisioterapeuta
{

    /**
    * Cria relação para cadastro dos pontosrotulofisioterapeuta a serem cadastrados pelo programa.
     */
    public class PontosRotuloFisioterapeuta
    {
        int tableId = 9;
        DataBase banco = new DataBase ();
        TableNameColumn tt = new TableNameColumn ();
        string path;

        /**
        * Cria a relação para pontosrotulofisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public PontosRotuloFisioterapeuta (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
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
        public void Insert (int idMovimento,
            string estagioMovimentoFisio,
            double tempo,
            double anguloDeJunta)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PONTOSROTULOFISIOTERAPEUTA (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
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
        public void Update (int id,
            int idMovimento,
            string estagioMovimentoFisio,
            double tempo,
            double anguloDeJunta)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], estagioMovimentoFisio);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], tempo);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], anguloDeJunta);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que lê dados já cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
         */
        public void Read ()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
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

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idRotuloFisioterapeuta +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idMovimento +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + estagioMovimentoFisio +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[3]) + tempoInicial +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[4]) + tempoFinal);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
            }
        }

        /**
        * Função que deleta dados cadastrados anteriormente na relação de pontosrotulofisioterapeuta.
         */
        public void DeleteValue (int id)
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
        * Função que apaga a relação de pontosrotulofisioterapeuta inteira de uma vez.
         */
        public void Drop ()
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