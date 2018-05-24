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
	public class TestPessoa
	{
		private DataBase database;
		private int tableId;

		[SetUp]
		public void SetUp()
		{
			database = new DataBase();
			tableId = 0;

			GlobalController.test = true;			
			GlobalController.Initialize();
		}

		[Test]
		public void TestPessoaCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();
				
				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PESSOA';";

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
		public void TestPessoaDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PESSOA';";

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
		public void TestPessoaInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", "615236622");

				var check = "SELECT * FROM PESSOA;";

				var id = 0;
				var result = "";
				int i = 1;

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
									id = reader.GetInt32(0);
									Assert.AreEqual (id, i);
								}

								if (!reader.IsDBNull(1)) 
								{
									result = reader.GetString(1);
									Assert.AreEqual (result, string.Format("fake name{0}", i));
								}

								if (!reader.IsDBNull(2)) 
								{
									result = reader.GetString(2);
									Assert.AreEqual (result, "m");
								}

								if (!reader.IsDBNull(3)) 
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, string.Format("1995-01-0{0}", i));
								}

								if (!reader.IsDBNull(4)) 
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, string.Format("619873271{0}", i));
								}

								if (!reader.IsDBNull(5)) 
								{
									result = reader.GetString(5);
									// null não entrará, logo só a segunda "pessoa" entra
									Assert.AreEqual (result, "615236622");
								}

								i++;
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
				conn.Dispose();
				conn.Close();
			}
			return;
		}

		[Test]
		public void TestPessoaUpdate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Update(1, "name1 fake", "f", "1996-09-07", "6132329094", "6187651234");
				
				var check = "SELECT * FROM PESSOA;";

				var id = 0;
				var result = "";

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
									id = reader.GetInt32(0);
									Assert.AreEqual (id, 1);
								}

								if (!reader.IsDBNull(1)) 
								{
									result = reader.GetString(1);
									Assert.AreEqual (result, "name1 fake");
								}

								if (!reader.IsDBNull(2)) 
								{
									result = reader.GetString(2);
									Assert.AreEqual (result, "f");
								}

								if (!reader.IsDBNull(3)) 
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, "1996-09-07");
								}

								if (!reader.IsDBNull(4)) 
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, "6132329094");
								}

								if (!reader.IsDBNull(5)) 
								{
									result = reader.GetString(5);
									Assert.AreEqual (result, "6187651234");
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
				conn.Dispose();
				conn.Close();
			}
			return;
		}
		

		// [Test]
		// public void TestPessoaRead ()
		// {
		// 	using (var conn = new SqliteConnection(GlobalController.path))
		// 	{
		// 		conn.Open();

		// 		System.Object[] columnsToInsert = new System.Object[] {"fake testname0"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);
		// 		columnsToInsert = new System.Object[] {"fake testname1"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);
		// 		columnsToInsert = new System.Object[] {"fake testname2"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);


		// 		System.Object[] columnsToRead = new System.Object[] {0, ""};
		// 		List<PESSOA> allTests = database.Read<PESSOA>(TablesManager.Tables[tableId].tableName, columnsToRead);

		// 		for (int i = 0; i < allTests.Count; ++i)
		// 		{
		// 			Assert.AreEqual (allTests[i].idTable, i+1);
		// 			Assert.AreEqual (allTests[i].nome, string.Format("fake testname{0}", i));
		// 		}


		// 		conn.Dispose();
		// 		conn.Close();
		// 	}

		// 	return;
		// }

		// [Test]
		// public void TestPessoaReadValue ()
		// {
		// 	using (var conn = new SqliteConnection(GlobalController.path))
		// 	{
		// 		conn.Open();

		// 		System.Object[] columnsToInsert = new System.Object[] {"fake testname0"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);
		// 		columnsToInsert = new System.Object[] {"fake testname1"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);
		// 		columnsToInsert = new System.Object[] {"fake testname2"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);


		// 		System.Object[] columnsToRead = new System.Object[] {0, ""};
		// 		for (int i = 0; i < 3; ++i)
		// 		{
		// 			PESSOA allTests = database.ReadValue<PESSOA>(TablesManager.Tables[tableId].tableName,
		// 			TablesManager.Tables[tableId].colName[0], i+1, columnsToRead);

		// 			Assert.AreEqual (allTests.idTable, i+1);
		// 			Assert.AreEqual (allTests.nome, string.Format("fake testname{0}", i));
		// 		}

				
		// 		conn.Dispose();
		// 		conn.Close();
		// 	}

		// 	return;
		// }

		
		// [Test]
		// public void TestPessoaDeleteValue ()
		// {
		// 	using (var conn = new SqliteConnection(GlobalController.path))
		// 	{
		// 		conn.Open();
		// 		System.Object[] columnsToInsert = new System.Object[] {"fake testname"};
		// 		database.Insert(columnsToInsert, TablesManager.Tables[tableId].tableName, tableId);

		// 		var check = "SELECT EXISTS(SELECT 1 FROM 'PESSOA' WHERE \"idTable\" = \"1\" and \"nome\"=\"fake testname\" LIMIT 1)";
				
		// 		var result = 0;
		// 		using (var cmd = new SqliteCommand(check, conn))
		// 		{
		// 			using (IDataReader reader = cmd.ExecuteReader())
		// 			{
		// 				try
		// 				{
		// 					while (reader.Read())
		// 					{
		// 						if (!reader.IsDBNull(0)) 
		// 						{
		// 							result = reader.GetInt32(0);
		// 						}
		// 					}
		// 				}
		// 				finally
		// 				{
		// 					reader.Dispose();
		// 					reader.Close();
		// 				}
		// 			}
		// 			cmd.Dispose();
		// 		}

		// 		Assert.AreEqual (result, 1);
		// 		database.DeleteValue(tableId, 1);

		// 		result = 0;
		// 		using (var cmd = new SqliteCommand(check, conn))
		// 		{
		// 			using (IDataReader reader = cmd.ExecuteReader())
		// 			{
		// 				try
		// 				{
		// 					while (reader.Read())
		// 					{
		// 						if (!reader.IsDBNull(0)) 
		// 						{
		// 							result = reader.GetInt32(0);
		// 						}
		// 					}
		// 				}
		// 				finally
		// 				{
		// 					reader.Dispose();
		// 					reader.Close();
		// 				}
		// 			}
		// 			cmd.Dispose();
		// 		}

		// 		Assert.AreEqual (result, 0);

		// 		conn.Dispose();
		// 		conn.Close();
		// 	}
		// 	return;
		// }


		[TearDown]
		public void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			database.Drop(tableId);
			database = null;
		}
	}
}