using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	public GameObject CurrentCheckpointTarget;
	private GameObject[] checkpointList;
	private int currentCheckpointNum;
	// Use this for initialization
	void Start () {
		checkpointList = new GameObject[10];
		for(int i=0; i < 10; i++)
		{
			checkpointList[i] = GameObject.Find ("Checkpoint "+ (i+1));
		}
		CurrentCheckpointTarget = checkpointList[0];
		currentCheckpointNum = 0;
		Move ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	void Move() {
		float xVel, zVel;
		if(transform.position.x > CurrentCheckpointTarget.transform.position.x)
			xVel = -1f;
		else if(transform.position.x < CurrentCheckpointTarget.transform.position.x)
			xVel = 1f;
		else
			xVel = 0f;
		if(transform.position.z > CurrentCheckpointTarget.transform.position.z)
			zVel = -1f;
		else if(transform.position.z < CurrentCheckpointTarget.transform.position.z)
			zVel = 1f;
		else
			zVel = 0f;
		Vector3 velocity = new Vector3(xVel,0,zVel);
		rigidbody.velocity = velocity;
		Debug.Log ("Moving");
	}
	void advanceCheckpoint() {
		currentCheckpointNum++;
		CurrentCheckpointTarget = checkpointList[currentCheckpointNum];
		Move ();
	}
		
}
