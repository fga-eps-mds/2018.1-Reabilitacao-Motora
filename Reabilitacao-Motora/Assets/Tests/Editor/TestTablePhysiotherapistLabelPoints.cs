using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using pontosrotulofisioterapeuta;
using movimento;
using fisioterapeuta;
using pessoa;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

/*
  Teste para Tabela Pontos Rotulo Fisioterapeuta do Banco de Dados
*/
namespace Tests
{
  public class TestTablePhysiotherapistLabelPoints
  {
    [SetUp]
		public void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}
        [Test]
        public void TestPhysiotherapistLabelPointsCreate()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                // tabela sendo criada no SetUp, no "Initialize" da GlobalController

                var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PONTOSROTULOFISIOTERAPEUTA';";

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

                Assert.AreEqual(result, 1);

                conn.Dispose();
                conn.Close();
            }
            return;
        }

        [Test]
        public void TestPhysiotherapistLabelPointsDrop()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                PontosRotuloFisioterapeuta.Drop();

                var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PONTOSROTULOFISIOTERAPEUTA';";

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

                Assert.AreEqual(result, 0);

                conn.Dispose();
                conn.Close();
            }
            return;
        }

        [Test]
        public void TestPhysiotherapistLabelPointsInsert()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
                Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
                Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);

                Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
                Fisioterapeuta.Insert(2, "abracadabra2", "demais2", null, null);
                Fisioterapeuta.Insert(3, "abracadabra3", "demais3", null, null);

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Melhora nesse local");

                PontosRotuloFisioterapeuta.Insert(1, "Mediano1", 14.00f, 15.00f);
                PontosRotuloFisioterapeuta.Insert(2, "Mediano2", 15.00f, 16.00f);
                PontosRotuloFisioterapeuta.Insert(3, "Mediano3", 16.00f, 17.00f);

                var check = "SELECT * FROM PONTOSROTULOFISIOTERAPEUTA;";

                var id = 0;
                var result = "";
                int i = 1;
                float resultFloat = 0.00f;

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
                                    Assert.AreEqual(id, i);
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    id = reader.GetInt32(1);
                                    Assert.AreEqual(id, i);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    result = reader.GetString(2);
                                    Assert.AreEqual(result, string.Format("Mediano{0}", i));
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    resultFloat = reader.GetFloat(3);
                                    Assert.AreEqual(resultFloat, 13.00f+i);
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    resultFloat = reader.GetFloat(4);
                                    Assert.AreEqual(resultFloat, 14.00f+i);
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
        public void TestPhysiotherapistLabelPointsUpdate()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
                Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
                Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);

                Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
                Fisioterapeuta.Insert(2, "abracadabra2", "demais2", null, null);
                Fisioterapeuta.Insert(3, "abracadabra3", "demais3", null, null);

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Melhora nesse local");

                PontosRotuloFisioterapeuta.Insert(1, "Mediano1", 14.00f, 15.00f);
                PontosRotuloFisioterapeuta.Insert(2, "Mediano2", 15.00f, 16.00f);
                PontosRotuloFisioterapeuta.Insert(3, "Mediano3", 16.00f, 17.00f);

                PontosRotuloFisioterapeuta.Update(1, 3, "Facilidade1", 07.00f, 12.00f);
                PontosRotuloFisioterapeuta.Update(2, 2, "Facilidade2", 08.00f, 13.00f);
                PontosRotuloFisioterapeuta.Update(3, 1, "Facilidade3", 09.00f, 14.00f);

                var check = "SELECT * FROM PONTOSROTULOFISIOTERAPEUTA;";

                var id = 0;
                var result = "";
                int i = 1;
                float resultFloat = 0.00f;

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
                                    Assert.AreEqual(id, i);
                                }

                                if (!reader.IsDBNull(1))
                                {
                                    id = reader.GetInt32(1);
                                    Assert.AreEqual(id, 4 - i);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    result = reader.GetString(2);
                                    Assert.AreEqual(result, string.Format("Facilidade{0}", i));
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    resultFloat = reader.GetFloat(3);
                                    Assert.AreEqual(resultFloat, 06.00f + i);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    resultFloat = reader.GetFloat(4);
                                    Assert.AreEqual(resultFloat, 11.00f + i);
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
        public void TestPhysiotherapistLabelPointsRead()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
                Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
                Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);

                Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
                Fisioterapeuta.Insert(2, "abracadabra2", "demais2", null, null);
                Fisioterapeuta.Insert(3, "abracadabra3", "demais3", null, null);

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Melhora nesse local");

                PontosRotuloFisioterapeuta.Insert(1, "Mediano1", 14.00f, 15.00f);
                PontosRotuloFisioterapeuta.Insert(2, "Mediano2", 15.00f, 16.00f);
                PontosRotuloFisioterapeuta.Insert(3, "Mediano3", 16.00f, 17.00f);

                List<PontosRotuloFisioterapeuta> allPhysioLabelPoints = PontosRotuloFisioterapeuta.Read();

                for (int i = 0; i < allPhysioLabelPoints.Count; ++i)
                {
                    Assert.AreEqual(allPhysioLabelPoints[i].moves.idMovimento, i + 1);
                    Assert.AreEqual(allPhysioLabelPoints[i].moves.nomeMovimento, string.Format("Movimento{0}", (i + 1)));
                    Assert.AreEqual(allPhysioLabelPoints[i].moves.pontosMovimento, "Musculo Redondo Maior");
                    Assert.AreEqual(allPhysioLabelPoints[i].idRotuloFisioterapeuta, i + 1);
                    Assert.AreEqual(allPhysioLabelPoints[i].estagioMovimentoFisio, string.Format("Mediano{0}", i + 1));
                    Assert.AreEqual(allPhysioLabelPoints[i].tempoInicial, 14.00f + i);
                    Assert.AreEqual(allPhysioLabelPoints[i].tempoFinal, 15.00f + i);
                }

                conn.Dispose();
                conn.Close();
            }

            return;
        }
        
        [Test]
        public void TestPhysiotherapistLabelPointsReadValue()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
                Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
                Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);

                Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
                Fisioterapeuta.Insert(2, "abracadabra2", "demais2", null, null);
                Fisioterapeuta.Insert(3, "abracadabra3", "demais3", null, null);

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Melhora nesse local");

                PontosRotuloFisioterapeuta.Insert(1, "Mediano1", 14.00f, 15.00f);
                PontosRotuloFisioterapeuta.Insert(2, "Mediano2", 15.00f, 16.00f);
                PontosRotuloFisioterapeuta.Insert(3, "Mediano3", 16.00f, 17.00f);

                for (int i = 0; i < 3; ++i)
                {
                    PontosRotuloFisioterapeuta auxPhysioLabelPoints = PontosRotuloFisioterapeuta.ReadValue(i + 1);
                    Assert.AreEqual(auxPhysioLabelPoints.moves.idMovimento, i + 1);
                    Assert.AreEqual(auxPhysioLabelPoints.moves.nomeMovimento, string.Format("Movimento{0}", (i + 1)));
                    Assert.AreEqual(auxPhysioLabelPoints.moves.pontosMovimento, "Musculo Redondo Maior");
                    Assert.AreEqual(auxPhysioLabelPoints.idRotuloFisioterapeuta, i + 1);
                    Assert.AreEqual(auxPhysioLabelPoints.estagioMovimentoFisio, string.Format("Mediano{0}", i + 1));
                    Assert.AreEqual(auxPhysioLabelPoints.tempoInicial, 14.00f + i);
                    Assert.AreEqual(auxPhysioLabelPoints.tempoFinal, 15.00f + i);
                    
                }

                conn.Dispose();
                conn.Close();
            }

            return;
        }

        [Test]
        public void TestPhysiotherapistLabelPointsDeleteValue()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                Pessoa.Insert("physio name1", "m", "1995-01-04", "6198732714", null);
                Pessoa.Insert("physio name2", "m", "1995-01-05", "6198732715", null);
                Pessoa.Insert("physio name3", "m", "1995-01-06", "6198732716", null);

                Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);
                Fisioterapeuta.Insert(2, "abracadabra2", "demais2", null, null);
                Fisioterapeuta.Insert(3, "abracadabra3", "demais3", null, null);

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Melhora nesse local");

                PontosRotuloFisioterapeuta.Insert(1, "Mediano1", 14.00f, 15.00f);
                PontosRotuloFisioterapeuta.Insert(2, "Mediano2", 15.00f, 16.00f);
                PontosRotuloFisioterapeuta.Insert(3, "Mediano3", 16.00f, 17.00f);

                var check = "SELECT EXISTS(SELECT 1 FROM 'PONTOSROTULOFISIOTERAPEUTA' WHERE \"idRotuloFisioterapeuta\" = \"1\" LIMIT 1)";

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

                Assert.AreEqual(result, 1);
                PontosRotuloFisioterapeuta.DeleteValue(1);

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

                Assert.AreEqual(result, 0);

                conn.Dispose();
                conn.Close();
            }
            return;
        }

        [TearDown]
        public static void AfterEveryTest()
        {
            SqliteConnection.ClearAllPools();
            GlobalController.DropAll();
        }
    }
}
