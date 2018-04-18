using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataBaseTables;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

namespace movimentomusculo
{
  /**
   * Cria relação para cadastro de movimentos dos musculos a serem cadastrados pelo programa.
   */
    public class MovimentoMusculo
    {
        int tableId = 8;
        DataBase banco = new DataBase();
        TableNameColumn tt = new TableNameColumn();
        string path;

        /**
         * Classe com todos os atributos de um movimentomusculo.
         */
        public class MovimentoMusculos
        {
            public int idMusculo, idMovimento;
            public MovimentoMusculos (int idmu, int idmo)
            {
                this.idMusculo = idmu;
                this.idMovimento = idmo;
            }
        }

        /**
         * Cria a relação para cadastro dos movimento do musculo, contendo um id que vem da relação de outra tabela (musculo) como chave primária e estrangeira, assim como idMovimento, que vem da relação movimento.
         */
        public MovimentoMusculo(string caminho)
        {
            path = caminho;
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = "CREATE TABLE IF NOT EXISTS MOVIMENTOMUSCULO (idMusculo INTEGER not null,idMovimento INTEGER not null, foreign key (idMovimento) references MOVIMENTO (idMovimento),foreign key (idMusculo) references MUSCULO (idMusculo),primary key (idMusculo, idMovimento));";

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que insere dados necessários para cadastro de movimentos dos musculos na relação MovimentoMusculo.
         */
        public void Insert(int idMusculo,
            int idMovimento)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "insert into MOVIMENTOMUSCULO (";

                int tableSize = tt.TABLES[tableId].Length;

                for (int i = 0; i < tableSize; ++i) {
                    string aux = (i+1 == tableSize) ? (")") : (",");
                    banco.sqlQuery += (tt.TABLES[tableId].colName[i] + aux);
                }

                banco.sqlQuery += string.Format(" values (\"{0}\",\"{1}\")", idMusculo,
                    idMovimento);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que atualiza dados já cadastrados anteriormente na relação MovimentoMusculo.
         */
        public void Update(int idMusculo, int idMovimento)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("UPDATE \"{0}\" set ", tt.TABLES[tableId].tableName);

                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\",", tt.TABLES[tableId].colName[0], idMusculo);
                banco.sqlQuery += string.Format("\"{0}\"=\"{1}\" ", tt.TABLES[tableId].colName[1], idMovimento);

                banco.sqlQuery += string.Format("WHERE \"{0}\" = \"{1}\", \"{2}\" = \"{3}\"", tt.TABLES[tableId].colName[0], idMusculo, tt.TABLES[tableId].colName[1], idMusculo);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que lê dados já cadastrados anteriormente na relação MovimentoMusculo.
         */
        public List<MovimentoMusculos> Read()
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();
                banco.sqlQuery = "SELECT * " + "FROM MOVIMENTOMUSCULO";
                banco.cmd.CommandText = banco.sqlQuery;
                IDataReader reader = banco.cmd.ExecuteReader();

                List<MovimentoMusculos> mm = new List<MovimentoMusculos>();

                while (reader.Read())
                {
                    int idMusculo = 0;
                    int idMovimento = 0;

                    if (!reader.IsDBNull(0)) idMusculo = reader.GetInt32(0);
                    if (!reader.IsDBNull(1)) idMovimento = reader.GetInt32(1);

                    MovimentoMusculos x = new MovimentoMusculos(idMusculo,idMovimento);
                    mm.Add(x);
                }
                reader.Close();
                reader = null;
                banco.cmd.Dispose();
                banco.cmd = null;
                banco.conn.Close();
                banco.conn = null;
                return mm;
            }
        }

        /**
         * Função que deleta dados cadastrados anteriormente na relação MovimentoMusculo.
         */
        public void DeleteValue(int id1, int id2)
        {
            using (banco.conn = new SqliteConnection(path))
            {
                banco.conn.Open();
                banco.cmd = banco.conn.CreateCommand();

                banco.sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\" AND \"{3}\" = \"{4}\"", tt.TABLES[tableId].tableName, tt.TABLES[tableId].colName[0], id1, tt.TABLES[tableId].colName[1], id2);

                banco.cmd.CommandText = banco.sqlQuery;
                banco.cmd.ExecuteScalar();
                banco.conn.Close();
            }
        }

        /**
         * Função que apaga a relação MovimentoMusculo inteira de uma vez.
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
