# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
09/04|1.0.0|Início do Documento | João Lucas
10/04|1.1.0|Adição do subitem 1.5 e do item 3| Davi Alves
10/04|1.2.0|Adição do tópico 2| Djorkaeff Alexandre Vilela Pereira
10/04|1.2.1|Revisão e correção dos itens 1.1, 1.2, 2, 3.1 e 3.2| Guilherme de Lyra
10/04|1.3.0|Adição do subitem 1.3| Guilherme de Lyra

# Sumário
----------------
* 1. [Introdução](#1)
    * 1.1 [Finalidade](#1_1)
    * 1.2 [Escopo](#1_2)
    * 1.3 [Definições, Acrônimos e Abreviações](#1_3)
    * 1.4 [Referências](#1_4)
    * 1.5 [Visão Geral](#1_5)
* 2. [Representação da Arquitetura](#2)
* 3. [Metas e Restrições de Arquitetura](#3)
* 4. [Visão de Casos de Uso](#4)
    * 4.1 [Atores de Casos de Uso](#4_1)
    * 4.2 [Descrições de Casos de Uso](#4_2)
* 5. [Visão Lógica](#5)
    * 5.1 [Pacotes de Design Significativos do Ponto de Vista da Arquitetura](#5_1)
    * 5.1.1 [Classe](#5_1_1)
    * 5.1.2 [Pacotes](#5_1_2)
* 6. [Visão de Processos](#6)
* 7. [Visão de Dados](#7)
* 8. [Tamanho e Desempenho](#8)

Documento de Arquitetura de Software
------------------------------------

## 1. Introdução

### 1.1 Finalidade
 <p align = "justify">Este documento possui como finalidade uma visão geral abrangente à implementação arquitetural do projeto Reabilitação Motora - FisioTech.
Desenvolvido pelos alunos das disciplinas de Engenharia de Produto de Software e Métodos de Desenvolvimento de Software com o intuito de ajudar no tratamento de pessoas que sofrem de paralisia do membro superior.</p>

### 1.2 Escopo
 <p align = "justify">Este artefato documenta a arquitetura a ser implementada no software e abrangendo assuntos relacionados as metas e restrições da arquitetura, visão de casos de uso, visão lógica, implementação, dados, tamanho e desempenho.</p>

### 1.3 Definições, Acrônimos e Abreviações
Abreviação|Significado
:-:|:-:
|**ECS**| Entity Component System (em tradução livre: "sistema entidade componente")

### 1.4 Referências

### 1.5 Visão Geral
<p align = "justify">Este documento descreve e detalha as características de arquitetura do software a ser desenvolvido, identificando e especificando os possíveis problemas assim como também, aprofundar e classificar os escopos do projeto. Inicialmente será apresentada a arquitetura da solução e logo em seguida serão descritas as metas estabelecidas e as restrições da arquitetura proposta. Depois serão definidas diversas visões sobre fundamentos da arquitetura. Enfim serão apresentados todos os recursos que são referentes ao tamanho, desempenho e também a qualidade do software.</p>

## 2. Representação da Arquitetura
<p align = "justify">A arquitetura utilizada no projeto é a arquitetura denominada "Entity Component System" (ECS, "entidade-componente-sistema"), a escolha dessa arquitetura foi feita por vários motivos, dentre eles a sua facilidade de aplicação dentro do Unity 3D e também por ser a arquitetura mais utilizada em jogos eletrônicos e sistemas com interface gráfica 3D nos tempos atuais. Essa arquitetura tem como princípio a "composição ao invés de herança", o que permite uma flexibilidade maior na criação de novas entidades. Com a ECS, criamos um sistema de hierarquia entre as entidades e seus componentes, podendo assim reutilizar os componentes e dar o mesmo comportamento específico para diversas entidades que tem fins totalmente diferentes. Cada entidade consiste de um ou mais componentes que adicionam comportamento ou funcionalidade para a mesma, portanto o comportamento de uma entidade qualquer pode ser alterado durante o tempo de execução simplesmente adicionando ou removendo um componente da mesma. Isso elimina os problemas de ambiguidade que eram gerados nas hierarquias feitas por heranças profundas e vastas, que se tornam difíceis de enteder, manter e estender.</p>

## 3. Metas e Restrições de Arquitetura
### 3.1 Metas
<p align = "justify">O sistema deve ter uma plataforma de captura, monitoramento e avaliação de movimentos; de forma que venha a facilitar, para o fisioterapeuta, a visualização do progresso do paciente. </p>

### 3.2 Restrições

<p align = "justify">O sistema a ser desenvolvido terá como base de sua arquitetura e interface gráfica a utilização da IDE Unity 3D. Um asset do Unity, específico para o sensor, deve estar devidamente contido nos Assets para a captura e sincronismo do movimento humano no sistema.</p><br />
O projeto tera sua implementação utilizando a linguagem de programação C#(C-Sharp).
Deverá ser ultilizado o ambiente Windows 10, porém, as versões superiores a Windows 7.0 possivelmente poderão suportar o programa.</p><br />

## 4. Visão de Casos de Uso

### 4.1 Atores de Casos de Uso

### 4.2 Descrições de Casos de Uso

## 5. Visão Lógica

### 5.1 Pacotes de design Significativos do Ponto de Vista da Arquitetura

#### 5.1.1 Classe

#### 5.1.2 Pacotes

## 6. Visão de Processos

## 7. Visão de Dados

## 8. Tamanho e Desempenho