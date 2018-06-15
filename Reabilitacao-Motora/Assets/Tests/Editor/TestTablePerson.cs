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
* Testes da Tabela Pessoa no banco de dados.
*/
namespace Tests
{
	public static class TestTablePerson
	{
		[SetUp]
		public static void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public static void TestPessoaCreate ()
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
		}

		[Test]
		public static void TestPessoaDrop ()
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
		}

		[Test]
		public static void TestPessoaInsert ()
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
		}

		[Test]
		public static void TestPessoaUpdate ()
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
		}

		[Test]
		public static void TestPessoaRead ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", "615236621");
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", "615236622");
				Pessoa.Insert("fake name3", "m", "1995-01-03", "6198732713", "615236623");

				List<Pessoa> allPpls = Pessoa.Read();

				for (int i = 0; i < allPpls.Count; ++i)
				{
					Assert.AreEqual (allPpls[i].idPessoa, i+1);
					Assert.AreEqual (allPpls[i].nomePessoa, string.Format("fake name{0}", i+1));
					Assert.AreEqual (allPpls[i].sexo, "m");
					Assert.AreEqual (allPpls[i].dataNascimento, string.Format("1995-01-0{0}", i+1));
					Assert.AreEqual (allPpls[i].telefone1, string.Format("619873271{0}", i+1));
					Assert.AreEqual (allPpls[i].telefone2, string.Format("61523662{0}", i+1));
				}

				conn.Dispose();
				conn.Close();
			}

		}

		[Test]
		public static void TestPessoaReadValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", "615236621");
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", "615236622");
				Pessoa.Insert("fake name3", "m", "1995-01-03", "6198732713", "615236623");

				for (int i = 0; i < 3; ++i)
				{
					Pessoa auxPpl = Pessoa.ReadValue(i+1);
					Assert.AreEqual (auxPpl.idPessoa, i+1);
					Assert.AreEqual (auxPpl.nomePessoa, string.Format("fake name{0}", i+1));
					Assert.AreEqual (auxPpl.sexo, "m");
					Assert.AreEqual (auxPpl.dataNascimento, string.Format("1995-01-0{0}", i+1));
					Assert.AreEqual (auxPpl.telefone1, string.Format("619873271{0}", i+1));
					Assert.AreEqual (auxPpl.telefone2, string.Format("61523662{0}", i+1));
				}

				conn.Dispose();
				conn.Close();
			}

		}


		[Test]
		public static void TestPessoaDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", "615236621");

				var check = "SELECT EXISTS(SELECT 1 FROM 'PESSOA' WHERE \"idPessoa\" = \"1\" LIMIT 1)";

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
				Pessoa.DeleteValue(1);

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
		}


		[TearDown]
		public static void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();
			GlobalController.DropAll();
		}
	}
}
