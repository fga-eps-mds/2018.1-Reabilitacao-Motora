# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
09/04|1.0.0|Início do Documento | João Lucas
10/04|1.1.0|Adição do subitem 1.5 e do item 3| Davi Alves
10/04|1.2.0|Adição do tópico 2| Djorkaeff Alexandre Vilela Pereira
10/04|1.2.1|Revisão e correção dos itens 1.1, 1.2, 2, 3.1 e 3.2| Guilherme de Lyra
10/04|1.3.0|Adição do subitem 1.3| Guilherme de Lyra
10/04|1.3.1|Revisão do subitem 1.3| Guilherme de Lyra
10/04|1.4.0|Adição do item 7| Guilherme de Lyra
10/04|1.5.0|Adição do subitem 4.1 e itens 8 e 9| Davi Alves
10/04|1.6.0|Adição do item 5| Guilherme Siqueira
11/04|1.6.1|Revisão dos subitens 1.3, 4.1, 5.1.1, 8 e 9| Guilherme de Lyra

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
|**MDS**| Métodos de Desenvolvimento de Software
|**EPS**| Engenharia de Produto de Software
|**kB**| Kilobyte

### 1.4 Referências

### 1.5 Visão Geral
<p align = "justify">Este documento descreve e detalha as características de arquitetura do software a ser desenvolvido, identificando e especificando os possíveis problemas assim como também, aprofundar e classificar os escopos do projeto. Inicialmente será apresentada a arquitetura da solução e logo em seguida serão descritas as metas estabelecidas e as restrições da arquitetura proposta. Depois serão definidas diversas visões sobre fundamentos da arquitetura. Enfim serão apresentados todos os recursos que são referentes ao tamanho, desempenho e também a qualidade do software.</p>

## 2. Representação da Arquitetura
<p align = "justify">A arquitetura utilizada no projeto é a arquitetura denominada "Entity Component System" (ECS, "entidade-componente-sistema"), a escolha dessa arquitetura foi feita por vários motivos, dentre eles a sua facilidade de aplicação dentro do Unity 3D e também por ser a arquitetura mais utilizada em jogos eletrônicos e sistemas com interface gráfica 3D nos tempos atuais. Essa arquitetura tem como princípio a "composição ao invés de herança", o que permite uma flexibilidade maior na criação de novas entidades. Com a ECS, criamos um sistema de hierarquia entre as entidades e seus componentes, podendo assim reutilizar os componentes e dar o mesmo comportamento específico para diversas entidades que tem fins totalmente diferentes. Cada entidade consiste de um ou mais componentes que adicionam comportamento ou funcionalidade para a mesma, portanto o comportamento de uma entidade qualquer pode ser alterado durante o tempo de execução simplesmente adicionando ou removendo um componente da mesma. Isso elimina os problemas de ambiguidade que eram gerados nas hierarquias feitas por heranças profundas e vastas, que se tornam difíceis de enteder, manter e estender.</p>

## 3. Metas e Restrições de Arquitetura
### 3.1 Metas
<p align = "justify">O sistema deve ter uma plataforma de captura, monitoramento e avaliação de movimentos; de forma que venha a facilitar, para o fisioterapeuta, a visualização do progresso do paciente. </p>

### 3.2 Restrições

<p align = "justify">O sistema a ser desenvolvido terá como base de sua arquitetura e interface gráfica a utilização da IDE Unity 3D. Um asset do Unity, específico para o sensor, deve estar devidamente contido nos Assets para a captura e sincronismo do movimento humano no sistema.<br />
O projeto tera sua implementação utilizando a linguagem de programação C#(C-Sharp).
Deverá ser ultilizado o ambiente Windows 10, porém, as versões superiores a Windows 7.0 possivelmente poderão suportar o programa.</p>

## 4. Visão de Casos de Uso

### 4.1 Atores

|**Fisioterapeuta/Operador**|<p align = "justify">Os profissionais responsáveis pela reabilitação estarão hábeis a cadastrarem-se no sistema e, também, a cadastrar pacientes. Após isso, numa sessão, poderão captar os movimentos do paciente, visualizar gráficos e dados concretos acerca do movimento realizado, e, também, salvar essas informações para acessá-las novamente quando necessário for; viabilizando, portanto, uma análise muito mais precisa e objetiva sobre a condição e evolução do paciente.</p>

### 4.2 Diagrama de Casos de Usos

### 4.3 Descrições de Casos de Uso

## 5. Visão Lógica

### 5.1 Pacotes de design Significativos do Ponto de Vista da Arquitetura

#### 5.1.1 GameObjects e Componentes
<p align = "justify">Devido à arquitetura de componentes inerente ao Unity, tudo que há no projeto é um GameObject. O GameObject é uma combinação de componentes. Ou seja: ele é a base para a adição de componentes ao objeto da scene, determinando o comportamento do mesmo nela. Basicamente tudo no Unity é um componente. Desde scripts a câmeras. Quando um componente ou um script é adicionado a um GameObject, esse componente adicionado pode ser acessado através da função GetComponent da classe GameObject. Uma vez que o GameObject é destruído, todos os componentes abaixo da sua hierarquia são destruídos.</p><br />
<p align = "justify">Dentro de todo GameObject há componentes, sendo exemplos deles Transform (representa a posição, rotação e escala do objeto na scene), RigidBody (dá propriedade fisicas ao GameObject), Renderers (componentes que permitem exibição dos GameObjects em cena), etc.</p><br />

Para melhor visualização da relação entre os componentes no Unity, segue um diagrama:   
![Diagrama Componentes](http://oi64.tinypic.com/23hsntc.jpg)

## 6. Visão de Processos

## 7. Visão de Dados
### 7.1 DER
![DER](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/der.png)    
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/der.png)
### 7.2 LÓGICO
![LÓGICO](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/logico.png)    
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/logico.png)


## 8. Tamanho e Desempenho

<p align = "justify">Estimamos que um movimento de duração de 15 segundos gera, em média, aproximadamente 750 pontos (o que, salvo num arquivo, dá aproximadamente 6kB); tendo em vista que em uma sessão poucos movimentos serão realizados de forma monitorada (já que o sensor tem a finalidade de mapear e estimar a situação do paciente, e que, após isso, o fisioterapeuta conduzirá os movimentos necessários), pode-se inferir que o sistema não processará uma grande quantidade de dados — principalmente por se tratar de um sistema local/*offline*. Seu desempenho será determinado, principalmente, pelo computador utilizado pelo operador.</p>

## 9. Qualidade

<p align = "justify">O sistema irá utilizar padrões de interface gráfica desktop desenvolvido na linguagem C# em paralelo com o software Unity 3D. Também deverá ser compatível com os principais sistemas operacionais. Além disso, os desenvolvedores deverão adotar boas práticas para que o sistema como um todo venha ser desenvolvido com qualidade satisfatória.</p>
