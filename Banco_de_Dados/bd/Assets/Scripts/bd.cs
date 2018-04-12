using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class bd : MonoBehaviour
{
    private string conn, sqlQuery;

    [System.Serializable]
    public class MultiDimensionalString 
    {
        public string tableName;
        public string[] colName;
        public int Length {
             get {
                 return colName.Length;
             }
         }
    }
    public MultiDimensionalString [] TABLES = new MultiDimensionalString[9];

    IDbConnection dbconn;
    IDbCommand dbcmd;

    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db"; //Path to database.
        insertTablePessoa ("foi, num foi? fala qfoi", "M", "1956-11-22"); 
        readerPessoa ();
        readerFisioterapeuta ();
        readerMovimento();
        readerMusculo();
        readerPaciente();
        readerSessao();
        readerTelefone();
        readerMovimentoMusculo();
        readerExercicio ();
    }
    
    private void insertTableFisioterapeuta (int idPessoa, 
                                            string regiao, 
                                            string crefito) 
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into FISIOTERAPEUTA (";

            int tableSize = TABLES[2].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[2].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idPessoa, 
                                                                           regiao, 
                                                                           crefito);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableFisioterapeuta (int id,
                                            int idPessoa, 
                                            string regiao, 
                                            string crefito) 
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[2].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[2].colName[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[2].colName[2], regiao);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[2].colName[3], crefito);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[2].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTableMovimento (int idFisioterapeuta,
                                       string nomeMovimento,
                                       string descricaoFisioterapeuta,
                                       string graficoResultadoFisioterapeuta,
                                       string movimentoFisioterapeuta,
                                       string rotuloMovimentoFisioterapeuta)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into MOVIMENTO (";

            int tableSize = TABLES[5].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[5].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", idFisioterapeuta,
                                                                                                   nomeMovimento,
                                                                                                   descricaoFisioterapeuta,
                                                                                                   graficoResultadoFisioterapeuta,
                                                                                                   movimentoFisioterapeuta,
                                                                                                   rotuloMovimentoFisioterapeuta);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableMovimento (int id,
                                       int idFisioterapeuta,
                                       string nomeMovimento,
                                       string descricaoFisioterapeuta,
                                       string graficoResultadoFisioterapeuta,
                                       string movimentoFisioterapeuta,
                                       string rotuloMovimentoFisioterapeuta)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[5].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[5].colName[1], idFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[5].colName[2], nomeMovimento);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[5].colName[3], descricaoFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[5].colName[4], graficoResultadoFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[5].colName[5], movimentoFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[5].colName[6], rotuloMovimentoFisioterapeuta);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[5].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTableMusculo (string nomeMusculo)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into MUSCULO (";

            int tableSize = TABLES[4].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[4].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\")", nomeMusculo);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableMusculo (int id, 
                                     string nomeMusculo)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[4].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[4].colName[1], nomeMusculo);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[4].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTablePaciente (int idPessoa,
                                      string observacoes)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into PACIENTE (";

            int tableSize = TABLES[3].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[3].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                                                                   observacoes);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTablePaciente (int id,
                                      int idPessoa,
                                      string observacoes)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[3].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[3].colName[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[3].colName[2], observacoes);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[3].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }



    private void insertTablePessoa (string nomePessoa,
                                    string sexo,
                                    string dataNascimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into PESSOA (";

            int tableSize = TABLES[0].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[0].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", nomePessoa,
                                                                           sexo,
                                                                           dataNascimento);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateValuePessoa (int id,
                                    string nomePessoa,
                                    string sexo,
                                    string dataNascimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[0].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[0].colName[1], nomePessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[0].colName[2], sexo);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[0].colName[3], dataNascimento);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[0].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTableSessao (int idFisioterapeuta,
                                    int idPaciente,
                                    string dataSessao)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into SESSAO (";

            int tableSize = TABLES[6].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[6].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idFisioterapeuta,
                                                                           idPaciente,
                                                                           dataSessao);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableSessao (int id,
                                    int idFisioterapeuta,
                                    int idPaciente,
                                    string dataSessao)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[6].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[6].colName[1], idFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[6].colName[2], idPaciente);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[6].colName[3], dataSessao);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[6].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTableTelefone (int idPessoa,
                                      string telefone)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into TELEFONE (";

            int tableSize = TABLES[1].Length;

            for (int i = 0; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[1].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                                                                   telefone);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableTelefone (int id,
                                      int idPessoa,
                                      string telefone)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[1].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[1].colName[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[1].colName[2], telefone);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[1].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void insertTableMovimentoMusculo (int idMusculo,
                                              int idMovimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into MOVIMENTOMUSCULO (";

            int tableSize = TABLES[8].Length;

            for (int i = 0; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[8].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idMusculo,
                                                                   idMovimento);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateTableMovimentoMusculo (int id,
                                              int idMusculo,
                                              int idMovimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[8].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[8].colName[1], idMusculo);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[8].colName[2], idMovimento);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[8].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    private void insertTableExercicio (int idPaciente,
                                       int idMovimento,
                                       int idSessao,
                                       string descricaoExercicio,
                                       string graficoResultadoPaciente,
                                       string movimentoPaciente,
                                       string rotuloMovimentoPaciente)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into EXERCICIO (";

            int tableSize = TABLES[7].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (TABLES[7].colName[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\")", idPaciente,
                                                                                                           idMovimento,
                                                                                                           idSessao,
                                                                                                           descricaoExercicio,
                                                                                                           graficoResultadoPaciente,
                                                                                                           movimentoPaciente,
                                                                                                           rotuloMovimentoPaciente);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    

    private void updateTableExercicio (int id,
                                       int idPaciente,
                                       int idMovimento,
                                       int idSessao,
                                       string descricaoExercicio,
                                       string graficoResultadoPaciente,
                                       string movimentoPaciente,
                                       string rotuloMovimentoPaciente)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[7].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[1], idPaciente);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[2], idMovimento);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[3], idSessao);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[4], descricaoExercicio);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[5], graficoResultadoPaciente);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[7].colName[6], movimentoPaciente);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[7].colName[7], rotuloMovimentoPaciente);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[7].colName[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    
    private void deleteValue(string name, int tableid, int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", name, 
                                                                                    TABLES[tableid].colName[0], 
                                                                                    id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void readerFisioterapeuta()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM FISIOTERAPEUTA";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idFisioterapeuta = 0;
                int idPessoa = 0;
                string regiao = "null";
                string crefito = "null";

                if (!reader.IsDBNull(0)) idFisioterapeuta = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) regiao = reader.GetString(2);
                if (!reader.IsDBNull(3)) crefito = reader.GetString(3);


                Debug.Log (string.Format("\"{0}\" = ", TABLES[2].colName[0]) + idFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[2].colName[1]) + idPessoa +
                           string.Format(" \"{0}\" = ", TABLES[2].colName[2]) + regiao +
                           string.Format(" \"{0}\" = ", TABLES[2].colName[3]) + crefito);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerMovimento()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM MOVIMENTO";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idMovimento = 0;
                int idFisioterapeuta = 0;
                string nomeMovimento = "null";
                string descricaoFisioterapeuta = "null";
                string graficoResultadoFisioterapeuta = "null";
                string movimentoFisioterapeuta = "null";
                string rotuloMovimentoFisioterapeuta = "null";

                if (!reader.IsDBNull(0)) idMovimento = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) nomeMovimento = reader.GetString(2);
                if (!reader.IsDBNull(3)) descricaoFisioterapeuta = reader.GetString(3);
                if (!reader.IsDBNull(4)) graficoResultadoFisioterapeuta = reader.GetString(4);
                if (!reader.IsDBNull(5)) movimentoFisioterapeuta = reader.GetString(5);
                if (!reader.IsDBNull(6)) rotuloMovimentoFisioterapeuta = reader.GetString(6);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[5].colName[0]) + idMovimento +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[1]) + idFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[2]) + nomeMovimento +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[3]) + descricaoFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[4]) + graficoResultadoFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[5]) + movimentoFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[5].colName[6]) + rotuloMovimentoFisioterapeuta);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }

    private void readerExercicio()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM EXERCICIO";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idExercicio = 0;
                int idPaciente = 0;
                int idMovimento = 0;
                int idSessao = 0;
                string descricaoExercicio = "null";
                string graficoResultadoPaciente = "null";
                string movimentoPaciente = "null";
                string rotuloMovimentoPaciente = "null";

                if (!reader.IsDBNull(0)) idExercicio = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPaciente = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) idMovimento = reader.GetInt32(2);
                if (!reader.IsDBNull(3)) idSessao = reader.GetInt32(3);
                if (!reader.IsDBNull(4)) descricaoExercicio = reader.GetString(4);
                if (!reader.IsDBNull(5)) graficoResultadoPaciente = reader.GetString(5);
                if (!reader.IsDBNull(6)) movimentoPaciente = reader.GetString(6);
                if (!reader.IsDBNull(7)) rotuloMovimentoPaciente = reader.GetString(7);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[7].colName[0]) + idExercicio +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[1]) + idPaciente +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[2]) + idMovimento +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[3]) + idSessao +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[4]) + descricaoExercicio +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[5]) + graficoResultadoPaciente +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[6]) + movimentoPaciente +
                           string.Format(" \"{0}\" = ", TABLES[7].colName[7]) + rotuloMovimentoPaciente);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerMusculo()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM MUSCULO";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idMusculo = 0;
                string nomeMusculo = "null";

                if (!reader.IsDBNull(0)) idMusculo = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) nomeMusculo = reader.GetString(1);
                

                Debug.Log (string.Format("\"{0}\" = ", TABLES[4].colName[0]) + idMusculo +
                           string.Format(" \"{0}\" = ", TABLES[4].colName[1]) + nomeMusculo);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerPaciente()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM PACIENTE";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idPaciente = 0;
                int idPessoa = 0;
                string observacoes = "null";

                if (!reader.IsDBNull(0)) idPaciente = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) observacoes = reader.GetString(2);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[3].colName[0]) + idPaciente +
                           string.Format(" \"{0}\" = ", TABLES[3].colName[1]) + idPessoa +
                           string.Format(" \"{0}\" = ", TABLES[3].colName[2]) + observacoes);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerPessoa()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM PESSOA";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idPessoa = 0;
                string nomePessoa = "null";
                string sexo = "null";
                string dataNascimento = "null";

                if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) nomePessoa = reader.GetString(1);
                if (!reader.IsDBNull(2)) sexo = reader.GetString(2);
                if (!reader.IsDBNull(3)) dataNascimento = reader.GetString(3);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[0].colName[0]) + idPessoa +
                           string.Format(" \"{0}\" = ", TABLES[0].colName[1]) + nomePessoa +
                           string.Format(" \"{0}\" = ", TABLES[0].colName[2]) + sexo +
                           string.Format(" \"{0}\" = ", TABLES[0].colName[3]) + dataNascimento);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerSessao()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM SESSAO";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idSessao = 0;
                int idFisioterapeuta = 0;
                int idPaciente = 0;
                string dataSessao = "";

                if (!reader.IsDBNull(0)) idSessao = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) idPaciente = reader.GetInt32(2);
                if (!reader.IsDBNull(3)) dataSessao = reader.GetString(3);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[6].colName[0]) + idSessao +
                           string.Format(" \"{0}\" = ", TABLES[6].colName[1]) + idFisioterapeuta +
                           string.Format(" \"{0}\" = ", TABLES[6].colName[2]) + idPaciente +
                           string.Format(" \"{0}\" = ", TABLES[6].colName[3]) + dataSessao);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerTelefone()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM TELEFONE";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idPessoa = 0;
                string telefone = "null";

                if (!reader.IsDBNull(0)) idPessoa = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) telefone = reader.GetString(1);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[1].colName[0]) + idPessoa +
                           string.Format(" \"{0}\" = ", TABLES[1].colName[1]) + telefone);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }


    private void readerMovimentoMusculo()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "SELECT * " + "FROM MOVIMENTOMUSCULO";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                int idMusculo = 0;
                int idMovimento = 0;

                if (!reader.IsDBNull(0)) idMusculo = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);

                Debug.Log (string.Format("\"{0}\" = ", TABLES[8].colName[0]) + idMusculo +
                           string.Format(" \"{0}\" = ", TABLES[8].colName[1]) + idMovimento);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
    }
}