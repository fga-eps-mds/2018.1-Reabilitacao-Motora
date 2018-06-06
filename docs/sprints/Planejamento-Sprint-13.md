## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> tem como objetivo:</p>

- Retomar o ritmo de trabalho (as soon as possible)
- Iniciar os trabalhos de integração com o software do cliente
- Aproveitar a estabilidade do pipeline de produção para realizarmos engenharia de software (entrega contínua)
- Fechar o backlog do produto previsto pela EAP
- Reduzir, sempre que possível, bugs encontrados

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
| **Data de Término** | **03/06/2018** |
| **Pontos Planejados** | **29**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no -A realizar-



## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/16)

-------

## 6. Tarefas a serem realizadas


### [US15 - Gerenciamento de interface gráfica](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/194)

#### Descrição:
Eu, como fisioterapeuta desejo configurar o ambiente gráfico para melhor adaptar às condições do tratamento.

#### Critérios de aceitação
- Testes passando.
- Build passando


**Pontos:** 13.

---

### [Correção de bugs UDP](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/195)

#### Descrição:
Scene e scripts UDP contem alguns erros, deve-se arruma-los.

#### Critérios de Aceitação
- Refatorar scripts UDP.
- Corrigir scenes relacionadas a conexão UDP.

**Pontos:** 2.

---

### [Adicionar tutorial para rotular movimento dentro do software](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/207)

#### Descrição:
Adicionar tutorial para rotular movimento dentro do software
#### Critérios de Aceitação
- Testes Unit passando.
- Build passando


**Pontos:** 3.

---

### [Não há avisos sobre erros no login](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/209)

#### Descrição:
Ao logar-se incorretamente, ambos campos se tornam vermelhos, mas não há um aviso específico sobre qual o problema no login.

#### Critérios de Aceitação:
- Testes Unity passando.
- Build passando

#### Tarefas:
- Criar um pop-up avisando sobre o tipo de erro que ocorreu.

**Pontos:** 1.

---

### [Tutorial de criação de paciente com bug de não conseguir voltar](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/210)

#### Descrição:
Ao entrar na pagina de tutorial sobre a criação de novos paciente não consegui voltar para o menu.

#### Critérios de Aceitação:
- Ao clicar no botão conseguir voltar
- Build passando
- Testes passando

#### Tarefas:
- Analisar causa do bug
- Corrigir bug

**Pontos:** 1.

---

### [Não há avisos sobre erros durante o cadastro de fisioterapeuta](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/211)

#### Descrição:
Não há avisos específicos para os erros indicados em vermelho durante o cadastro de conta de fisioterapeuta. Necessita-se:

#### Critérios de Aceitação:
- Criar um pop-up explicando o porque do preenchimento de tal campo ser inválido


**Pontos:** 2.

---

### [Tutorial de criação de novos pacientes desformatado](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/212)

#### Descrição:
Descrição do tutoria de criação de novos pacientes está desformatado

#### Critérios de Aceitação:
- Tutorial sem sobreposição de layouts
- Build passando
- Testes passando

#### Tarefas:
- Analisar causa do bug
- Corrigir bug

**Pontos:** 1.

---

### [Não há avisos sobre erros durante o cadastro de paciente](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/213)

#### Descrição:
Não há avisos específicos para os erros indicados em vermelho durante o cadastro de conta de paciente. Necessita-se:

#### Critérios de Aceitação:
- Criar um pop-up explicando o porque do preenchimento de tal campo ser inválido


**Pontos:** 1.

---

### [Login sem a identificação dos campos](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/214)

#### Descrição:
Ao entrar na pagina de login os campos de login e senha não estão corretamente identificados, eles podem ser identificados com um hint interno ou um campo de texto em cima.

#### Critérios de Aceitação:
- Visualizar a identificação dos campos
- Build passando
- Testes passando

#### Tarefas:
- Analisar causa do bug
- Corrigir bug

**Pontos:** 1.

---

### [Botão de retorno não funciona - Seleção de Sensor](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/215)

#### Descrição:
O botão de retornar não está funcionando na tela de seleção de Sensor. Necessita-se:

#### Critérios de Aceitação:
- Tornar o botão de retorno funcional.

**Pontos:** 1.

---

### [Botão de retorno não funciona - Tela de movimento](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/216)

#### Descrição:
O botão de retornar não está funcionando na tela de movimento (Paciente -> Sessão -> exercício -> movimento). Necessita-se:

#### Critérios de Aceitação:
- Tornar o botão de retorno funcional.

**Pontos:** 1.

---

### [Tela de salvar sensor não volta para o menu inicial ao salvar o sensor a ser utilizado](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/217)

#### Descrição:
Ao entrar na tela de seleção sensores e clicar em salvar a aplicação vai para tela de gravação de movimento onde apenas deveria voltar para o menu iniciar e salvar a instancia do sensor a ser usado.
Além disso a tela de gravação em que o usuário é levado nao é possivel voltar e nem um campo desformatado perto da localização de voltar.

#### Critérios de Aceitação:
- Após salvar um sensor voltar para o menu
- Arrumar a tela de gravação que o usuário é levado
- Build passando
- Testes passando

#### Tarefas:
- Analisar causa do bug
- Corrigir bug

**Pontos:** 1.

---

### [Botão salvar, na tela de escolha de sensor, muito pequeno](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/218)

#### Descrição:
Ao entrar na tela de seleção sensores o botão de salvar está muito pequeno comparado ao de outras telas.

#### Critérios de Aceitação:
- Botão com tamanho proporcional
- Build passando
- Testes passando

#### Tarefas:
- Fazer correção

**Pontos:** 1.

---

### [Criação dos adapters para o código do cliente](https://github.com/fga-gpp-mds/2018.1-reabilitacao-motora/issues/221)

#### Descrição:
Criação dos adapters necessários para se acoplar o código do cliente ao projeto.

#### Critérios de Aceitação:
- Adapters criados
- Adapters funcionando

#### Tarefas:
- Estudos sobre o código
- Criação do adapter do módulo do sensor
- Criação do adapter do módulo de processamento

**Pontos:** 8.

---
