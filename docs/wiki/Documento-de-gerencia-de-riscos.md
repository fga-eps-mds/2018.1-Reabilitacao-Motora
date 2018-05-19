# Riscos do Projeto

|    Data    | Versão |                             Alteração                             |                    Autor                    |
|:----------:|:------:|:-----------------------------------------------------------------:|:-------------------------------------------:|
| 10/04/2018 |   0.1  | Criação do documento | Victor Moura |
| 10/04/2018 |   0.2  | Adicionando referência de quantificação | Victor Moura |
| 18/05/2018 | 1.0 | Adicionando tratamento de riscos | Lucas Malta |

## 1- Levantamento de Riscos Negativos

| Label | Título | Descrição | Probabilidade | Nível do Impacto |
| ----- | ------ | --------- | ------------- | ---------------- |
| R01 | Integração com o sensor do Cliente | Software feito pela equipe não estar integrado com o sensor do cliente | - | - |
| R02 | Utilizar Kinect para captar movimentos | Software feito pela equipe não suportar integração do Kinect para captar os movimentos | - | - |
| R03 | Falta de código a ser feito por conta da plataforma utilizada | Excesso de uso da interface do Unity e falta de scripts pode reduzir o engajamento do time | - | - |
| R04 | Integração Contínua do Unity | Integração contínua do Unity não funcionar | - | - |
| R05 | Greve na Universidade | UnB entrar em greve, impedindo o andamento do projeto | - | - |
| R06 | Tecnologia desconhecida | Falta de conhecimento da tecnologia pode dificultar o desenvolvimento do projeto | - | - |
| R07 | Falta de contato com o Cliente | Falta de contato com o cliente torna obscuro o processo de gerência de requisitos  | - | - |
| R08 | Baixa maturidade de MDS em relação à metodologia e às ferramentas de apoio | Falta de conhecimento nas ferramentas que apoiam o projeto pode reduzir a produtividade do time | - | - |
| R09 | Uso de tecnologia privada | Por não ser uma plataforma de código aberto, o Unity possui muitas limitações em sua versão gratuita | - | - |
| R10 | Atraso nas entregas | Entregas não condizentes com o planejamento realizado | - | - |
| R11 | Baixa produtividade da equipe | Equipe não apresentar desempenho esperado durante a sprint | - | - |
| R12 | Falta de documentação | Falta de documentação atualizada com a implementação pode dificultar o acompanhamento do projeto | - | - |
| R13 | Complexidade da arquitetura | Arquiteturas complexas podem, por conta da curva de aprendizado, reduzir a produtividade do time | - | - |
| R14 | Falta de disponibilidade dos membros | Membros não presentes nos rituais da metodologia acabam ficando desatualizados em relação ao andamento do projeto | - | - |

## 2- Levantamento de Riscos Positivos

| Label | Título | Descrição | Probabilidade | Nível do Impacto |
| ----- | ------ | --------- | ------------- | ---------------- |
| R15 | Boa integração do time | Times bem integrados possuem um melhor ambiente de trabalho, propiciando o aumento da produtividade e o engajamento dos membros | - | - |
| R16 | Engajamento dos membros em relação ao projeto | Membros mais engajados estimulam a criatividade e a resiliência durante o processo de desenvolvimento | - | - |
| R17 | Alta produtividade da equipe | Alta produtividade da equipe reduz a probabilidade de se ocorrerem atrasos | - | - |
| R18 | Estabilidade técnica dos pipelines de produção | Com os pipelines estáveis, tem-se mais tempo para ser dedicado às outras atividades pertinentes ao projeto | - | - |
| R19 | Arquitetura estar bem definida | Com uma arquitetura bem definida, menos mudanças impactantes ocorrem e, portanto, ocorre menos retrabalho | - | - |
| R20 | Satisfação do cliente | O sucesso do projeto possui como um dos principais indicadores a satisfação do cliente | - | - |

## 3- Probabilidade x Impacto

### 3.1- Tabela de probabilidades

| Probabilidade | Intervalo | Nível |
| ------------- | --------- | ----- |
| Muito baixa | Menos de 20% | 1 |
| Baixa | 21% a 40% | 2 |
| Moderada | 41% a 60% | 3 |
| Alta | 61% a 80% | 4 |
| Muito alta | Mais de 80% | 5 |

### 3.2 - Tabela de impactos

| Probabilidade | Intervalo | Nível |
| ------------- | --------- | ----- |
| Muito baixo | Impacto não significativo | 1 |
| Baixo | Impacto de baixa influência | 2 |
| Moderado | Impacto notável com poucas consequências | 3 |
| Alto | Impacto que compromete o andamento do projeto | 4 |
| Muito alto | Impacto que inviabiliza o andamento do projeto | 5 |

### 3.3 - Matriz de quantificação dos riscos

| Probabilidade/Impacto | Muito baixo | Baixo | Moderado | Alto | Muito alto |
| --------------------- | ----------- | ----- | -------- | ---- | ---------- |
| Muito baixa | 1 | 2 | 3 | 4 | 5 |
| Baixa | 2 | 4 | 6 | 8 | 10 |
| Moderada | 3 | 6 | 9 | 12 | 15 |
| Alta | 4 | 8 | 12 | 16 | 20 |
| Muito alta | 5 | 10 | 15 | 20 | 25 |

## 4 - Gerência de Riscos

Além das tabelas presentes neste documento, temos as [planilhas no Google Drive](https://docs.google.com/spreadsheets/d/1EIi_RUSnb4NRGk6ByyrqA3ADAQUBa38AiujRxv7egA0/edit?usp=sharing) que possuem o registro por sprint e os gráficos de burndown.

## 5 - Planejamento de resposta aos riscos
A resposta aos riscos tem como objetivo reduzir as ameaças provindas dos riscos negativos e aumentar as oportunidades e melhorias dos riscos positivos.

### 5.1 - Riscos negativos
São ocorrências que afetam o projeto de forma negativa. De acordo com o PMBoK, esses riscos devem ser tratados com uma série de atitudes:

#### 5.1.1 - Prevenir
Estratégia de resposta ao risco para eliminar a ameaça ou proteger o projeto do seu impacto. Envolve a alteração dos planejamentos do projeto de forma a, por exemplo, estender o cronograma ou reduzir o escopo.

#### 5.1.2 - Transferir
Essa estratégia consiste em transferir o impacto e a responsabilidade de resposta da ameaça para terceiros. Não elimina o risco, nem nega a existência desse risco. Esse esforço por meio de um acordo na maioria das vezes é tirado para terceiros.

#### 5.1.3 - Mitigar
Mitigar o risco é uma estratégia de resposta a riscos onde a equipe trabalha para reduzir a probabilidade de ocorrência do risco e/ou a redução do impacto caso esse risco ocorra. Reduzir a probabilidade de ocorrer o risco é mais eficaz do que tentar reparar o dano causado por um risco.

#### 5.1.4 - Aceitar
Essa estratégia consiste em a equipe reconhecer o risco e não agir, a menos que ele ocorra. Quando qualquer método já exposto é inviável então essa abordagem deve ser aplicada.

### 5.2 - Riscos positivos
São os riscos que afetam positivamente o projeto. O PMBoK também tem uma abordagem para tais riscos, de modo que os mesmos sejam mais aproveitados:

#### 5.2.1 - Explorar
Essa estratégia tem como objetivo auxiliar a organização a garantir que aquela oportunidade seja concretizada. Isso pode ser alcançado eliminando incertezas associadas aquele risco positivo.

#### 5.2.2 - Melhorar
Melhorar é uma estratégia utilizada para aumentar a probabilidade e/ou impacto de um risco positivo. Identificar e maximizar os principais fatores que contribuem com esse risco pode aumentar a probabilidade e/ou impacto

#### 5.2.3 - Compartilhar
Compartilhar um risco significa de certa forma uma transferência, parcialmente ou integralmente, da responsabilidade daquele risco ao um terceiro que tenha mais capacidade de explorá-lo.

#### 5.2.4 - Aceitar
Essa estratégia consiste em reconhecer que essa oportunidade existe porém não persegui-la.

## 6 - Controle dos riscos

| Label | Título | Descrição | Ação tomada |
| ----- | ------ | --------- | ------------- | 
| R01 | Integração com o sensor do Cliente | Software feito pela equipe não estar integrado com o sensor do cliente | Mitigar e transferir - A arquitetura da aplicação foi repensada de modo que não só o sensor do Cliente, mas qualquer sensor possa se conectar à nossa aplicação por meio de um adapter. (Mais informações: [Documento de arquitetira](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Documento-de-Arquitetura.md)) |
| R02 | Utilizar Kinect para captar movimentos | Software feito pela equipe não suportar integração do Kinect para captar os movimentos | Prevenir - O desenvolvimento da utilização do Kinect foi uma das primeiras grandes features a ser desenvolvida pelo time, sobrando assim tempo para eventuais correções, caso necessário. Essa feature é tratada na US17, que pode ser visualizada em nosso [Roadmap](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Roadmap.md) |
| R03 | Falta de código a ser feito por conta da plataforma utilizada | Excesso de uso da interface do Unity e falta de scripts pode reduzir o engajamento do time | Mitigar e prevenir - Aulas e treinamentos foram programados para manter o time unido, além de demonstrar que o Unity, por mais prático que seja, necessita de scripts para se produzir conteúdo relevante. Esses treinamentos. Esses treinamentos também foram realizados com antecedência, como pode ser visto em nosso [Roadmap](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Roadmap.md)  |
| R04 | Integração Contínua do Unity | Integração contínua do Unity não funcionar | Prevenir - A produção da Integração contínua foi um tópico discutido e implementado desde o início do projeto. Este esforço pode ser visto em nosso [Roadmap de DevOps](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/RoadmapDevOps.md) |
| R05 | Greve na Universidade | UnB entrar em greve, impedindo o andamento do projeto | Aceitar - Como este evento não está sob nosso controle, não nos resta nenhuma opção para tratá-lo. |
| R06 | Tecnologia desconhecida | Falta de conhecimento da tecnologia pode dificultar o desenvolvimento do projeto | Mitigar e previnir - Foi dado o mesmo tratamento do R03: treinamentos e aulas. |
| R07 | Falta de contato com o Cliente | Falta de contato com o cliente torna obscuro o processo de gerência de requisitos  | Mitigar - Alguns encontros foram marcados com o cliente para se definir melhor os requisitos e ampliar nosso entendimento geral com relação ao projeto. |
| R08 | Baixa maturidade de MDS em relação à metodologia e às ferramentas de apoio | Falta de conhecimento nas ferramentas que apoiam o projeto pode reduzir a produtividade do time | Mitigar e previnir - Treinamentos de SCRUM e git foram dados para o time desenvolvimento. Além disso,  templates de issue, commit, branch e stylesheets foram criados para auxiliar o time de desenvolvimento nesses pormenores. Tudo isso pode ser visto no [Roadmap](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Roadmap.md), durante a Sprint 0. |
| R09 | Uso de tecnologia privada | Por não ser uma plataforma de código aberto, o Unity possui muitas limitações em sua versão gratuita | Mitigar - As limitações provindas do Unity ser uma tecnologia privada foram mitigadas com o auxílio de outras tecnologias abertas, como o próprio Github, tanto como o Codacy e o Travis. |
| R10 | Atraso nas entregas | Entregas não condizentes com o planejamento realizado | Mitigar - As histórias foram alocadas de modo que uma não tenha dependência da outra. Além disso, buscamos colocar um número adequado de pontos por sprint, de modo que uma sprint não se sobrecarregue e haja pendências. No caso de ainda sim haver pendências, estas são tratadas com prioridade na sprint seguinte, buscando minimizar o atraso ao máximo. |
| R11 | Baixa produtividade da equipe | Equipe não apresentar desempenho esperado durante a sprint | Mitigar - Ao final de cada sprint, durante o fechamento da mesma, reservamos um tempo para comentar sobre os pontos positivos, negativos e a melhorar. Durante essa exposição de acontecimentos, tentamos compreender o que acontecia em cada sprint. Desse modo, caso o desempenho da equipe se demonstre baixo, buscamos o problema através dessa retrospectiva, para que possamos agir de acordo. |
| R12 | Falta de documentação | Falta de documentação atualizada com a implementação pode dificultar o acompanhamento do projeto | Prevenir - A documentação foi criada durante o início do projeto, e refatorada durante, de acordo com a necessidade do mesmo. [Documento de visão](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Documento-de-Vis%C3%A3o.md) e [Documento de arquitetura](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/Documento-de-Arquitetura.md) |
| R13 | Complexidade da arquitetura | Arquiteturas complexas podem, por conta da curva de aprendizado, reduzir a produtividade do time | Mitigar - Estudos sobre as mudanças na arquitetura foram incentivados, de modo que a complexidade da nova arquitetura não impacte os desenvolvedores tão fortemente. [Documento sobre implementação do TCP/UDP](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/wiki/TCP_UDP.md) |
| R14 | Falta de disponibilidade dos membros | Membros não presentes nos rituais da metodologia acabam ficando desatualizados em relação ao andamento do projeto | Prevenir e mitigar - Ao início do projeto, decidimos os horários mais disponíveis entre os membros, para que pudéssemos ter ao menos a maioria presente durante os rituais da metodologia. Além disso, durante ocasiões específicas (Feriados ou muitos membros indisponíveis), realizamos votações para repor o evento perdido o mais cedo o possível. |
