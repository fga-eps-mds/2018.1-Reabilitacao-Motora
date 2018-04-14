using UnityEngine;
using System.Collections;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace sessao 
{
  /**
  * Cria relação para cadastro dos sessão a serem cadastrados pelo programa.
   */
    public class Sessao
    {
        int tableId = 6;
        DataBase banco = new DataBase ();
        TableNameColumn tt = new TableNameColumn ();
        string path;

        /**
        * Cria a relação para sessão, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public Sessao (string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS SESSAO (idSessao INTEGER primary key AUTOINCREMENT,idFisioterapeuta INTEGER not null,idPaciente INTEGER not null,dataSessao DATE not null,observacaoSessao VARCHAR (300),foreign key (idPaciente) references PACIENTE (idPaciente),foreign key (idFisioterapeuta) references FISIOTERAPEUTA (idFisioterapeuta));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que insere dados na tabela de sessão.
         */
        public void Insert (int idFisioterapeuta,
            int idPaciente,
            string dataSessao,
            string observacaoSessao)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into SESSAO (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idFisioterapeuta,
                    idPaciente,
                    dataSessao,
                    observacaoSessao);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que atualiza dados já cadastrados anteriormente na relação de sessão.
         */
        public void Update (int id,
            int idFisioterapeuta,
            int idPaciente,
            string dataSessao,
            string observacaoSessao)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idFisioterapeuta);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], idPaciente);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], dataSessao);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], observacaoSessao);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que lê dados já cadastrados anteriormente na relação de sessão.
         */
        public void Read ()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM SESSAO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
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

                    Debug.Log (string.Format("\"{0}\" = ", tt.TABLES[tableId].colName[0]) + idSessao +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[1]) + idFisioterapeuta +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[2]) + idPaciente +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[3]) + dataSessao +
                        string.Format(" \"{0}\" = ", tt.TABLES[tableId].colName[4]) + observacaoSessao);
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
        * Função que deleta dados cadastrados anteriormente na relação de sessão.
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
        * Função que apaga a relação de sessão inteira de uma vez.
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