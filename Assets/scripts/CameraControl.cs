using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public float leftBorder = -17f, rightBorder = 15.5f, upperBorder = -2.5f, lowerBorder = -12.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("w"))
		{
			if (transform.position.z < upperBorder)
				transform.Translate (0,.5f,0);
		}
		else if(Input.GetKey ("s"))
		{
			if (transform.position.z >= lowerBorder)
				transform.Translate (0,-.5f,0);
		}
		else if(Input.GetKey ("a"))
		{
			if (transform.position.x > leftBorder)
				transform.Translate (-.5f,0,0);
		}
		else if(Input.GetKey ("d"))
		{
			if (transform.position.x < rightBorder)
				transform.Translate (.5f,0,0);
		}
	}
}
