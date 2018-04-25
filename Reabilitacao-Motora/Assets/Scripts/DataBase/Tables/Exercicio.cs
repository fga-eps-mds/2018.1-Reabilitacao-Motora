using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace exercicio
{
    /**
     * Cria relação para cadastro dos exercicios a serem cadastrados pelo programa.
     */
    public class Exercicio
    {
        int tableId = 7;
        DataBase banco = new DataBase();
        int idExercicio;
        int idPaciente;
        int idMovimento;
        int idSessao;
        string descricaoExercicio;
        string pontosExercicio;


        /**
         * Classe com todos os atributos de um exercicio.
         */
        public Exercicio(int ide, int idp, int idm, int ids, string de, string pe)
        {
            this.idExercicio = ide;
            this.idPaciente = idp;
            this.idMovimento = idm;
            this.idSessao = ids;
            this.descricaoExercicio = de;
            this.pontosExercicio = pe;
        }

        /**
         * Cria a relação para exercicios, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public void Create()
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS EXERCICIO (idExercicio INTEGER primary key AUTOINCREMENT,idPaciente INTEGER not null,idMovimento INTEGER not null,idSessao INTEGER not null,descricaoExercicio VARCHAR (150),pontosExercicio VARCHAR (150) not null,foreign key (idSessao) references SESSAO (idSessao),foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idPaciente) references PACIENTE (idPaciente));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados na tabela de exercicios.
         */
        public void Insert(int idPaciente,
            int idMovimento,
            int idSessao,
            string descricaoExercicio,
            string pontosExercicio)
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into EXERCICIO (";

                int tableSize = TablesManager.instance.Tables[tableId].Length;

                for (int i = 0; i < tableSize; ++i)
                {
                    string aux = (i + 1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (TablesManager.instance.Tables[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", idPaciente,
                    idMovimento,
                    idSessao,
                    descricaoExercicio,
                    pontosExercicio);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação de exercicios.
         */
        public void Update(int id,
            int idPaciente,
            int idMovimento,
            int idSessao,
            string descricaoExercicio,
            string pontosExercicio)
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", TablesManager.instance.Tables[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[1], idPaciente);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[2], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[3], idSessao);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", TablesManager.instance.Tables[tableId].colName[4], descricaoExercicio);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", TablesManager.instance.Tables[tableId].colName[5], pontosExercicio);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.instance.Tables[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação de exercicios.
         */
        public List<Exercicio> Read()
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM EXERCICIO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<Exercicio> e = new List<Exercicio>();

                while (reader.Read())
                {
                    int idExercicio = 0;
                    int idPaciente = 0;
                    int idMovimento = 0;
                    int idSessao = 0;
                    string descricaoExercicio = "null";
                    string pontosExercicio = "null";

                    if (!reader.IsDBNull(0)) idExercicio = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idPaciente = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) idMovimento = reader.GetInt32(2);
                    if (!reader.IsDBNull(3)) idSessao = reader.GetInt32(3);
                    if (!reader.IsDBNull(4)) descricaoExercicio = reader.GetString(4);
                    if (!reader.IsDBNull(5)) pontosExercicio = reader.GetString(5);

                    Exercicio x = new Exercicio(idExercicio, idPaciente, idMovimento, idSessao, descricaoExercicio, pontosExercicio);
                    e.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return e;
            }
        }

        public Exercicio ReadValue(int id)
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", TablesManager.instance.Tables[tableId].tableName,
                    TablesManager.instance.Tables[tableId].colName[0],
                    id);
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                int idExercicio = 0;
                int idPaciente = 0;
                int idMovimento = 0;
                int idSessao = 0;
                string descricaoExercicio = "null";
                string pontosExercicio = "null";

                if (!reader.IsDBNull(0)) idExercicio = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idPaciente = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) idMovimento = reader.GetInt32(2);
                if (!reader.IsDBNull(3)) idSessao = reader.GetInt32(3);
                if (!reader.IsDBNull(4)) descricaoExercicio = reader.GetString(4);
                if (!reader.IsDBNull(5)) pontosExercicio = reader.GetString(5);

                Exercicio x = new Exercicio(idExercicio, idPaciente, idMovimento, idSessao, descricaoExercicio, pontosExercicio);

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
         * Função que deleta dados cadastrados anteriormente na relação de exercicios.
         */
        public void DeleteValue(int id)
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.instance.Tables[tableId].tableName, TablesManager.instance.Tables[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que apaga a relação de exercicios inteira de uma vez.
         */
        public void Drop()
        {
            using (banco.conn = new SqliteConnection(GlobalController.instance.path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.instance.Tables[tableId].tableName);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }
    }
}
