using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;


namespace DataBase {
    public class bdConnection
    {
        public string sqlQuery;

        public IDbConnection conn;
        public IDbCommand cmd;
    }
}