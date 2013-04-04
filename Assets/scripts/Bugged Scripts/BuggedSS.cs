using UnityEngine;
using System.Collections;

public class SelectSquare : MonoBehaviour {
	
	
	public GameObject archerPrefab, catapultPrefab, spikePrefab, healerPrefab; // Prefabs for different towers
	private GameObject[] prefabs = new GameObject[4]; // Array of prefabs for easy selection
	
	private GameObject newTower;
	private bool empty = true, tower = false, unavailable = false; // Possible states of grid piece
	public Texture rangeImage;
	public int towerType; // Type of tower the user currently has selected
	public GameObject dummyArch, dummyCat, dummySpike, dummyHeal;
	
	private GameObject gm;
	private GameMaster gmScript;
	private Vector3 offScreen = new Vector3(-30, 40, 0);
	
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameMaster");
		gmScript = gm.GetComponent<GameMaster>();
		
		prefabs[0] = archerPrefab;
		prefabs[1] = catapultPrefab;
		prefabs[2] = spikePrefab;
		prefabs[3] = healerPrefab;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		if (empty && !unavailable) { // If the cube is empty, places a tower and alters the properties of the piece
			towerType = gmScript.selectionGridInt;
			newTower = Instantiate(prefabs[towerType], new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Quaternion.identity) as GameObject;  
			empty = false;
			tower = true;
			Debug.Log ("placed");
		} else if (tower) { // If there is a tower, send a message to the GameMaster to update the GUI
			GameObject.Find("GameMaster").SendMessage("towerDisplay", towerType);
			GameObject.Find("GameMaster").SendMessage("setSelectedTower", newTower);
			//Archer arch = (Archer) newTower.GetComponent("Archer");
			//if (arch.RangeObject) 
			//	arch.RangeObject.renderer.enabled = true;
			Debug.Log ("clicked tower");
		} else {
			Debug.Log ("Not an available area to build on");
		}
		
	}
	
	void OnMouseOver() {
		if (!unavailable && empty) {
			moveDummy(new Vector3(transform.position.x, transform.position.y - 2, transform.position.z));
		} else if (tower) {	
		//	Archer arch = (Archer) newTower.GetComponent("Archer");
			//if (arch.RangeObject) 
				//arch.RangeObject.renderer.enabled = true;
		}
    }
	
	// Makes block invisible again upon moving the mouse off of it
	void OnMouseExit() {
		if (!unavailable && empty) {
			moveDummy(offScreen);
		}/* else if (tower) {
			Archer arch = (Archer) newTower.GetComponent("Archer");
			if (arch.RangeObject)
				arch.RangeObject.renderer.enabled = false;
		}*/
	}
	
	void moveDummy(Vector3 newPos) {
		towerType = gmScript.selectionGridInt;
		switch(towerType){
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
	
	// Will be used to alter what blocks are available depending on map path
	void setUnavailable() {
		unavailable = true;	
		renderer.enabled = false;
	}
	
	void setAvailable() {
		unavailable = false;
		
	}
	
	public GameObject getSelectedTower() {
		return newTower;	
	}
}
