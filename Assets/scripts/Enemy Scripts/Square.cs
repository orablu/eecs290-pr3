using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Move() {
		rigidbody.AddForce(-10f,0,0);
		Debug.Log ("Moving");
	}
}
