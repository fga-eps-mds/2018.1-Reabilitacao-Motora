import socket 

"""
Cria conexao Client/Servidor.
Envia e recebe mensagens entre  servidor/cliente.
"""

host = '' 
port = 50000 
backlog = 5 
size = 1024 
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
s.bind((host,port)) 
s.listen(backlog) 

while True:
    client, address = s.accept() 
    print "Cliente Conectado:", address
    client.send("Conectado, Mensagem python...\n")
    
    while True:
        msg = client.recv(1024)
        if not msg:
            break
        print adress,msg
    client.close()
    break

#    while 1: 
#        data = client.recv(size).rstrip('\r\n')
#        if data: 
#            if data=="quit":
#                client.send("Desconectado!\n")
#                client.close()
#                break
#            else:
#                client.send("Mensagem: " + data + "\n")
        
