using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public GameObject CurrentCheckpoint;
	private GameObject[] checkpointList;
	// Use this for initialization
	void Start () {
		checkpointList = new GameObject[10];
		for(int i=0; i < 10; i++)
		{
			checkpointList[i] = GameObject.Find ("Checkpoint "+ (i+1));
		}
		CurrentCheckpoint = checkpointList[0];
		Move ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	void Move() {
		
		Debug.Log ("Moving");
	}
}
