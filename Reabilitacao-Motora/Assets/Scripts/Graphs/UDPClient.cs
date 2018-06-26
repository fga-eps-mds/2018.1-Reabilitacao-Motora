using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    protected Transform mao, cotovelo, ombro, braco;
    float current_time_movement = 0;

    [System.Serializable]
    public class NecessaryJoints
    {
        public Transform ombroAux, bracoAux, cotoveloAux, maoAux;
    }

    [SerializeField]
    protected NecessaryJoints[] joints;

    public void Assign ()
    {
        if (GlobalController.choiceAvatar == 1)
        {
            ombro = joints[0].ombroAux;
            braco = joints[0].bracoAux;
            cotovelo = joints[0].cotoveloAux;
            mao = joints[0].maoAux;
        }
        else if (GlobalController.choiceAvatar == 2)
        {
            ombro = joints[1].ombroAux;
            braco = joints[1].bracoAux;
            cotovelo = joints[1].cotoveloAux;
            mao = joints[1].maoAux;
        }
        else if (GlobalController.choiceAvatar == 3)
        {
            ombro = joints[2].ombroAux;
            braco = joints[2].bracoAux;
            cotovelo = joints[2].cotoveloAux;
            mao = joints[2].maoAux;
        }
        else if (GlobalController.choiceAvatar == 4)
        {
            ombro = joints[3].ombroAux;
            braco = joints[3].bracoAux;
            cotovelo = joints[3].cotoveloAux;
            mao = joints[3].maoAux;
        }
        else if (GlobalController.choiceAvatar == 5)
        {
            ombro = joints[4].ombroAux;
            braco = joints[4].bracoAux;
            cotovelo = joints[4].cotoveloAux;
            mao = joints[4].maoAux;
        }
    }

    /**
    * Metodo que ao dar start no unity instancia um client e o conecta ao servidor
    */
    void Start()
    {
        client = new UdpClient();
        try
        {
            client.Connect(host, port);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        Assign(); 
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
