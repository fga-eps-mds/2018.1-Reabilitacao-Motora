using UnityEngine;
using System.Collections;
using DataBase;
using MuDiSt;
using Mono.Data.Sqlite;
using System.Data;

namespace movimento 
{
    public class Movimento
    {
        int tableId = 5;
        bdConnection banco = new bdConnection ();
        MDS tt = new MDS ();
        string path;

        public Movimento (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,descricaoMovimento VARCHAR (150),pontosMovimento VARCHAR (150) not null,foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Insert (int idFisioterapeuta,
            string nomeMovimento,
            string descricaoFisioterapeuta,
            string pontosMovimento)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into MOVIMENTO (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
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

        public void Update (int id,
            int idFisioterapeuta,
            string nomeMovimento,
            string descricaoFisioterapeuta,
            string pontosMovimento)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idFisioterapeuta);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], nomeMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], descricaoFisioterapeuta);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], pontosMovimento);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Read ()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM MOVIMENTO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
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

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idMovimento +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idFisioterapeuta +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + nomeMovimento +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[3]) + descricaoFisioterapeuta +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[4]) + pontosMovimento);

                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
            }
        }                  

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