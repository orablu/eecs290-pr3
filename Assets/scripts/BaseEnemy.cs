using UnityEngine;
using System.Collections;
using System;

public class BaseEnemy : MonoBehaviour {
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
		if(checkAtCheckpoint())
			advanceCheckpoint();
		
			
	}
	void Move() {
		float xVel, zVel;
		if((transform.position.x - CurrentCheckpointTarget.transform.position.x) > .1)
			xVel = -1f;
		else if((transform.position.x - CurrentCheckpointTarget.transform.position.x) < -.1)
			xVel = 1f;
		else
			xVel = 0f;
		if((transform.position.z - CurrentCheckpointTarget.transform.position.z) > .1)
			zVel = -1f;
		else if((transform.position.z - CurrentCheckpointTarget.transform.position.z) < -.1)
			zVel = 1f;
		else
			zVel = 0f;
		Vector3 velocity = new Vector3(xVel,0,zVel);
		rigidbody.velocity = velocity;
	}
	
	void advanceCheckpoint() {
		currentCheckpointNum++;
		CurrentCheckpointTarget = checkpointList[currentCheckpointNum];
		Move ();
	}
	
	bool checkAtCheckpoint() {
		if (Math.Abs (transform.position.x - CurrentCheckpointTarget.transform.position.x) <=.1 && Math.Abs (transform.position.z - CurrentCheckpointTarget.transform.position.z) <=.1)
		{
			rigidbody.velocity = new Vector3(0f,0f,0f);
			transform.position.Set(CurrentCheckpointTarget.transform.position.x,transform.position.y,CurrentCheckpointTarget.transform.position.z);
			return true;
		}
		else
			return false;
	}
		
}
