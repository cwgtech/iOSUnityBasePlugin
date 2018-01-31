using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginTest : MonoBehaviour {

#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern double IOSgetElapsedTime();
#endif

	// Use this for initialization
	void Start () {

		Debug.Log("Elapsed Time: " + getElapsedTime());
	}

	int frameCounter = 0;
	// Update is called once per frame
	void Update () {

		frameCounter++;
		if (frameCounter>=5)
		{
			Debug.Log("Tick: " + getElapsedTime());
			frameCounter = 0;
		}
	}

	double getElapsedTime()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
			return IOSgetElapsedTime();
		Debug.LogWarning("Wrong platform!");
		return 0;
	}
}
