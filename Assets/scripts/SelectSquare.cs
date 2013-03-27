using UnityEngine;
using System.Collections;

public class SelectSquare : MonoBehaviour {
	
	
	public GameObject archerPrefab, catapultPrefab;
	private GameObject[] prefabs = new GameObject[2];
	
	//public GameObject catapultPrefab;
	private GameObject testTower; 
	private bool empty = true, tower = false, unavailable = false; // Possible states of grid piece
	public Texture bumpMap;
	public int towerType; // Type of tower the user currently has selected
	private GameObject gm;
	private GameMaster gmScript;
	
	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameMaster");
		gmScript = gm.GetComponent<GameMaster>();
		
		prefabs[0] = archerPrefab;
		prefabs[1] = catapultPrefab;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		
		if (empty) { // If the cube is empty, places a tower and alters the properties of the piece
			towerType = gmScript.selectionGridInt;
			testTower = Instantiate(prefabs[towerType], transform.position, Quaternion.identity) as GameObject;
			empty = false;
			tower = true;
		} else if (tower) { // If there is a tower, send a message to the GameMaster to update the GUI
			GameObject.Find("GameMaster").SendMessage("towerDisplay", towerType);	
		} else {
			print("Not an available area to build on");
		}
	}
	
	void OnMouseOver() {
		
		renderer.enabled = true; // Show the Selection area
		if (tower) { // TODO: select different ranges for different towers
			renderer.material.SetTexture("_MainTex", bumpMap); // If there is a tower there, show a range
		}
    }
	
	// Makes block invisible again upon moving the mouse off of it
	void OnMouseExit() {
		renderer.enabled = false;	
	}
	
	// Will be used to alter what blocks are available depending on map path
	void setUnavailable() {
		unavailable = true;	
	}
}
