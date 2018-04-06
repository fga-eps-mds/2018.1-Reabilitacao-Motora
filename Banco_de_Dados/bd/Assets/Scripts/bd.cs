using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

using pessoa;
using telefone;
using fisioterapeuta;
using paciente;
using musculo;
using movimento;
using sessao;
using exercicio;
using movimentomusculo;
using pontosmovimentofisioterapeuta;
using pontosmovimentopaciente;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

public class bd : MonoBehaviour
{
    string path;

    Pessoa tablePessoa;
    Telefone tableTel;
    Fisioterapeuta tableFisio;
    Paciente tablePaciente;
    Musculo tableMusculo;
    Movimento tableMovimento;
    Sessao tableSessao;
    Exercicio tableExercicio;
    MovimentoMusculo tableMovimentoMusculo;
    PontosMovimentoFisioterapeuta  tablePMF;
    PontosRotuloFisioterapeuta tablePRF;
    PontosMovimentoPaciente tablePMP;
    PontosRotuloPaciente tablePRP;


    void Start()
    {
        path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
        
        Initialize ();
                
        Insertions ();

        Updates ();
        ReadAll ();

        Deletions ();
        ReadAll ();
    }

    void Initialize () 
    {
        tablePessoa = new Pessoa (path);
        tableTel = new Telefone (path);
        tableFisio = new Fisioterapeuta (path);
        tablePaciente = new Paciente (path);
        tableMusculo = new Musculo (path);
        tableMovimento = new Movimento (path);
        tableSessao = new Sessao (path);
        tableExercicio = new Exercicio (path);
        tableMovimentoMusculo = new MovimentoMusculo (path);
        tablePMF = new PontosMovimentoFisioterapeuta (path);
        tablePRF = new PontosRotuloFisioterapeuta (path);
        tablePMP = new PontosMovimentoPaciente (path);
        tablePRP = new PontosRotuloPaciente (path);
    }

    void Insertions () 
    {
        tablePessoa.Insert ("mateus", "m", "1995-11-04"); // id = 5
        tablePessoa.Insert ("carlos", "m", "1997-01-11"); // id = 6
        tableTel.Insert (5, "+55 44 9998 1717"); // 6 = mateus
        tableFisio.Insert (5); // mateus = fisioterapeuta, id = 3
        tablePaciente.Insert (6, "semi top"); // carlos = paciente, id = 3
        tableMusculo.Insert ("deltoide"); // id = 5
        tableMovimento.Insert (3, "levantando peso pra cima", "utilizando um halter levante-o ate altura do ombro"); //mateus cadastra movimento, id = 4
        tableSessao.Insert (3, 3, "2018-05-04", "carlos realizou o exercicio x bem"); // id = 10
        tableExercicio.Insert (3, 4, 10, "leve dificuldade no começo mas dps show de bola"); // id = 5
        tableMovimentoMusculo.Insert (5, 4);
        tablePMF.Insert (4, 1.2, 1.5); // id = 6
        tablePRF.Insert (4, "ascençao do braço", 0, 1); // id = 6
        tablePMP.Insert (5, 0.7, 1.5); // id = 6
        tablePRP.Insert (5, "ascençao do braço", 0, 1); // id = 6*/
    }

    void Updates () 
    {
        tablePessoa.Update (5, "mathews", "m", "1995-11-04"); //mateus cansou do nome brasileiro plebeu 
        tablePessoa.Update (6, "carlos martins", "m", "1997-01-11"); //carlos se casou com a ana (martins) 
        tableTel.Update (5, "+55 44 9900 1515"); //mathews começou a ser assediado por paparazis e mudou de cel
        tableFisio.Update (3, 5, "PR", "13183128"); //mathews nao é mais um mero estagiario
        tablePaciente.Update (3, 6, "100% top"); //carlos martins recuperou movimento do braço
        tableMusculo.Update (5, "deltóide"); //reforma ortografica
        tableMovimento.Update (4, 3, "halter deltoide", "levantar halter ate altura do ombro");
        tableSessao.Update (10, 3, 3, "2018-05-04", "carlos realizou o exercicio x excepcionalmente bem");
        tableExercicio.Update (5, 3, 4, 10, "sem cutcharra alguma");
        tablePMF.Update (6, 4, 1.1, 1.6);
        tablePRF.Update (6, 4, "ascençao do braço", 0, 1);
        tablePMP.Update (6, 5, 1.0, 1.5);
        tablePRP.Update (6, 5, "subimento do braço", 0, 1);
    }

    void Deletions () 
    {
        tablePessoa.DeleteValue (5);
        tablePessoa.DeleteValue (6);
        tableTel.DeleteValue (5, "+55 44 9900 1515");
        tableFisio.DeleteValue (3);
        tablePaciente.DeleteValue (3);
        tableMusculo.DeleteValue (5);
        tableMovimento.DeleteValue (4);
        tableSessao.DeleteValue (10);
        tableExercicio.DeleteValue (5);
        tableMovimentoMusculo.DeleteValue (5, 4);
        tablePMF.DeleteValue (6);
        tablePRF.DeleteValue (6);
        tablePMP.DeleteValue (6);
        tablePRP.DeleteValue (6);
    }

    void ReadAll () 
    {
        tablePessoa.Read ();
        tableTel.Read ();
        tableFisio.Read ();
        tablePaciente.Read ();
        tableMusculo.Read ();
        tableMovimento.Read ();
        tableSessao.Read ();
        tableExercicio.Read ();
        tableMovimentoMusculo.Read ();
        tablePMF.Read ();
        tablePRF.Read ();
        tablePMP.Read ();
        tablePRP.Read ();
    }

}