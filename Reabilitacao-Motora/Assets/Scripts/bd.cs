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
    public MultiDimensionalString [] TABLES = new MultiDimensionalString[13];

    IDbConnection dbconn;
    IDbCommand dbcmd;

    public class Pessoa
    {
        int tableId = 0;

        public Pessoa ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PESSOA (idPessoa INTEGER primary key AUTOINCREMENT,nomePessoa VARCHAR (30) not null,sexo CHAR (1) not null,dataNascimento DATE not null);";
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (string nomePessoa,
                             string sexo,
                             string dataNascimento)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into PESSOA (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", nomePessoa,
                                                                               sexo,
                                                                               dataNascimento);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                                        string nomePessoa,
                                        string sexo,
                                        string dataNascimento)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], nomePessoa);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], sexo);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[3], dataNascimento);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idPessoa +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + nomePessoa +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + sexo +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + dataNascimento);
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

    public class Telefone
    {
        int tableId = 1;

        public Telefone ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS TELEFONE (idPessoa INTEGER not null,telefone VARCHAR (18) not null,foreign key (idPessoa) references PESSOA (idPessoa),primary key (idPessoa, telefone));";
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idPessoa,
                             string telefone)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into TELEFONE (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 0; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                                                                       telefone);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idPessoa,
                             string telefone)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idPessoa);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[2], telefone);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idPessoa +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + telefone);
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


    public class Fisioterapeuta
    {
        int tableId = 2;

        public Fisioterapeuta ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (idFisioterapeuta INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,regiao VARCHAR (2),crefito VARCHAR (10),foreign key (idPessoa) references PESSOA (idPessoa),constraint crefito_regiao UNIQUE (crefito, regiao));";
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idPessoa, 
                             string regiao, 
                             string crefito) 
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into FISIOTERAPEUTA (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idPessoa, 
                                                                               regiao, 
                                                                               crefito);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idPessoa, 
                             string regiao, 
                             string crefito) 
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idPessoa);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], regiao);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[3], crefito);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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


                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idFisioterapeuta +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idPessoa +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + regiao +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + crefito);
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

    public class Paciente
    {
        int tableId = 3;

        public Paciente ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PACIENTE (idPaciente INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,observacoes VARCHAR (300),foreign key (idPessoa) references PESSOA (idPessoa));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idPessoa,
                             string observacoes)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into PACIENTE (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idPessoa,
                                                                       observacoes);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idPessoa,
                             string observacoes)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idPessoa);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[2], observacoes);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idPaciente +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idPessoa +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + observacoes);
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


    public class Musculo
    {
        int tableId = 4;

        public Musculo ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS MUSCULO (idMusculo INTEGER primary key AUTOINCREMENT,nomeMusculo VARCHAR (20) not null);";
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (string nomeMusculo)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into MUSCULO (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\")", nomeMusculo);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id, 
                             string nomeMusculo)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[1], nomeMusculo);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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
                    

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idMusculo +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + nomeMusculo);
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

    public class Movimento
    {
        int tableId = 5;

        public Movimento ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTO (idMovimento INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,nomeMovimento VARCHAR (50) not null,descricaoMovimento VARCHAR (150),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idFisioterapeuta,
                             string nomeMovimento,
                             string descricaoFisioterapeuta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into MOVIMENTO (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idFisioterapeuta,
                                                                               nomeMovimento,
                                                                               descricaoFisioterapeuta);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idFisioterapeuta,
                             string nomeMovimento,
                             string descricaoFisioterapeuta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idFisioterapeuta);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], nomeMovimento);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], descricaoFisioterapeuta);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    if (!reader.IsDBNull(0)) idMovimento = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) nomeMovimento = reader.GetString(2);
                    if (!reader.IsDBNull(3)) descricaoFisioterapeuta = reader.GetString(3);

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idFisioterapeuta +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + nomeMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + descricaoFisioterapeuta);
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


    public class Sessao
    {
        int tableId = 6;

        public Sessao ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS SESSAO (idSessao INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,idPaciente INTEGER not null,dataSessao DATE not null,observacaoSessao VARCHAR (300),foreign key (idPaciente) references PACIENTE (idPaciente),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idFisioterapeuta,
                             int idPaciente,
                             string dataSessao,
                             string observacaoSessao)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into SESSAO (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idFisioterapeuta,
                                                                                       idPaciente,
                                                                                       dataSessao,
                                                                                       observacaoSessao);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idFisioterapeuta,
                             int idPaciente,
                             string dataSessao,
                             string observacaoSessao)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idFisioterapeuta);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], idPaciente);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], dataSessao);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[4], observacaoSessao);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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
                    string observacaoSessao = "";

                    if (!reader.IsDBNull(0)) idSessao = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idFisioterapeuta = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) idPaciente = reader.GetInt32(2);
                    if (!reader.IsDBNull(3)) dataSessao = reader.GetString(3);
                    if (!reader.IsDBNull(4)) observacaoSessao = reader.GetString(4);

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idSessao +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idFisioterapeuta +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + idPaciente +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + dataSessao +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[4]) + observacaoSessao);
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

    public class Exercicio
    {
        int tableId = 7;

        public Exercicio ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS EXERCICIO (idExercicio INTEGER primary key AUTOINCREMENT,idPaciente INTEGER not null,idMovimento INTEGER not null,idSessao INTEGER not null,descricaoExercicio VARCHAR (150),foreign key (idSessao) references SESSAO (idSessao),foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idPaciente) references PACIENTE (idPaciente));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idPaciente,
                             int idMovimento,
                             int idSessao,
                             string descricaoExercicio)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into EXERCICIO (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idPaciente,
                                                                                       idMovimento,
                                                                                       idSessao,
                                                                                       descricaoExercicio);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idPaciente,
                             int idMovimento,
                             int idSessao,
                             string descricaoExercicio)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idPaciente);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], idMovimento);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], idSessao);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[4], descricaoExercicio);
                
                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    if (!reader.IsDBNull(0)) idExercicio = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idPaciente = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) idMovimento = reader.GetInt32(2);
                    if (!reader.IsDBNull(3)) idSessao = reader.GetInt32(3);
                    if (!reader.IsDBNull(4)) descricaoExercicio = reader.GetString(4);

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idExercicio +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idPaciente +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + idMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + idSessao +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[4]) + descricaoExercicio);
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


    public class MovimentoMusculo
    {
        int tableId = 8;

        public MovimentoMusculo ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (idMusculo INTEGER not null,idMovimento INTEGER not null, foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idMusculo) references MUSCULO (idMusculo),primary key (idMusculo, idMovimento));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idMusculo,
                             int idMovimento)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into MOVIMENTOMUSCULO (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 0; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idMusculo,
                                                                       idMovimento);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idMusculo,
                             int idMovimento)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idMusculo);
                sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TABLES[tableId].colName[2], idMovimento);

                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idMusculo +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idMovimento);
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


    public class PontosMovimentoFisioterapeuta
    {
        int tableId = 9;

        public PontosMovimentoFisioterapeuta ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSMOVIMENTOFISIOTERAPEUTA (idMovimentoFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,tempo REAL not null,anguloDeJunta REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idMovimento,
                             double tempo,
                             double anguloDeJunta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into PONTOSMOVIMENTOFISIOTERAPEUTA (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idMovimento,
                                                                               tempo,
                                                                               anguloDeJunta);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }
        
        private void Update (int id,
                             int idMovimento,
                             double tempo,
                             double anguloDeJunta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idMovimento);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], tempo);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], anguloDeJunta);
                
                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "SELECT * " + "FROM PONTOSMOVIMENTOFISIOTERAPEUTA";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    int idMovimentoFisioterapeuta = 0;
                    int idMovimento = 0;
                    double tempo = 0;
                    double anguloDeJunta = 0;

                    if (!reader.IsDBNull(0)) idMovimentoFisioterapeuta = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) tempo = reader.GetDouble(2);
                    if (!reader.IsDBNull(3)) anguloDeJunta = reader.GetDouble(3);

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idMovimentoFisioterapeuta +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + tempo +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + anguloDeJunta);
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


    public class PontosRotuloFisioterapeuta
    {
        int tableId = 10;

        public PontosRotuloFisioterapeuta ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOFISIOTERAPEUTA (idRotuloFisioterapeuta INTEGER primary key AUTOINCREMENT,idMovimento INTEGER not null,estagioMovimentoFisio VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idMovimento) references MOVIMENTO (idMovimento));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idMovimento,
                             string estagioMovimentoFisio,
                             double tempo,
                             double anguloDeJunta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into PONTOSROTULOFISIOTERAPEUTA (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                                                                                       estagioMovimentoFisio,
                                                                                       tempo,
                                                                                       anguloDeJunta);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void updateTablePontosRotuloFisioterapeuta (int id,
                                                            int idMovimento,
                                                            string estagioMovimentoFisio,
                                                            double tempo,
                                                            double anguloDeJunta)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idMovimento);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], estagioMovimentoFisio);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], tempo);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[4], anguloDeJunta);
                
                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void readerPontosRotuloFisioterapeuta()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idRotuloFisioterapeuta +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + estagioMovimentoFisio +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + tempoInicial +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[4]) + tempoFinal);
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


    public class PontosMovimentoPaciente
    {
        int tableId = 11;

        public PontosMovimentoPaciente ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSMOVIMENTOPACIENTE (idMovimentoPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,tempo REAL not null,anguloDeJunta REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

       private void Insert (int idMovimento,
                            double tempo,
                            double anguloDeJunta)
       {
           using (dbconn = new SqliteConnection(conn))
           {
               dbconn.Open();
               dbcmd = dbconn.CreateCommand();
               sqlQuery = "insert into PONTOSMOVIMENTOPACIENTE (";

               int tableSize = TABLES[tableId].Length;

               for (int i = 1; i < tableSize; ++i) {
                   string aux = (i+1 == tableSize) ? (")") : (",");
                   sqlQuery += (TABLES[tableId].colName[i] + aux);
               }

               sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idMovimento,
                                                                              tempo,
                                                                              anguloDeJunta);
               
               dbcmd.CommandText = sqlQuery;
               dbcmd.ExecuteScalar();
               dbconn.Close();
           }
       }
       
       private void Update (int id,
                            int idMovimento,
                            double tempo,
                            double anguloDeJunta)
       {
           using (dbconn = new SqliteConnection(conn))
           {
               dbconn.Open();
               dbcmd = dbconn.CreateCommand();

               sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

               sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idMovimento);
               sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], tempo);
               sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], anguloDeJunta);
               
               sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

               dbcmd.CommandText = sqlQuery;
               dbcmd.ExecuteScalar();
               dbconn.Close();
           }
       }

       private void Read ()
       {
           using (dbconn = new SqliteConnection(conn))
           {
               dbconn.Open();
               dbcmd = dbconn.CreateCommand();
               sqlQuery = "SELECT * " + "FROM PONTOSMOVIMENTOPACIENTE";
               dbcmd.CommandText = sqlQuery;
               IDataReader reader = dbcmd.ExecuteReader();
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

                   Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idMovimentoPaciente +
                              string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idExercicio +
                              string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + tempo +
                              string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + anguloDeJunta);
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


    public class PontosRotuloPaciente
    {
        int tableId = 12;

        public PontosRotuloPaciente ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Insert (int idMovimento,
                             string estagioMovimentoPaciente,
                             double tempoInicial,
                             double tempoFinal)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "insert into PONTOSROTULOPACIENTE (";

                int tableSize = TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    sqlQuery += (TABLES[tableId].colName[i] + aux);
                }

                sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                                                                                       estagioMovimentoPaciente,
                                                                                       tempoInicial,
                                                                                       tempoFinal);
                
                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Update (int id,
                             int idMovimento,
                             string estagioMovimentoPaciente,
                             double tempoInicial,
                             double tempoFinal)
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();

                sqlQuery = string.Format("UPDATE \"{0}\" set ", TABLES[tableId].tableName);

                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[1], idMovimento);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[2], estagioMovimentoPaciente);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[3], tempoInicial);
                sqlQuery += string.Format("\"{0}\"=\"{1}\",", TABLES[tableId].colName[4], tempoFinal);
                
                sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TABLES[tableId].colName[0], id);

                dbcmd.CommandText = sqlQuery;
                dbcmd.ExecuteScalar();
                dbconn.Close();
            }
        }

        private void Read ()
        {
            using (dbconn = new SqliteConnection(conn))
            {
                dbconn.Open();
                dbcmd = dbconn.CreateCommand();
                sqlQuery = "SELECT * " + "FROM PONTOSROTULOPACIENTE";
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
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

                    Debug.Log (string.Format("\"{0}\" = ", TABLES[tableId].colName[0]) + idRotuloPaciente +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[1]) + idMovimento +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[2]) + estagioMovimentoPaciente +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[3]) + tempoInicial +
                               string.Format(" \"{0}\" = ", TABLES[tableId].colName[4]) + tempoFinal);
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


    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db"; //Path to database.

        Pessoa tablePessoa = new Pessoa ();
        Telefone tableTel = new Telefone ();
        Fisioterapeuta tableFisio = new Fisioterapeuta ();
        Paciente tablePaciente = new Paciente ();
        Musculo tableMusculo = new Musculo ();
        Movimento tableMovimento = new Movimento ();
        Sessao tableSessao = new Sessao ();
        Exercicio tableExercicio = new Exercicio ();
        MovimentoMusculo tableMovimentoMusculo = new MovimentoMusculo ();
        PontosMovimentoFisioterapeuta  tablePMF = new PontosMovimentoFisioterapeuta ();
        PontosRotuloFisioterapeuta tablePRF = new PontosRotuloFisioterapeuta ();
        PontosMovimentoPaciente tablePMP = new PontosMovimentoPaciente ();
        PontosRotuloPaciente tablePRP = new PontosRotuloPaciente ();

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

}