| Data | Versão | Descrição | Autor(es) |
| :---: | :---: | --- | :---: |
| 22/06/2018 | 1.0 | Criação do documento| Romeu Antunes/Victor Moura |
| 23/06/2018 | 1.1 | Explicações da API de deploy, AWS e dificuldades encontradas| Victor Moura |

# Integração Contínua

## O que é ?

<p align="justify">&emsp;&emsp; A integração contínua é uma prática de desenvolvimento de software de DevOps em que os desenvolvedores, com frequência, juntam suas alterações de código em um repositório central. Depois disso, criações e testes são executados. Geralmente, a integração contínua se refere ao estágio de criação ou integração do processo de lançamento de software, além de originar um componente de automação (ex.: uma CI ou serviço de criação) e um componente cultural (ex.: aprender a integrar com frequência). Os principais objetivos da integração contínua são encontrar e investigar bugs mais rapidamente, melhorar a qualidade do software e reduzir o tempo que leva para validar e lançar novas atualizações de software.</p>

<p align="justify">&emsp;&emsp; No passado, os desenvolvedores de uma equipe podiam trabalhar isoladamente por um longo período e só juntar suas alterações à ramificação mestre quando concluíssem seu trabalho. Dessa forma, a junção das alterações de códigos era difícil e demorada, além de resultar no acúmulo de erros sem correção por longos períodos. Estes fatores dificultavam uma distribuição de atualizações rápida para os clientes.</p>

<p align="justify">&emsp;&emsp; Com a integração contínua, os desenvolvedores frequentemente confirmam um repositório compartilhado usando um sistema de controle de versão, como o Git. Antes de cada confirmação, os desenvolvedores podem escolher executar testes de unidade locais em seus códigos como uma camada de verificação extra anterior à integração. Um serviço de integração contínua cria e executa automaticamente testes de unidade nas novas alterações de código para destacar imediatamente todos os erros.
Integração e distribuição contínuas.
A integração contínua é referente aos estágios de criação e teste de unidade do processo de lançamento de software. Cada revisão confirmada aciona criação e teste automatizados. </p>

<p align="justify">&emsp;&emsp; Com a distribuição contínua, as alterações de código são criadas, testadas e preparadas automaticamente para que a produção seja liberada. A distribuição contínua expande com base na integração contínua ao implantar todas as alterações de código em um ambiente de teste e/ou ambiente de produção, após o estágio de criação.</p>

## Pipeline do projeto
![](/docs/integracao_continua/Diagrama_CI.png)

### Git
### Travis/Integração

<p align="justify">&emsp;&emsp; O Travis CI é um serviço web de Integração Contínua na nuvem integrado com o GitHub. Ele é gratuito para repositórios públicos(travis-ci.org) e pago para repositórios privados(travis-ci.com). Foi desenvolvido em Ruby e seus componentes são distribuídos sob a licença MIT.</p>
<p align="justify">&emsp;&emsp;Atualmente ele tem suporte para as seguintes linguagens de programação: Android, C, C#, C++, Clojure, Crystal, D, Dart, Erlang, Elixir, F#, GO, Groovy, Haskell, Haxe, Java, Javascript, Julia, Objctive-C, Perl, Perl6, PHP, Python, R, Ruby, Rust, Scala, Smalltalk, Visual Basic. </p>

#### Scripts
Os Scripts do travis se encontram todos dentro do repositório, além do script padrão como o <a href"">"travis.yml"</a> nosso processo de Integração Contínua conta com mais alguns scripts de configurações para que a integração possa funcionar. São eles:

> - [_Travis Install_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_install.sh) responsável por fazer a instalação do ambiente _Unity_ dentro da máquina virtual do _Travis_.
> - [Validação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_validation.sh) é o gerenciador de scripts central da nossa integração contínua, nele ocorre a validação de cada script, em caso de uma resposta positiva o script inicia o próximo estágio em caso de resposta negativa a build para, o script de desativação é chamado e o _travis_ encerra com erro de build.
> - [Ativação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_unity_key.sh) responsável por ativar a chave do _Unity_.
> - [_PlayTests_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_tests.sh) responsável por executar os testes de aceitação do produto, ao final o arquivo _xml_ é exibido dentro do próprio log do _travis_, contendo os resultados positivos, de falhas ou testes que foram pulados.
> - [_EditorsTests_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_tests.sh) responsável por executar os testes unitários do programa, ao final o arquivo _xml_ é exibido dentro do próprio log do _travis_, contendo os resultados positivos, de falhas ou testes que foram pulados.
> - [_Build_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_build.sh) responsável por buildar e zipar o projeto em todas as plataformas (Windows, Linux, Mac)
> - [Desativação](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_unity_return_key.sh) responsável por desativar o _Unity_, sendo este junto com o script de validação um dos mais importantes visto que a Key de ativação é única e caso não seja retornada pelo script não será possível realizar a integração contínua do projeto, pelo limite de Keys disponibilizadas.

A ordem de execução dos scripts é a mesma já explicitada acima.

Para realizarmos o _deploy_ contínuo, houve a criação de dois scripts:

> - [_Deploy Dev_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_deploy_dev.sh) Responsável por realizar o upload das builds de __dev__ para a API de armazenamento.
> - [_Deplo Master_](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/travis_deploy_master.sh) Responsável por realizar o upload das builds __master__ para a API de armazenamento.

Cada um dos _scripts_ é executado em uma _branch_ específica. As _builds_ de dev são geradas a partir de _commits_ na _branch_ __development__ e as _builds master_ são geradas a partir de _commits_ na _branch_ __master__. Qualquer outra _branch_ não aciona a execução destes _scripts_.

Ambos os _scripts_ têm, como principal objetivo, realizar o _upload_ das _builds_, construídas em etapas anteriores do _pipeline_, para uma API de distribuição.

#### Spatium API
<p align="justify">&emsp;&emsp;Como estamos tratando de uma aplicação _desktop_, houve de se bolar um pipeline personalizado para realizarmos o _deploy_ contínuo. A solução encontrada foi o desenvolvimento de uma API com as seguintes funcionalidades:</p>

- Armazenamento dos arquivos das _builds_
- Versionamento automático das _builds_
- Classificação das _builds_ em dois níveis hierárquicos:
  - _Build_ de desenvolvimento (_Nightly Build_)
  - _Build_ master (_Stable Build_)
- Disponibilização de todas as _builds_ por meio de _links_ de _download_

<p align="justify">&emsp;&emsp;A implementação destas _features_ resultou na [Spatium API](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora-Spatium-API).</p>

<p align="justify">&emsp;&emsp;O versionamento das _builds_ é feito de forma automática obedecendo a seguinte regra de negócio:</p>

- No _upload_ de _build_ de dev
  - Caso não exista _build_ armazenada
    - Versão: 0.1
  - Caso exista _build_ armazenada
    - Incrementa-se o segundo índice da última versão
    - Exemplo:
      - Ultima versão armazenada: 4.2
      - Nova versão: 4.3

- No _upload_ de _build master_
  - Caso não exista _build_ armazenada
    - Versão: 1.0
  - Caso exista _build_ armazenada
    - Incrementa-se o primeiro índice da última versão e zera-se o segundo índice
    - Exemplo:
      - Ultima versão armazenada: 4.2
      - Nova versão: 5.0

<p align="justify">&emsp;&emsp;O sistema de versionamento sempre obedece a divisão por plataformas. Então irá existir até três objetos da mesma versão, onde cada um pertence a um dos sistemas suportados:</p>

- _Windows_
- _Linux_
- _OSX_

<p align="justify">&emsp;&emsp;Feita em Ruby on Rails, conseguiu cumprir com os seus objetivos de distribuir as _builds_ geradas de forma automática no _pipeline_ de integração contínua. Todo o armazenamento dos arquivos é feito na _Amazon_ S3 por meio da integração do _ActiveStorage_ com os serviços AWS.</p>

### Amazon
<p align="justify">&emsp;&emsp;Para realizarmos o _deploy_ contínuo, utilizamos a infraestrutura da _Amazon Web Service_ (AWS). Os serviços utilizados foram:</p>

- _Amazon_ EC2 - _Elastic Compute Cloud_
  - Instância virtual para hospedar a Spatium API.
- _Amazon_ EBS - _Elastic Block Storage_
  - Bloco de armazenamento persistente acoplado ao EC2 para manter o banco de dados da Spatium API.
- _Amazon_ S3 - _Simple Storage Service_
  - _Bucket_ que armazena todos os arquivos das builds enviadas.

<p align="justify">&emsp;&emsp;Inicialmente, no levantamento dos requisitos de infraestrutura para manter a API de deploy, pensou-se em utilizar o _Heroku_. Por conta do seu funcionamento com falta de persistência de arquivos, arquiteturou-se o uso do _Amazon_ S3 para suprir tal demanda. Com a implementação da integração com o S3, surgiu a oportunidade de se utilizar outros serviços AWS no lugar do Heroku, gerando maior desempenho de acesso, já que as instâncias nunca entram em _sleep mode_.</p>

<p align="justify">&emsp;&emsp;O serviço EC2 foi utilizado para hospedar a API. Como possui bom tempo de resposta, mesmo após longos períodos sem ser requisitada, a instância EC2 foi vista como a solução definitiva. Com a necessidade de volumes persistentes para manter-se o banco de dados, acoplou-se o EBS à instância EC2.</p>

## Launcher

### O que é ?
Launcher é uma aplicação feita para ajudar os usuários a localizar e iniciar outros programas de computador. Um launcher de aplicativos pode fornecer atalhos para programas de computador em um local para facilitar  sua localização e execução.

### Launcher Reabilitação Motora
No contexto da nossa aplicação o launcher serve para atualizar as builds da aplicação e executada sem dar trabalho ao usuário de ter que entrar em nosso site para baixar uma nova release.

### Funcionamento
Quando executado o launcher faz uma verificação da versão mais atualizada da aplicação localizada em uma API que guarda as builds e versões, caso ele identifique que a versão guardada localmente está desatualizada ele baixa a build mais atualizada da API, faz o unzip dela e deixa preparada para execução, assim que o processo termina o botão de iniciar é desbloqueado e a versão mais atual já pode ser iniciada.

![](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/docs/integracao_continua/Launcher_diagrama.png)

### Dificuldades
Um dos pontos mais críticos em relação a dificuldade do launcher foi a questão de fazer um sistema que pudesse ser utilizado em qualquer sistema operacional. Portanto foi decidido usar a linguagem de programação Java + Gradle para proporcionar esse ambiente multi plataforma. Dessa forma a aplicação do launcher ao gerar um compilado pode ser executada em qualquer computador. Outro ponto crítico interessante é o gerenciamento de permissões dentro do sistema operacional para a execução de programas pelo launcher. Dessa forma toda vez que uma nova build é atualizada e descompactada esse tratamento de permissões de execução do programa tem que ser feito, caso não ocorra corretamente o launcher não conseguiria abrir nenhum programa externo


## Dificuldades Encontradas
<p align="justify">&emsp;&emsp;Inicialmente, na tentativa de se levantar possibilidades para a implementação da integração contínua do projeto, percebeu-se que as poucas pessoas que haviam o feito utilizaram o Travis CI. Entretanto, perdeu-se muito tempo tentando criar-se o pipeline de build por conta das limitações do _Unity_ executado via linha de comando. A única solução existente exigia que o time tivesse uma _key_ de ativação do _Unity Pro_. Até obter-se acesso à chave, o time não pôde contar com as vantagens do CI em seu processo produtivo.</p>

<p align="justify">&emsp;&emsp;Ainda por conta das limitações do _Unity_ executado via linha de comando, perdeu-se um certo tempo para configurar a execução dos testes unitários e de aceitação no _pipeline_. Ainda assim, os logs resultantes são pouco intuitivos e demandam trabalho de análise para identificar-se eventuais erros.</p>

<p align="justify">&emsp;&emsp;Um dos principais problemas encontrados e, ainda sem solução implementada, é o tempo de execução do _pipeline_. Por conta da não existência de _template_ definido para o ambiente de integração contínua, é realizada toda a configuração a cada ciclo do processo, aumentando o tempo necessário para se iniciar as tarefas principais, como as _builds_ e a execução dos testes. Outro fator que contribui para tal resultado é a necessidade de se construir três versões do _software_, uma para cada sistema operacional. Os esforços feitos em prol da resolução desta dificuldade envolveram refatoração dos _scripts_ para eliminar passos duplicados.</p>

<p align="justify">&emsp;&emsp;Infelizmente, ainda existem problemas sem solução prevista. A instabilidade de alguns testes de aceitação exigem com que o _pipeline_ tenha, em alguns casos, de ser executado diversas vezes até a sua aprovação. Além disso, a necessidade de se ter informações cruciais nos _logs_ nos obriga a mostrar completamente tudo o que o _Unity_ escreve na saída padrão. Pela falta de controle no que é mostrado ou não, temos registros extensos e poluídos por informações desnecessárias fornecidas pela plataforma de desenvolvimento.</p>

## Esforços desperdiçados
> - Implementação do _script_ de [transformação do log dos testes](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/playTest_log_converter.py) visando melhorar a visualização dos _logs_ já poluídos.
> - Implementação do _Chatops_ para unir as ferramentas de comunicação com o _pipeline_ de produção.

## Resultados Obtidos  
<p align="justify">&emsp;&emsp;De forma geral, o _pipeline_ de produção tem se mostrado estável e maduro. Nas _sprints_ finais, foi possível observar excelente desempenho do sistema quando solicitado pelo ritmo acelerado de entregas conquistado. Os problemas críticos tiveram tratamento rápido, sendo resolvidos de formas que não impactassem a equipe em seu pico de produtividade no final do projeto. Certamente, apesar do pioneirismo no uso da tecnologia _Unity_, atingiu-se um patamar maduro o suficiente que possibilita o reuso das soluções por outras equipes que venham a explorar o desenvolvimento de aplicações similares.</p>
