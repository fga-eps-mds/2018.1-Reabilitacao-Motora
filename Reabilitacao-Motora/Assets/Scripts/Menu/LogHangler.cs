using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class LogHangler : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void OnEnable() {
		Application.logMessageReceived += HandleLog;
	}
	void OnDisable() {
		Application.logMessageReceived -= HandleLog;
	}

	private void HandleLog(string logstring, string stackTrace, LogType type)
	{
		File.AppendAllText("log.txt", logstring+"\n");
	}
}
