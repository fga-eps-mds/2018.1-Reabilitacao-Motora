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
	public class TestTablePhysiotherapist
	{
		[SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public void TestFisioterapeutaCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='FISIOTERAPEUTA';";

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
		public void TestFisioterapeutaDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Fisioterapeuta.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='FISIOTERAPEUTA';";

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
		public void TestFisioterapeutaInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(1, "abracadabra2", "demais2", "DF", "123424");

				var check = "SELECT * FROM FISIOTERAPEUTA;";

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
									id = reader.GetInt32(1);
									Assert.AreEqual (id, 3-i);
								}

								if (!reader.IsDBNull(2))
								{
									result = reader.GetString(2);
									Assert.AreEqual (result, string.Format("abracadabra{0}", i));
								}

								if (!reader.IsDBNull(3))
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, string.Format("demais{0}", i));
								}

								if (!reader.IsDBNull(4))
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, "DF");
								}

								if (!reader.IsDBNull(5))
								{
									result = reader.GetString(5);
									Assert.AreEqual (result, "123424");
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
		public void TestFisioterapeutaUpdate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(1, "abracadabra2", "demais2", "DF", "123424");

				Fisioterapeuta.Update(1, 1, "abracadabra12", "demais2", null, null);
				Fisioterapeuta.Update(2, 2, "abracadabra11", "demais2", null, null);

				var check = "SELECT * FROM FISIOTERAPEUTA;";

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
									id = reader.GetInt32(1);
									Assert.AreEqual (id, i);
								}

								if (!reader.IsDBNull(2))
								{
									result = reader.GetString(2);
									Assert.AreEqual (result, string.Format("abracadabra1{0}", 3-i));
								}

								if (!reader.IsDBNull(3))
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, "demais2");
								}

								Assert.AreEqual (reader.IsDBNull(4), true);
								Assert.AreEqual (reader.IsDBNull(5), true);

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
		public void TestFisioterapeutaRead ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(1, "abracadabra2", "demais2", "DF", "123424");

				List<Fisioterapeuta> allPhysios = Fisioterapeuta.Read();

				for (int i = 0; i < allPhysios.Count; ++i)
				{
					Assert.AreEqual (allPhysios[i].persona.idPessoa, 3 - (i+1));
					Assert.AreEqual (allPhysios[i].persona.nomePessoa, string.Format("fake name{0}", 3-(i+1)));
					Assert.AreEqual (allPhysios[i].persona.sexo, "m");
					Assert.AreEqual (allPhysios[i].persona.dataNascimento, string.Format("1995-01-0{0}", 3-(i+1)));
					Assert.AreEqual (allPhysios[i].persona.telefone1, string.Format("619873271{0}", 3-(i+1)));
					Assert.AreEqual (allPhysios[i].idFisioterapeuta, i+1);
					Assert.AreEqual (allPhysios[i].login, string.Format("abracadabra{0}", i+1));
					Assert.AreEqual (allPhysios[i].senha, string.Format("demais{0}", i+1));
					
					if (i == 0)
					{
						Assert.AreEqual (allPhysios[i].regiao, null);
						Assert.AreEqual (allPhysios[i].crefito, null);
					}
					else
					{
						Assert.AreEqual (allPhysios[i].regiao, "DF");
						Assert.AreEqual (allPhysios[i].crefito, "123424");
					}
				}

				conn.Dispose();
				conn.Close();
			}

			return;
		}

		[Test]
		public void TestFisioterapeutaReadValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(1, "abracadabra2", "demais2", "DF", "123424");


				for (int i = 0; i < 2; ++i)
				{
					Fisioterapeuta auxPhysio = Fisioterapeuta.ReadValue(i+1);

					Assert.AreEqual (auxPhysio.persona.idPessoa, 3 - (i+1));
					Assert.AreEqual (auxPhysio.persona.nomePessoa, string.Format("fake name{0}", 3-(i+1)));
					Assert.AreEqual (auxPhysio.persona.sexo, "m");
					Assert.AreEqual (auxPhysio.persona.dataNascimento, string.Format("1995-01-0{0}", 3-(i+1)));
					Assert.AreEqual (auxPhysio.persona.telefone1, string.Format("619873271{0}", 3-(i+1)));
					Assert.AreEqual (auxPhysio.idFisioterapeuta, i+1);
					Assert.AreEqual (auxPhysio.login, string.Format("abracadabra{0}", i+1));
					Assert.AreEqual (auxPhysio.senha, string.Format("demais{0}", i+1));
					if (i == 0)
					{
						Assert.AreEqual (auxPhysio.regiao, null);
						Assert.AreEqual (auxPhysio.crefito, null);
					}
					else
					{
						Assert.AreEqual (auxPhysio.regiao, "DF");
						Assert.AreEqual (auxPhysio.crefito, "123424");
					}
				}

				conn.Dispose();
				conn.Close();
			}

			return;
		}


		[Test]
		public void TestFisioterapeutaDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);
				Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

				var check = "SELECT EXISTS(SELECT 1 FROM 'FISIOTERAPEUTA' WHERE \"idFisioterapeuta\" = \"1\" LIMIT 1)";

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
				Fisioterapeuta.DeleteValue(1);

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
		public static void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			GlobalController.DropAll();
		}
	}
}
