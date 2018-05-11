# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
09/05|1.0.0|Descrição do modelo TCP/IP. | Guilherme Siqueira
10/05|1.1.0|Adição do tópico 2. | Guilherme Siqueira
# Sumário
----------------
 1. [Transmission Control Protocol/Internet Protocol - TCP/IP](#1)
   * 1.1 [Visão Geral](#1_1)
   * 1.2 [TCP/IP em Camadas](#1_2)
 2. [Transport Control Protocol - TCP](#2)
    * 2.1 [Visão Geral](#2_1)
    * 2.2 [Socket](#2_2)


Documento de Especificação
------------------------------------
## 1. Transmission Control Protocol/Internet Protocol - TCP/IP

### 1.1 Visão Geral
 <p align = "justify"> O TCP/IP é uma sequência de protocolos, e representa o conjunto de regras de comunicação na internet. Baseia-se no conhecimento do endereço de IP de um computador para outro e realizar o encaminhamento do pacote de dados.
 </p>

### 1.2 TCP/IP em Camadas
<p align = "justify"> Permite aplicar o modelo TCP/IP em qualquer máquina, independentemente do sistema operacional. O sistema de protocolos TCP/IP foi decomposto em vários módulos que efetuam cada tarefa específica, e estes módulos executam estas tarefas umas após as outras em uma ordem determinada, resultando em um sistema estratificado. Os dados transitam na rede e atravessam vários níveis de protocolos, assim os dados são tratados por cada camada sequencialmente, acrescentando um elemento de informação (cabeçalho) e transmitindo para a próxima camada.
</p>

<p align = "justify"> O objetivo de um sistema em camadas é separar o problema em partes diferentes de acordo com o nível de abstração delas, com cada camada se comunicando com as suas vizinhas, utilizando os serviços das camadas inferiores e fornecendo os seus próprios serviços às camadas do nível superior. O TCP/IP possui quatro camadas.
</p>

<p align = "justify"> O TCP/IP possui quatro camadas. Sendo elas a Camada de Aplicação, a camada de Transporte (TCP), a camada de internet (IP) e a Camada de Acesso à Rede. </p>
<p align = "justify"> A <b>Camada de Aplicação</b> agrupa os a padrão da rede (SMTP, FTP, etc). Faz a comunicação entre os programas e os protocolos de transporte no TCP/IP. </p>
<p align = "justify"> A <b>Camada de Transporte (TCP)</b> garante o encaminhamento dos dados e os mecanismos que permitem conhecer o estado da transmissão. Recebe os dados enviados pela camada de aplicação e transforma em pacotes menores que são repassados para a camada de internet. É formado pelos protocolos TCP e UDP. </p>
<p align = "justify"> A <b>Camada de Internet (IP)</b> é encarregada fornecer o pacote de dados (datagrama). É responsável pelo endereçamento e roteamento do pacote, fazendo a conexão entre as redes locais. Adiciona ao pacote o endereço IP de origem e o de destino, para que ele saiba qual o caminho deve percorrer. </p>
<p align = "justify"> A <b>Camada de Acesso</b> à Rede especifica a forma que os dados devem ser encaminhados independentemente do tipo de rede utilizado. O Ethernet é o protocolo mais utilizado e possui três componentes principais: Logic Link Control (LLC) que é responsável por adicionar ao pacote, qual protocolo da camada de internet vai entregar os dados para a serem transmitidos. Media Access Control (MAC): responsável por montar o quadro que vai ser enviado pela rede e adiciona tanto o endereço origem MAC quanto o endereço destino, que é o endereço físico da placa de rede. Physical: responsável por converter o quadro gerado pela camada MAC em eletricidade  ou em ondas eletromagnéticas.</p>

Funcionamento das camadas do TCP/IP:
![imagem](http://infotecnews.com.br/wp-content/uploads/2017/01/camada-tcpip-funcionamento.jpg)

## 2. Transport Control Protocol - TCP

### 2.1 Visão Geral
<p align = "justify"> É um dos principais protocolos da camada de transporte do modelo TCP/IP. É um protocolo de transporte fim-a-fim, orientado à conexão, que fornece um serviço confiável de dados entre aplicações parceiras. O TCP garante que dados são entregues integralmente, sem erros, pois ele não só envia pacote de dados, como também recebe, mas isso deixa a aplicação mais lenta. É recomendada para aplicações que não necessitam de respostas em um curtíssimo espaço de tempo.
</p>
<p align = "justify"> Para assegurar que os pacotes de dados enviados vão chegar ao receptor na ordem correta, o TCP usa um sistema de numeração prórpio. A informação é enviada repetidamente para o receptor até o pacote de dados ser recebido corretamente, e ainda há uma checagem de erros que garante que a informação não foi corrompida durante o trajeto.
</p>

### 2.2 Socket
<p align = "justify"> Socket é a ligação entre os processos do servidor e do cliente. Ele é a porta na qual os processos enviam e recebem mensagens. James Kurose definiu socket como "a interface entre a camada de aplicação e a de transporte dentro de uma máquina". O TCP e o UDP são dois tipos de serviços de transporte via socket.
</p>
<p align = "justify"> Quando um script ou aplicação interage com o software de protocolo, ele deve especificar se é um servidor ou um cliente, e os scripts devem especificar também os dados a serem enviados (o remetente), enquanto o receptor deve especificar onde o pacote de dados recebido deve ser armazenado.
</p>
<p align = "justify"> A <b>sequência de funcionamento do servidor TCP</b> é:
</p>
1. Se fornecido um nome de protocolo de transporte, deve-se converter em número; 
2. Criar o socket utilizando a função **socket**;
3. Colocar um endereço IP e porta no socket (função **bind**);
4. Fazer o sistema operacional a colocar o socket em modo passivo (função **listen**);
5. Aceitar uma nova conexão (função **accept**);
6. Enviar/receber dados;
7. Fechar o socket.

### 3.4 Referências
<p align = "justify"> Este documento faz referência aos seguintes links:

* REIS, Rodrigo. Modelo TCP/IP – Definição, camadas e funcionamento . Disponível em: <http://infotecnews.com.br/modelo-tcpip/>. Acesso em: 09 maio 2018.

* http://penta2.ufrgs.br/Esmilda/tcp.html

* https://br.ccm.net/contents/285-o-que-e-o-protocolo-tcp-ip

* https://br.ccm.net/contents/284-o-protocolo-tcp

* https://www.inf.ufes.br/~zegonc/material/Redes_de_Computadores/O%20Protocolo%20TCP.pdf

*  GUGELMIN, Felipe. Internet: qual a diferença entre os protocolos UDP e TCP?. Disponível em: <https://www.tecmundo.com.br/internet/57947-internet-diferenca-entre-protocolos-udp-tcp.htm>. Acesso em: 09 maio 2018.

*  RODRIGUES, Diego Mendes. Python – Sockets – Criando aplicações Cliente e Servidor TCP. Disponível em: <https://pt.linkedin.com/pulse/python-sockets-criando-aplica%C3%A7%C3%B5es-cliente-e-servidor-diego>. Acesso em: 10 maio 2018. 
