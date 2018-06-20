using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Net;
using UnityEngine.UI;
using System.Threading;

/**
* Descrever aqui o que essa classe realiza.
*/
public class MoveByUDP : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab;
	protected Transform mao, ombro, cotovelo, braco;

	[SerializeField]
	protected GameObject popUpLabel;
	
	Vector3 f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot;
	float current_time_movement;
	LineRenderer lineRenderer;
	bool t;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;
	private static readonly Color c3 = Color.blue;

    UdpClient client;


    private UdpSocketManager udpSocketManager;
    private bool isListenPortLogged = false;
    
    //funciona
    /*
    private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    private const int bufSize = 1024;
    private State state = new State();
    private EndPoint epFrom = new IPEndPoint(IPAddress.Any, 5022);
    private AsyncCallback recv = null;
    
    
    public class State
    {
        public byte[] buffer = new byte[bufSize];
    }

    public void Server(string address, int port)
    {
        Debug.Log("Server");
        _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
        _socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
        Receive();
    }

    private void Receive()
    {
        Debug.Log("Receive");
        _socket.BeginReceiveFrom(state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
        {
            State so = (State)ar.AsyncState;
            int bytes = _socket.EndReceiveFrom(ar, ref epFrom);
            _socket.BeginReceiveFrom(so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);
            Console.WriteLine("RECV: {0}: {1}, {2}", epFrom.ToString(), bytes, Encoding.ASCII.GetString(so.buffer, 0, bytes));
            Debug.Log(Encoding.ASCII.GetString(so.buffer, 0, bytes));
        }, state);
    }

    */
    string rxString;

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

    void Start () 
    {
        Debug.Log("Starting Client");

        udpSocketManager = new UdpSocketManager("0.0.0.0", 5018);
        StartCoroutine(udpSocketManager.initSocket());
        //remoteEP = new IPEndPoint(IPAddress.Any, receivePort);

        //client = new UdpClient(remoteEP);
        //client.JoinMulticastGroup(groupIP);

        //client.BeginReceive(new AsyncCallback(ReceiveServerInfo), null);

       // Server("0.0.0.0", 5022);

    	Assign();
    }
    /*
    void ReceiveServerInfo (IAsyncResult result) 
    {        
        //Debug.Log("Received Server Info");
        byte[] receivedBytes = client.EndReceive(result, ref remoteEP);

        rxString = System.Text.Encoding.UTF8.GetString(receivedBytes);
        //LoadData(rxString);
    }
    */
	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void LoadData(string line)
	{
		var pair = line.Split(' ');
		
		float a = (float.Parse(pair[1]));
		float b = (float.Parse(pair[2]));
		float c = (float.Parse(pair[3]));
		f_mao_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[4]));
		b = (float.Parse(pair[5]));
		c = (float.Parse(pair[6]));
		f_mao_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[7]));
		b = (float.Parse(pair[8]));
		c = (float.Parse(pair[9]));
		f_cotovelo_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[10]));
		b = (float.Parse(pair[11]));
		c = (float.Parse(pair[12]));
		f_cotovelo_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[13]));
		b = (float.Parse(pair[14]));
		c = (float.Parse(pair[15]));
		f_ombro_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[16]));
		b = (float.Parse(pair[17]));
		c = (float.Parse(pair[18]));
		f_ombro_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[19]));
		b = (float.Parse(pair[20]));
		c = (float.Parse(pair[21]));
		f_braco_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[22]));
		b = (float.Parse(pair[23]));
		c = (float.Parse(pair[24]));
		f_braco_rot = (new Vector3 (a, b, c));					
	
	}
	
	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Awake()
	{
		if(GlobalController.instance != null && 
		   (GlobalController.instance.movement != null ||
		   	GlobalController.instance.exercise != null)
		  )
		{
			t = false;
			var go = gameObject;
			current_time_movement = 0;
			if (GlobalController.patientOrPhysio)
			{
				GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
			}
			else
			{
				GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c3);
			}
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}
		
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Update () 
	{
		if (popUpLabel.activeSelf == false && Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
		}
	}

	public void FixedUpdate()
	{
        if (!udpSocketManager.isInitializationCompleted())
        {
            Debug.Log("Initialization Completed");
            return;
        }

        if (!isListenPortLogged)
        {
            Debug.Log("UdpSocketManager, listen port: " + udpSocketManager.getListenPort());
            isListenPortLogged = true;
        }

        foreach (byte[] recPacket in udpSocketManager.receive())
        {

            string receivedMsg = Encoding.UTF8.GetString(recPacket);

            Debug.Log(receivedMsg);

        }

        /*
		if (t){
			//client.BeginReceive (new AsyncCallback (ReceiveServerInfo), null);

			current_time_movement += Time.fixedDeltaTime;

			ombro.localPosition = f_ombro_pos;
			ombro.localEulerAngles = f_ombro_rot;

			braco.localPosition = f_braco_pos;
			braco.localEulerAngles = f_braco_rot;

			cotovelo.localPosition = f_cotovelo_pos;
			cotovelo.localEulerAngles = f_cotovelo_rot;

			mao.localPosition = f_mao_pos;
			mao.localEulerAngles = f_mao_rot;

			if (GlobalController.patientOrPhysio)
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Movimentos/", 
					GlobalController.instance.movement.pontosMovimento,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}
			else
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Exercicios/", 
					GlobalController.instance.exercise.pontosExercicio,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}	

			GetMovementPoints.graphSpawner(transform, pointPrefab, mao, cotovelo, ombro, current_time_movement, ref lineRenderer); 
			if (current_time_movement > 15)
			{
				t = false;
			}
            
		}
<<<<<<< Updated upstream
	}

    void OnApplicationQuit()
    {
        client.Close();
    }

=======
        */
    }

    private void OnDestroy()
    {

        if (udpSocketManager != null)
        {

            udpSocketManager.closeSocketThreads();

        }

    }
}