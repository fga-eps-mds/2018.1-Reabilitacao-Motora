using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
        private static int tableId = 2;
        public int idFisioterapeuta, idPessoa;
        public string login, senha, regiao, crefito;
        public Pessoa persona;

        /**
         * Classe com todos os atributos de um fisioterapeuta.
         */
        public Fisioterapeuta(int idf, int idp, string l, string s, string r, string c)
        {
            this.idFisioterapeuta = idf;
            this.idPessoa = idp;
            this.login = l;
            this.senha = s;
            this.regiao = r;
            this.crefito = c;
            this.persona = Pessoa.ReadValue(idp);
            
        }

        /**
         * Cria a relação para fisioterapeuta, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public static void Create()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = "CREATE TABLE IF NOT EXISTS FISIOTERAPEUTA (idFisioterapeuta INTEGER primary key AUTOINCREMENT,idPessoa INTEGER not null,login VARCHAR (255) not null,senha VARCHAR (255) not null,regiao VARCHAR (2),crefito VARCHAR (10),foreign key (idPessoa) references PESSOA (idPessoa),constraint crefito_regiao UNIQUE (crefito, regiao), constraint login_senha UNIQUE (login, senha));";

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro dos fisioterapeutas na relação fisioterapeuta.
         */
        public static void Insert(int idPessoa, string login, string senha)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "insert into FISIOTERAPEUTA (";

                int tableSize =  TablesManager.instance.Tables[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    GlobalController.instance.sqlQuery += ( TablesManager.instance.Tables[tableId].colName[i] + aux);
                }

                GlobalController.instance.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\")", idPessoa,
                    login,
                    senha);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro dos pacientes do fisioterapeuta na relação fisioterapeuta.
         */
        public static void Insert(int idPessoa,
            string login,
            string senha,
            string regiao,
            string crefito)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "insert into FISIOTERAPEUTA (";

                int tableSize =  TablesManager.instance.Tables[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    GlobalController.instance.sqlQuery += ( TablesManager.instance.Tables[tableId].colName[i] + aux);
                }

                GlobalController.instance.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\", \"{4}\")", idPessoa,
                    login,
                    senha,
                    regiao,
                    crefito);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public static void Update(int id,
            int idPessoa,
            string senha)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("UPDATE \"{0}\" set ",  TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",",  TablesManager.instance.Tables[tableId].colName[1], idPessoa);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",  TablesManager.instance.Tables[tableId].colName[3], senha);

                GlobalController.instance.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"",  TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }


        /**
         * Função que atualiza dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public static void Update(int id,
            int idPessoa,
            string senha,
            string regiao,
            string crefito)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("UPDATE \"{0}\" set ",  TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",",  TablesManager.instance.Tables[tableId].colName[1], idPessoa);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\",",  TablesManager.instance.Tables[tableId].colName[4], regiao);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",  TablesManager.instance.Tables[tableId].colName[5], crefito);
                GlobalController.instance.sqlQuery += string.Format("\"{0}\"=\"{1}\" ",  TablesManager.instance.Tables[tableId].colName[3], senha);

                GlobalController.instance.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"",  TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação fisioterapeuta.
         */
        public static List<Fisioterapeuta> Read()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "SELECT * " + "FROM FISIOTERAPEUTA";
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                IDataReader reader = GlobalController.instance.cmd.ExecuteReader();
                List<Fisioterapeuta> f = new List<Fisioterapeuta>();

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

                    Fisioterapeuta x = new Fisioterapeuta (idFisioterapeuta, idPessoa, login, senha, regiao, crefito);
                    f.Add(x);
                }
                reader.Close();
                reader = null;
                GlobalController.instance.cmd.Dispose();
                GlobalController.instance.cmd = null;
                GlobalController.instance.conn.Close();
                GlobalController.instance.conn = null;
                return f;
            }
        }

        public static Fisioterapeuta ReadValue (int id)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();
                GlobalController.instance.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";",  TablesManager.instance.Tables[tableId].tableName, 
                     TablesManager.instance.Tables[tableId].colName[0], 
                    id);
                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                IDataReader reader = GlobalController.instance.cmd.ExecuteReader();

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

                Fisioterapeuta x = new Fisioterapeuta (idFisioterapeuta,idPessoa,login,senha,regiao,crefito);

                reader.Close();
                reader = null;
                GlobalController.instance.cmd.Dispose();
                GlobalController.instance.cmd = null;
                GlobalController.instance.conn.Close();
                GlobalController.instance.conn = null;
                return x;
            }
        }

        /**
         * Função que deleta dados cadastrados anteriormente na relação fisioterapeuta.
         */
        public static void DeleteValue(int id)
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"",  TablesManager.instance.Tables[tableId].tableName,  TablesManager.instance.Tables[tableId].colName[0], id);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }

        /**
         * Função que apaga a relação fisioterapeuta inteira de uma vez.
         */
        public static void Drop()
        {
            using (GlobalController.instance.conn = new SqliteConnection(GlobalController.instance.path))
            {
                GlobalController.instance.conn.Open();
                GlobalController.instance.cmd = GlobalController.instance.conn.CreateCommand();

                GlobalController.instance.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"",  TablesManager.instance.Tables[tableId].tableName);

                GlobalController.instance.cmd.CommandText = GlobalController.instance.sqlQuery;
                GlobalController.instance.cmd.ExecuteScalar();
                GlobalController.instance.conn.Close();
            }
        }
    }
}
