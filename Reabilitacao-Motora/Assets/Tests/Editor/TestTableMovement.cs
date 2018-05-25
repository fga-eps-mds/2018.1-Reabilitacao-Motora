using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using movimento;
using fisioterapeuta;
using pessoa;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;


/**
* Testes da tabela Movimento no banco de dados.
*/
namespace Tests
{
	public class TestTableMovement
	{
		[SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public void TestCreateMovement ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='MOVIMENTO';";

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
		public void TestDropMovement ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Movimento.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='MOVIMENTO';";

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
		public void TestInsertMovement ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

        Movimento.Insert(1, "Movimento1", null, "Musculo Redondo Maior");
				Movimento.Insert(2, "Movimento2", "Dificuldade nesse local", "Musculo Redondo Maior");

				var check = "SELECT * FROM MOVIMENTO;";

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
									Assert.AreEqual (result, string.Format("Movimento{0}", i));
								}

                if (!reader.IsDBNull(3))
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, "Dificuldade nesse local");
								}

								if (!reader.IsDBNull(4))
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, "Musculo Redondo Maior");
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
		public void TestUpdateMovement ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

        Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

        Movimento.Insert(1, "Movimento1", null, "Musculo Redondo Maior");
				Movimento.Insert(2, "Movimento2", "Dificuldade nesse local", "Musculo Redondo Maior");

				Movimento.Update(1, 2, "Movimento11", null, "Musculo do Braquiorradial");
				Movimento.Update(2, 1, "Movimento12", null, "Musculo do Braquiorradial");

				var check = "SELECT * FROM MOVIMENTO;";

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
									Assert.AreEqual (result, string.Format("Movimento1{0}", i));
								}

								if (!reader.IsDBNull(4))
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, "Musculo do Braquiorradial");
								}

                  Assert.AreEqual (reader.IsDBNull(3), true);

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
    public void TestReadMovement ()
    {
      using (var conn = new SqliteConnection(GlobalController.path))
      {
        conn.Open();

        Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

        Movimento.Insert(1, "Movimento1", null, "Musculo Redondo Maior");
				Movimento.Insert(2, "Movimento2", "Dificuldade nesse local", "Musculo Redondo Maior");

        List<Movimento> allMovements = Movimento.Read();

        for (int i = 0; i < allMovements.Count; ++i)
        {
          Assert.AreEqual (allMovements[i].physio.idFisioterapeuta, (i+1));
          Assert.AreEqual (allMovements[i].physio.login, string.Format("abracadabra{0}", (i+1)));
          Assert.AreEqual (allMovements[i].physio.senha, string.Format("demais{0}", (i+1)));
          Assert.AreEqual (allMovements[i].idMovimento, i+1);
          Assert.AreEqual (allMovements[i].nomeMovimento, string.Format("Movimento{0}", (i+1)));
          Assert.AreEqual (allMovements[i].pontosMovimento, "Musculo Redondo Maior");
          if (i == 0)
          {
            Assert.AreEqual (allMovements[i].descricaoMovimento, "Dificuldade nesse local");
          }
          else
          {
            Assert.AreEqual (allMovements[i].descricaoMovimento, null);
          }
        }

        conn.Dispose();
        conn.Close();
      }

      return;
    }

    [Test]
    public void TestReadValueMovement ()
    {
      using (var conn = new SqliteConnection(GlobalController.path))
      {
        conn.Open();

        Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(2, "abracadabra2", "demais2", "DF", "123424");

        Movimento.Insert(1, "Movimento1", null, "Musculo Redondo Maior");
				Movimento.Insert(2, "Movimento2", "Dificuldade nesse local", "Musculo Redondo Maior");


        for (int i = 0; i < 2; ++i)
        {

          Movimento auxMovements = Movimento.ReadValue(i+1);

          Assert.AreEqual (auxMovements.physio.idFisioterapeuta, (i+1));
          Assert.AreEqual (auxMovements.physio.login, string.Format("abracadabra{0}", (i+1)));
          Assert.AreEqual (auxMovements.physio.senha, string.Format("demais{0}", (i+1)));
          Assert.AreEqual (auxMovements.idMovimento, i+1);
          Assert.AreEqual (auxMovements.nomeMovimento, string.Format("Movimento{0}", (i+1)));
          Assert.AreEqual (auxMovements.pontosMovimento, "Musculo Redondo Maior");

          if (i == 0)
          {
            Assert.AreEqual (auxMovements.descricaoMovimento, "Dificuldade nesse local");
          }
          else
          {
            Assert.AreEqual (auxMovements.descricaoMovimento, null);
          }
        }

        conn.Dispose();
        conn.Close();
      }

      return;
    }


    [Test]
    public void TestDeleteValueMovement ()
    {
      using (var conn = new SqliteConnection(GlobalController.path))
      {
        conn.Open();

        Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

        Movimento.Insert(1, "Movimento1", null, "Musculo Redondo Maior");

        var check = "SELECT EXISTS(SELECT 1 FROM 'MOVIMENTO' WHERE \"idMovimento\" = \"1\" LIMIT 1)";

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
        Movimento.DeleteValue(1);

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
