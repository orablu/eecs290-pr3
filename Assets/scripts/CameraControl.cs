using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public float leftBorder = -17f, rightBorder = 15.5f, upperBorder = -2.5f, lowerBorder = -12.5f;
	private Vector3 startPos, zoomedOut; 
	private bool stopCam = true;
	
	// Use this for initialization
	void Start () {
		startPos = new Vector3(13, 10, -7);
		zoomedOut = new Vector3(-5, 10, -7);
		zoomOut();
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopCam) {
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
	
	void zoomOut() {
		camera.orthographicSize = 12;
		transform.position = zoomedOut;
		stopCam = true;
	}
	
	void zoomStandard() {
		camera.orthographicSize = 3;
		transform.position = startPos;
		stopCam = false;
	}
}
