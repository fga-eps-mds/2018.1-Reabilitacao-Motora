using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace pontosrotulopaciente {

    /**
    * Cria relação para cadastro dos pontosrotulopaciente a serem cadastrados pelo programa.
     */
    public class PontosRotuloPaciente
    {
        int tableId = 10;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;
        public int idRotuloPaciente, idExercicio;
        public double tempoInicial, tempoFinal;
        public string estagioMovimentoPaciente;

        /**
         * Classe com todos os atributos de um pontosrotulopaciente.
         */
        public PontosRotuloPaciente(int idrp, int ide, double ti, double tf, string e)
        {
                this.idRotuloPaciente = idrp;
                this.idExercicio = ide;
                this.tempoInicial = ti;
                this.tempoFinal = tf;
                this.estagioMovimentoPaciente = e;
        }

        /**
        * Cria a relação para pontosrotulopaciente, contendo um id gerado automaticamente pelo banco como chave primária.
         */
        public void Create(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS PONTOSROTULOPACIENTE (idRotuloPaciente INTEGER primary key AUTOINCREMENT,idExercicio INTEGER not null,estagioMovimentoPaciente VARCHAR (30) not null,tempoInicial REAL not null,tempoFinal REAL not null,foreign key (idExercicio) references EXERCICIO (idExercicio));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que insere dados na tabela de pontosrotulopaciente.
         */
        public void Insert(int idMovimento,
            string estagioMovimentoPaciente,
            double tempoInicial,
            double tempoFinal)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into PONTOSROTULOPACIENTE (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 1; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", idMovimento,
                    estagioMovimentoPaciente,
                    tempoInicial,
                    tempoFinal);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que atualiza dados já cadastrados anteriormente na relação de pontosrotulopaciente.
         */
        public void Update(int id,
            int idMovimento,
            string estagioMovimentoPaciente,
            double tempoInicial,
            double tempoFinal)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[1], idMovimento);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[2], estagioMovimentoPaciente);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[3], tempoInicial);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[4], tempoFinal);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\"", tt.TABLES[tableId].colName[0], id);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
        * Função que lê dados já cadastrados anteriormente na relação de pontosrotulopaciente.
         */
        public List<PontosRotuloPaciente> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM PONTOSROTULOFISIOTERAPEUTA";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<PontosRotuloPaciente> prp = new List<PontosRotuloPaciente>();

                while (reader.Read())
                {
                    int idRotuloPaciente = 0;
                    int idExercicio = 0;
                    string estagioMovimentoPaciente = "null";
                    double tempoInicial = 0;
                    double tempoFinal = 0;

                    if (!reader.IsDBNull(0)) idRotuloPaciente = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idExercicio = reader.GetInt32(1);
                    if (!reader.IsDBNull(2)) estagioMovimentoPaciente = reader.GetString(2);
                    if (!reader.IsDBNull(3)) tempoInicial = reader.GetDouble(3);
                    if (!reader.IsDBNull(4)) tempoFinal = reader.GetDouble(4);

                    PontosRotuloPaciente x = new PontosRotuloPaciente(idRotuloPaciente,idExercicio,tempoInicial,tempoFinal,estagioMovimentoPaciente);
                    prp.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return prp;
            }
        }


        public PontosRotuloPaciente ReadValue (int id)
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

                int idRotuloPaciente = 0;
                int idExercicio = 0;
                string estagioMovimentoPaciente = "null";
                double tempoInicial = 0;
                double tempoFinal = 0;

                if (!reader.IsDBNull(0)) idRotuloPaciente = reader.GetInt32(0);
                if (!reader.IsDBNull(1)) idExercicio = reader.GetInt32(1);
                if (!reader.IsDBNull(2)) estagioMovimentoPaciente = reader.GetString(2);
                if (!reader.IsDBNull(3)) tempoInicial = reader.GetDouble(3);
                if (!reader.IsDBNull(4)) tempoFinal = reader.GetDouble(4);

                PontosRotuloPaciente x = new PontosRotuloPaciente (idRotuloPaciente,idExercicio,tempoInicial,tempoFinal,estagioMovimentoPaciente);

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
        * Função que deleta dados cadastrados anteriormente na relação de pontosrotulopaciente.
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
        * Função que apaga a relação de pontosrotulopaciente inteira de uma vez.
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
