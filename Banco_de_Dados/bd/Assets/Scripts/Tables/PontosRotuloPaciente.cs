using UnityEngine;
using System.Collections;
using DataBase;
using MuDiSt;
using Mono.Data.Sqlite;
using System.Data;

namespace pontosrotulopaciente {    
    public class PontosRotuloPaciente
    {
        int tableId = 10;
        bdConnection banco = new bdConnection ();
        MDS tt = new MDS ();
        string path;

        public PontosRotuloPaciente (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Insert (int idMovimento,
            string estagioMovimentoPaciente,
            double tempoInicial,
            double tempoFinal)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PONTOSROTULOPACIENTE (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                    estagioMovimentoPaciente,
                    tempoInicial,
                    tempoFinal);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Update (int id,
            int idMovimento,
            string estagioMovimentoPaciente,
            double tempoInicial,
            double tempoFinal)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], estagioMovimentoPaciente);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], tempoInicial);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], tempoFinal);

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
                banco.sqlQuery = "SELECT * " + "FROM PONTOSROTULOPACIENTE";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idRotuloPaciente = 0;
                    int idMovimento = 0;
                    string estagioMovimentoPaciente = "null";
                    double tempoInicial = 0;
                    double tempoFinal = 0;

                    if (!reader.IsDBNull(0)) idRotuloPaciente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) estagioMovimentoPaciente = reader.GetString(2);
                    if (!reader.IsDBNull(3)) tempoInicial = reader.GetDouble(3);
                    if (!reader.IsDBNull(4)) tempoFinal = reader.GetDouble(4);

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idRotuloPaciente +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idMovimento +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + estagioMovimentoPaciente +
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