using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace DataBaseAttributes
{
  /**
   * Classe que cria a base de dados em que as relações serão criadas.
   */
	public class DataBase
	{
		private string SqlQuery;
		public string sqlQuery 
		{
			get
			{
				return SqlQuery;
			}
			set
			{
				SqlQuery = value;
			}
		}
		private IDbConnection Conn;
		public IDbConnection conn
		{
			get
			{
				return Conn;
			}
			set
			{
				Conn = value;
			}
		}
		private IDbCommand Cmd;
		public IDbCommand cmd
		{
			get
			{
				return Cmd;
			}
			set
			{
				Cmd = value;
			}
		}

		public List<T> Read<T> (string path, string tableName, Object[] columns)
		{
			using (conn = new SqliteConnection(path))
			{
				conn.Open();
				cmd = conn.CreateCommand();

				sqlQuery = "SELECT * " + string.Format("FROM \"{0}\";", tableName);
				cmd.CommandText = sqlQuery;

				IDataReader reader = cmd.ExecuteReader();
				List<T> classList = new List<T>();
				while (reader.Read())
				{

					var z = columns;
					ObjectArray (ref z, ref reader);
					columns = z;

					Type classType = typeof(T);
					ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { columns.GetType() });
					T classInstance = (T)classConstructor.Invoke(new object[] { columns });

					classList.Add(classInstance);
				}

				CloseDB(reader, cmd, conn);
				return classList;	 
			}
		}

		public T ReadValue<T> (string path, string tableName, string colName, int idTable, Object[] columns)
		{
			using (conn = new SqliteConnection(path))
			{
				conn.Open();
				cmd = conn.CreateCommand();
				sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", tableName,
																		    					  colName,
																								 idTable);
				cmd.CommandText = sqlQuery;
				IDataReader reader = cmd.ExecuteReader();
				reader.Read();

				var z = columns;
				ObjectArray (ref z, ref reader);
				columns = z;

				Type classType = typeof(T);
				ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { columns.GetType() });
				T classInstance = (T)classConstructor.Invoke(new object[] { columns });

				CloseDB(reader, cmd, conn);

				return classInstance;	 
			}
		}

		private static void CloseDB (IDataReader reader, IDbCommand cmd, IDbConnection conn)
		{
			reader.Close();
			cmd.Dispose();
			conn.Close();
		}

		private static void ObjectArray (ref Object[] columns, ref IDataReader reader)
		{
			for (int i = 0; i < columns.Length; ++i)
			{
				Type t = columns[i].GetType();
				if (!reader.IsDBNull(i))
				{
					if ( t.Equals(typeof(int)) ) 
					{
						columns[i] = reader.GetInt32(i);
					}
					else if ( t.Equals(typeof(string)) ) 
					{
						columns[i] = reader.GetString(i);
					}
					else if ( t.Equals(typeof(double)) ) 
					{
						columns[i] = reader.GetDouble(i);
					}
				}
			}
		}
	}
}
