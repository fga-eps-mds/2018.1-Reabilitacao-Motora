using UnityEngine;
using System.Collections;
using DataBase;
using MuDiSt;
using Mono.Data.Sqlite;
using System.Data;

namespace pontosmovimentopaciente
{
    public class PontosMovimentoPaciente
    {
        int tableId = 11;
        bdConnection banco = new bdConnection ();
        MDS tt = new MDS ();
        string path;

        public PontosMovimentoPaciente (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSMOVIMENTOPACIENTE (idMovimentoPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,tempo REAL not null,anguloDeJunta REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Insert (int idMovimento,double tempo, double anguloDeJunta) {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PONTOSMOVIMENTOPACIENTE (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idMovimento,
                    tempo,
                    anguloDeJunta);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Update (int id,
            int idMovimento,
            double tempo,
            double anguloDeJunta)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], tempo);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[3], anguloDeJunta);

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
                banco.sqlQuery = "SELECT * " + "FROM PONTOSMOVIMENTOPACIENTE";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idMovimentoPaciente = 0;
                    int idExercicio = 0;
                    double tempo = 0;
                    double anguloDeJunta = 0;

                    if (!reader.IsDBNull(0)) idMovimentoPaciente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idExercicio = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) tempo = reader.GetDouble(2);
                    if (!reader.IsDBNull(3)) anguloDeJunta = reader.GetDouble(3);

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idMovimentoPaciente +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idExercicio +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + tempo +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[3]) + anguloDeJunta);
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