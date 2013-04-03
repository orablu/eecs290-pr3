using UnityEngine;
using System.Collections;
using System;

public class BaseEnemy : MonoBehaviour {
	private GameObject checkpointTarget;
	public float speed;
	public float hp;
	
	private Vector3 pointLeftPath;
	private GameObject storedTarget;
	private GameObject waveMaster;
	public GameObject currentTarget;
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
		checkpointTarget = checkpointList[0];
		currentTarget = checkpointTarget;
		currentCheckpointNum = 0;
		speed = 3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StepToTarget(currentTarget);
		checkIfDead();
	}
	
	// Advances one step toward obj.  Must be called in update
	public void StepToTarget(GameObject obj) {
		rigidbody.position = Vector3.MoveTowards(rigidbody.position, obj.transform.position, speed*Time.deltaTime);
		// If you are at the current checkpoint after moving, start advancing to the next
		if(checkAtCheckpoint()) {
			if(currentCheckpointNum == checkpointList.Length - 1) {
				Destroy (gameObject);
				waveMaster.BroadcastMessage("enemyFinished");
			}
			else
				advanceCheckpoint();
		}
	}
	
	void advanceCheckpoint() {
		currentCheckpointNum++;
		checkpointTarget = checkpointList[currentCheckpointNum];
		currentTarget = checkpointTarget;
	}
	
	bool atTarget(GameObject obj) {
		if (Math.Abs (transform.position.x - obj.transform.position.x) <=.1 && 
			Math.Abs (transform.position.z - obj.transform.position.z) <=.1) {
			//rigidbody.velocity = new Vector3(0f,0f,0f);
			transform.position.Set(obj.transform.position.x,transform.position.y,obj.transform.position.z);
			return true;
		}
		else
			return false;
	}
	
	bool checkAtCheckpoint() {
		if (Math.Abs (transform.position.x - checkpointTarget.transform.position.x) <=.1 && 
			Math.Abs (transform.position.z - checkpointTarget.transform.position.z) <=.1) {
			//rigidbody.velocity = new Vector3(0f,0f,0f);
			transform.position.Set(checkpointTarget.transform.position.x,transform.position.y,checkpointTarget.transform.position.z);
			return true;
		}
		else
			return false;
	}
	
	public void hit(float dmg, GameObject source) {
		hp = hp - dmg;
		storedTarget = currentTarget;
		currentTarget = source;
		checkIfDead();
	}
	
	void checkIfDead() {
		if(hp <= 0f) {
			Destroy (gameObject);
			waveMaster.BroadcastMessage("enemyKilled");
		}
	}
		
}
