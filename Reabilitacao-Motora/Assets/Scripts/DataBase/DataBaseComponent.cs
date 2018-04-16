using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

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
    string path, pathEx, pathMv;
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

        pathEx = "URI=file:" + Application.dataPath + "/Exercicios";
        pathMv = "URI=file:" + Application.dataPath + "/Movimentos";

        Directory.CreateDirectory(pathEx);
        Directory.CreateDirectory(pathMv);

        Initialize();
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
}
