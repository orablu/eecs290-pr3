using UnityEngine;
using System.Collections;

public class hitType{
	public float dmg;
	public GameObject source;
			
	public hitType(float d, GameObject s) {
		dmg = d;
		source = s;
	}
}
