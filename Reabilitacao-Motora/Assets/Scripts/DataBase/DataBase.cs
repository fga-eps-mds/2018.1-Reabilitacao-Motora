using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace DataBaseAttributes
{
  /**
   * Classe que cria a base de dados em que as relações serão criadas.
   */
	public static class DataBase
	{
		public static void Create (string query)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var sqlQuery = query;
				
				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		public static void Insert (System.Object[] columns, string tableName, int tableId)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				StringBuilder bld = new StringBuilder();

				bld.Append(string.Format("insert into {0} (", tableName));

				int tableSize = TablesManager.Tables[tableId].colName.Count;
				for (int i = 1; i < tableSize; ++i) 
				{
					if (columns[i-1] != null)
					{
						string aux;											
						if (i + 1 == tableSize)
						{
							aux = "";
						}
						else
						{
							aux = ",";
						}

						bld.Append(TablesManager.Tables[tableId].colName[i] + aux);
					}
				}

				if (bld[bld.Length - 1] == ',')
				{
					bld.Remove(bld.Length - 1, 1);
				}

				bld.Append(") values (");
				for (int i = 0; i < columns.Length; ++i) 
				{
					if (columns[i] != null)
					{
						string aux;
						if (i + 1 == columns.Length)
						{
							aux = "";
						}
						else
						{
							aux = ",";
						}

						bld.Append((string.Format("@param{0}", i) + aux));
					}
				}

				if (bld[bld.Length - 1] == ',')
				{
					bld.Remove(bld.Length - 1, 1);
				}


				bld.Append(")");

				var sqlQuery = bld.ToString();

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					for (int i = 0; i < columns.Length; ++i) 
					{
						if (columns[i] != null)
						{
							cmd.Parameters.AddWithValue(string.Format("@param{0}", i), columns[i]);
						}
					}

					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		public static void Update (System.Object[] columns, string tableName, int tableId)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				StringBuilder bld = new StringBuilder();

				bld.Append(string.Format("UPDATE \"{0}\" set ", tableName));

				for (int i = 1; i < TablesManager.Tables[tableId].colName.Count; ++i)
				{
					string aux;

					if (i + 1 == columns.Length)
					{
						aux = " ";
					}
					else
					{
						aux = ",";
					}

					bld.Append(string.Format("\"{0}\"=@param{1}{2}", TablesManager.Tables[tableId].colName[i], i, aux));
				}


				bld.Append(string.Format("WHERE \"{0}\" = \"{1}\"", TablesManager.Tables[tableId].colName[0], columns[0]));

				var sqlQuery = bld.ToString();

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					for (int i = 1; i < TablesManager.Tables[tableId].colName.Count; ++i)
					{
						cmd.Parameters.AddWithValue(string.Format("@param{0}", i), columns[i]);
					}
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}


		public static List<T> Read<T> (string tableName, System.Object[] columns)
		{
			// uma copia do array já que não é possivel passá-lo sem ser por referencia
			System.Object[] backup = new System.Object [] {};
			foreach (var col in columns)
			{
				Array.Resize(ref backup, backup.Length + 1);
				backup[backup.Length - 1] = col;
			}

			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				var sqlQuery = "SELECT * " + string.Format("FROM \"{0}\";", tableName);

				List<T> classList = new List<T>();

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (SqliteDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							// recuperando cópia aos valores originais
							for (int i = 0; i < columns.Length; ++i)
							{
								columns[i] = backup[i];
							}
							
							var columnsCopy = ObjectArray (columns, reader);

							Type classType = typeof(T);
							ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
							T classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

							classList.Add(classInstance);
						}
						
						reader.Dispose();
						reader.Close();
						cmd.Dispose();
						conn.Dispose();
						conn.Close();
						SqliteConnection.ClearAllPools();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						return classList;	 
					}
				}
			}
		}

		public static List<T> MultiSpecificSelect<T> (string tableName, System.Object[] columns, string query)
		{
			// uma copia do array já que não é possivel passá-lo sem ser por referencia
			System.Object[] backup = new System.Object [] {};
			foreach (var col in columns)
			{
				Array.Resize(ref backup, backup.Length + 1);
				backup[backup.Length - 1] = col;
			}

			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				var sqlQuery = query;

				List<T> classList = new List<T>();

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (SqliteDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							// recuperando cópia aos valores originais
							for (int i = 0; i < columns.Length; ++i)
							{
								columns[i] = backup[i];
							}
							
							var columnsCopy = ObjectArray (columns, reader);

							Type classType = typeof(T);
							ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
							T classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

							classList.Add(classInstance);
						}
						
						reader.Dispose();
						reader.Close();
						cmd.Dispose();
						conn.Dispose();
						conn.Close();
						SqliteConnection.ClearAllPools();
						GC.Collect();
						GC.WaitForPendingFinalizers();

						return classList;	 
					}
				}
			}
		}

		public static T SingleSpecificSelect<T> (string tableName, System.Object[] columns, string query)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var sqlQuery = query;

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (SqliteDataReader reader = cmd.ExecuteReader())
					{
						T classInstance;

						reader.Read();
						
						var columnsCopy = ObjectArray (columns, reader);

						Type classType = typeof(T);
						ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
						classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

						reader.Dispose();
						reader.Close();

						cmd.Dispose();

						conn.Dispose();
						conn.Close();
						SqliteConnection.ClearAllPools();

						GC.Collect();
						GC.WaitForPendingFinalizers();

						return classInstance;
					}
				} 
			}
		}

		public static T ReadValue<T> (string tableName, string colName, int idTable, System.Object[] columns)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", tableName,
																		    					  colName,
																								 idTable);
				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (SqliteDataReader reader = cmd.ExecuteReader())
					{
						T classInstance;

						reader.Read();
						
						var columnsCopy = ObjectArray (columns, reader);

						Type classType = typeof(T);
						ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
						classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

						reader.Dispose();
						reader.Close();

						cmd.Dispose();

						conn.Dispose();
						conn.Close();
						SqliteConnection.ClearAllPools();

						GC.Collect();
						GC.WaitForPendingFinalizers();

						return classInstance;
					}
				} 
			}
		}

		public static T GetLast<T> (string tableName, string colName, System.Object[] columns)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var sqlQuery = "SELECT * FROM " + string.Format("\"{0}\" WHERE \"{1}\"= (SELECT MAX(\"{2}\") FROM \"{3}\")", tableName,
																															 colName,
																															 colName,
																															 tableName);
				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (SqliteDataReader reader = cmd.ExecuteReader())
					{
						T classInstance;

						reader.Read();
						
						var columnsCopy = ObjectArray (columns, reader);

						Type classType = typeof(T);
						ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
						classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

						reader.Dispose();
						reader.Close();

						cmd.Dispose();

						conn.Dispose();
						conn.Close();
						SqliteConnection.ClearAllPools();

						GC.Collect();
						GC.WaitForPendingFinalizers();

						return classInstance;
					}
				} 
			}
		}

		public static int CountRead (string sqlQuery)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				var result = 0;

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					using (IDataReader reader = cmd.ExecuteReader())
					{
						try
						{
							while (reader.Read())
							{
								if (!reader.IsDBNull(0)) 
								{
									result = reader.GetInt32(0);
								}
							}
						}
						finally
						{
							reader.Dispose();
							reader.Close();
						}
					}
					cmd.Dispose();
				}

				return result;
			}
		}

		/**
		* Função que deleta dados cadastrados anteriormente na relação de pessoas.
		 */
		public static void DeleteValue(int tableId, int id)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				var sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.Tables[tableId].tableName, TablesManager.Tables[tableId].colName[0], id);
				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		/**
		* Função que apaga a relação de pessoas inteira de uma vez.
		 */
		public static void Drop(int tableId)
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				var sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.Tables[tableId].tableName);

				using (var cmd = new SqliteCommand(sqlQuery, conn))
				{
					cmd.ExecuteNonQuery();
					cmd.Dispose();
				}

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
		}

		private static System.Object[] ObjectArray (System.Object[] columns, SqliteDataReader reader)
		{
			for (int i = 0; i < columns.Length; ++i)
			{
				if (!reader.IsDBNull(i))
				{
					if (columns[i] != null)
					{
						Type t = columns[i].GetType();
						if ( t.Equals(typeof(int)) ) 
						{
							columns[i] = reader.GetInt32(i);
						}
						else if ( t.Equals(typeof(string)) ) 
						{
							columns[i] = reader.GetString(i);
						}
                        else if (t.Equals(typeof(float)))
                        {
                            columns[i] = reader.GetFloat(i);
                        }
                    }
				}
				else
				{
					columns[i] = null;
				}
			}
			return columns;
		}
	}
}
