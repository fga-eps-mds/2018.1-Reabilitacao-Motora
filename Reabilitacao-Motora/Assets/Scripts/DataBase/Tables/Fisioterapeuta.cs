using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;
using pessoa;

namespace fisioterapeuta
{
  /**
   * Cria relação para cadastro dos fisioterapeutas a serem cadastrados pelo programa.
   */
    public class Fisioterapeuta
    {
        int tableId = 2;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;

        /**
         * Classe com todos os atributos de um fisioterapeuta.
         */
        public class Fisioterapeutas
        {
            public int idFisioterapeuta, idPessoa;
            public string login, senha, regiao, crefito;
            public Pessoa.Pessoas persona;
            public Pessoa temp;
            public Fisioterapeutas (int idp, int idf, string l, string s, string r, string c)
            {
                this.idPessoa = idp;
                this.idFisioterapeuta = idf;
                this.login = l;
                this.senha = s;
                this.regiao = r;
                this.crefito = c;
                this.persona = temp.ReadValue(idp);
            }
        }

        /**
         * Cria a relação para fisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public Fisioterapeuta(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (idFisioterapeuta INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,login VARCHAR (255) not null,senha VARCHAR (255) not null,regiao VARCHAR (2),crefito VARCHAR (10),foreign key (idPessoa) references PESSOA (idPessoa),constraint crefito_regiao UNIQUE (crefito, regiao));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro dos fisioterapeutas na relação fisioterapeuta.
         */
        public void Insert(int idPessoa, string login, string senha)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into FISIOTERAPEUTA (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idPessoa,
                    login,
                    senha);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro dos pacientes do fisioterapeuta na relação fisioterapeuta.
         */
        public void Insert(int idPessoa,
            string login,
            string senha,
            string regiao,
            string crefito)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into FISIOTERAPEUTA (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\", \"{4}\")", idPessoa,
                    login,
                    senha,
                    regiao,
                    crefito);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public void Update(int id,
            int idPessoa,
            string senha)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idPessoa);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[3], senha);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }


        /**
         * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public void Update(int id,
            int idPessoa,
            string senha,
            string regiao,
            string crefito)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idPessoa);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[4], regiao);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[5], crefito);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[3], senha);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public List<Fisioterapeutas> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM FISIOTERAPEUTA";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();
                List<Fisioterapeutas> f = new List<Fisioterapeutas>();

                while (reader.Read())
                {
                    int idFisioterapeuta = 0;
                    int idPessoa = 0;
                    string login = "null";
                    string senha = "null";
                    string regiao = "null";
                    string crefito = "null";

                    if (!reader.IsDBNull(0)) idFisioterapeuta = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) login = reader.GetString(2);
                    if (!reader.IsDBNull(3)) senha = reader.GetString(3);
                    if (!reader.IsDBNull(4)) regiao = reader.GetString(4);
                    if (!reader.IsDBNull(5)) crefito = reader.GetString(5);

                    Fisioterapeutas x = new Fisioterapeutas (idFisioterapeuta, idPessoa, login, senha, regiao, crefito);
                    f.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return f;
            }
        }

        public Fisioterapeutas ReadValue (int id)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", tt.TABLES[tableId].tableName, 
                    tt.TABLES[tableId].colName[0], 
                    id);
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                int idFisioterapeuta = 0;
                int idPessoa = 0;
                string login = "null";
                string senha = "null";
                string regiao = "null";
                string crefito = "null";

                if (!reader.IsDBNull(0)) idFisioterapeuta = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPessoa = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) login = reader.GetString(2);
                if (!reader.IsDBNull(3)) senha = reader.GetString(3);
                if (!reader.IsDBNull(4)) regiao = reader.GetString(4);
                if (!reader.IsDBNull(5)) crefito = reader.GetString(5);

                Fisioterapeutas x = new Fisioterapeutas (idFisioterapeuta,idPessoa,login,senha,regiao,crefito);

                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return x;
            }
        }

        /**
         * Função que deleta dados cadastrados anteriormente na relação fisioterapeuta.
         */
        public void DeleteValue(int id)
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
         * Função que apaga a relação fisioterapeuta inteira de uma vez.
         */
        public void Drop()
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
