using UnityEngine;
using System.Collections;
using System;

public class SelectSquare : MonoBehaviour {
	
	
	public GameObject archerPrefab, catapultPrefab, spikePrefab, healerPrefab; // Prefabs for different towers
	private GameObject[] prefabs = new GameObject[4]; // Array of prefabs for easy selection
	
	private GameObject newTower, tempRange; 
	private GameObject dummyArch, dummyCat, dummySpike, dummyHeal;
	private bool empty = true, tower = false, unavailable = false, selected = false; // Possible states of grid piece
	public Texture rangeImage;
	public int towerType; // Type of tower the user currently has selected
	
	private GameObject gm;
	private GameMaster gmScript;
	private string towerName;
	private Vector3 offScreen = new Vector3(0,20,0);
	
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameMaster");
		gmScript = gm.GetComponent<GameMaster>();
		
		prefabs[0] = archerPrefab;
		prefabs[1] = catapultPrefab;
		prefabs[2] = spikePrefab;
		prefabs[3] = healerPrefab;
		
		dummyArch = GameObject.Find("ArchDum");
		dummyCat = GameObject.Find ("CatDum");
		dummySpike = GameObject.Find ("FlameDum");
		dummyHeal = GameObject.Find("HealDum");
		
		/* Disable the towers */
		dummyArch.SendMessage("Disable");
		/*dummyCat.SendMessage("Disable");
		dummySpike.SendMessage("Disable");
		dummyHeal.SendMessage("Disable");*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		if (empty && !unavailable) { // If the cube is empty, places a tower and alters the properties of the piece
			if (selected) {
				moveDummys(offScreen);
				selected = false;
			}
			towerType = gmScript.selectionGridInt;
			newTower = Instantiate(prefabs[towerType], transform.position, Quaternion.identity) as GameObject;  
			empty = false;
			tower = true;
		} else if (tower) { // If there is a tower, send a message to the GameMaster to update the GUI
			GameObject.Find("GameMaster").SendMessage("towerDisplay", towerType);	
		} else {
			Debug.Log ("Not an available area to build on");
		}
	}
	
	void OnMouseOver() {
		
		if (!unavailable && empty) {
			selected = true;
			towerType = gmScript.selectionGridInt;
			moveDummys(this.transform.position);
		}
    }
	
	/* Moves dummys in and out of view for previewing square purchases */
	void moveDummys(Vector3 newPos) {
			
		switch (towerType) {
				case 0:
					dummyArch.transform.position = newPos;	
					break;
				case 1:
					dummyCat.transform.position = newPos;
					break;
				case 2:
					dummySpike.transform.position = newPos;
					break;
				case 3: 
					dummyHeal.transform.position = newPos;
					break;
			}
	}
	
	// Makes block invisible again upon moving the mouse off of it
	void OnMouseExit() {
		if (selected) {
			moveDummys(offScreen);
			selected = false;
		}
	}
	
	// Will be used to alter what blocks are available depending on map path
	void setUnavailable() {
		unavailable = true;	
		renderer.enabled = false;
	}
	
	void setAvailable() {
		unavailable = false;
		
	}
	
	
}
