/// <summary>
/// Sam Schneider
/// EECS 290
/// Project 3
/// </summary>
using UnityEngine;
using System.Collections;

public class testingTower : MonoBehaviour {
	public float hp;
	public float dmg;
	public GameObject target;
	public float delayTime;
	public bool attacking;
	// Use this for initialization
	void Start () {
		hp = 100f;
		dmg = 20f;
		target = null;
		delayTime = 1;
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!target && !attacking) {
			target = GameObject.Find("Square(Clone)");
		}
		if(target != null && !attacking) {
			attacking = !attacking;
			StartCoroutine(attack (target));
		}
		
	}
	
	void hit(hitType args) {
		float dmg = args.dmg;
		hp = hp - dmg;
		if(hp < 0) {
			args.source.SendMessage("targetDown");
			Destroy(gameObject);
		}
	}
	IEnumerator attack(GameObject target) {
		for(int i=10; i > 0; i--) {
			yield return new WaitForSeconds(delayTime);
			hitType args = new hitType(5f, gameObject);
			target.SendMessage("hit", args);
		}
	}
	
	void onCollisionEnter(Collision collision) {
		Debug.Log("Collision");
	}
	
	void onTriggerEnter(Collider other) {
		Debug.Log("Collision");	
	}
	
}
