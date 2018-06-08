## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> tem como objetivo:</p>

- Refatoração geral do UX para tornar o projeto utilizável.
- Finalização das configurações de pipeline.
- Refatoração geral das features implementadas focando estabilidade no produto para possibilitar entregas contínuas estáveis nas próximas sprints.

## 2. Papéis

| <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Victor_Moura.png?raw=true" width="200" height="200"/> |  <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Lucas_Malta.png?raw=true" width="200" height="200"/> |
|:--:|:--:|
| **Scrum Master** | **Product Owner** |

| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Romeu_Antunes.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Arthur_Diniz.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Vitor_Falc%C3%A3o.png?raw=true" width="200" height="200"/> |
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

| Data de Início | 20/05/2018 |
|:--|:--:|
| **Data de Término** | **27/05/2018** |
| **Pontos Planejados** | **37**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no -A realizar-



## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/13)

-------

## 6. Tarefas a serem realizadas


### [Otimização do fluxo entre cenas e do visual da aplicação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/186)

#### Descrição:
Otimização do fluxo entre cenas para melhor apresentação ao usuário. Melhorias no visual do projeto.

#### Critérios de Aceitação
- Fluxo com menor acoplamento de cenas
- Telas refatoradas

#### Tarefas
- Mudar paleta de cores
- Manter banco de dados funcional
- Manter estrutura de Prefabs


**Pontos:** 8.

---

### [Melhorar exibição dos logs de teste no Travis](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/182)

#### Descrição:
Atualmente, os logs de teste estão em formato xml e sendo exibidos no stdout com uma formatação que dificulta a leitura.

#### Critérios de Aceitação
- Melhorar visualmente a exibição dos resultados dos testes
- Não quebrar a build

#### Tarefas
- Script que exiba o arquivo xml de uma forma amigável


**Pontos:** 5.

---

### [Logout de fisioterapeuta](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/185)

#### Descrição:
Um launcher para controle de versão da aplicação é necessário.

#### Critérios de Aceitação
- Launcher atualizando de acordo com a versão mais atual


#### Tarefas
- Launcher verificando a versão instalada
- Launcher verificando a versão mais recente
- Launcher baixando e instalando a versão mais recente
- Alguma outra tarefa


**Pontos:** 3.

---

### [Refatoração das interfaces TCP/UDP](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/181)

#### Descrição:
Deve-se refinar a solução implementada para que ela gere máximo valor ao produto final.

#### Critérios de Aceitação:
- Testes Unity passando.
- Build passando

#### Tarefas:
- Documentar modelo de dados utilizado nas interfaces
- Inserir configurações na interface gráfica para auxiliar o usuário no uso das interfaces
- Criar exemplos refinados (módulo de processamento simples e emulador de movimentos do sensor)
- Criar testes unitários

**Pontos:** 13.

---

### [Launcher para controlar versionamento](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/169)

#### Descrição:
A refatoração do launcher é necessária.

#### Critérios de Aceitação:
- Launcher atualizando de acordo com a versão mais atual

#### Tarefas:
- Launcher verificando a versão instalada
- Launcher verificando a versão mais recente
- Launcher baixando e instalando a versão mais recente

**Pontos:** 8.

---
