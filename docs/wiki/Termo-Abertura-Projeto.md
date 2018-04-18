## Histórico de Revisão

|    Data    | Versão |                             Alteração                             |                    Autor                    |
|:----------:|:------:|:-----------------------------------------------------------------:|:-------------------------------------------:|
| 15/03/2018 |   0.1  | Criação do documento e elaboração dos tópicos 11, 13, 14 e 15 |                Arthur Diniz                 |
| 20/03/2018 |   0.2  | Inserção dos tópicos 1 e 2 | Vitor Falcão |
| 02/04/2018 |   0.3  | Inserção dos tópicos 3 e 7. Modificações no tópico 4 | Victor Moura |
| 02/04/2018 |   0.4  | Elaboração dos tópicos 8 e 9 | Arthur Diniz |
| 17/04/2018 |   0.5  | Concluindo e revisando o documento | Romeu Antunes |


----
##  Índice

[1. Propósito ou Justificativa do Projeto](#1-propósito-ou-justificativa-do-projeto)

[2. Objetivos do Projeto](#2-objetivos-do-projeto)

[3. Descrição do Projeto em alto nível](#3-descrição-do-projeto-em-alto-nível)

[4. Requisitos de Alto Nível](#4-requisitos-de-alto-nível)

[5. Premissas](#5-premissas)

[6. Restrições](#6-restrições)

[7. Limites do Projeto](#7-limites-do-projeto)

[8. Riscos](#8-riscos)

[9. Cronograma e Marcos](#9-cronograma-e-marcos)

[10. Resumo do orçamento](#10-resumo-do-orçamento)

[11. Lista das partes interessadas](#11-lista-das-partes-interessadas)

 >[11.1 Desenvolvedor da Sistema e do Software de Reabilitação](#111-desenvolvedor-do-sistema-e-do-software-de-reabilitacao)

 >[11.2 Fisioterapeutas e pacientes](#112-fisioterapeutas-e-pacientes)

 >[11.3 Equipe de Engenharia de Produto de _Software_](#113-equipe-de-engenharia-de-produto-de-software)

 >[11.4 Equipe de Desenvolvimento de <i>Software</i>](#114-equipe-de-desenvolvimento-de-software)

[12. Requisitos para aprovação do Projeto](#12-equipe-de-desenvolvimento-de-software)

[13. Gerente do Projeto](#13-gerente-do-projeto)

[14. Patrocinador](#14-patrocinador)

[15. Responsável pela autorização do Projeto](#15.responsável-pela-autorização-do-projeto)

----

## 1. Justificativa do Projeto
<p align="justify">
O Acidente Vascular Cerebral (AVC), popularmente conhecido como derrame, é a segunda maior causa de mortes atualmente no Brasil. Sua causa é problemas na irrigação sanguínea do cérebro causando morte celular, como consequência há um mal funcionamento do cérebro. Como resultado temos os sintomas de dificuldade de movimento ou percepção em um dos lados do corpo, dificuldades em falar ou compreender, perda de visão em um dos lados e sensação de que os objetos a sua volta estão se movimentando.
</p>
<p align="justify">
Um dos problemas enfrentados é a reabilitação dos pacientes que sofreram AVC, ela se torna um desafio quando focamos na reabilitação motora do paciente que teve como sintoma a dificuldade de movimentação em um dos lados. Um fisioterapeuta se baseia em medições empíricas ao análisar o estado e evolução de um paciente, não tendo um devido mapeamento do empírico para o formal.
</p>
<p align="justify">
O projeto tem como foco contornar este problema com medições bem mapeadas, ou seja, quando um paciente tem dificuldade de contração de um dos braços podemos medir facilmente a angulação entre seu antebraço e o eixo que passa do ombro ao cotovelo e então analisar sua evolução por atendimento feito.
</p>
<p align="justify">
Em cada atendimento será efetuado as avaliações de acordo com movimentos previamente gravados pelo fisioterapeuta, então o paciente tentará reproduzí-lo e os dados relacionados a esta tentativa (angulação pelo tempo) será gravado em um banco de dados relacionado a este paciente ou apenas apresentado ao fisioterapeuta responsável para que haja uma análise mais profissional e com mais precisão.
</p>

## 2. Objetivos do Projeto
<p align="justify">
Prover uma análise não superficial durante o atendimento de reabilitação de um paciente ajudando o fisioterapeuta a tomar melhores decisões médicas em relação a ele. A recuperação mais rápida do paciente se torna um dos objetivos e uma das consequências do método de espelhamento utilizado.
</p>

## 3. Descrição do Projeto
<p align="justify">
O projeto em questão é um software com interface tridimensional que servirá de apoio em sessões de fisioterapia. A interface irá reproduzir, em um modelo digital, os movimentos que serão captados por um sensor enquanto o paciente os executa. O movimento executado pelo paciente será baseado em outro movimento anteriormente cadastrado pelo fisioterapeuta. O grande foco do projeto é permitir que o paciente tenha o controle de movimentos de um modelo digital, abrindo possibilidade para uma futura implementação de um sistema gamificado. Os movimentos cadastrados pelo fisioterapeuta serão rotulados com o auxílio de um gráfico gerado automaticamente. O gráfico mostra a relação entre o ângulo de junta da articulação pelo tempo, ou seja, a curva acompanha os movimentos de extensão e contração do membro mapeado. A partir do gráfico gerado, o fisioterapeuta fará a rotulação de cada parte da curva, possibilitando a divisão do movimento completo em etapas menores. A divisão das etapas do movimento completo permite que o profissional possa identificar em qual etapa o paciente está apresentando mais dificuldade ou facilidade.
</p>

## 4. Requisitos de alto nível
 - Cadastro e gerenciamento de pacientes
 - Sessões de fisioterapia assistidas por sensor de captura de movimentos
 - Rotulação dos movimentos cadastrados por profissional de fisioterapia


## 5. Premissas
 - O fisioterapeuta tem conhecimentos básicos de computação
 - A clínica do fisioterapeuta contém ao menos um computador e um sensor de movimento
 - A clínica do fisioterapeuta contém espaço suficiente para o sensor de movimento funcionar adequadamente

## 6. Restrições
 - O projeto deve ser concluído no período letivo de 2018/1 da Universidade de Brasília
 - O projeto só pode utilizar de recursos disponíveis pelos próprios membros
 - O projeto deve ser concluído somente pela equipe de gestão e desenvolvimento do projeto, com consultas somente ao cliente do mesmo.

## 7. Limites do Projeto
<p align="justify">
Como limitações do projeto, temos o uso de sistemas externos que irão ser responsáveis pela interpretação dos sinais captados. O escopo do projeto foi definido levando em consideração que a integração com o sistema externo será possível. Pela falta de disponibilidade de tempo, caso haja grandes dificuldades em se integrar os sistemas, coloca-se em risco a qualidade do produto final. Além disso, a baixa confiabilidade da tecnologia selecionada quando utilizada em sistema operacional que não seja da Microsoft ou da Apple exige que a equipe utilize Windows ou OSX como ambiente de desenvolvimento. Tal limitação dos sistemas operacionais afeta, também, a configuração dos ambientes de integração/*deploy* contínuo, podendo afetar a qualidade final do *pipeline* de desenvolvimento.
</p>

## 8. Riscos

<p align = "justify">
Existem inúmeros riscos que envolvem o desenvolvimento de software, Riscos são situações de incertezas que envolvem escolhas relacionadas com decisões que estão ligadas diretamente aos riscos.
Uma vez conhecidos os riscos, as decisões podem reduzir perdas, aumentar ganhos ou, o contrário, levando a prejuízos.
</p>

<p align = "justify">
Os principais riscos do projeto envolvem a equipe e a tecnologia a ser utilizada. Esses riscos exigem um plano de ação para se obter o sucesso do projeto, que são:
</p>

**Riscos** | **Plano de Ação**
-----------|------------|
O tamanho da equipe, que dificulta a comunicação e o gerenciamento dos membros | Manter uma boa integração da equipe para que o gap da comunicação seja amenizado, assim como a utilização de meios de comunicação eficientes para todos, reuniões semanais e acompanhamento dos membros
Tecnologia nova e nunca antes implementada na disciplina | Pelo fato da tecnologia sair dos padrões da disciplina sendo usado assim um motor gráfico é necessário realizar treinamentos com a equipe de desenvolvimento sobre as tecnologias a serem utilizadas e buscar pessoas capacitadas que possam ajudar a sanar dúvidas.
A falta ou desistência de algum membro | Adequar os horários e realocar as tarefas entre os membros sem sobrecarregar nenhum membro.
Um membro da equipe não possuir notebook ou aparelhos periféricos | Organizar reuniões onde tenha a possibilidade de usar um desktop ou um notebook para que todos trabalhem, no mesmo caso de aparelhos periféricos, ou pegar emprestado um notebook que atenda as necessidades das reuniões.
Periféricos externos como o kinect ou sensor, dificultam ainda mais a implementação  | Analisar o seu acoplamento o quanto antes e manter o conhecimento atualizado em todo o time.
Falta de conhecimento sobre git e da metodologia SCRUM por parte da equipe de MDS  | Fazer dojos sobre o assunto e dar o máximo de apoio para que os integrantes de MDS tenham uma curva de aprendizado acentuada.

## 9. Cronograma e Marcos

<p align = "justify">
O cronograma de planejamento foi necessário para manter o controle das tarefas e seus fluxos, nele foram detalhados minuciosamente as atividades a serem executadas durante um período estimado.
<p>
<p align = "justify"> O cronograma do projeto começou no  início ao semestre letivo das disciplinas de Métodos de Desenvolvimento de Software e Engenharia do Produto de Software.
</p>

- Marco inicial no dia 05/03/2018.

- Marco final no dia XX/06/2017.

<p align = "justify">
Entre essas datas acontece uma primeira entrega parcial, onde devem ser apresentados os casos de uso priorizados,toda documentação de gerenciamento do projeto, além de 30% de cobertura de testes sobre o sistema e a entrega final, com uma cobertura de testes maior ou igual a 90%, como segue o quadro: </p>

<p align = "justify">
Obs: No caso do nosso projeto será cobrado apenas a cobertura de testes unitários já que a tecnologia usada não cobre os outros tipos de teste. </p>

 **Pontos de Controles**     | **Data**          |  **Resumo**
-----------------------------|-------------------|-----------
Release 01                   | 05/03/18 e 19/04/18 | Entrega dos documentos de gerenciamento e entrega parcial do sistema
Release 02                   | 20/04/18 a 25/06/18 | Entrega total do sistema


## 10. Resumo do Custo estimado
### 10.1. Recursos Humanos
<p align="justify"> &emsp;&emsp; Os recursos humanos que estão sendo usados no desenvolvimento do projeto são, 5 pessoas para gerenciamento sendo os papéis definidos pelo <i>Framework Scrum</i> e sendo os papéis <i>Scrum Master</i>, <i>Product Owner</i>, <i>DevOps</i>, <i>Arquitetura</i> e joker. A parte de desenvolvimento do projeto está com o grupo de MDS que é constituído de 5 integrantes. Cada membro dos diferentes grupos deve disponibilizar o período de 10 horas semanais para se dedicar ao desenvolvimento do projeto. Utilizando esses dados estimamos quanto um aluno custa por mês para a Universidade de Brasília (UnB), para utilizarmos no calculo de valor do projeto e estimar o valor das nossas horas de trabalho. </p>

### 10.2. Equipamentos e Serviços
<p align="justify"> &emsp;&emsp; O custo de equipamentos utilizados pelos membros do grupo está no valor de R$ 33.618,00 este valor foi retirado com base nos valores de mercado dos notebooks pessoais dos membros. Na parte de serviços foi utilizada uma média de consumo elétrico dos notebooks pessoais dos membros para estimar um valor para uma conta de luz onde seria o local de trabalho do grupo, acrescemos também um valor de uma franquia de internet que julgamos suficientes para suportar os 10 membros trabalhando juntos ao mesmo tempo.  </p>

### 10.3. Custo Total
![](https://raw.githubusercontent.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/449db6c1815f5857c99fa32370849b2835e9366b/docs/imagens/EVM/Custos_do_Projeto.png)

> O Custo total do projeto esta no valor de R$ 98.174,78.

## 11. Lista das partes interessadas
### 11.1 Desenvolvedor da Sistema e do Software de Reabilitação

<p align="justify"> &emsp;&emsp; O desenvolvedor da Tese de Doutorado referente ao <i>Software de Reabilitação</i> é  do professor Roberto da Universidade de Brasília - Campus Gama na área da Engenharia, com parceria de um estudante ...  de gradução que desenvolveu uma versão web do produto. A tese foi elaborada com base na avaliação de paciente que sofreram de AVC (acidente vascular cerebral) realizando testes com o possivel potencial dos pacientes na recuperação.</p>

|          Nome          |   Cargo   | Papel |
|:----------------------:|:---------:|:---------:|
| Roberto ... | Professor | Tese de Doutorado e Acompanhamento
|...          | Aluno  | Trabalho de Conclusão de Curso e Aplicação web sobre a tese|

### 11.2 Fisioterapeutas e pacientes

<p align="justify"> &emsp;&emsp; Fisioterapeutas e seus pacientes que sofreram de AVC (acidente vascular cerebral). Os Fisioterapeutas procuram ganhar melhorias no processo de avaliação, classificação e recuperação de seus pacientes e os pacientes ganham em uma melhor recuperação e qualidade de vida após tratamento.</p>

### 11.3 Equipe de Engenharia de Produto de <i>Software</i>

<p align="justify"> &emsp;&emsp; A equipe de produto de <i>software</i> é composta pelos alunos da disciplina Engenharia de Produto de <i>Software</i> da Universidade de Brasília campus Gama que cursam Engenharia de <i>Software</i>.</p>

|                 Nome                 |           Email           |
|:------------------------------------:|:-------------------------:|
| Arthur Barbosa Diniz | arthurbdiniz@gmail.com |
| Lucas Henrique Araújo Malta   | lucas50xd@hotmail.com  |
| Romeu Carvalho Antunes   | romeucarvalho2009@hotmail.com |
| Vitor Falcão Costa   | 	vitorfhcosta@gmail.com  |
| Victor Moura   | victor_cmoura@hotmail.com  |

### 11.4 Equipe de Desenvolvimento de <i>Software</i>

<p align="justify"> &emsp;&emsp; A equipe de desenvolvimento de <i>software</i> é composta pelos alunos da disciplina Métodos de Desenvolvimento de <i>Software</i> da Universidade de Brasília campus Gama que cursam Engenharia de <i>Software</i>.</p>

|              Nome              |             Email             |
|:------------------------------:|:-----------------------------:|
| Alexandre Djorkaeff | djorkaeff.unb@gmail.com |
| Davi Alves Bezerra   | davialvb@gmail.com |
| Guilherme de Lyra   | guilyra12@gmail.com |
| Guilherme Siqueira Brandão | guilhersiqueira@gmail.com |
| João Lucas Sousa Reis   | joao.lucas.ssr@gmail.com |


## 12. Requisitos para aprovação do Projeto
<p align="justify"> &emsp;&emsp;  Para considerar o projeto aprovado ele deverá estar de acordo com as especificações dos nossos <i>Stakeholders</i> externos que são: Prof. Carla Silva Rocha Aguiar e Prof. Roberto. O projeto deverá captar o movimento do paciente e gerar o gráfico de linha a respeito do mesmo movimento, o fisioterapeuta deverá poder marcar no gráfico pontos para que haja a rotulação de movimento o projeto deve se comunicar com outras plataformas por meio de uma interface TCP para que o cliente não fique dependendo de um sensor especifico. </p>

## 13. Gerente do Projeto

* Nome: Arthur Barbosa Diniz, Lucas Henrique Araújo Malta, Romeu Carvalho Antunes, Vitor Falcão Costa, Victor Moura.
* Responsabilidade: Gerir e desenvolver o projeto.
* Nível de autoridade designado: Aluno da disciplina Engenharia de Produto de <i>Software</i> da Universidade de Brasília.

## 14. Patrocinador

* Nome: Carla Aguiar.
* Autoridade: Orientadora e Avaliadora do projeto.

## 15. Responsável pela autorização do Projeto

<p align="justify"> &emsp;&emsp; É a orientadora da disciplina de Engenharia de Produto de <i>Software</i>, professora Carla Aguiar, em conjunto com o dono da ideia central do sistema, professor Roberto ..., ambos da Universidade de Brasília.</p>

## Referências bibliográficas

PMBOK, GUIA. "Um guia do conjunto de conhecimentos em gerenciamento de projetos." <i>Project Management Institute</i>. 2004.
