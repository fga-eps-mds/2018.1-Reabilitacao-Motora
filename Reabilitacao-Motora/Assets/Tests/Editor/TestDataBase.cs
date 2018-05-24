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
			var create = "CREATE TABLE IF NOT EXISTS TESTE (idTable INTEGER primary key AUTOINCREMENT,nome VARCHAR (255) not null);";
			GlobalController.Initialize();
			database.Create (create);
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
		public void TestCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='TESTE';";

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
			}
			return;
		}

		[Test]
		public void TestDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				database.Drop(10);
				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='TESTE';";

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

				Assert.AreEqual (result, 0);

				conn.Dispose();
				conn.Close();
			}
			return;
		}
		
		[Test]
		public void TestInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

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
			}

			return;
		}

		[Test]
		public void TestUpdate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

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
			}

			return;
		}

		[Test]
		public void TestRead ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

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
			}

			return;
		}

		[Test]
		public void TestReadValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				System.Object[] columnsToInsert = new System.Object[] {"fake testname0"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);
				columnsToInsert = new System.Object[] {"fake testname1"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);
				columnsToInsert = new System.Object[] {"fake testname2"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);


				System.Object[] columnsToRead = new System.Object[] {0, ""};
				for (int i = 0; i < 3; ++i)
				{
					Teste allTests = database.ReadValue<Teste>(TablesManager.Tables[10].tableName,
					TablesManager.Tables[10].colName[0], i+1, columnsToRead);

					Assert.AreEqual (allTests.idTable, i+1);
					Assert.AreEqual (allTests.nome, string.Format("fake testname{0}", i));
				}

				
				conn.Dispose();
				conn.Close();
			}

			return;
		}

		
		[Test]
		public void TestDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				System.Object[] columnsToInsert = new System.Object[] {"fake testname"};
				database.Insert(columnsToInsert, TablesManager.Tables[10].tableName, 10);

				var check = "SELECT EXISTS(SELECT 1 FROM 'TESTE' WHERE \"idTable\" = \"1\" and \"nome\"=\"fake testname\" LIMIT 1)";
				
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
				database.DeleteValue(10, 1);

				result = 0;
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

				Assert.AreEqual (result, 0);

				conn.Dispose();
				conn.Close();
			}
			return;
		}


		[TearDown]
		public void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			database.Drop(10);
			database = null;
		}




// 		/**
// 		* Função que apaga a relação de pessoas inteira de uma vez.
// 		 */

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