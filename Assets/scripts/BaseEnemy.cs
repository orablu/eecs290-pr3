using UnityEngine;
using System.Collections;
using System;

public class BaseEnemy : MonoBehaviour {
	public GameObject CurrentCheckpointTarget;
	private GameObject[] checkpointList;
	private int currentCheckpointNum;
	public float hp;
	private GameObject waveMaster;
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		hp = 100f;
		waveMaster = GameObject.Find ("WaveMaster");
		checkpointList = new GameObject[13];
		for(int i=0; i < 13; i++)
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
		checkIfDead();
			
	}
	void Move() {
		rigidbody.velocity.Set(0,0,0);
		transform.LookAt(CurrentCheckpointTarget.transform.position);
		
		//Vector3 velocity = Vector3.MoveTowards(transform.position, CurrentCheckpointTarget.transform.position, Time.deltaTime);
		rigidbody.velocity = Vector3.forward;
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
	
	public void hit(float dmg, GameObject source) {
		hp = hp - dmg;
		target = source;
		checkIfDead();
	}
	
	void checkIfDead() {
		if(hp <= 0f) {
			Destroy (gameObject);
			waveMaster.BroadcastMessage("enemyKilled");
		}
	}
		
}
