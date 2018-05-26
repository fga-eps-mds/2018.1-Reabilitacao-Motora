using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using musculo;
using DataBaseAttributes;
using movimento;
using pessoa;
using fisioterapeuta;
using movimentomusculo;
using Mono.Data.Sqlite;
using System.Data;


/**
* Cria um novo MovimentoMusculo no banco de dados.
*/
namespace Tests
{
	public class TestTableMovementMuscle
	{
		[SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public void TestMovimentoMusculoCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='MOVIMENTOMUSCULO';";

				var id = 0;

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

				Assert.AreEqual (id, 1);

				conn.Dispose();
				conn.Close();
			}
			return;
		}

		[Test]
		public void TestMovimentoMusculoDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				MovimentoMusculo.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='MOVIMENTOMUSCULO';";

				var id = 0;

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

				Assert.AreEqual (id, 0);

				conn.Dispose();
				conn.Close();
			}
			return;
		}

		[Test]
		public void TestMovimentoMusculoInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

				Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
				Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");

				Musculo.Insert("bíceps");
				Musculo.Insert("tríceps");

				MovimentoMusculo.Insert(1, 1);
				MovimentoMusculo.Insert(1, 2);
				MovimentoMusculo.Insert(2, 1);
				MovimentoMusculo.Insert(2, 2);

				var check = "SELECT * FROM MOVIMENTOMUSCULO;";

				var id = 0;
				int i = 1;
				int j = 1;
				int k = 1;
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
									Assert.AreEqual (id, j);
								}

								if (!reader.IsDBNull(1))
								{
									id = reader.GetInt32(1);
									Assert.AreEqual (id, i);
								}

								i = 3 - i;
								if (k == 2)
								{
									j++;
								}
								k++;
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
		public void TestMovimentoMusculoRead ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

				Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
				Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");

				Musculo.Insert("bíceps");
				Musculo.Insert("tríceps");

				MovimentoMusculo.Insert(1, 1);
				MovimentoMusculo.Insert(1, 2);
				MovimentoMusculo.Insert(2, 1);
				MovimentoMusculo.Insert(2, 2);

				List<MovimentoMusculo> allMuscMov = MovimentoMusculo.Read();

				for (int i = 1, j = 1, k = 1; i <= allMuscMov.Count; i++, k = 3 - k)
				{
					Assert.AreEqual (allMuscMov[i-1].idMusculo, j);
					Assert.AreEqual (allMuscMov[i-1].idMovimento, k);
					if (i == 2)
					{
						j++;
					}
				}

				conn.Dispose();
				conn.Close();
			}

			return;
		}

		[Test]
		public void TestMovimentoMusculoDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

				Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
				Musculo.Insert("bíceps");

				MovimentoMusculo.Insert(1, 1);

				var check = "SELECT EXISTS(SELECT 1 FROM 'MOVIMENTOMUSCULO' WHERE \"idMusculo\" = \"1\" AND \"idMovimento\" = \"1\" LIMIT 1)";

				var id = 0;
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

				Assert.AreEqual (id, 1);
				MovimentoMusculo.DeleteValue(1, 1);

				id = 0;
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

				Assert.AreEqual (id, 0);

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
