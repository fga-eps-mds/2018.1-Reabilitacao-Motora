## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> tem como objetivo:</p>

- Testes rodando na build do Travis.
- Mudanças gerais na arquitetura documentadas (TCP/UDP).
- Novas relações entre entidades (Usuário, sessão, movimento).

## 2. Papéis

| <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Lucas_Malta.png?raw=true" width="200" height="200"/> |  <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Romeu_Antunes.png?raw=true" width="200" height="200"/> |
|:--:|:--:|
| **Scrum Master** | **Product Owner/DevOps** |

| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Victor_Moura.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Arthur_Diniz.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Vitor_Falc%C3%A3o.png?raw=true" width="200" height="200"/> |
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

| Data de Início | 06/05/2018 |
|:--|:--:|
| **Data de Término** | **13/05/2018** |
| **Pontos Planejados** | **67**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no -A realizar-



## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/11)

-------

## 6. Histórias de Usuário


### [US06 - Visualizar Movimento](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/135)

#### Descrição:
**Eu, como**  fisioterapeuta, **desejo** visualizar movimento  **para** ver melhor representação da ação

#### Critérios de Aceitação:
- Testes Unity passando.

#### Tarefas:
- Captura do movimento.
- Salvar o movimento.
- Conseguir rever o movimento.

**Pontos:** 13.

---

### [US10 - Remover Paciente](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/138)

#### Descrição:
**Eu, como**  fisioterapeuta, **desejo** remover paciente  **para** melhor utilizar os recursos de armazenamento do sistema

#### Critérios de Aceitação:
- Testes Unity passando.

#### Tarefas:
- Acessar como administrador.
- Acessar o paciente desejado.
- Acessar a parte de atualizar paciente.
- Remover paciente.
- Persistir no banco de dados.

**Pontos:** 05.

---

### [US11 - Consultar resultados do paciente](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/160)

#### Descrição:
Eu, como fisioterapeuta, desejo consultar os resultados do paciente para que eu possa acompanhar seu progresso e visualizar resultados específicos.

### Critérios de Aceitação
-  Testes Unit passando.
-  Página de sessões de cada usuário
-  Visualizar os resultados de cada sessão


### Tarefas
-  Página de usuário
-  Página de sessão
-  Relação usuário x sessão definidos
-  Visualização dos movimentos de uma sessão

**Pontos:** 08.

---

### [US12 - Relacionar movimento gravado com paciente](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/161)

### Descrição:
Eu, como fisioterapeuta, desejo conectar o movimento de uma sessão do paciente, de modo que os movimentos dessa sessão fiquem salvos para futuras consultas.

### Critérios de Aceitação
-  Testes Unit passando.
-  Visualizar os movimentos de uma sessão de um paciente.


### Tarefas
-  Página de sessão
-  Relação movimento x sessão definidos

**Pontos:** 21.

---

## 7. Tarefas Importantes

### [Validar os campos de registro de paciente.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/131)

#### Descrição:
Validar se os campos de dados estão vazios antes de tentar cadastrar um paciente no banco.

#### Critérios de Aceitação
- Mostrar mensagem que alerta o usuário sobre campo obrigatório.

**Pontos:** 05.

---

### [Implementar Teste](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/152)

### Descrição:
Incrementa a integração continua com teste unitários e deploy 

### Critérios de Aceitação
-  Sscript de teste no travis passando com algum teste base.
-  Script de deploy do travis passando
-  Apos a finalização do deploy fazer o upload do executavel em algum lugar


### Tarefas
-  Fazer script de teste no travis.
-  Fazer script de deploy do travis
-  Apos a finalização do deploy fazer o upload do executavel em algum lugar


**Pontos:** 05.

---

### [Pesquisa sobre conexão TCP/UDP](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/151)

#### Descrição:
Como requisitado pelo cliente, devemos propor uma forma de conexão entre módulos de processamento externos e nossa aplicação.

#### Critérios de Aceitação
- Documento de pesquisa sobre conexão TCP/UDP criado.
- Capacidade de disseminar o conhecimento para o resto do time.


#### Tarefas
- Criar documento sobre conexão TCP/UDP.
- Disseminar conhecimento sobre o assunto para os integrantes do time.

**Pontos:** 01.

---

### [Refatorar documento de arquitetura](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/150)

#### Descrição:
O documento de arquitetura atual não condiz completamente com a nossa proposta, revisar. Além disso, adicionar informações sobre a nova proposta de conexão TCP/UDP.

#### Critérios de Aceitação
- Tópico sobre conexão TCP/UDP adicionado ao documento.
- Revisão geral.


#### Tarefas
- Adicionar tópico sobre conexão TCP/UDP, vantagens, desvantagens, e como/porque ela será utilizado em nossa aplicação.

**Pontos:** 01.

---

### [Implementar Sistema de Deploy Contínuo](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/166)

#### Descrição:
Para entregar continuamente o produto, devemos ter um repositorio global que permita qualquer um acessar
as últimas versões.

#### Critérios de Aceitação
-  Builds sendo disponibilizadas para o público


#### Tarefas
- API capaz de receber e armazenar as builds
- Travis enviar as builds para a API


**Pontos:** 08.

---
