using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;


namespace DataBaseAttributes 
{
    public class DataBase
    {
        public string sqlQuery;
        public IDbConnection conn;
        public IDbCommand cmd;
    }
}