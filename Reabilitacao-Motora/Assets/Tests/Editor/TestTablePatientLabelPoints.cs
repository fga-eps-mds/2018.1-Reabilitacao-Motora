using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Text.RegularExpressions;
using pontosrotulopaciente;
using sessao;
using exercicio;
using movimento;
using paciente;
using fisioterapeuta;
using pessoa;
using DataBaseAttributes;
using Mono.Data.Sqlite;
using System.Data;

/*
  Teste para Tabela Pontos Rotulo Paciente do Banco de Dados
*/
namespace Tests
{
    public static class TestTablePatientLabelPoints
    {
        [SetUp]
        public static void SetUp()
        {
            GlobalController.test = true;
            GlobalController.Initialize();
        }
        [Test]
        public static void TestPatientLabelPointsCreate()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                // tabela sendo criada no SetUp, no "Initialize" da GlobalController

                var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PONTOSROTULOPACIENTE';";

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
        public static void TestPatientLabelPointsDrop()
        {
            using (var conn = new SqliteConnection(GlobalController.path))
            {
                conn.Open();

                PontosRotuloPaciente.Drop();

                var check = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PONTOSROTULOPACIENTE';";

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
        public static void TestPatientLabelPointsInsert()
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

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Dificuldade nesse local");

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Exercicio.Insert(1, 1, 1, "caminhopaciente4.ponto", null);
                Exercicio.Insert(1, 2, 1, "caminhopaciente6.ponto", "levantou mt coisa1");
                Exercicio.Insert(2, 1, 2, "caminhopaciente8.ponto", null);
                Exercicio.Insert(2, 2, 2, "caminhopaciente10.ponto", "levantou mt coisa2");
                Exercicio.Insert(3, 1, 3, "caminhopaciente12.ponto", null);
                Exercicio.Insert(3, 2, 3, "caminhopaciente14.ponto", "levantou mt coisa3");

                PontosRotuloPaciente.Insert(1, "Aperfeicoando1", 05.00f, 06.00f);
                PontosRotuloPaciente.Insert(2, "Aperfeicoando2", 06.00f, 07.00f);
                PontosRotuloPaciente.Insert(3, "Aperfeicoando3", 07.00f, 08.00f);

                var check = "SELECT * FROM PONTOSROTULOPACIENTE;";

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
                                    Assert.AreEqual(result, string.Format("Aperfeicoando{0}", i));
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    resultFloat = reader.GetFloat(3);
                                    Assert.AreEqual(resultFloat, 04.00f + i);
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    resultFloat = reader.GetFloat(4);
                                    Assert.AreEqual(resultFloat, 05.00f + i);
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
        public static void TestPatientLabelPointsUpdate()
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

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Dificuldade nesse local");

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Exercicio.Insert(1, 1, 1, "caminhopaciente4.ponto", null);
                Exercicio.Insert(1, 2, 1, "caminhopaciente6.ponto", "levantou mt coisa1");
                Exercicio.Insert(2, 1, 2, "caminhopaciente8.ponto", null);
                Exercicio.Insert(2, 2, 2, "caminhopaciente10.ponto", "levantou mt coisa2");
                Exercicio.Insert(3, 1, 3, "caminhopaciente12.ponto", null);
                Exercicio.Insert(3, 2, 3, "caminhopaciente14.ponto", "levantou mt coisa3");

                PontosRotuloPaciente.Insert(1, "Aperfeicoando1", 05.00f, 06.00f);
                PontosRotuloPaciente.Insert(2, "Aperfeicoando2", 06.00f, 07.00f);
                PontosRotuloPaciente.Insert(3, "Aperfeicoando3", 07.00f, 08.00f);

                PontosRotuloPaciente.Update(1, 3, "SemResultados1", 10.00f, 11.00f);
                PontosRotuloPaciente.Update(2, 2, "SemResultados2", 11.00f, 12.00f);
                PontosRotuloPaciente.Update(3, 1, "SemResultados3", 12.00f, 13.00f);

                var check = "SELECT * FROM PONTOSROTULOPACIENTE;";

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
                                    Assert.AreEqual(result, string.Format("SemResultados{0}", i));
                                }

                                if (!reader.IsDBNull(3))
                                {
                                    resultFloat = reader.GetFloat(3);
                                    Assert.AreEqual(resultFloat, 09.00f + i);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    resultFloat = reader.GetFloat(4);
                                    Assert.AreEqual(resultFloat, 10.00f + i);
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
        public static void TestPatientLabelPointsRead()
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

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Dificuldade nesse local");

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Exercicio.Insert(1, 1, 1, "caminhopaciente1.ponto", null);
                Exercicio.Insert(1, 2, 1, "caminhopaciente2.ponto", "levantou mt coisa1");
                Exercicio.Insert(2, 1, 2, "caminhopaciente3.ponto", null);
                Exercicio.Insert(2, 2, 2, "caminhopaciente4.ponto", "levantou mt coisa2");
                Exercicio.Insert(3, 1, 3, "caminhopaciente5.ponto", null);
                Exercicio.Insert(3, 2, 3, "caminhopaciente6.ponto", "levantou mt coisa3");

                PontosRotuloPaciente.Insert(1, "Aperfeicoando1", 05.00f, 06.00f);
                PontosRotuloPaciente.Insert(2, "Aperfeicoando2", 06.00f, 07.00f);
                PontosRotuloPaciente.Insert(3, "Aperfeicoando3", 07.00f, 08.00f);

                List<PontosRotuloPaciente> allPatientsLabelPoints = PontosRotuloPaciente.Read();

                for (int i = 0; i < allPatientsLabelPoints.Count; ++i)
                {
                    Assert.AreEqual(allPatientsLabelPoints[i].exer.idExercicio, i + 1);
                    Assert.AreEqual(allPatientsLabelPoints[i].idRotuloPaciente, i + 1);
                    Assert.AreEqual(allPatientsLabelPoints[i].estagioMovimentoPaciente, string.Format("Aperfeicoando{0}", i + 1));
                    Assert.AreEqual(allPatientsLabelPoints[i].tempoInicial, 05.00f + i);
                    Assert.AreEqual(allPatientsLabelPoints[i].tempoFinal, 06.00f + i);
                }

                conn.Dispose();
                conn.Close();
            }

            return;
        }
       
        [Test]
        public static void TestPatientLabelPointsReadValue()
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

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Dificuldade nesse local");

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Exercicio.Insert(1, 1, 1, "caminhopaciente1.ponto", null);
                Exercicio.Insert(1, 2, 1, "caminhopaciente2.ponto", "levantou mt coisa1");
                Exercicio.Insert(2, 1, 2, "caminhopaciente3.ponto", null);
                Exercicio.Insert(2, 2, 2, "caminhopaciente4.ponto", "levantou mt coisa2");
                Exercicio.Insert(3, 1, 3, "caminhopaciente5.ponto", null);
                Exercicio.Insert(3, 2, 3, "caminhopaciente6.ponto", "levantou mt coisa3");

                PontosRotuloPaciente.Insert(1, "Aperfeicoando1", 05.00f, 06.00f);
                PontosRotuloPaciente.Insert(2, "Aperfeicoando2", 06.00f, 07.00f);
                PontosRotuloPaciente.Insert(3, "Aperfeicoando3", 07.00f, 08.00f);

                for (int i = 0; i < 3; ++i)
                {
                    PontosRotuloPaciente auxPatientsLabelPoints = PontosRotuloPaciente.ReadValue(i + 1);
                    Assert.AreEqual(auxPatientsLabelPoints.exer.idExercicio, i + 1);
                    Assert.AreEqual(auxPatientsLabelPoints.idRotuloPaciente, i + 1);
                    Assert.AreEqual(auxPatientsLabelPoints.estagioMovimentoPaciente, string.Format("Aperfeicoando{0}", i + 1));
                    Assert.AreEqual(auxPatientsLabelPoints.tempoInicial, 05.00f + i);
                    Assert.AreEqual(auxPatientsLabelPoints.tempoFinal, 06.00f + i);

                }

                conn.Dispose();
                conn.Close();
            }

            return;
        }
        
        [Test]
        public static void TestPatientLabelPointsDeleteValue()
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

                Movimento.Insert(1, "Movimento1", "Musculo Redondo Maior", null);
                Movimento.Insert(2, "Movimento2", "Musculo Redondo Maior", "Dificuldade nesse local");
                Movimento.Insert(3, "Movimento3", "Musculo Redondo Maior", "Dificuldade nesse local");

                Sessao.Insert(1, 1, "2018-03-01", null);
                Sessao.Insert(2, 2, "2018-03-02", "procedimento2");
                Sessao.Insert(3, 3, "2018-03-03", "procedimento3");

                Exercicio.Insert(1, 1, 1, "caminhopaciente1.ponto", null);
                Exercicio.Insert(1, 2, 1, "caminhopaciente2.ponto", "levantou mt coisa1");
                Exercicio.Insert(2, 1, 2, "caminhopaciente3.ponto", null);
                Exercicio.Insert(2, 2, 2, "caminhopaciente4.ponto", "levantou mt coisa2");
                Exercicio.Insert(3, 1, 3, "caminhopaciente5.ponto", null);
                Exercicio.Insert(3, 2, 3, "caminhopaciente6.ponto", "levantou mt coisa3");

                PontosRotuloPaciente.Insert(1, "Aperfeicoando1", 05.00f, 06.00f);
                PontosRotuloPaciente.Insert(2, "Aperfeicoando2", 06.00f, 07.00f);
                PontosRotuloPaciente.Insert(3, "Aperfeicoando3", 07.00f, 08.00f);

                var check = "SELECT EXISTS(SELECT 1 FROM 'PONTOSROTULOPACIENTE' WHERE \"idRotuloPaciente\" = \"1\" LIMIT 1)";

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
                PontosRotuloPaciente.DeleteValue(1);

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
