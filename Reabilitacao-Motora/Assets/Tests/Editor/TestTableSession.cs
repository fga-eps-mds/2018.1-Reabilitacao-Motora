using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using pessoa;
using fisioterapeuta;
using paciente;
using sessao;
using System.Text.RegularExpressions;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;


/**
* Testa a table de Sessão do banco de dados.
*/
namespace Tests
{
	public class TestTableSession
	{
		[SetUp]
		public static void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public static void TestSessionCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='SESSAO';";

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
		public static void TestSessionDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Sessao.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='SESSAO';";

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
		public static void TestSessionInsert()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("patient name3", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
				Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
				Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);
				
				Fisioterapeuta.Insert(4, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(5, "abracadabra2", "demais2", null, null);
				Fisioterapeuta.Insert(6, "abracadabra3", "demais3", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);
				Paciente.Insert(3, null);

				Sessao.Insert(1, 1, "2018-03-01", null);
				Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                var check = "SELECT * FROM SESSAO;";

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
                                    Assert.AreEqual(id, i);
                                }

								if (!reader.IsDBNull(2))
								{
                                    id = reader.GetInt32(2);
                                    Assert.AreEqual (id, i);
								}

                                if (!reader.IsDBNull(3))
                                {
                                    result = reader.GetString(3);
                                    Assert.AreEqual(result, string.Format("2018-03-0{0}", i));
                                }

								if (!reader.IsDBNull(4))
								{
									result = reader.GetString(4);
                                    // null não entrará, logo só as demais "sessoes" entra
                                    Assert.AreEqual(result, string.Format("procedimento{0}", i));
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
		public static void TestSessionUpdate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("patient name3", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
				Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
				Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);
				
				Fisioterapeuta.Insert(4, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(5, "abracadabra2", "demais2", null, null);
				Fisioterapeuta.Insert(6, "abracadabra3", "demais3", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);
				Paciente.Insert(3, null);

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Sessao.Update(1, 3, 3, "2018-04-01", null);
                Sessao.Update(2, 2, 2, "2018-05-01", null);
                Sessao.Update(3, 1, 1, "2018-06-01", null);

                var check = "SELECT * FROM SESSAO;";

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
                                    Assert.AreEqual (id, 4-i);
								}

								if (!reader.IsDBNull(2))
								{
                                    id = reader.GetInt32(2);
                                    Assert.AreEqual (id, 4-i);
								}

								if (!reader.IsDBNull(3))
								{
									result = reader.GetString(3);
									Assert.AreEqual (result, string.Format("2018-0{0}-01", 3+i));
								}

                                Assert.AreEqual (reader.IsDBNull(4), true);

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
		public static void TestSessionRead()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("patient name3", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
				Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
				Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);
				
				Fisioterapeuta.Insert(4, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(5, "abracadabra2", "demais2", null, null);
				Fisioterapeuta.Insert(6, "abracadabra3", "demais3", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);
				Paciente.Insert(3, null);

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                List<Sessao> allSessions = Sessao.Read();

				for (int i = 0; i < allSessions.Count; ++i)
				{
					Assert.AreEqual (allSessions[i].idSessao, i+1);
					Assert.AreEqual (allSessions[i].idFisioterapeuta, i+1);
					Assert.AreEqual (allSessions[i].idPaciente, i+1);
					Assert.AreEqual (allSessions[i].dataSessao, string.Format("2018-03-0{0}", i+1));

                    if (i == 0)
                    {
                        Assert.AreEqual(allSessions[i].observacaoSessao, null);
                    }
                    else
                    {
                        Assert.AreEqual(allSessions[i].observacaoSessao, string.Format("procedimento{0}", i + 1));
                    }
                }

				conn.Dispose();
				conn.Close();
			}

		}

		[Test]
		public static void TestSessionReadValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("patient name3", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
				Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
				Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);
				
				Fisioterapeuta.Insert(4, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(5, "abracadabra2", "demais2", null, null);
				Fisioterapeuta.Insert(6, "abracadabra3", "demais3", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);
				Paciente.Insert(3, null);

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                for (int i = 0; i < 3; ++i)
                {
                    Sessao auxSession = Sessao.ReadValue(i + 1);
                    Assert.AreEqual(auxSession.idSessao, i + 1);
                    Assert.AreEqual(auxSession.idFisioterapeuta, i + 1);
                    Assert.AreEqual(auxSession.idPaciente, i + 1);
                    Assert.AreEqual(auxSession.dataSessao, string.Format("2018-03-0{0}", i + 1));
      
                    if (i == 0)
                    {
                        Assert.AreEqual(auxSession.observacaoSessao, null);
                    }
                    else
                    {
                        Assert.AreEqual(auxSession.observacaoSessao, string.Format("procedimento{0}", i + 1));
                    }
                }

                conn.Dispose();
				conn.Close();
			}

		}


		[Test]
		public static void TestSessionDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("patient name2", "m", "1995-01-02", "6198732712", null);
				Pessoa.Insert("patient name3", "m", "1995-01-03", "6198732713", null);
				Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
				Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
				Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);
				
				Fisioterapeuta.Insert(4, "abracadabra1", "demais1", null, null);
				Fisioterapeuta.Insert(5, "abracadabra2", "demais2", null, null);
				Fisioterapeuta.Insert(6, "abracadabra3", "demais3", null, null);

				Paciente.Insert(1, null);
				Paciente.Insert(2, null);
				Paciente.Insert(3, null);

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                var check = "SELECT EXISTS(SELECT 1 FROM 'SESSAO' WHERE \"idSessao\" = \"1\" LIMIT 1)";

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
				Sessao.DeleteValue(1);

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
