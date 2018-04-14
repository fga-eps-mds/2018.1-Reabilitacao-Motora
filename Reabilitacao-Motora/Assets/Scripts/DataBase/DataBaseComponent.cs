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
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

/**
* Essa classe é um aclopador que serve de esqueleto para poder ser adaptado posteriormente de acordo com as necessidades.
*/
public class DataBaseComponent : MonoBehaviour
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
    PontosRotuloFisioterapeuta tablePRF;
    PontosRotuloPaciente tablePRP;


    /**
    * Chama as funções para inicio do banco
    */
    void Start()
    {
        path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

        Initialize();

        Insertions();

        Updates();
        ReadAll();

        Deletions();
        ReadAll();
    }

    /**
    * Inicializa as tabelas necessárias para o sistema.
    */
    void Initialize()
    {
        tablePessoa = new Pessoa(path);
        tableTel = new Telefone(path);
        tableFisio = new Fisioterapeuta(path);
        tablePaciente = new Paciente(path);
        tableMusculo = new Musculo(path);
        tableMovimento = new Movimento(path);
        tableSessao = new Sessao(path);
        tableExercicio = new Exercicio(path);
        tableMovimentoMusculo = new MovimentoMusculo(path);
        tablePRF = new PontosRotuloFisioterapeuta(path);
        tablePRP = new PontosRotuloPaciente(path);
    }

    /**
    * Insere valores nas tabelas à fins de teste
    */
    void Insertions()
    {
        tablePessoa.Insert("mateus", "m", "1995-11-04");
        tablePessoa.Insert("carlos", "m", "1997-01-11");
        //tableTel.Insert (5, "+55 44 9998 1717");
        tableFisio.Insert(5);
        tablePaciente.Insert(6, "semi top");
        tableMusculo.Insert("deltoide");
        tableMovimento.Insert(3, "levantando peso pra cima", "utilizando um halter levante-o ate altura do ombro", "MVtest5.txt");
        tableSessao.Insert(3, 3, "2018-05-04", "carlos realizou o exercicio x bem");
        tableExercicio.Insert(3, 4, 10, "leve dificuldade no começo", "EXtest5.txt");
        tableMovimentoMusculo.Insert(5, 4);
        tablePRF.Insert(4, "ascensao do braço", 0, 1);
        tablePRP.Insert(5, "ascensao do braço", 0, 1);
    }

    /**
    * Atualiza valores já cadastrados anteriormente nas relações
    */
    void Updates()
    {
        tablePessoa.Update(5, "mathews", "m", "1995-11-04");
        tablePessoa.Update(6, "carlos martins", "m", "1997-01-11");
        //tableTel.Update (5, "+55 44 9900 1515");
        tableFisio.Update(3, 5, "PR", "13183128");
        tablePaciente.Update(3, 6, "100% top");
        tableMusculo.Update(5, "deltóide");
        tableMovimento.Update(4, 3, "halter deltoide", "levantar halter ate altura do ombro", "mv_halterdeltoide_5.txt");
        tableSessao.Update(10, 3, 3, "2018-05-04", "carlos realizou o exercicio x excepcionalmente bem");
        tableExercicio.Update(5, 3, 4, 10, "sem cutcharra alguma", "ex_2018-05-04_5.txt");
        tablePRF.Update(6, 4, "ascençao do braço", 0, 1);
        tablePRP.Update(6, 5, "subimento do braço", 0, 1); //*/
    }

    /**
    * Deleta valores cadastrados anteriormente nas relações
    */
    void Deletions()
    {
        tablePessoa.DeleteValue(5);
        tablePessoa.DeleteValue(6);
        //tableTel.DeleteValue (5, "+55 44 9998 1717"); //ja q n ta updatando...
        tableFisio.DeleteValue(3);
        tablePaciente.DeleteValue(3);
        tableMusculo.DeleteValue(5);
        tableMovimento.DeleteValue(4);
        tableSessao.DeleteValue(10);
        tableExercicio.DeleteValue(5);
        tableMovimentoMusculo.DeleteValue(5, 4);
        tablePRF.DeleteValue(6);
        tablePRP.DeleteValue(6);
    }

    /**
    * Lê valores cadastrados nas relações
    */
    void ReadAll()
    {
        tablePessoa.Read();
        tableTel.Read();
        tableFisio.Read();
        tablePaciente.Read();
        tableMusculo.Read();
        tableMovimento.Read();
        tableSessao.Read();
        tableExercicio.Read();
        tableMovimentoMusculo.Read();
        tablePRF.Read();
        tablePRP.Read();
    }
}
