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
        public string []stringArray;
        public int Length {
             get {
                 return stringArray.Length;
             }
         }
    }
    public MultiDimensionalString [] tableNames = new MultiDimensionalString[8];

    IDbConnection dbconn;
    IDbCommand dbcmd;

    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db"; //Path to database.
        insertTablePessoa ("joao parana", "M", "1986-10-22"); 
        readerPessoa ();
    }
    
    private void insertTableFisioterapeuta (int idPessoa, 
                                            string regiao, 
                                            int crefito) 
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into FISIOTERAPEUTA (";

            int tableSize = tableNames[0].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[0].stringArray[i] + aux);
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
                                            int crefito) 
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[0].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[0].stringArray[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[0].stringArray[2], regiao);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[0].stringArray[3], crefito);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[0].stringArray[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    private void insertTableMovimento (int idMovimentoPai,
                                       int idPessoa,
                                       string nomeMovimento,
                                       string graficoResultado,
                                       string movimentoExecutor,
                                       string rotuloMovimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into MOVIMENTO (";

            int tableSize = tableNames[1].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[1].stringArray[i] + aux);
            }

            sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", idMovimentoPai,
                                                                                                   idPessoa,
                                                                                                   nomeMovimento,
                                                                                                   graficoResultado,
                                                                                                   movimentoExecutor,
                                                                                                   rotuloMovimento);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    private void updateTableMovimento (int id,
                                       int idMovimentoPai,
                                       int idPessoa,
                                       string nomeMovimento,
                                       string graficoResultado,
                                       string movimentoExecutor,
                                       string rotuloMovimento)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[1].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[1].stringArray[1], idMovimentoPai);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[1].stringArray[2], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[1].stringArray[3], nomeMovimento);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[1].stringArray[4], graficoResultado);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[1].stringArray[5], movimentoExecutor);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[1].stringArray[6], rotuloMovimento);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[1].stringArray[0], id);

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

            int tableSize = tableNames[2].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[2].stringArray[i] + aux);
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

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[2].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[2].stringArray[1], nomeMusculo);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[2].stringArray[0], id);

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

            int tableSize = tableNames[3].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[3].stringArray[i] + aux);
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

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[3].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[3].stringArray[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[3].stringArray[2], observacoes);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[3].stringArray[0], id);

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

            int tableSize = tableNames[4].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[4].stringArray[i] + aux);
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

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[4].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[4].stringArray[1], nomePessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[4].stringArray[2], sexo);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[4].stringArray[3], dataNascimento);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[4].stringArray[0], id);

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

            int tableSize = tableNames[5].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[5].stringArray[i] + aux);
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

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[5].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[5].stringArray[1], idFisioterapeuta);
            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[5].stringArray[2], idPaciente);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[5].stringArray[3], dataSessao);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[5].stringArray[0], id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    private void insertTableTelefone (int idPessoa,
                                      int telefone)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into TELEFONE (";

            int tableSize = tableNames[6].Length;

            for (int i = 0; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[6].stringArray[i] + aux);
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
                                      int telefone)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[6].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[6].stringArray[1], idPessoa);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[6].stringArray[2], telefone);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[6].stringArray[0], id);

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

            int tableSize = tableNames[7].Length;

            for (int i = 0; i < tableSize; ++i) {
                string aux = (i+1 == tableSize) ? (")") : (",");
                sqlQuery += (tableNames[7].stringArray[i] + aux);
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

            sqlQuery = string.Format("UPDATE \"{0}\" set ", tableNames[7].tableName);

            sqlQuery += string.Format("\"{0}\"=\"{1}\",", tableNames[7].stringArray[1], idMusculo);
            sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tableNames[7].stringArray[2], idMovimento);

            sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tableNames[7].stringArray[0], id);

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
                                                                                    tableNames[tableid].stringArray[0], 
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
                int idFisioterapeuta = reader.GetInt32(0);
                int idPessoa = reader.GetInt32(1);
                string regiao = reader.GetString(2);
                int crefito = reader.GetInt32(3);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[0].stringArray[0]) + idFisioterapeuta +
                           string.Format(" \"{0}\" = ", tableNames[0].stringArray[1]) + idPessoa +
                           string.Format(" \"{0}\" = ", tableNames[0].stringArray[2]) + regiao +
                           string.Format(" \"{0}\" = ", tableNames[0].stringArray[3]) + crefito);
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
                int idMovimento = reader.GetInt32(0);
                int idMovimentoPai = reader.GetInt32(1);
                int idPessoa = reader.GetInt32(2);
                string nomeMovimento = reader.GetString(3);
                string graficoResultado = reader.GetString(4);
                string movimentoExecutor = reader.GetString(5);
                string rotuloMovimento = reader.GetString(6);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[1].stringArray[0]) + idMovimento +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[1]) + idMovimentoPai +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[2]) + idPessoa +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[3]) + nomeMovimento +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[4]) + graficoResultado +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[5]) + movimentoExecutor +
                           string.Format(" \"{0}\" = ", tableNames[1].stringArray[6]) + rotuloMovimento);
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
                int idMusculo = reader.GetInt32(0);
                string nomeMusculo = reader.GetString(1);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[2].stringArray[0]) + idMusculo +
                           string.Format(" \"{0}\" = ", tableNames[2].stringArray[1]) + nomeMusculo);
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
                int idPaciente = reader.GetInt32(0);
                int idPessoa = reader.GetInt32(1);
                string observacoes = reader.GetString(2);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[3].stringArray[0]) + idPaciente +
                           string.Format(" \"{0}\" = ", tableNames[3].stringArray[1]) + idPessoa +
                           string.Format(" \"{0}\" = ", tableNames[3].stringArray[2]) + observacoes);
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
                int idPessoa = reader.GetInt32(0);
                string nomePessoa = reader.GetString(1);
                string sexo = reader.GetString(2);
                string dataNascimento = reader.GetString(3);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[4].stringArray[0]) + idPessoa +
                           string.Format(" \"{0}\" = ", tableNames[4].stringArray[1]) + nomePessoa +
                           string.Format(" \"{0}\" = ", tableNames[4].stringArray[2]) + sexo +
                           string.Format(" \"{0}\" = ", tableNames[4].stringArray[3]) + dataNascimento);
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
                int idSessao = reader.GetInt32(0);
                int idFisioterapeuta = reader.GetInt32(1);
                int idPaciente = reader.GetInt32(2);
                string dataSessao = reader.GetString(3);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[5].stringArray[0]) + idSessao +
                           string.Format(" \"{0}\" = ", tableNames[5].stringArray[1]) + idFisioterapeuta +
                           string.Format(" \"{0}\" = ", tableNames[5].stringArray[2]) + idPaciente +
                           string.Format(" \"{0}\" = ", tableNames[5].stringArray[3]) + dataSessao);
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
                int idPessoa = reader.GetInt32(0);
                string telefone = reader.GetString(1);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[6].stringArray[0]) + idPessoa +
                           string.Format(" \"{0}\" = ", tableNames[6].stringArray[1]) + telefone);
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
                int idMusculo = reader.GetInt32(0);
                int idMovimento = reader.GetInt32(1);

                Debug.Log (string.Format("\"{0}\" = ", tableNames[7].stringArray[0]) + idMusculo +
                           string.Format(" \"{0}\" = ", tableNames[7].stringArray[1]) + idMovimento);
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