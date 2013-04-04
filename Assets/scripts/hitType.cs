/// <summary>
/// Sam Schneider
/// EECS 290
/// Project 3
/// </summary>
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
