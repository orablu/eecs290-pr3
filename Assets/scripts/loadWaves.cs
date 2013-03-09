using UnityEngine;
using System.Collections;
using System.IO;

public class loadWaves : MonoBehaviour {
	//File waveList;
	// Use this for initialization
	void Start () {
		
		StreamReader streamReader = new StreamReader("Assets\\scenes\\Enemy Testing\\waveList.txt");
		string temp = streamReader.ReadToEnd();
		streamReader.Close();
		Debug.Log(temp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
