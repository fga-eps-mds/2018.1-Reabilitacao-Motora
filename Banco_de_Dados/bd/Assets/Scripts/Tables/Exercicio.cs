using UnityEngine;
using System.Collections;
using DataBase;
using MuDiSt;
using Mono.Data.Sqlite;
using System.Data;

namespace exercicio 
{
    public class Exercicio
    {
        int tableId = 7;
        bdConnection banco = new bdConnection ();
        MDS tt = new MDS ();
        string path;

        public Exercicio (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS EXERCICIO (idExercicio INTEGER primary key AUTOINCREMENT,idPaciente INTEGER not null,idMovimento INTEGER not null,idSessao INTEGER not null,descricaoExercicio VARCHAR (150),foreign key (idSessao) references SESSAO (idSessao),foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idPaciente) references PACIENTE (idPaciente));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Insert (int idPaciente,
           int idMovimento,
           int idSessao,
           string descricaoExercicio)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into EXERCICIO (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idPaciente,
                 idMovimento,
                 idSessao,
                 descricaoExercicio);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        public void Update (int id,
           int idPaciente,
           int idMovimento,
           int idSessao,
           string descricaoExercicio)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idPaciente);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], idSessao);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], descricaoExercicio);

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
                banco.sqlQuery = "SELECT * " + "FROM EXERCICIO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idExercicio = 0;
                    int idPaciente = 0;
                    int idMovimento = 0;
                    int idSessao = 0;
                    string descricaoExercicio = "null";

                    if (!reader.IsDBNull(0)) idExercicio = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idPaciente = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) idMovimento = reader.GetInt32(2);
                    if (!reader.IsDBNull(3)) idSessao = reader.GetInt32(3);
                    if (!reader.IsDBNull(4)) descricaoExercicio = reader.GetString(4);

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idExercicio +
                     string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idPaciente +
                     string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + idMovimento +
                     string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[3]) + idSessao +
                     string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[4]) + descricaoExercicio);
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