using UnityEngine;
using System.Collections;

public class CheckpointBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("Checkpoint reached");
        other.BroadcastMessage("advanceCheckpoint");
    }
}
