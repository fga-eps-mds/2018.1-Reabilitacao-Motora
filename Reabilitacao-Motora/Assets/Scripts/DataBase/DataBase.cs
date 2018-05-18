using Mono.Data.Sqlite;
using System.Data;


namespace DataBaseAttributes
{
  /**
   * Classe que cria a base de dados em que as relações serão criadas.
   */
	public class DataBase
	{
		public string sqlQuery;
		public IDbConnection conn;
		public IDbCommand cmd;
	}
}
