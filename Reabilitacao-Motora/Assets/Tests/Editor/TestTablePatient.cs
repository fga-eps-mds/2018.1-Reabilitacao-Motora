using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using paciente;
using pessoa;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;


/**
* Testa a Tabela Paciente do banco de dados.
*/
namespace Tests
{
	public class TestTablePatient
	{
		[SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public void TestPacienteCreate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				// tabela sendo criada no SetUp, no "Initialize" da GlobalController

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PACIENTE';";

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
		public void TestPacienteDrop ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Paciente.Drop();

				var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PACIENTE';";

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
		public void TestPacienteInsert ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Paciente.Insert(1, "observacao teste");
				Paciente.Insert(2, null);

				var check = "SELECT * FROM PACIENTE;";

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
									Assert.AreEqual (result, "observacao teste");
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
		public void TestPacienteUpdate ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Paciente.Insert(1, "observacao teste");
				Paciente.Insert(2, null);

				Paciente.Update(1, 2, null);
				Paciente.Update(2, 1, "teste observacao");

				var check = "SELECT * FROM PACIENTE;";

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
									Assert.AreEqual (result, "teste observacao");
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
		public void TestPacienteRead ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Paciente.Insert(1, "observacao teste");
				Paciente.Insert(2, null);

				List<Paciente> allPatients = Paciente.Read();

				for (int i = 0; i < allPatients.Count; ++i)
				{
					Assert.AreEqual (allPatients[i].persona.idPessoa, (i+1));
					Assert.AreEqual (allPatients[i].persona.nomePessoa, string.Format("fake name{0}", (i+1)));
					Assert.AreEqual (allPatients[i].persona.sexo, "m");
					Assert.AreEqual (allPatients[i].persona.dataNascimento, string.Format("1995-01-0{0}", (i+1)));
					Assert.AreEqual (allPatients[i].persona.telefone1, string.Format("619873271{0}", (i+1)));
					Assert.AreEqual (allPatients[i].idPaciente, i+1);

					if (i == 0)
					{
						Assert.AreEqual (allPatients[i].observacoes, "observacao teste");
					}
					else
					{
						Assert.AreEqual (allPatients[i].observacoes, null);
					}
				}

				conn.Dispose();
				conn.Close();
			}

			return;
		}

		[Test]
		public void TestPacienteReadValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Pessoa.Insert("fake name2", "m", "1995-01-02", "6198732712", null);

				Paciente.Insert(1, "observacao teste");
				Paciente.Insert(2, null);


				for (int i = 0; i < 2; ++i)
				{
					Paciente auxPatient = Paciente.ReadValue(i+1);

					Assert.AreEqual (auxPatient.persona.idPessoa, (i+1));
					Assert.AreEqual (auxPatient.persona.nomePessoa, string.Format("fake name{0}", (i+1)));
					Assert.AreEqual (auxPatient.persona.sexo, "m");
					Assert.AreEqual (auxPatient.persona.dataNascimento, string.Format("1995-01-0{0}", (i+1)));
					Assert.AreEqual (auxPatient.persona.telefone1, string.Format("619873271{0}", (i+1)));
					Assert.AreEqual (auxPatient.idPaciente, i+1);
					if (i == 0)
					{
						Assert.AreEqual (auxPatient.observacoes, "observacao teste");
					}
					else
					{
						Assert.AreEqual (auxPatient.observacoes, null);
					}
				}

				conn.Dispose();
				conn.Close();
			}

			return;
		}


		[Test]
		public void TestPacienteDeleteValue ()
		{
			using (var conn = new SqliteConnection(GlobalController.path))
			{
				conn.Open();

				Pessoa.Insert("fake name1", "m", "1995-01-01", "6198732711", null);
				Paciente.Insert(1, "observacao teste");

				var check = "SELECT EXISTS(SELECT 1 FROM 'PACIENTE' WHERE \"idPaciente\" = \"1\" LIMIT 1)";

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
				Paciente.DeleteValue(1);

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
			GlobalController.DropAll();
		}
	}
}
