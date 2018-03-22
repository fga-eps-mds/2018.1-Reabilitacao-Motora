### Histórico de Revisões

| Data       | Versão | Descrição            | Autor             |
|:----------:|:------:|:--------------------:|:-----------------:|
| 18/03/2018 | 1.0 | Criação do Documento com levantamento inicial  | Romeu Carvalho e Victor Moura |


## _Epics, suas user stories e tasks_
#### [**EP01** - Como fisioterapeuta, eu desejo que o sistema tenha saídas de dados padrão para possibilitar portabilidade.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/31)

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) | Gerenciamento de Movimentos | fisioterapeuta | conectar um sensor ao sistema | possibilitar a captura de movimentos | 3 | 1 | Não implementado |

#### Tasks
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| TK01 | Verificar se o esqueleto está sendo movido pelo sensor | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
| TK02 | Validar dados recebidos pelo sensor no console do Unity | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
| TK08 | Verificar e documentar limitações do sensor utilizado | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |

##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT01 | Gerenciamento de Movimentos | [US01](), [US02](), [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29), [US04](), [US05](), [US06](), [US12](), [US13]() e [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |  

---


#### **EP02** - Como fisioterapeuta, eu desejo que o software seja adaptável para a melhor experiência do paciente.

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |

##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| ---- | --------- | ------------------------- |

---

#### [**EP03** - Como fisioterapeuta, eu desejo captar movimentos do meu paciente para avaliar a sua evolução.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/32)

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| US01 | Gerenciamento de Movimentos | fisioterapeuta | cadastrar movimentos | fornecer um modelo de movimento ao sistema | 34 | 1 | Não implementado |
| US02 | Gerenciamento de Movimentos | fisioterapeuta | atualizar movimentos | corrigir um modelo de movimento cadastrado | 34 | 3 | Não implementado |
| [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29) | Gerenciamento de Movimentos | fisioterapeuta | executar movimentos | espelhar virtualmente a atividade em um modelo tridimensional | 8 | 2 | Não implementado |
| US04 | Gerenciamento de Movimentos | fisioterapeuta | remover movimentos | eliminar um modelo de movimento no sistema | 34 | 3 | Não implementado |
| US05 | Gerenciamento de Movimentos | fisioterapeuta | rotular movimento | dividir o movimento em etapas | 21 | 1 | Não implementado |
| US06 | Gerenciamento de Movimentos | fisioterapeuta | visualizar movimento | ver melhor representação da ação | 13 | 3 | Não implementado |
| US13 | Gerenciamento de Movimentos | fisioterapeuta | que o sistema gere gráficos dos movimentos | que eu possa aplicar metodologias científicas no processo de recuperação do paciente | 5 | 1 | Não implementado |

#### Tasks
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| TK06 | Inserir modelo tridimensional que seja compatível com o esqueleto movido pelo sensor | [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29) |
| TK07 | Validar movimentação do modelo com feedback em tempo real | [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29) |

##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT01 | Gerenciamento de Movimentos | [US01](), [US02](), [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29), [US04](), [US05](), [US06](), [US12](), [US13]() e [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |

---

#### [**EP04** - Como fisioterapeuta, eu desejo utilizar interface gráfica para configurar o sistema.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/33)

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) | Gerenciamento de Interface Gráfica | fisioterapeuta | que o sistema contenha um menu | facilitar a navegação entre as funcionalidades do sistema | 3 | 1 | Não implementado |
| US15 | Gerenciamento de Interface Gráfica | fisioterapeuta | configurar o ambiente gráfico | melhor adaptar às condições do tratamento | 13 | 4 | Não implementado |

#### Tasks
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| TK03 | Criar menu principal que dá acesso a todas as features | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |
| TK04 | Criar feedback de feature não implementada quando se aplicar tal situação | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |
| TK05 | Definir identidade visual e seguí-la na criação da interface | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |

##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT03 | Gerenciamento de Interface Gráfica | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) e [US15]() |

---

#### [**EP05** - Como fisioterapeuta, eu desejo manter o cadastro do meu paciente para melhor avaliá-lo.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/34)

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| ---- | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| US07 | Gerenciamento de Pacientes | fisioterapeuta | cadastrar paciente | inserir dados de um novo paciente no sistema | 5 | 2 | Não implementado |
| US08 | Gerenciamento de Pacientes | fisioterapeuta | atualizar paciente | modificar dados de um paciente cadastrado | 5 | 3 | Não implementado |
| US09 | Gerenciamento de Pacientes | fisioterapeuta | visualizar perfil do paciente | ter acesso aos dados de um paciente cadastrado | 3 | 2 | Não implementado |
| US10 | Gerenciamento de Pacientes | fisioterapeuta | remover paciente | melhor utilizar os recursos de armazenamento do sistema | 5 | 3 | Não implementado |
| US11 | Gerenciamento de Pacientes | fisioterapeuta | consultar resultados do paciente | melhor avaliar os resultados da consulta | 21 | 2 | Não implementado |
| US12 | Gerenciamento de Movimentos | fisioterapeuta | relacionar movimento gravado com um paciente | que eu possa coletar dados que se apliquem à minha metodologia de avaliação | 21 | 2 | Não implementado |


##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT01 | Gerenciamento de Movimentos | [US01](), [US02](), [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29), [US04](), [US05](), [US06](), [US12](), [US13]() e [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
| FT02 | Gerenciamento de Pacientes | [US07](), [US08](), [US09](), [US10]() e [US11]() |

---

#### [**EP06** - Como fisioterapeuta, eu desejo ter acesso a um ambiente de suporte para me auxiliar na operação do software.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/35)

|ID | Tema | Eu, como | Desejo | Para | Notas | Prioridade | Status |
| - | ---- | -------- | ------ | -------- | ----- | ---------- | ------ |
| US16 | Suporte | fisioterapeuta | visualizar instruções de uso | me auxiliar no uso do sistema | 3 | 4 | Não implementado |


##### _Features envolvidas_
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT04 | Suporte | [US16]() |

---
## Features
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| FT01 | Gerenciamento de movimentos | [US01](), [US02](), [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29), [US04](), [US05]() e [US06]() |
| FT02 | Gerenciamento de pacientes | [US07](), [US08](), [US09](), [US10](), [US11]() e [US12]()|
| FT03 | Gerenciamento de interface gráfica | [US13](), [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) e [US15]()|
| FT04 | Suporte | [US16]() e [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |

#### Tasks
|  ID  | Descrição | User stories relacionadas |
| ---- | --------- | ------------------------- |
| TK01 | Verificar se o esqueleto está sendo movido pelo sensor | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
| TK02 | Validar dados recebidos pelo sensor no console do Unity | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
| TK03 | Criar menu principal que dá acesso a todas as features | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |
| TK04 | Criar feedback de feature não implementada quando se aplicar tal situação | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |
| TK05 | Definir identidade visual e seguí-la na criação da interface | [US14](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/30) |
| TK06 | Inserir modelo tridimensional que seja compatível com o esqueleto movido pelo sensor | [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29) |
| TK07 | Validar movimentação do modelo com feedback em tempo real | [US03](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/29) |
| TK08 | Verificar e documentar limitações do sensor utilizado | [US17](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/28) |
