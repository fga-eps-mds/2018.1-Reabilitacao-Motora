# Histórico de Versões

Data|Versão|Descrição|Autor
-|-|-|-
09/05|1.0.0|Descrição do modelo TCP/IP. | Guilherme Siqueira
10/05|1.1.0|Adição do tópico 2. | Guilherme Siqueira
11/05|1.2.0|Adição do item 3 e revisão do item 2. | Guilherme Siqueira
11/05|1.3.0|Adição do item 4 e revisão dos itens 2 e 3. | Guilherme Siqueira
# Sumário
----------------
 1. [Transmission Control Protocol/Internet Protocol - TCP/IP](#1)
   * 1.1 [Visão Geral](#1_1)
   * 1.2 [TCP/IP em Camadas](#1_2)
 2. [Transport Control Protocol - TCP](#2)
    * 2.1 [Visão Geral](#2_1)
    * 2.2 [Socket](#2_2)
 3. [User Datagram Protocol - UDP](#3)
    * 3.1 [Visão Geral](#3_1)
 4. [Estrutura Básica de Programas para Rede](#4)
    * 4.1 [Sequência de Funcionamento do Cliente](#4_1)
    * 4.2 [Sequência de Funcionamento do Servidor](#4_2)
    * 4.3 [Servidor Concorrente](#4_3)
 5. [Referências](#5)

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

## 3. User Datagram Protocol - UDP
### 3.1 Visão Geral
<p align = "justify"> O UDP também é baseado no envio de pacote de informações, mas, ao contrário do UDP, preza pela velocidade ao invés da confiabilidade dos dados enviados. O UDP é voltado para a não conexão, então o fluxo de envio de pacote de dados é unidirecional. O receptor recebe os dados enviados pelo emissor sem conhecer o que foi emitido, mas conhecendo apenas o IP do emissor.
</p>
<p align = "justify"> Em caso de erros na transmissão dos pacote de dados, ocorre o envio do próximo pacote programado pelo sistema, sendo que os anteriores não podem ser recuperados.Isso garante a transmissão rápida dos dados, mas o risco de ter dados perdidos no caminho é potencializado.
</p>
<p align = "justify"> Enquanto no protocolo TCP o cliente envia uma solicitação de abertura de conexão para o envio dos pacotes de dados, no UDP não há essa solicitação e os pacotes são enviados diretamente.
</p>

## 4. Estrutura Básica de Programas para Rede
<p align = "justify"> Utilizando a linguagem de programação Python para exemplificar na prática e algoritmizar o funcionamento do TCP e UDP, temos algumas considerações a fazer:
</p>

* Todo socket pode estar em modo ativo ou passivo;
* Quando um socket é criado ele sempre está no modo ativo.

### 4.1 Sequência de Funcionamento do Cliente
<p align = "justify"> O algoritmo para descrever a <b>sequência de funcionamento do cliente</b> é:
</p>
<p align = "justify"> 1. Caso fornecido um nome de hospedeiro, deve-se convertê-lo em endereço IP; </p>
<p align = "justify"> 2. Caso fornecido um nome de protocolo de transporte, deve-se convertê-lo em número; </p>
<p align = "justify"> 3. Cria-se o socket (função <b>socket</b>); </p>
<p align = "justify"> 4. Conecta-se com o servidor (função <b>connect</b>); </p>
<p align = "justify"> 5. Envia-se/recebe-se dados; </p>
<p align = "justify"> 6. Fecha-se o socket. </b>

<b> Cliente UDP em Python: </b>
```

import socket
HOST = '192.168.1.10'  # Endereco de IP do servidor
PORT = 5000            # Porta em que o servidor está
udp = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
dest = (HOST, PORT)
print 'Para sair use CTRL+X\n'
msg = raw_input()
while msg <> '\x18':
    udp.sendto (msg, dest)
    msg = raw_input()
udp.close()


```
<b> Cliente TCP em Python: </b>
```

import socket
HOST = '127.0.0.1'     # Endereco de IP do servidor
PORT = 5000            # Porta em que o servidor está
tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
dest = (HOST, PORT)
tcp.connect(dest)
print 'Para sair use CTRL+X\n'
msg = raw_input()
while msg <> '\x18':
    tcp.send (msg)
    msg = raw_input()
tcp.close()

```
### 4.2 Sequência de Funcionamento do Servidor
<p align = "justify"> A <b>sequência de funcionamento do servidor</b> é:
</p>
<p align = "justify"> 1. Se fornecido um nome de protocolo de transporte, deve-se converter em número; </p> 
<p align = "justify"> 2. Cria-se o socket utilizando a função <b>socket</b>;</p>
<p align = "justify"> 3. Coloca-se um endereço IP e porta no socket (função <b>bind</b>); </p>
<p align = "justify"> 4. Faz-se o sistema operacional a colocar o socket em modo passivo (função <b>listen</b>); </p>
<p align = "justify"> 5. Aceita-se uma nova conexão (função <b>accept</b>); </p>
<p align = "justify"> 6. Envia-se/recebe-se dados; </p>
<p align = "justify"> 7. Fecha-se o socket; </p>
<p align = "justify"> 8. Volta ao passo 5 para aceitar outra conexão. </p> 

* <b>Observação:</b> Os passos 4 e 5 do servidor só são feitos quando utiliza-se o protocolo TCP.  


<b> Servidor UDP em Python: </b>
```

import socket
HOST = ''              # Endereco de IP do servidor
PORT = 5000            # Porta em que o servidor está
udp = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
orig = (HOST, PORT)
udp.bind(orig)
while True:
    msg, cliente = udp.recvfrom(1024)
    print cliente, msg
udp.close()

```

<b> Servidor TCP em Python: </b>
```

import socket
HOST = ''              # Endereco de IP do servidor
PORT = 5000            # Porta em que o servidor está
tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
orig = (HOST, PORT)
tcp.bind(orig)
tcp.listen(1)
while True:
    con, cliente = tcp.accept()
    print 'Concetado por', cliente
    while True:
        msg = con.recv(1024)
        if not msg: break
        print cliente, msg
    print 'Finalizando conexao do cliente', cliente
    con.close()
    
```

### 4.3 Servidor Concorrente
<p align = "justify"> Quando o servidor está atendendo uma conexão, ele fica dedicado somente a ela, mas para contornar isso deve-se fazer um passo intermediário entre os passos 5 e 6 do subitem <b>4.2</b> para criar um novo processo ou thread e tratar da nova conexão que estará sendo solicitada. Com isso, o processo/thread pai ficará somente recebendo as conexões e o processo/thread filho tratará das requisições dos clientes. Segue abaixo os códigos exemplos do exposto: 
</p>

<b> Servidor TCP concorrente em Python: </b>
```

import socket
import os
import sys
HOST = ''              # Endereco de IP do servidor
PORT = 5000            # Porta em que o servidor está
tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
orig = (HOST, PORT)
tcp.bind(orig)
tcp.listen(1)
while True:
    con, cliente = tcp.accept()
    pid = os.fork()
    if pid == 0:
        tcp.close()
        print 'Conectado por', cliente
        while True:
            msg = con.recv(1024)
            if not msg: break
            print cliente, msg
        print 'Finalizando conexao do cliente', cliente
        con.close()
        sys.exit(0)
    else:
        con.close()
        
```

<b> Servidor TCP concorrente em Python usando thread: </b>
```
import socket
import thread

HOST = ''              # Endereco IP do Servidor
PORT = 5000            # Porta que o Servidor esta

def conectado(con, cliente):
    print 'Conectado por', cliente

    while True:
        msg = con.recv(1024)
        if not msg: break
        print cliente, msg

    print 'Finalizando conexao do cliente', cliente
    con.close()
    thread.exit()

tcp = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

orig = (HOST, PORT)

tcp.bind(orig)
tcp.listen(1)

while True:
    con, cliente = tcp.accept()
    thread.start_new_thread(conectado, tuple([con, cliente]))

tcp.close()

```




## 5 Referências
<p align = "justify"> Este documento faz referência aos seguintes links:

* <b>REIS, Rodrigo. Modelo TCP/IP – Definição, camadas e funcionamento</b> . Disponível em: <http://infotecnews.com.br/modelo-tcpip/>. Acesso em: 09 maio 2018.

* http://penta2.ufrgs.br/Esmilda/tcp.html

* https://br.ccm.net/contents/285-o-que-e-o-protocolo-tcp-ip

* https://br.ccm.net/contents/284-o-protocolo-tcp

* https://www.inf.ufes.br/~zegonc/material/Redes_de_Computadores/O%20Protocolo%20TCP.pdf

*  GUGELMIN, Felipe. <b>Internet: qual a diferença entre os protocolos UDP e TCP?</b>. Disponível em: <https://www.tecmundo.com.br/internet/57947-internet-diferenca-entre-protocolos-udp-tcp.htm>. Acesso em: 09 maio 2018.

*  RODRIGUES, Diego Mendes. <b>Python – Sockets – Criando aplicações Cliente e Servidor TCP</b>. Disponível em: <https://pt.linkedin.com/pulse/python-sockets-criando-aplica%C3%A7%C3%B5es-cliente-e-servidor-diego>. Acesso em: 10 maio 2018. 

*  MORIMOTO, Carlos E. <b>Redes, guia prático</b> . 2ª. ed. [S.l.]: GDH Press e Sul Editores, 2008. 560 p. 

*  MINICZ, Marcio. <b>Socket Básico:</b> Estrutura Básica de Programas para Rede. Disponível em: <https://wiki.python.org.br/SocketBasico>. Acesso em: 11 maio 2018. 
