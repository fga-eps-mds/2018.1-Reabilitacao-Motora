using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class TestUDPClient {

	[Test]
	public void TestUDPClientSimplePasses() {
		
		string host = "127.0.0.1";
    	int port = 5005;
    	UdpClient client;
    
        client = new UdpClient();
        client.Connect(host, port);
		
		Assert.AreNotEqual(client.Client.Connected, false);
	}
}
