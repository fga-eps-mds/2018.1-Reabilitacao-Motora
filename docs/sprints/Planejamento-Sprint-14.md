## 1. Objetivo da _Sprint_

<p align="justify">Esta <i>Sprint</i> tem como objetivo:</p>

- Continuar com o excelente ritmo de trabalho
- Continuar os trabalhos de integração UDP com a IMU
- Melhorar a pipeline de produção em relação ao launcher
- Encontrar o máximo de falhar no software
- Reportar issues em relação aos bugs encontrados
- Corrigir o máximo de issues possíveis
- Melhorar testes na integração contínua


## 2. Papéis


| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Arthur_Diniz.png?raw=true" width="200" height="200"/> |  <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Lucas_Malta.png?raw=true" width="200" height="200"/> |
|:--:|:--:|
| **Scrum Master** | **Product Owner** |

| <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Romeu_Antunes.png?raw=true" width="200" height="200"/> | <img src="https://github.com/RomeuCarvalhoAntunes/2018.1-Reabilitacao-Motora/blob/master/docs/imagens/grupo/Victor_Moura.png?raw=true" width="200" height="200"/> | <img src="https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/docs/imagens/grupo/Vitor_Falc%C3%A3o.png?raw=true" width="200" height="200"/> |
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

| Data de Início | 11/06/2018 |
|:--|:--:|
| **Data de Término** | **17/06/2018** |
| **Pontos Planejados** | **76**|
| **Duração** | **7 dias** |


## 4. Pareamento

O Quadro de pareamento está disponível no -A realizar-



## 5. Sprint Backlog

A Milestone desta Sprint encontra-se neste [link](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/milestone/17)

-------

## 6. Tarefas a serem realizadas


### [Criação de label com clique do mouse](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/293)

#### Descrição:
Adicionar a possibilidade de criar Rotulos no grafico clicando duas vezes no mesmo.

#### Critérios de aceitação
- Criação de labels viável à partir de cliques


**Pontos:** 13.

---

### [Criação do adapter para o sensor do cliente](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/221)

#### Descrição:
Criação do adapters necessário para se acoplar o sensor do cliente ao projeto.

#### Critérios de Aceitação
- Adapters criados
- Adapters funcionando

**Pontos:** 8.

---

### [Corrigir bug do mal funcionamento do Kinect](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/257)

#### Descrição:
Kinect está apresentando problemas de funcionamento que devem ser corrigidos.

#### Critérios de Aceitação
- Testes passando
- Build passando

**Pontos:** 8.

---

### [Preencher GameObjects dos Avatares Dinamicamente](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/267)

#### Descrição:
Ao entrar nas scenes de gravação de movimento, o script GenerateLineChart não consegue referenciar a mão, cotovelo, ombro e braço do avatar ativo.

#### Critérios de Aceitação
- Testes passando
- Build passando

**Pontos:** 3.

---

### [Exibição de resultados (Personagens)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/304)

#### Descrição:
Na exibição de resultados dos exercícios as imagens dos bonecos do kinect estão desformatadas, desalinhadas e não condizentes. As vezes os bonecos que eram para serem iguais são diferentes as vezes estão em tamanhos desproporcionais.

#### Critérios de Aceitação
- Testes Unit passando (PlayTests).
- Tela refatorada e arrumada.

**Pontos:** 1.

---

### [Bug de Observações do Paciente não estão sendo Visualizadas)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/311)

### Descrição:
Ao cadastrar um Paciente, a observação daquele paciente não está sendo possível visualizar na tela **VER PACIENTE**, Mas se for editar o paciente é possível visualizar sua observação cadastrada.

### Acesso ao Bug
1. Acesse o menu principal
2. Navegue pelo fluxo do paciente, cadastre preenchendo o campo de observação e clique no nome do paciente para visualizar.
3. Veja o erro.

### Critérios de Aceitação
- [ ] Corrigir bug de não poder visualizar a observação adicionada.

### Screenshots
![aaaaa](https://user-images.githubusercontent.com/23347866/41376165-c5aaee1e-6f2e-11e8-880c-dc343bb59357.png)
![observacao](https://user-images.githubusercontent.com/23347866/41376177-ce3903d6-6f2e-11e8-8b0a-168faa298aeb.png)

**Pontos:** 1.

---

### [Campo telefone do paciente sem limitador e desformatado)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/283)

#### Descrição:
O campo telefone está sem limite de números e aceitando letras.

**Para reproduzir o bug**
1. Acesse a tela de cadastro de pacientes
2. Preencha o  telefone com letras
3. Veja o erro

**Comportamento esperado**
O inputfield deve aceitar somente números e limitado em 11 (Ex: 61994014789)

**Screenshots**
![sem titulo](https://user-images.githubusercontent.com/30915713/41266051-a5aebfb4-6dcb-11e8-929a-7f2f8398da8f.png)

**Pontos:** 1.

---

### [Títulos de telas)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/305)

#### Descrição:
Algumas telas possuem títulos não condizentes com o conteúdo esperado.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Títulos modificados

**Pontos:** 1.

---

### [Melhorar mensagem erro de usuário ou senha](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/296)

#### Descrição:
Mensagem mostrada ao usuário quando erra o usuário ou senha poderia ser melhorada.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando
- Mensagem trocada

**Pontos:** 1.

---

### [Campo telefone do fisioterapeuta sem limitador e desformatado](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/269)

#### Descrição:
Mensagem mostrada ao usuário quando erra o usuário ou senha poderia ser melhorada.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando

O campo telefone está sem limite de números e aceitando letras.

**Para reproduzir o bug**
1. Acesse a tela de cadastro
2. Preencha o  telefone com letras
4. Veja o erro

**Comportamento esperado**
O inputfield deve aceitar somente números e limitado em 11 (Ex: 61994014789)
**Screenshots**

![image](https://user-images.githubusercontent.com/30915713/41264432-0e635d0c-6dc3-11e8-975c-45f8797a5002.png)

**Pontos:** 1.

---

### [Bug de privilégios para fisioterapeutas como SuperAdmin na tela de login](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/287)

#### Descrição:
Esse bug pode ser reproduzido da seguinte forma: ao fazer login como admin, clicar no popup para gerenciar os fisioterapeutas,votar para a tela anterior e clicar em cadastrar, aparece como se o fisioterapeuta ainda estivesse com super admin, mas deveria ser apenas um fisioterapeuta.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando
- Apenas o super admin conseguir gerenciar os fisioterapeutas

**Pontos:** 1.

---

### [Criação de um NFR Framework](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/225)

#### Descrição:
O NFR Framework irá nos ajudar a documentar melhor os requisitos não funcionais da aplicação e se eles foram implementados ou não.

#### Critérios de Aceitação
- Diagrama feito
- Checks feitos

**Pontos:** 3.

---

### [Títulos e botões das scenes diferentes em cada tela](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/297)

#### Descrição:
Melhorar posicionamento de textos e botões nas scenes. Pois estão fora do formato.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Telas padronizadas

**Pontos:** 3.

---

### [Cadastro de Movimento Aceitando Números no Campo de Músculos](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/294)

#### Descrição:
Ao cadastrar um Movimento, O campo de Músculos Trabalhos aceita como entrada Número

### Acesso ao Bug
1. Acesse o menu principal
2. Navegue pelo fluxo do movimento, após selecionar seu personagem e ir clicar na tela de **GRAVAR MOVIMENTO**.
3. Preencha o campo de Músculos Trabalhos com Números.
4. Veja o erro.

### Critérios de Aceitação
- [ ] Apenas letras como entrada no campo de Músculos Trabalhados

### Screenshots
![sem titulo](https://user-images.githubusercontent.com/23347866/41296910-5eceffd2-6e34-11e8-93eb-abebf62e26f6.png)

**Pontos:** 1.

---

### [Campo de usuário e senha do fisioterapeuta sem limite de caracteres](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/273)

#### Descrição:
O inputfield de usuário e senha de login e cadastro do usuário está sem limite de caracteres.

**Para reproduzir o bug**
1. Acesse a tela de cadastro
2. Preencha o campo de login e senha com quantos caracteres quiser
4. Veja o erro

**Comportamento esperado**
Os inputfield devem limitar os caracteres em 20 para login e senha.
**Screenshots**
![1](https://user-images.githubusercontent.com/30915713/41264822-37befc04-6dc5-11e8-9849-c1c80ee26fd2.png)

**Pontos:** 1.

---

### [Tamanho dos botões da scene de configuração](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/272)

#### Descrição:
O tamanho dos botões de voltar e salvar da scene de configuração não estão no tamanho adequado. Também deveriam estar centralizados.

**Para reproduzir o bug**
1. Acesse a tela de configurações
2. Veja os erros

**Comportamento esperado**
Botões centralizados e com o tamanho padronizado.

![image](https://user-images.githubusercontent.com/34287081/41264771-f1cbd3c0-6dc4-11e8-99ce-b59acbc69cba.png)

**Pontos:** 2.

---

### [Mudar layout dos botões (LAUNCHER)](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/234)

#### Descrição:
Para obter um melhor visual no launcher, fazer a estilização dos botão de Iniciar

#### Critérios de Aceitação
-  Build passando
- Botão com design bonito

**Pontos:** 1.

---

### [Nav link do github pages saindo da toolbar](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/248)

#### Descrição:
Ao clicar ou passar o mouse em cima da nav bar o hint do item aparece uma borda para fora da toolbar

#### Critérios de Aceitação
-  Build passando
- Pagina corrigida

**Pontos:** 1.

---

### [Adicionando limite de range p labels não extrapolarem o grafico](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/pull/321)

#### Descrição:
Modifiquei script MoveObjectXAxis*.cs adicionando limitadores

#### Critérios de Aceitação
- Build passando
- Build passando
- Sem conflitos com a Branch Development

**Pontos:** 2.

---

### [Juntar a tela de pacientes com a de sessões](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/320)

#### Descrição:
Para ter uma melhor flow dentro da aplicação como temos muito espaço para se trabalhar na tela seria interessante mesclar a tela pacientes com a de sessões realizadas.

### Screenshots
![image](https://user-images.githubusercontent.com/34287081/41445639-355cc85c-7021-11e8-861d-004b0423c2fa.png)

![image](https://user-images.githubusercontent.com/34287081/41445650-42e488f2-7021-11e8-84db-59798dd17f61.png)

#### Critérios de Aceitação
- Build passando
- Build passando


**Pontos:** 2.

---

### [Persistencia da escolha do tipo de sensor](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/298)

#### Descrição:
Ao escolher o tipo do sensor o dropdown não mantem a escolha quando sai da scene.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Dropdown mantendo a escolha.


**Pontos:** 3.

---

### [Limitar range das labels](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/292)

#### Descrição:
Atualmente, pode-se mover a label, no eixo x, para qualquer lugar da cena. Deve-se limitá-la para ficar contida, sempre, no gráfico.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Label limitada


**Pontos:** 2.

---

### [Destacar Label de Movimento](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/291)

#### Descrição:
Destacar os rótulos dos movimentos em relação aos de exercício, de alguma forma.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Label diferente de outras
- Pop-up de deleção informa se o rotulo é de movimento ou de exercício


**Pontos:** 3.

---

### [Ver exercicios da sessão com bug de duplicação.](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/pull/290)

#### Descrição:
Corrigido bug em que quando listado a lista de movimentos feitos pelo paciente em uma sessão, essa lista aparecia duplicada e desalinhada.

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.


**Pontos:** 2.

---

### [Divisória entre panels de cadastrar e listar pacientes/fisioterapeutas](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/281)

#### Descrição:
Painéis transparentes confundem o usuário.

**Para reproduzir o bug**
1. Acesse a tela de cadastro de fisioterapeuta/paciente
2. Veja o erro

**Comportamento esperado**
Painéis com fundo preto.
**Screenshots**
![1](https://user-images.githubusercontent.com/30915713/41265516-0aa6da76-6dc9-11e8-9d9e-c09f3ba4d369.png)

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.


**Pontos:** 1.

---

### [Ver exercicios da sessão com bug de duplicação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/279)

#### Descrição:
Os exercícios cadastrados estão duplicados na scene.

**Para reproduzir o bug**
1. Acesse o menu principal
2. Navegue pelo fluxo do paciente até a scene que tem a lista de movimentos realizados na sessão
3. Veja o erro

**Comportamento esperado**
Botões não duplicados

**Screenshots**
![photo_2018-06-11_16-14-10](https://user-images.githubusercontent.com/30915713/41265262-c67bb502-6dc7-11e8-8177-c99d25d92b67.jpg)

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.


**Pontos:** 1.

---

### [Alinhamento de botões na escolha do personagem](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/276)

#### Descrição:
Os botões da scene de escolha do personagem estão desalinhados.

**Para reproduzir o bug**
1. Acesse o menu principal
2. Clique no botão movimento
3. Veja o erro

**Comportamento esperado**
Botões alinhados

**Screenshots**
![image](https://user-images.githubusercontent.com/30915713/41265081-c2e79fd8-6dc6-11e8-924a-4830b5a04791.jpg)

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.


**Pontos:** 2.

---

### [Pesquisar por músculo](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/250)

#### Descrição:
Utilizar o campo de busca de movimento para buscar movimentos que utilizam apenas o(s) musculo(s) desejado(s).

Exemplo:
Em vez de pesquisar por "Levantamento de braço", pesquisar por "bíceps e tríceps"

#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Listar todos os movimentos que utilizam os musculos inseridos
- Tokenizar (com Regex por exemplo) o input de modo que a linguagem possa ser o mais natural possível


**Pontos:** 2.

---

### [Pesquisar movimento/exercicio](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/issues/249)

#### Descrição:
Uma search-box onde é possivel pesquisar pelo nome do movimento.


#### Critérios de Aceitação
- Testes Unit passando.
- Build passando.
- Campo de busca funcional
- Listagem correta


**Pontos:** 5.
