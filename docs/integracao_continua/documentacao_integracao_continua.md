| Data | Versão | Descrição | Autor(es) |
| :---: | :---: | --- | :---: |
| 22/06/2018 | 1.0 | Criação do documento| Romeu Antunes/Victor Moura |

# Integração Contínua

## O que é ?

<p align="justify">&emsp;&emsp; A integração contínua é uma prática de desenvolvimento de software de DevOps em que os desenvolvedores, com frequência, juntam suas alterações de código em um repositório central. Depois disso, criações e testes são executados. Geralmente, a integração contínua se refere ao estágio de criação ou integração do processo de lançamento de software, além de originar um componente de automação (ex.: uma CI ou serviço de criação) e um componente cultural (ex.: aprender a integrar com frequência). Os principais objetivos da integração contínua são encontrar e investigar bugs mais rapidamente, melhorar a qualidade do software e reduzir o tempo que leva para validar e lançar novas atualizações de software.</p>

<p align="justify">&emsp;&emsp; No passado, os desenvolvedores de uma equipe podiam trabalhar isoladamente por um longo período e só juntar suas alterações à ramificação mestre quando concluíssem seu trabalho. Dessa forma, a junção das alterações de códigos era difícil e demorada, além de resultar no acúmulo de erros sem correção por longos períodos. Estes fatores dificultavam uma distribuição de atualizações rápida para os clientes.</p>

<p align="justify">&emsp;&emsp; Com a integração continuada, os desenvolvedores frequentemente confirmam um repositório compartilhado usando um sistema de controle de versão, como o Git. Antes de cada confirmação, os desenvolvedores podem escolher executar testes de unidade locais em seus códigos como uma camada de verificação extra anterior à integração. Um serviço de integração contínua cria e executa automaticamente testes de unidade nas novas alterações de código para destacar imediatamente todos os erros.
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


### Amazon/Deploy
#### API Spatium

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
<p align="justify">&emsp;&emsp; A principal dificuldade encontrada pelo time em primeiro momento foi, a falta de repositórios com este tipo de tecnologia, na primeira <i>release</i> foi citado a dificuldade de se implementar a integração continua em um repositório com o <i>Unity</i>, depois disso enfrentamos o problema de colocar os testes unitários e os de aceitação para que fossem rodados junto com a integração continua, feita essa parte o outro problema enfrentado foi com relação o tempo de build do <i>travis</i> visto que quanto maior a quantidade de testes maior era o tempo de execução de build, e mesmo que os testes falhassem a build continuaria rodando, a solução encontrada foi a criação do script de validação que seria responsável primeiramente para garantir que se algum teste de qualquer tipo falhasse a build seria encerrada dando um feedback mais rápido para o desenvolvedor que aguardava a integração continua.</p>

<p align="justify">&emsp;&emsp; Foi visto também que os scripts de ativação e desativação estavam redundantes visto que em todos os outros scripts o <i>unity</i> era ativado e desativado, o que acarretava mais ainda no tempo longo de build. depois de resolvidos todos estes problemas verificamos que o log de testes do <i>unity</i> era exportado em <i>xml</i>, o que dificultava a leitura para encontrar os erros por parte do desenvolvedor. A solução encontrada foi um script em <i>python</i> criado para tratar esse arquivo, após um tempo decidimos descartar essa modificação devido a um overhead desnecessário e pouco aproveitado. Mais para o final do projeto surgiram problemas que ainda não foram resolvidos como por exemplo o teste do UDP de paciente que só é dado como aprovado após a terceira vez que o <i>travis</i> é forçado a se executar.</p>

## Esforços desperdiçados
> - Implementação do _script_ de [transformação do log dos testes](https://github.com/fga-gpp-mds/2018.1-Reabilitacao-Motora/blob/development/Reabilitacao-Motora/Assets/Scripts/playTest_log_converter.py)
> - Implementação do _Chatops_

## Resultados Obtidos  
De forma geral a integração contínua com o _deploy_ contínuo e o _launcher_ da aplicação estão funcionando de forma totalmente autônoma o que mostra uma maturidade no _pipeline_ de integração continua e _deploy_ continuo apesar de existirem pontos onde é possível existir uma melhora, não mancha o processo como um todo visto que ele está funcionado e servindo de acordo com o planejado.
