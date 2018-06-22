import random
import socket
from time import sleep
from time import time as current_time
import sys

UDP_IP = "192.168.0.2"
UDP_SEND_PORT = 61201

UDP_RECEIVE_PORT   = 5005
bufferSize  = 1024

def generate_data():
    time = 0.0

    mao_x = random.uniform(-1.0, 1.0)
    mao_y = random.uniform(-1.0, 1.0)
    mao_z = random.uniform(-1.0, 1.0)
    
    r_mao_x = random.uniform(-1.0, 1.0)
    r_mao_y = random.uniform(-1.0, 1.0)
    r_mao_z = random.uniform(-1.0, 1.0)

    braco_x = random.uniform(-1.0, 1.0)
    braco_y = random.uniform(-1.0, 1.0)
    braco_z = random.uniform(-1.0, 1.0)
    
    r_braco_x = random.uniform(-1.0, 1.0)
    r_braco_y = random.uniform(-1.0, 1.0)
    r_braco_z = random.uniform(-1.0, 1.0)

    ombro_x = random.uniform(-1.0, 1.0)
    ombro_y = random.uniform(-1.0, 1.0)
    ombro_z = random.uniform(-1.0, 1.0)
    
    r_ombro_x = random.uniform(-1.0, 1.0)
    r_ombro_y = random.uniform(-1.0, 1.0)
    r_ombro_z = random.uniform(-1.0, 1.0)

    cotovelo_x = random.uniform(-1.0, 1.0)
    cotovelo_y = random.uniform(-1.0, 1.0)
    cotovelo_z = random.uniform(-1.0, 1.0)
    
    r_cotovelo_x = random.uniform(-1.0, 1.0)
    r_cotovelo_y = random.uniform(-1.0, 1.0)
    r_cotovelo_z = random.uniform(-1.0, 1.0)

    time+=0.2
    message = str(time) + ' '
    message += str(mao_x) + ' ' + str(mao_y) + ' ' + str(mao_z) + ' '
    message += str(r_mao_x) + ' ' + str(r_mao_y) + ' ' + str(r_mao_z) + ' ' 
    message += str(cotovelo_x) + ' ' + str(cotovelo_y) + ' ' + str(cotovelo_z) + ' '
    message += str(r_cotovelo_x) + ' ' + str(r_cotovelo_y) + ' ' + str(r_cotovelo_z) + ' ' 
    message += str(ombro_x) + ' ' + str(ombro_y) + ' ' + str(ombro_z) + ' '
    message += str(r_ombro_x) + ' ' + str(r_ombro_y) + ' ' + str(r_ombro_z) + ' ' 
    message += str(braco_x) + ' ' + str(braco_y) + ' ' + str(braco_z) + ' '
    message += str(r_braco_x) + ' ' + str(r_braco_y) + ' ' + str(r_braco_z) + ' ' 

    return message

def get_latency(data, UDPClientSocket, UDPServerSocket):
    start_time = current_time()
    UDPClientSocket.sendto(str.encode(message), (UDP_IP, UDP_SEND_PORT))

    first_time = True

    while True:
        bytesAddressPair = UDPServerSocket.recvfrom(bufferSize)

        message = "{}".format(bytesAddressPair[0])

        if not first_time:
            if message != old_message:
                return current_time() - start_time

        old_message = message

        address = bytesAddressPair[1]

        clientMsg = "Message from Client: {}".format(message)

        print(clientMsg)

# Configure data sending socket
    
try:
    UDPClientSocket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
except socket.error as msg:
    print ('Failed to create socket. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()

print("UDP socket up and sending")

# Configure data receiving socket

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

try:
    UDPServerSocket.bind((UDP_IP, UDP_RECEIVE_PORT))
except socket.error as msg:
    print ('Bind failed. Error Code : ' + str(msg[0]) + ' Message ' + msg[1])
    sys.exit()

print("UDP server up and listening")

data = generate_data()

latency = get_latency(data, UDPClientSocket, UDPServerSocket)

print(latency)


