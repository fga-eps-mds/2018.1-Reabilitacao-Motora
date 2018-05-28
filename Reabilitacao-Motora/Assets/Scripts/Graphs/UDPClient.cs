using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;

/**
 * Classe que inicia a comunicação udp para envio de dados a um servidor
 */
public class UDPClient : MonoBehaviour
{
    private string host = "127.0.0.1";
    private const int port = 5005;
    private UdpClient client;

    public Transform mao, cotovelo, ombro, braco; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
    float current_time_movement = 0; //tempo do movimento inicial

    /**
    * Metodo que ao dar start no unity instancia um client e o conecta ao servidor
    */
    void Start()
    {
        client = new UdpClient();
        client.Connect(host, port);
    }

    /**
	 * Metodo que atualiza em tempo real os valores das posições do braço do avatar e envia ao servidor
	 */
    void FixedUpdate()
    {
       
        current_time_movement += Time.fixedDeltaTime;

        StringBuilder sb = new StringBuilder();
        //sb recebe o tempo do movimento
        sb.Append(current_time_movement).Append(" ");

        //sb recebe a posição e rotação da mão
        sb.Append(mao.position.x).Append(" ").Append(mao.position.y).Append(" ").Append(mao.position.z).Append(" ");
        sb.Append(mao.rotation.x).Append(" ").Append(mao.rotation.y).Append(" ").Append(mao.rotation.z).Append(" ");

        //sb recebe a posição e rotação da cotovelo
        sb.Append(cotovelo.position.x).Append(" ").Append(cotovelo.position.y).Append(" ").Append(cotovelo.position.z).Append(" ");
        sb.Append(cotovelo.rotation.x).Append(" ").Append(cotovelo.rotation.y).Append(" ").Append(cotovelo.rotation.z).Append(" ");

        //sb recebe a posição e rotação da ombro
        sb.Append(ombro.position.x).Append(" ").Append(ombro.position.y).Append(" ").Append(ombro.position.z).Append(" ");
        sb.Append(ombro.rotation.x).Append(" ").Append(ombro.rotation.y).Append(" ").Append(ombro.rotation.z).Append(" ");

        //sb recebe a posição e rotação da braco
        sb.Append(braco.position.x).Append(" ").Append(braco.position.y).Append(" ").Append(braco.position.z).Append(" ");
        sb.Append(braco.rotation.x).Append(" ").Append(braco.rotation.y).Append(" ").Append(braco.rotation.z).Append("\n");
        
        //codifica toda a string para fazer o envio ao servidor
        byte[] dgram = Encoding.UTF8.GetBytes(sb.ToString());
        client.Send(dgram, dgram.Length);   
    }
    
    /**
    * Metodo que finaliza a comunicação 
    */
    void OnApplicationQuit()
    {
        client.Close();
    }
}
