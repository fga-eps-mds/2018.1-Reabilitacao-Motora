using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using exercicio;
using pessoa;
using fisioterapeuta;
using paciente;
using movimento;
using sessao;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;


/**
* Cria um novo Exercicio no banco de dados.
*/
namespace Tests
{
	public class TestTableExercise
	{
		[SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public void TestExercicioCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EXERCICIO';";

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
		public void TestExercicioDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Exercicio.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='EXERCICIO';";

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
		public void TestExercicioInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name2", "m", "1995-01-04", "6198732714", null);
				
				Fisioterapeuta.Insert(3, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(4, "abracadabra2", "demais2", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);

				Movimento.Insert (1,"levantamento de peso", "caminhoy.com", null);
				Movimento.Insert (2,"levantamento de pena", "caminhox.com", null);

				Sessao.Insert (1, 1, "1940-10-10", null);
				Sessao.Insert (1, 2, "2010-10-10", null);

				Exercicio.Insert (1, 1, 1, "caminhopaciente4.ponto", null);
				Exercicio.Insert (1, 2, 1, "caminhopaciente6.ponto", "levantou mt coisa1");
				Exercicio.Insert (2, 1, 2, "caminhopaciente8.ponto", null);
				Exercicio.Insert (2, 2, 2, "caminhopaciente10.ponto", "levantou mt coisa2");

				var check = "SELECT * FROM EXERCICIO;";

				var id = 0;
				var result = "";
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
									Assert.AreEqual (id, i);
								}

								if (!reader.IsDBNull(1))
								{
									id = reader.GetInt32(1);
									Assert.AreEqual (id, j);
								}

								if (!reader.IsDBNull(2))
								{
									id = reader.GetInt32(2);
									Assert.AreEqual (id, k);
								}

								if (!reader.IsDBNull(3))
								{
									id = reader.GetInt32(3);
									Assert.AreEqual (id, j);
								}

								if (!reader.IsDBNull(4))
								{
									result = reader.GetString(4);
									Assert.AreEqual (result, string.Format("caminhopaciente{0}.ponto", i+j+j+k));
								}

								if (!reader.IsDBNull(5))
								{
									result = reader.GetString(5);
									Assert.AreEqual (result, string.Format("levantou mt coisa{0}",j));
								}

								i++;
								if (i == 3)
								{
									j++;
								}
								k = 3-k;
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
