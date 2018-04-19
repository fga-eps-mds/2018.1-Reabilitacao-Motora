## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> 2 tem como objetivo:</p>

- Aprimoramento dos documentos de EPS.
- Início da fase de implementação do projeto por parte de MDS [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29), [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30), [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28).
- Modelagem do Banco de Dados.

## 2. Papéis

| <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Romeu_Antunes.png?raw=true" width="200" height="200"/> |  <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Lucas_Malta.png?raw=true" width="200" height="200"/> |
|:--:|:--:|
| **Scrum Master** | **Product Owner** |

| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Victor_Moura.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Vitor_Falc%C3%A3o.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Arthur_Diniz.png?raw=true" width="200" height="200"/> |
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

| Data de Início | 18/03/2018 |
|:--|:--:|
| **Data de Término** | **25/03/2018** |
| **Pontos Planejados** | **22**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no [Link](https://raw.githubusercontent.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/master/docs/imagens/Quadro%20de%20Pareamento/Quadro_de_Pareamento_Sprint02.png)

## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/3)

-------

## 6. Histórias de Usuário


### [US 03 - Executar movimentos](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29)
#### Descrição:
**Eu, como** fisioterapeuta **desejo** executar movimentos **para** espelhar virtualmente a atividade em um modelo tridimensional .

#### Critérios de Aceitaçã:
- Testes Unity passando.

#### Tarefas
- Inserir modelo tridimensional que seja compatível com o esqueleto movido pelo sensor.
- Validar movimentação do modelo com feedback em tempo real.

**Pontos:** 08

**Responsáveis:** João Lucas e Davi Alves

---

### [US14 - Menu do Sistema](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30)
#### Descrição:

 **Eu, como** fisioterapeuta **desejo** que o sistema contenha um menu **para** facilitar a navegação entre as funcionalidades do sistema.

#### Critérios de Aceitação:
- Testes Unity passando.

#### Tarefas:
- Criar menu principal que dá acesso a todas as features.
- Criar feedback de feature não implementada quando se aplicar tal situação.
- Definir identidade visual e seguí-la na criação da interface.

**Pontos:** 03

**Responsáveis:** Alexandre Djorkaeff e Guilherme Siqueira

---

### [US17 - Conectar um Sensor ao Sistema](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28)
#### Descrição:
**Eu, como**  fisioterapeuta, **desejo** conectar um sensor ao sistema  **para** possibilitar a captura de movimentos.

##### Critérios de Aceitação:
- Testes Unity passando.

##### Tarefas:
- Verificar se o esqueleto está sendo movido pelo sensor.
- Validar dados recebidos pelo sensor no console do Unity.
- Verificar e documentar limitações do sensor utilizado.

**Pontos:** 03

**Responsáveis:** João Lucas e Guilherme de Lyra

-------


## 7. Tarefas Importantes

### [Levantamento para o armazenamento e modelagem de Banco de Dados](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/38)

#### Descrição
É preciso fazer um levantamento do Banco de Dados, de forma que seja possível pensar na linguagem, nas entidades, atributos e relacionamentos que serão trabalhados futuramente.

#### Critérios de Aceitação
- Pensar na elaboração do Banco de Dados

#### Tarefas:
- Criar MER.
- Criar DER.
- Gerar Script .sql
- Criar model do banco no unity

**Pontos:** 08
