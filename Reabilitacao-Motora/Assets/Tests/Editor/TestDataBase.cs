using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using fisioterapeuta;
using pessoa;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;


/**
* Cria um novo Fisioterapeuta no banco de dados.
*/
namespace Tests
{
	public class TestDataBase
	{
		private DataBase database;

		[SetUp]
		public void SetUp()
		{
			database = new DataBase();
		}

		[Test]
		public void TestCreate ()
		{
			GlobalController.Initialize();
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var query = "CREATE TABLE IF NOT EXISTS TESTE (idTable INTEGER primary key AUTOINCREMENT,nome VARCHAR (255) not null);";
				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='TESTE';";

				database.Create (query);

				var result = 0;

				using (var cmd = new SqliteCommand(check, conn))
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

				Assert.AreEqual (result, 1);

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();

				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			return;
		}

		
		[Test]
		public void TestInsert ()
		{
			GlobalController.Initialize();
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var create = "CREATE TABLE IF NOT EXISTS TESTE (idTable INTEGER primary key AUTOINCREMENT,nome VARCHAR (255) not null);";
				database.Create (create);

				System.Object[] columns = new System.Object[] {"fake testname"};
				database.Insert(columns, TablesManager.Tables[10].tableName, 10);

				var check = "SELECT * FROM TESTE;";

				var result = "";

				using (var cmd = new SqliteCommand(check, conn))
				{
					using (IDataReader reader = cmd.ExecuteReader())
					{
						try
						{
							while (reader.Read())
							{
								if (!reader.IsDBNull(1)) 
								{
									result = reader.GetString(1);
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

				Assert.AreEqual (result, "fake testname");

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				
			}

			return;
		}

		[Test]
		public void TestUpdate ()
		{
			GlobalController.Initialize();
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var create = "CREATE TABLE IF NOT EXISTS TESTE (idTable INTEGER primary key AUTOINCREMENT,nome VARCHAR (255) not null);";
				database.Create (create);

				System.Object[] columnsToInsert = new System.Object[] {"fake testname"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);

				System.Object[] columnsToUpdate = new System.Object[] {1, "testname fake"};
				database.Update(columnsToUpdate, TablesManager.Tables[10].tableName, 10);

				var check = "SELECT * FROM TESTE;";

				var result = "";

				using (var cmd = new SqliteCommand(check, conn))
				{
					using (IDataReader reader = cmd.ExecuteReader())
					{
						try
						{
							while (reader.Read())
							{
								if (!reader.IsDBNull(1)) 
								{
									result = reader.GetString(1);
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

				Assert.AreNotEqual (result, "fake testname");
				Assert.AreEqual (result, "testname fake");

				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				
			}

			return;
		}

		public class Teste
		{
			private int IdTable;
			private string Nome;
			public int idTable {get{return IdTable;} set {IdTable = value;}}
			public string nome {get{return Nome;} set {Nome = value;}}
			public Teste (System.Object[] cols)
			{
				this.idTable = (int) cols[0];
				this.nome = (string) cols[1];
			}
		}

		[Test]
		public void TestRead ()
		{
			GlobalController.Initialize();
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var create = "CREATE TABLE IF NOT EXISTS TESTE (idTable INTEGER primary key AUTOINCREMENT,nome VARCHAR (255) not null);";
				database.Create (create);

				System.Object[] columnsToInsert = new System.Object[] {"fake testname0"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);
				columnsToInsert = new System.Object[] {"fake testname1"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);
				columnsToInsert = new System.Object[] {"fake testname2"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);


				System.Object[] columnsToRead = new System.Object[] {0, ""};
				List<Teste> allTests = database.Read<Teste>(TablesManager.Tables[10].tableName, columnsToRead);

				for (int i = 0; i < allTests.Count; ++i)
				{
					Assert.AreEqual (allTests[i].idTable, i+1);
					Assert.AreEqual (allTests[i].nome, string.Format("fake testname{0}", i));
				}


				conn.Dispose();
				conn.Close();
				SqliteConnection.ClearAllPools();

				GC.Collect();
				GC.WaitForPendingFinalizers();
				
			}

			return;
		}

		[TearDown]
		public void AfterEveryTest ()
		{
			database.Drop(10);
		}

// 		[Test]
// 		public T ReadValue<T> ()
// 		{
// 			database.ReadValue<T> (string path, string tableName, string colName, int idTable, System.Object[] columns);

// 			using (conn = new SqliteConnection(path))
// 			{
// 				conn.Open();
// 				cmd = conn.CreateCommand();
// 				sqlQuery = "SELECT * " + string.Format("FROM \"{0}\" WHERE \"{1}\" = \"{2}\";", tableName,
// 																		    					  colName,
// 																								 idTable);
// 				cmd.CommandText = sqlQuery;
// 				IDataReader reader = cmd.ExecuteReader();
// 				reader.Read();

// 				var aux = columns;
// 				ObjectArray (ref aux, ref reader);
// 				var columnsCopy = aux;

// 				Type classType = typeof(T);
// 				ConstructorInfo classConstructor = classType.GetConstructor(new [] { columnsCopy.GetType() });
// 				T classInstance = (T)classConstructor.Invoke(new object[] { columnsCopy });

// 				CloseDB(reader, cmd, conn);

// 				return classInstance;	 
// 			}
// 		}

// 		/**
// 		* Função que deleta dados cadastrados anteriormente na relação de pessoas.
// 		 */
// 		[Test]
// 		public void TestDeleteValue()
// 		{
// 			database.DeleteValue(int tableId, int id);

// 			using (conn = new SqliteConnection(GlobalController.path))
// 			{
// 				conn.Open();
// 				cmd = conn.CreateCommand();

// 				sqlQuery = string.Format("delete from \"{0}\" WHERE \"{1}\" = \"{2}\"", TablesManager.Tables[tableId].tableName, TablesManager.Tables[tableId].colName[0], id);

// 				cmd.CommandText = sqlQuery;
// 				cmd.ExecuteScalar();
// 				conn.Close();
// 			}
// 		}

// 		/**
// 		* Função que apaga a relação de pessoas inteira de uma vez.
// 		 */
// 		[Test]
// 		public void TestDrop()
// 		{
// 			database.Drop(int tableId);

// 			using (conn = new SqliteConnection(GlobalController.path))
// 			{
// 				conn.Open();
// 				cmd = conn.CreateCommand();

// 				sqlQuery = string.Format("DROP TABLE IF EXISTS \"{0}\"", TablesManager.Tables[tableId].tableName);

// 				cmd.CommandText = sqlQuery;
// 				cmd.ExecuteScalar();
// 				conn.Close();
// 			}
// 		}

// 	

// 		[Test]
// 		private static void ObjectArray ()
// 		{
// 			database.ObjectArray (ref System.Object[] columns, ref IDataReader reader);

// 			for (int i = 0; i < columns.Length; ++i)
// 			{
// 				Type t = columns[i].GetType();
// 				if (!reader.IsDBNull(i))
// 				{
// 					if ( t.Equals(typeof(int)) ) 
// 					{
// 						columns[i] = reader.GetInt32(i);
// 					}
// 					else if ( t.Equals(typeof(string)) ) 
// 					{
// 						columns[i] = reader.GetString(i);
// 					}
// 					else if ( t.Equals(typeof(float)) ) 
// 					{
// 						columns[i] = (float) reader.GetDouble(i);
// 					}
// 				}
// 			}
// 		}

	}
}