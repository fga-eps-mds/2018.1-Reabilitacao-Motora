using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class LogHangler : MonoBehaviour
{
	public void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void OnEnable() {
		Application.logMessageReceived += HandleLog;
	}
	public void OnDisable() {
		Application.logMessageReceived -= HandleLog;
	}

	private void HandleLog(string logstring, string stackTrace, LogType type)
	{
		File.AppendAllText("log.txt", logstring+"\n");
	}
}
