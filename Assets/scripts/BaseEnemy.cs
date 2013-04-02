using UnityEngine;
using System.Collections;
using System;

public class BaseEnemy : MonoBehaviour {
	public GameObject CurrentCheckpointTarget;
	public float hp;
	
	private GameObject waveMaster;
	private GameObject target;
	private GameObject[] checkpointList;
	private int currentCheckpointNum;
	
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
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		StepToTarget(CurrentCheckpointTarget);
		checkIfDead();
	}
	
	// Advances one step toward obj.  Must be called in update
	public void StepToTarget(GameObject obj) {
		rigidbody.position = Vector3.MoveTowards(rigidbody.position, obj.transform.position, Time.deltaTime);
		// If you are at the current checkpoint after moving, start advancing to the next
		if(checkAtCheckpoint())
			advanceCheckpoint();
	}
	
	void advanceCheckpoint() {
		currentCheckpointNum++;
		CurrentCheckpointTarget = checkpointList[currentCheckpointNum];
	}
	
	bool atTarget(GameObject obj) {
		if (Math.Abs (transform.position.x - obj.transform.position.x) <=.1 && 
			Math.Abs (transform.position.z - obj.transform.position.z) <=.1)
		{
			//rigidbody.velocity = new Vector3(0f,0f,0f);
			transform.position.Set(obj.transform.position.x,transform.position.y,obj.transform.position.z);
			return true;
		}
		else
			return false;
	}
	
	bool checkAtCheckpoint() {
		if (Math.Abs (transform.position.x - CurrentCheckpointTarget.transform.position.x) <=.1 && 
			Math.Abs (transform.position.z - CurrentCheckpointTarget.transform.position.z) <=.1)
		{
			//rigidbody.velocity = new Vector3(0f,0f,0f);
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
