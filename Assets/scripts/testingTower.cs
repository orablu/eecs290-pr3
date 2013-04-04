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
	
	IEnumerator attack(GameObject target) {
		for(int i=10; i > 0; i--) {
			yield return new WaitForSeconds(delayTime);
			hitType args = new hitType(5f, gameObject);
			target.SendMessage("hit", args);
		}
	}
	
}
