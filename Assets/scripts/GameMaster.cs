using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public Texture2D archerTex; // Symbol for archer tower
	public GUISkin TDSkin; // Custom skin to be used for all GUIs in game
	private int selectionGridInt = 0; // Index for selected tower
	private string[] selectionStrings = {"Archer", "Catapult", "Spike", "Healer"}; // Names of the Towers available for purchase
	public GameObject testTower; // Prefab for a test tower to be placed
	public GameObject gridPrefab;
	
	private GameObject newTower; 
	private GameObject gridPiece;
	// Use this for initialization
	void Start () {
	
		for (int i = -14; i < 15; i+=2) {
			for (int j = -19; j < 20; j+=2) {
				gridPiece = Instantiate(gridPrefab, new Vector3(j, 1, i), Quaternion.identity) as GameObject;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			
			newTower = Instantiate(testTower, Input.mousePosition, Quaternion.identity) as GameObject;
		}
	}
	
	void OnGUI(){
		
		GUI.skin = TDSkin;
		GUI.Box (new Rect (0,0,200,Screen.height), "");
		GUI.Label (new Rect (0,0,100,20), "Wave Number:");
		GUI.Label (new Rect (0,20,100,20), "Base Health:");
		GUI.Label (new Rect (0,40,100,20), "Gold:");
		GUI.Label (new Rect (120,0,80,20), "1");
		GUI.Label (new Rect (120,20,80,20), "100");
		GUI.Label (new Rect (120,40,80,20), "0");
		//GUI.Button (new Rect (0,60,100,30), new GUIContent ("Archer", archerTex, "Basic shooting tower"));
		GUI.Label (new Rect (100,60,100,40), GUI.tooltip);
		selectionGridInt = GUI.SelectionGrid (new Rect (0, 60, 200, 60), selectionGridInt, selectionStrings, 2);
		
		/* Used to determine which tower to display in the tower preview area */
		switch(selectionGridInt) {
			case 0:
				GUI.Label (new Rect (0, Screen.height/2, 200, Screen.height/2), archerTex);
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Basic Shooting Tower");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 100 gold");	
				break;
			case 1:
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Launches a large cannon ball");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 200 gold");
				break;
			case 2:
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Shoots in multiple directions at once");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 300 gold");
				break;
			case 3:
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Heals towers close within a certain range");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 400 gold");
				break;
		}
		
	}
	
}
