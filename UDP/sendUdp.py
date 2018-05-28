import random
import socket
from time import sleep

UDP_IP = "127.0.0.1"
UDP_PORT = 5005

UDPClientSocket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # UDP

time = 0.0

while 1:
    mao_x = random.uniform(-15.0, 15.0)
    mao_y = random.uniform(-15.0, 15.0)
    mao_z = random.uniform(-15.0, 15.0)
    
    r_mao_x = random.uniform(-15.0, 15.0)
    r_mao_y = random.uniform(-15.0, 15.0)
    r_mao_z = random.uniform(-15.0, 15.0)


    braco_x = random.uniform(-15.0, 15.0)
    braco_y = random.uniform(-15.0, 15.0)
    braco_z = random.uniform(-15.0, 15.0)
    
    r_braco_x = random.uniform(-15.0, 15.0)
    r_braco_y = random.uniform(-15.0, 15.0)
    r_braco_z = random.uniform(-15.0, 15.0)

    ombro_x = random.uniform(-15.0, 15.0)
    ombro_y = random.uniform(-15.0, 15.0)
    ombro_z = random.uniform(-15.0, 15.0)
    
    r_ombro_x = random.uniform(-15.0, 15.0)
    r_ombro_y = random.uniform(-15.0, 15.0)
    r_ombro_z = random.uniform(-15.0, 15.0)

    cotovelo_x = random.uniform(-15.0, 15.0)
    cotovelo_y = random.uniform(-15.0, 15.0)
    cotovelo_z = random.uniform(-15.0, 15.0)
    
    r_cotovelo_x = random.uniform(-15.0, 15.0)
    r_cotovelo_y = random.uniform(-15.0, 15.0)
    r_cotovelo_z = random.uniform(-15.0, 15.0)

    time+=0.2
    message = str(x) + ' '
    message += str(mao_x) + ' ' + str(mao_y) + ' ' + str(mao_z) + ' '
    message += str(r_mao_x) + ' ' + str(r_mao_y) + ' ' + str(r_mao_z) + ' ' 
    message += str(cotovelo_x) + ' ' + str(cotovelo_y) + ' ' + str(cotovelo_z) + ' '
    message += str(r_cotovelo_x) + ' ' + str(r_cotovelo_y) + ' ' + str(r_cotovelo_z) + ' ' 
    message += str(ombro_x) + ' ' + str(ombro_y) + ' ' + str(ombro_z) + ' '
    message += str(r_ombro_x) + ' ' + str(r_ombro_y) + ' ' + str(r_ombro_z) + ' ' 
    message += str(braco_x) + ' ' + str(braco_y) + ' ' + str(braco_z) + ' '
    message += str(r_braco_x) + ' ' + str(r_braco_y) + ' ' + str(r_braco_z) + ' ' 
    
    UDPClientSocket.sendto(bytes(message), (UDP_IP, UDP_PORT))
    sleep(.02)

    
