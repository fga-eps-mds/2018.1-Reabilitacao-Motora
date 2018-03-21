# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
07/03|0.0.0|Adição dos artefatos do documento de visão|Djorkaeff Alexandre
07/03|0.0.1|Adição dos subitens 2.2 e 2.3|Guilherme Siqueira
07/03|0.0.2|Atualização dos subitens 3.3.1 e 3.3.2|Djorkaeff Alexandre
08/03|0.0.3|Adição do item 4|Guilherme Siqueira
08/03|0.0.4|Adição dos itens 3 e 3.1|João Lucas
# Sumário

1. [Introdução](#1)
  - 1.1 [Propósito](#1_1)
  - 1.2 [Escopo](#1_2)
  - 1.3 [Definições, acrônimos e abreviações](#1_3)
  - 1.4 [Referências](#1_4)
  - 1.5 [Visão Geral](#1_5)
2. [Posicionamento](#2)
  - 2.1 [Oportunidade de Negócio](#2_1)
  - 2.2 [Descrição do Problema](#2_2)
  - 2.3 [Instrução de Posição do Produto](#2_3)
3. [Descrições da parte interessada e dos Usuários](#3)
  - 3.1 [Resumo dos Usuários](#3_1)
  - 3.2 [Ambiente do Usuário](#3_2)
  - 3.3 [Perfis dos Envolvidos](#3_3)
  - 3.4 [Perfis dos Usuários](#3_4)
  - 3.5 [Principais Necessidades dos Usuários ou dos Envolvidos](#3_5)
  - 3.6 [Alternativas e Concorrência](#3_6)
4. [Visão Geral do Produto](#4)
5. [Recursos do Produto](#5)
6. [Restrições](#6)
  - 6.1 [Restrições de Design](#6_1)
  - 6.2 [Restrições de Implementação](#6_2)
  - 6.3 [Restrições de Segurança](#6_3)
  - 6.4 [Restrições de Uso](#6_4)

___

### 1. <a name="1">Introdução</a>

##### 1.1	<a name ="1_1">Propósito</a>

<p align = "justify">Este documento tem por objetivo estabelecer um posicionamento geral sobre a aplicação de Reabilitação motora, definindo suas principais funcionalidade e seus requisitos.</p>

##### 1.2	<a name="1_2">Escopo</a>

<p align = "justify"></p>

##### 1.3	<a name=1_3>Definições, acrônimos e abreviações</a>

* FGA - Faculdade do Gama (UnB)
* UnB - Universidade de Brasília
* MDS - Métodos de Desenvolvimento de Software
* EPS - Engenharia de Produto de Software

##### 1.4 <a name="1_4">	Referências:</a>


IBM Knowledge Center - Documento de Visão: A estrutura de tópicos do documento de visão. Disponível em: https://www.ibm.com/support/knowledgecenter/pt-br/SSWMEQ_3.0.1/com.ibm.rational.rrm.help.doc/topics/r_vision_doc.htm. Acesso em: 07 mar. 2018;

CHAVES, Felipe; SILVA, Guilherme; HORINOUCHI, Lucas; DOS SANTOS, Lucas; NÓBREGA, Lucas; DE CAMARGO, Michel; QUEIROZ, Natália. Receituário Médico: Documento de Visão.
Disponível em: https://github.com/fga-gpp-mds/2017.2-Receituario-Medico/wiki. Acesso em 07 mar. 2018;

##### 1.5 <a name="1_5">Visão geral</a>
 Este documento é dividido em 7 tópicos descrevendo os detalhes das características do software proposto.
Sendo dividido em:

* **Introdução:** no qual é introduzido os detalhes gerais sobre a visão do projeto;
* **Posicionamento:** descrevendo o problema e a oportunidade de negócio;
* **Descrições dos Envolvidos e dos Usuários:** esta seção descreve o perfil das partes interessadas no projeto;
* **Visão Geral do Produto:** Esta seção fornece uma visualização de alto nível das capacidades do produto, interfaces para outros aplicativos e configurações dos sistemas;
* **Recursos do Produto:** breve descrição dos recursos do produto;
* **Restrições:** as restrições de *design*, restrições externas, como requisitos operacionais ou regulamentares;

___

### 2. <a name="2">Posicionamento</a>

##### 2.1 <a name="2_1">Oportunidade de Negócio</a>

##### 2.2 <a name="2_2">Descrição do problema</a>

|**O problema de**|Falta de eficiência em análises fisioterapêuticas|
|:---|:---|
|**afeta**|Fisioterapeutas e pacientes|
|**cujo impacto é**|entrega de resultados quantitativos e numéricos ao fisioterapeuta|
|**uma boa solução seria**|um sistema que analise os movimentos do paciente e forneça dados precisos sobre o movimento realizado|

##### 2.3 <a name="2_3">Instrução de Posição do Produto</a>

|**Para** |Fisioterapeutas e pacientes|
|:---|:---|
|**Que** |precisem de analises mais precisas para um melhor tratamento|
|**O Reabilitação Motora**|é uma aplicação para otimizar a fisioterapia|
|**Que**|faz a leitura por sensores dos movimentos do paciente e efetua uma analise automática dos mesmos|
|**Diferente de**|avaliações subjetivas e qualitativas efetuadas por fisioterapeutas|
|**Nosso produto**|é uma solução para chegar a melhores resultados em sessões de fisioterapias|

___

### 3. <a name="3">Descrições da parte interessada e dos Usuários</a>


Nome|Descrição|Responsabilidade
--|--|--
| Equipe de Desenvolvimento | Estudantes da disciplina Métodos de Desenvolvimento de *Software* da Universidade de Brasília Campus Gama | Desenvolvimento, Documentação, Implementação e Testes do *Software* solicitado. |
| Equipe de Gestão de Processo | Estudantes da disciplina de Engenharia de Produto de *Software* da Universidade de Brasília Campus Gama | Gerir o desenvolvimento do produto, Identificar erros e *bugs* e Instruir caminhos e soluções para um bom desempenho. |
| Professora | Professora das disciplinas Métodos de Desenvolvimento de *Software* e Engenharia de Produto de *Software* da Universidade de Brasília Campus Gama | Avaliar e Orientar os estudantes de ambas disciplinas. |

##### 3.1 <a name="3_1">Resumo dos Usuários</a>

Nome|Descrição
-|-
| Paciente | Pacientes com a doença que buscam tratamento com fisioterapeutas |
| Fisioterapeuta | Profissionais da área de Fisioterapia que auxiliam pessoas com problemas de coordenação e mobilidade. | 
##### 3.2 <a name="3_2">Ambiente do Usuário</a>



##### 3.3 <a name="3_3">Perfis dos Envolvidos</a>

###### 3.3.1 Equipe de Desenvolvimento

Representante|Djorkaeff Alexandre, Guilherme de Lyra, Guilherme Siqueira, João Lucas.
-|-
**Descrição**|Desenvolvedores.
**Tipo**|Estudantes da FGA da disciplina MDS.
**Responsabilidade**|Desenvolvimento, Testes, Documentação e Implementação do *software*.
**Critérios de Sucesso**|Finalizar o desenvolvimento e realizar entrega do *software* em tempo estipulado.
**Envolvimento**|Alto.
**Problemas/Comentários**|A equipe é inexperiente na linguagem de programação utilizada no desenvolvimento, no padrão arquitetural e nas metodologias de desenvolvimento.


###### 3.3.2 Equipe de Gestão de Projeto

Representante|Lucas Malta, Vitor Falcão, Arthur Diniz, Victor Moura, Romeu Carvalho.
-|-
**Descrição**|Gerenciamento de projeto.
**Tipo**|Estudantes da matéria EPS da FGA.
**Responsabilidade**|Gerir o desenvolvimento do produto identificando problemas e apontando caminhos e soluções.
**Critérios de Sucesso**|Manter a equipe focada no projeto, gerência dos riscos associados ao projeto e finalizar o desenvolvimento do projeto.
**Envolvimento**|Alto.
**Problemas/Comentários**|Não familiarizados com o ambiente de desenvolvimento de aplicações com uso de sensores de movimento.



###### 3.3.3 Cliente



##### 3.4 <a name="3_4">Perfis dos Usuários</a>




##### 3.5 <a name="3_5">Principais Necessidades dos Usuários ou dos Envolvidos</a>

Necessidade|Interesse|Solução Atual|Solução Proposta
-|-|-|-



##### 3.6 <a name="3_6">Alternativas e Concorrência

___

### 4. <a name="4">Visão Geral do Produto</a>
A aplicação analisará de forma automática, com auxílio de sensores, o movimento do braço (desde o ombro até a mão) dos pacientes de sessões de fisioterapia, apresentando um modelo esqueletal completo do mesmo e dando para o usuário, em tempo real, os resultados da estimação dos movimentos realizados. Esses resultados são menos propensos a erros antrópicos, pois são analisados pelo software e resultados quantitativos e numéricos são entregues ao fisioterapeuta.

___

### 5. <a name="5">Recursos do Produto</a>

___

### 6. <a name="6">Restrições</a>

##### 6.1 <a name="6_1">Restrições de Design</a>


##### 6.2 <a name="6_2">Restrições de Implementação</a>


##### 6.3 <a name="6_3">Restrições de Segurança</a>


##### 6.4 <a name="6_4">Restrições de Uso</a>

___
