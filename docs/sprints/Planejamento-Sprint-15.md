## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> tem como objetivo:</p>

- Melhorar ainda mais o ritmo de trabalho que foi quase constante
- Integrar o <i>software</i> com o aplicativo de sensor
- Arrumar o máximo de falhas encontradas nas <i>sprints</i> anteriores
- Melhorar o UX para entrega final da segunda <i>release</i>
- Corrigir o máximo de issues possíveis


## 2. Papéis


| <img src="https://raw.githubusercontent.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/development/docs/imagens/grupo/Vitor_Falc%C3%A3o.png" width="200" height="200"/> |  <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Lucas_Malta.png?raw=true" width="200" height="200"/> |
|:--:|:--:|
| **Scrum Master** | **Product Owner** |

| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Romeu_Antunes.png?raw=true" width="200" height="200"/> | <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Victor_Moura.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Arthur_Diniz.png?raw=true" width="200" height="200"/> |
|:--:|:--:|:--:|
| **DevOps** | **Arquitetura** | **Joker** |

| Time de Desenvolvimento |
|:--:|
| Alexandre Djorkaeff |
| Davi Alves |
| Guilherme de Lyra |
| Guilherme Siqueira |
| João Lucas |

## 3. Tamanho da _Sprint_

| Data de Início | 18/06/2018 |
|:--|:--:|
| **Data de Término** | **24/06/2018** |
| **Pontos Planejados** | **xx**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no -A realizar-


## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/18)

-------

## 6. Tarefas a serem realizadas


### [Refatorar Telas de Ajuda](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/325)

#### Descrição:
Com todas correções acontecendo, uma atualização das telas de ajuda devem ser feitas.

#### Critérios de aceitação
- Todas as telas de ajuda devem ser atualizadas com as correções realizadas das últimas sprints. 


**Pontos:** 1.

---

### [Pesquisar movimento/exercício](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/249)

#### Descrição:
Uma search-box onde é possivel pesquisar pelo nome do movimento.

#### Critérios de aceitação
- Campos de busca funcional
- Listagem correta

**Pontos:** 5.

---

### [Destacar label de movimento](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/291)

#### Descrição:
Destacar os rótulos dos movimentos em relação aos de exercício, de alguma forma.

#### Critérios de aceitação
- Label diferente de outras
- Pop-up de deleção informa se o rotulo é de movimento ou de exercício

**Pontos:** 3.

---

### [Pesquisa por músculo](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/250)

#### Descrição:
Utilizar o campo de busca de movimento para buscar movimentos que utilizam apenas o(s) musculo(s) desejado(s).

#### Critérios de aceitação
- Listar todos os movimentos que utilizam os musculos inseridos 
- Tokenizar (com Regex por exemplo) o input de modo que a linguagem possa ser o mais natural possível

**Pontos:** 2.

---

### [Atualizar doxygen](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/260)

#### Descrição:
Para manter sempre a documentação do doxygen atualizada, rodar o script para gerar uma nova pagina é extremamente importante.

#### Critérios de aceitação
- Pagina do doxygen sem estar quebrando
- Pagina com todos os links funcionando

**Pontos:** 1.

---

### [Card de visualizar sessão deve ter as observações](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/280)

#### Descrição:
Atualmente, o card de sessão possui apenas o seu nome (data da sessão). Além disso, deve-se adicionar as observações da sessão, escritas com fonte menor que o título, no mesmo card.


#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 3.

---

### [Campo de texto com entrada de teclado duplicada](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/270)

#### Descrição:
Em computadores com Ubuntu (unica distro que apresentou problemas até agora), os campos de texto estão duplicando as letras inseridas pelo teclado.

**Pontos:** 2.

---

### [Não é possível visualizar corretamente os movimentos executados na sessão](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/275)

#### Descrição:
Atualmente, a cena de visualizar o movimento realizado na sessão não possui nem o gráfico apresentando o movimento realizado nem a execução do movimento em si. Além disso há dois modelos 3D que, pela falta de informações, não possuem razão para serem duplicados.

#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 3.

---

### [Escrever PlayTests para testes de aceitação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/271)

#### Descrição:
Escrever playtests que ajam como testes de aceitação para aplicar a técnica de testes de regressão.

#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 3.

---

### [Melhorar a visualização do fisioterapeuras ja cadastrados](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/268)

#### Descrição:
Criar um card para colocar os fisioterapeutas com mais informações alem do nome como, CREFITO e telefone

#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 1.

---

### [Personagem não aparece quando não se seleciona nenhum](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/264)

#### Descrição:
Quando não há a seleção de um personagem, não há opção default e, como resultado, a tela de captação de movimento de paciente fica sem modelo 3D.

#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 1.

---

### [Melhorar README do projeto](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/256)

#### Descrição:
Para ter um projeto mais apresentavel para a R2 é interessante ajustar o README

#### Critérios de aceitação
- README não estar quebrando

**Pontos:** 1.

---

### [Melhorar a qualidade de comentários no código](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/259)

#### Descrição:
Antes de atualizar o doxygen é interessante revisar os comentários no código e atualizar as classes que estão faltando.

#### Critérios de aceitação
- Testes passando
- Build passando

**Pontos:** 1.

---

### [Tutorial para Desenvolvedores](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/243)

#### Descrição:
Um documento ensinando como contribuir para o projeto, indicando o que é cada script, do que cada um depende, qual o flow mais natural entre os scripts etc

#### Critérios de aceitação
- Tornar o aprendizado do software o mais simples possível

**Pontos:** 13.

---

### [Progress bar download (LAUNCHER)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/235)

#### Descrição:
Para o usuário ter uma ideia de como está o andamento do download, criar uma progress bar como a porcentagem de download do arquivo.

#### Critérios de aceitação
- Build passando
- Download sendo efetuado
- Percentual correto do download e instalação

**Pontos:** 2.
