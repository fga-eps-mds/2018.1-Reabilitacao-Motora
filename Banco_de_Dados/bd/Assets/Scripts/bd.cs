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
        insertTablePessoa ("moura", "M","1997-10-10"); 
        readers();
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[0].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\",\"{2}\")", idPessoa, regiao, crefito);

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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[1].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", idMovimentoPai,
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

    private void insertTableMusculo (string nomeMusculo)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "insert into MUSCULO (";

            int tableSize = tableNames[2].Length;

            for (int i = 1; i < tableSize; ++i) {
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[2].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\")", nomeMusculo);
            
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[3].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\")", idPessoa,
                                                           observacoes);
            
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[4].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\",\"{2}\")", nomePessoa,
                                                                   sexo,
                                                                   dataNascimento);
            
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[5].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\",\"{2}\")", idFisioterapeuta,
                                                                   idPaciente,
                                                                   dataSessao);
            
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[6].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\")", idPessoa,
                                                           telefone);
            
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
                string aux = i+1 == tableSize ? ") values " : ", ";
                sqlQuery += (tableNames[7].stringArray[i] + aux);
            }

            sqlQuery += string.Format("(\"{0}\",\"{1}\")", idMusculo,
                                                           idMovimento);
            
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }

    /*
    private void deleteValue(int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("Delete from Usersinfo WHERE ID=\"{0}\"", id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


    private void updateValue(string name, string email, string address, int id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Usersinfo set Name=\"{0}\", Email=\"{1}\", Address=\"{2}\" WHERE ID=\"{3}\" ", name, email, address, id);
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
    */

    private void readers()
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

                Debug.Log ("value = " + idPessoa + "  name = " + nomePessoa + "  Sexo = " + sexo + " date of birth = " + dataNascimento);
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