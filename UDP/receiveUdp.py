import socket
from time import sleep
import sys

UDP_IP = ""
UDP_PORT   = 5005
bufferSize  = 1024

# Create a datagram socket
try:
    UDPServerSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)
except socket.error as msg:
    print ('Failed to create socket. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()

try:    
    UDPServerSocket.setsockopt(socket.SOL_SOCKET, socket.SO_RCVBUF, 0)
except socket.error as msg:
    print ('Failed. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()
    
# Bind to address and ip
try:
    UDPServerSocket.bind((UDP_IP, UDP_PORT))
except socket.error as msg:
    print ('Bind failed. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()

print("UDP server up and listening")

# Listen for incoming datagrams
while(True):

    bytesAddressPair = UDPServerSocket.recvfrom(bufferSize)

    message = bytesAddressPair[0]

    address = bytesAddressPair[1]

    clientMsg = "Message from Client: {}".format(message)
    print(clientMsg)
