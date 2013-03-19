using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("w"))
		{
			transform.Translate (0,.5f,0);
		}
		else if(Input.GetKey ("s"))
		{
			transform.Translate (0,-.5f,0);
		}
		else if(Input.GetKey ("a"))
		{
			transform.Translate (-.5f,0,0);
		}
		else if(Input.GetKey ("d"))
		{
			transform.Translate (.5f,0,0);
		}
	}
}
