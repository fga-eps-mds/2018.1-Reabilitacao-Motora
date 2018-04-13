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
10/04|1.5.0|Adição do subitem 4.2 e itens 8 e 9| Davi Alves
10/04|1.6.0|Adição do item 5| Guilherme Siqueira
11/04|1.6.1|Revisão dos subitens 1.3, 4.2, 5.1.1, 8 e 9| Guilherme de Lyra
11/04|1.7.0|Adição dos subitens 4.1 e 4.3| Guilherme de Lyra
11/04|1.8.0|Revisão e Complementação do item 2| João Lucas
11/02|1.8.1|Revisão dos itens 2, 7 e subitem 4.1| Davi Alves
11/04|1.9.0|Adição do subitem 6.1| João Lucas
11/04|1.9.1|Revisão do subitem 3.2| Davi Alves
12/04|1.9.2|Atualização o Diagrama de Casos de Uso | Guilherme de Lyra
12/04|1.9.3|Revisão e Pequenas Alterações| João Lucas
12/04|1.10.0|Modificação do subitem 6.1| João Lucas
12/04|1.10.1|Revisão do Documento| João Lucas

# Sumário
----------------
 1. [Introdução](#1)
    * 1.1 [Finalidade](#1_1)
    * 1.2 [Escopo](#1_2)
    * 1.3 [Definições, Acrônimos e Abreviações](#1_3)
    * 1.4 [Referências](#1_4)
    * 1.5 [Visão Geral](#1_5)
 2. [Representação da Arquitetura](#2)
 3. [Metas e Restrições de Arquitetura](#3)
 4. [Visão dos Casos de Uso](#4)
    * 4.1 [Diagrama de Casos de Uso](#4_1)
    * 4.2 [Atores de Casos de Uso](#4_2)
    * 4.3 [Descrições de Casos de Uso](#4_3)
 5. [Visão Lógica](#5)
    * 5.1 [Pacotes de Design Significativos do Ponto de Vista da Arquitetura](#5_1)
    * 5.1.1 [Classe](#5_1_1)
    * 5.1.2 [Pacotes](#5_1_2)
 6. [Visão de Dados](#6)
    * 6.1 [MER](#6_1)
    * 6.2 [DER](#6_2)
    * 6.3 [Diagrama Lógico](#6_3)
 7. [Tamanho e Desempenho](#7)
 8. [Qualidade](#8)

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
|**MMO**| Massive Multiplayer Online Game - Jogo Online em Massa de Multijogadores
|**MER**| Modelo Entidade-Relacionamento
|**DER**| Diagrama Entidade-Relacionamento

### 1.4 Referências
<p align = "justify"> Este documento faz referência ao seguinte link e  documento.

<p align = "justify">LINS DE ALBUQUERQUE, Leonardo. **Plataforma para captura e estimação de movimentos em membro superior utilizando Sistemas Dinâmicos Lineares Chaveados**. 150 f. Tese (Monografia) - Departamento de Engenharia Elétrica, Universidade de Brasília, 2017 </p>

* **Unity** </p>
* -- https://unity3d.com/pt/

### 1.5 Visão Geral
<p align = "justify">Este documento descreve e detalha as características de arquitetura do software a ser desenvolvido, identificando e especificando os possíveis problemas assim como também, aprofundar e classificar os escopos do projeto. Inicialmente será apresentada a arquitetura da solução e logo em seguida serão descritas as metas estabelecidas e as restrições da arquitetura proposta. Depois serão definidas diversas visões sobre fundamentos da arquitetura. Enfim serão apresentados todos os recursos que são referentes ao tamanho, desempenho e também a qualidade do software.</p>

## 2. Representação da Arquitetura
<p align = "justify">A arquitetura utilizada no projeto é a arquitetura denominada "Entity Component System" (ECS, "entidade-componente-sistema"), a escolha dessa arquitetura foi feita por vários motivos, dentre eles a sua facilidade de aplicação dentro do Unity 3D e também por ser a arquitetura mais utilizada em jogos eletrônicos e sistemas com interface gráfica 3D nos tempos atuais. Essa arquitetura tem como princípio a "composição ao invés de herança", o que permite uma flexibilidade maior na criação de novas entidades. Com a ECS, criamos um sistema de hierarquia entre as entidades e seus componentes, podendo assim reutilizar os componentes e dar o mesmo comportamento específico para diversas entidades que tem fins totalmente diferentes. Cada entidade consiste de um ou mais componentes que adicionam comportamento ou funcionalidade para a mesma, portanto o comportamento de uma entidade qualquer pode ser alterado durante o tempo de execução simplesmente adicionando ou removendo um componente da mesma. Isso elimina os problemas de ambiguidade que eram gerados nas hierarquias feitas por heranças profundas e vastas, que se tornam difíceis de entender, manter e estender. </p>

![Entity-Component-System](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/doc_arq/docs/imagens/Arquitetura/ECS.png) </p>
**Figura 1**- Diagrama de classes</p>
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/doc_arq/docs/imagens/Arquitetura/ECS.png)

<p align = "justify">Adam Martin, um desenvolvedor de jogos MMO, criou a terminologia mais utilizada de jogos. Em jogos, a arquitetura trabalha com "sistemas" que seriam como funções que interagem com outras entidades que tenham componentes físicos e visíveis. Entidade é o objeto que consiste apenas de uma identificação única, Componentes são os dados brutos do aspecto do objeto e como interage com o mundo e Sistema são *threads* que executam ações das entidades que possuem mesmos componentes.
</p>

## 3. Metas e Restrições de Arquitetura
### 3.1 Metas
<p align = "justify">O sistema deve ter uma plataforma de captura, monitoramento e avaliação de movimentos; de forma que venha a facilitar, para o fisioterapeuta, a visualização do progresso do paciente. </p>

### 3.2 Restrições

<p align = "justify">O sistema a ser desenvolvido terá como base de sua arquitetura e interface gráfica a utilização da *game engine* Unity 3D. Um *asset* do Unity, específico para o sensor, deve estar devidamente contido nos *Assets* para a captura e sincronismo do movimento humano no sistema.<br />
A implementação do projeto será a linguagem de programação C# (C-Sharp).Ele Deverá ser utilizado no ambiente Windows 10.</p>

## 4. Visão dos Casos de Uso

### 4.1 Diagrama de Casos de Uso

![DiagramaCasoDeUso](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/doc_arq/docs/imagens/Arquitetura/Casos_de_uso.png)
**Figura 2**- Diagrama de casos de uso</p>
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/doc_arq/docs/imagens/Arquitetura/Casos_de_uso.png)

### 4.2 Atores de Casos de Uso

|**Ator**|**Descrição**
:-:|:-:
|**Fisioterapeuta/Operador**|<p align = "justify">Os profissionais responsáveis pela reabilitação estarão hábeis a cadastrarem-se no sistema e, também, a cadastrar pacientes. Após isso, numa sessão, poderão captar os movimentos do paciente, visualizar gráficos e dados concretos acerca do movimento realizado, e, também, salvar essas informações para acessá-las novamente quando necessário for; viabilizando, portanto, uma análise muito mais precisa e objetiva sobre a condição e evolução do paciente.</p>

### 4.3 Descrições de Casos de Uso

| **Caso de uso** | **Descrição** |
:-:|:-:
| **UC01 - Manter movimento** | Criar, alterar ou deletar um movimento. |
| **UC02 - Manter paciente** | Criar, alterar ou deletar um paciente. |
| **UC03 - Manter rótulo** | Criar, alterar ou deletar um rótulo de um movimento. |
| **UC04 - Manter fisioterapeuta** | Criar, alterar ou deletar um fisioterapeuta. |


## 5. Visão Lógica

### 5.1 Pacotes de design Significativos do Ponto de Vista da Arquitetura

#### 5.1.1 GameObjects e Componentes
<p align = "justify">Devido à arquitetura de componentes inerente ao Unity, tudo que há no projeto é um *GameObject*. O *GameObject* é uma combinação de componentes. Ou seja: ele é a base para a adição de componentes ao objeto da *scene*, determinando o comportamento do mesmo nela. Basicamente tudo no Unity é um componente. Desde scripts a câmeras. Quando um componente ou um script é adicionado a um *GameObject*, esse componente adicionado pode ser acessado através da função *GetComponent* da classe *GameObject*. Uma vez que o *GameObject* é destruído, todos os componentes abaixo da sua hierarquia são destruídos.</p><br />
<p align = "justify">Dentro de todo *GameObject* há componentes, sendo exemplos deles *Transform* (representa a posição, rotação e escala do objeto na *scene*), *RigidBody* (dá propriedade físicas ao *GameObject*), Renderers (componentes que permitem exibição dos *GameObjects* em cena), etc.</p><br />

Para melhor visualização da relação entre os componentes no Unity, segue um diagrama:   </p>
![Diagrama Componentes](http://oi64.tinypic.com/23hsntc.jpg) </p>

## 6. Visão de Dados

### 6.1 MER

#### 6.1.1 Entidades

**PESSOA** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idPessoa** | Chave Primária </p> Obrigatório | INTEGER | Identificação da Pessoa
**nomePessoa** | Obrigatório | VARCHAR(30) | Nome da Pessoa
**sexo** | Obrigatório | CHAR(1) | Sexo da Pessoa
**dataNascimento** | Obrigatório | DATE | Data de Nascimento da Pessoa

**TELEFONE** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idPessoa** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação da Pessoa
**telefone** | Obrigatório | VARCHAR(18) | Número do Telefone da Pessoa

**FISIOTERAPEUTA** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idFisioterapeuta** | Chave Primária </p> Obrigatório | INTEGER | Identificação de um Fisioterapeuta
**idPessoa** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação da Pessoa
**regiao** | Opcional | VARCHAR(2) | Região de tratamento do Fisioterapeuta
**crefito** | Opcional | VARCHAR(10) | Identificação do CREFITO do Fisioterapeuta

**PACIENTE** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idPaciente** | Chave Primária </p> Obrigatório | INTEGER | Identificação de um Paciente
**idPessoa** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação da Pessoa
**observacoes** | Opcional | VARCHAR(300) | Observações do Paciente


**MÚSCULO** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idMusculo** | Chave Primária </p> Obrigatório | INTEGER | Identificação de um Músculo
**nomeMusculo** | Obrigatório | VARCHAR(20) | Nome do Músculo


**SESSÃO** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idSessao** | Chave Primária </p> Obrigatório | INTEGER | Identificação da Sessão
**idFisioterapeuta** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação de um Fisioterapeuta
**idPaciente** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação de um Paciente
**dataSessao** | Obrigatório | DATE | Data da realização da Sessão de Exercícios
**observacaoSessao** | Opcional | VARCHAR(300) | Observação da Sessão

**MOVIMENTO** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idMovimento** | Chave Primária </p> Obrigatório | INTEGER | Identificação do Movimento
**idFisioterapeuta** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação de um Fisioterapeuta
**nomeMovimento** | Obrigatório | VARCHAR(50) | Nome do Movimento
**descricaoMovimento** | Opcional | VARCHAR(150) | Descrição do Movimento
**pontosMovimento** | Obrigatório | VARCHAR(150) | Pontos do Movimento

**EXERCÍCIO** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idExercicio** | Chave Primária </p> Obrigatório | INTEGER | Identificação do Exercício
**idPaciente** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação de um Paciente
**idMovimento** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação do Movimento
**idSessao** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação da Sessão
**descricaoExercicio** | Opcional | VARCHAR(150) | Descrição do Exercício
**pontosExercicio** | Obrigatório | VARCHAR(150) | Pontos do Exercícios

**PONTOS RÓTULO FISIOTERAPEUTA** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idRotuloFisioterapeuta** | Chave Primária </p> Obrigatório | INTEGER | Identificação dos Pontos de Rótulo do Fisioterapeuta
**idMovimento** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação do Movimento
**estagioMovimentoFisio** | Obrigatório | VARCHAR(30) | Estagio do Movimento do Fisioterapeuta solicita
**tempoInicial** | Obrigatório | REAL | Tempo Inicial do Movimento
**tempoFinal** | Obrigatório | REAL | Tempo Final do Movimento

**PONTOS RÓTULO PACIENTE** </p>

Atributo|Propriedade|Tipo|Descrição
-|-|-|-
**idRotuloPaciente** | Chave Primária </p> Obrigatório | INTEGER | Identificação dos Pontos de Rótulo do Paciente
**idExercicio** | Chave Estrangeira </p> Obrigatório | INTEGER | Identificação do Exercício
**estagioMovimentoPaciente** | Obrigatório | VARCHAR(30) | Estagio do Movimento que o Paciente executa
**tempoInicial** | Obrigatório | REAL | Tempo Inicial do Movimento
**tempoFinal** | Obrigatório | REAL | Tempo Final do Movimento

#### 6.1.2 Relacionamentos

**PESSOA** especializa totalmente em **FISIOTERAPEUTA** ou **PACIENTE**, pois ambas as entidades compartilham vários atributos em comum.

**MOVIMENTO** -- estimula – **MÚSCULO**
Um movimento estimula, obrigatoriamente, um ou mais músculos; e, um músculo, é estimulado por vários tipos de movimentos.
(Cardinalidade n:m)

**MOVIMENTO** -- baseia -- **EXERCÍCIO**
O exercício, realizado pelo paciente, é baseado num movimento ideal.
(Cardinalidade 1:n)

**FISIOTERAPEUTA** -- cadastra -- **MOVIMENTO**
Um fisioterapeuta cadastra um ou vários movimentos.
(Cardinalidade 1:n)

**PACIENTE** -- realiza – **EXERCÍCIO**
Um paciente realiza um ou vários movimentos.
(Cardinalidade 1:n)

**SESSÃO** -- possui -- **EXERCÍCIO**
Numa sessão, múltiplos exercícios são realizados.
(Cardinalidade 1:n)

**PACIENTE** -- participa -- **SESSÃO**
Um paciente participa de uma ou várias sessões.
(Cardinalidade 1:n)

**FISIOTERAPEUTA** -- conduz -- **SESSÃO**
Um fisioterapeuta conduz uma ou varias sessões.
(Cardinalidade 1:n

**MOVIMENTO** -- gera – **PONTOS RÓTULO FISIOTERAPEUTA**
Um movimento gera n pontos nos eixos x e y.
(Cardinalidade 1:n)

**EXERCÍCIO** -- gera – **PONTOS RÓTULO PACIENTE**
Um exercício gera n pontos nos eixos x e y.
(Cardinalidade 1:n)


### 6.2 DER
![DER](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/der.png)
**Figura 3**- Diagrama Entidade-Relacionamento</p>
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/der.png)
### 6.3 Diagrama Lógico
![LÓGICO](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/logico.png)
**Figura 4**- Diagrama ME-R Lógico</p>
[Clique aqui para visualizar a imagem](https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/database/Banco_de_Dados/logico.png)


## 7. Tamanho e Desempenho

<p align = "justify">Estimamos que um movimento de duração de 15 segundos gera, em média, aproximadamente 750 pontos (o que, salvo num arquivo, dá aproximadamente 6kB); tendo em vista que em uma sessão poucos movimentos serão realizados de forma monitorada (já que o sensor tem a finalidade de mapear e estimar a situação do paciente, e que, após isso, o fisioterapeuta conduzirá os movimentos necessários), pode-se inferir que o sistema não processará uma grande quantidade de dados — principalmente por se tratar de um sistema local/*offline*. Seu desempenho será determinado, principalmente, pelo computador utilizado pelo operador.</p>

## 8. Qualidade

<p align = "justify">O sistema irá utilizar padrões de interface gráfica desktop desenvolvido na linguagem C# em paralelo com o software Unity 3D. Também deverá ser compatível com os principais sistemas operacionais. Além disso, os desenvolvedores deverão adotar boas práticas para que o sistema como um todo venha ser desenvolvido com qualidade satisfatória.</p>
