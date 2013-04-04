using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public Texture2D archerTex; // Symbol for archer tower
	public Texture2D cannonTex; // Symbol for cannon tower
	public Texture2D flamerTex; // Symbol for flamer tower
	public Texture2D healerTex; // Symbol for healer tower
	public GUISkin TDSkin; // Custom skin to be used for all GUIs in game
	public int selectionGridInt = 0; // Index for selected tower
	private string[] selectionStrings = {"Archer", "Catapult", "Spike", "Healer"}; // Names of the Towers available for purchase
	public GameObject gridPrefab;
	private GameObject[][] gridPieces = new GameObject[39][];
	private GameObject waveMaster;
	private GameObject gridPiece;
	
	public int waveCount = 1, baseHealth = 100, gold; // User Resources & Wave info
	private bool betweenRounds = true;
	
	// Use this for initialization
	void Start () {
		waveMaster = GameObject.Find ("WaveMaster");
		for (int i = 0; i < 39; i++) {
			gridPieces[i] = new GameObject[14];	
		}
		
		/* Instantiates an multi-dimensional array of cubes, making a grid placement system for towers */
		for (int i = -19; i < 20; i++) {
			for (int j = -14; j < 0; j++) {
				gridPiece = Instantiate(gridPrefab, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
				gridPieces[i + 19][j + 14] = gridPiece;
			}
		}
		
		/* Declares selective grid pieces unavailable */
		for (int i = 11; i < 26; i++) {
			gridPieces[i][5].gameObject.SendMessage("setUnavailable");
			gridPieces[i][6].gameObject.SendMessage("setUnavailable");
		}
		for (int i = 24; i < 26; i++) 
			for (int j = 5; j < 14; j++)
				gridPieces[i][j].gameObject.SendMessage("setUnavailable");
		for (int i = 25; i < 36; i++) {
			gridPieces[i][13].gameObject.SendMessage("setUnavailable");
			gridPieces[i][12].gameObject.SendMessage("setUnavailable");
		}
		for (int j = 9; j < 12; j++) {
			gridPieces[34][j].gameObject.SendMessage("setUnavailable");
			gridPieces[35][j].gameObject.SendMessage("setUnavailable");
		}
		for (int i = 26; i < 35; i++) {
			gridPieces[i][9].gameObject.SendMessage("setUnavailable");
			gridPieces[i][10].gameObject.SendMessage("setUnavailable");
		}
		
		for (int j = 1; j < 13; j++) {
			gridPieces[5][j].gameObject.SendMessage("setUnavailable");
			gridPieces[6][j].gameObject.SendMessage("setUnavailable");
			gridPieces[7][j].gameObject.SendMessage("setUnavailable");
		}
		
		for (int i = 8; i < 12; i++) {
			gridPieces[i][11].gameObject.SendMessage("setUnavailable");
			gridPieces[i][12].gameObject.SendMessage("setUnavailable");
		}
		
		for (int i = 16; i < 28; i++) {
			gridPieces[i][2].gameObject.SendMessage("setUnavailable");
			gridPieces[i][3].gameObject.SendMessage("setUnavailable");
			if (i < 18)
				gridPieces[i][4].gameObject.SendMessage("setUnavailable");
		}
		
		for (int i = 30; i < 39; i++) {
			gridPieces[i][7].gameObject.SendMessage("setUnavailable");
			gridPieces[i][8].gameObject.SendMessage("setUnavailable");
		}
		
		for (int i = 27; i < 31; i++) 
			for (int j = i - 25; j < i - 22; j++)
				gridPieces[i][j].gameObject.SendMessage("setUnavailable");
		for (int i = 12; i > 9; i--) 
			for (int j = 14 - (i - 5); j > 14 - (i - 2); j--) {
				gridPieces[i][j].gameObject.SendMessage("setUnavailable");
				gridPieces[i][j + 2].gameObject.SendMessage("setUnavailable");
		}
		for (int i = 17; i < 22; i++)
			for (int j = i - 10; j < i - 8; j++) {
				if ( i < 19 && j == i - 10)
					gridPieces[i][j].gameObject.SendMessage("setUnavailable");
				if ( i < 20 )
					gridPieces[i + 2][j].gameObject.SendMessage("setUnavailable");
				if ( i > 19 )
					gridPieces[i + 2][j - 2].gameObject.SendMessage("setUnavailable");
		}
		
		gridPieces[18][7].gameObject.SendMessage("setUnavailable");
		gridPieces[17][8].gameObject.SendMessage("setUnavailable");
		gridPieces[16][7].gameObject.SendMessage("setUnavailable");
		gridPieces[22][8].gameObject.SendMessage("setUnavailable");
		gridPieces[19][9].gameObject.SendMessage("setUnavailable");
		gridPieces[22][10].gameObject.SendMessage("setUnavailable");
		gridPieces[21][8].gameObject.SendMessage("setUnavailable");
		gridPieces[22][8].gameObject.SendMessage("setAvailable");
		
	}	
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		
		if (betweenRounds) {
			if (GUI.Button (new Rect (Screen.width/2, Screen.height/2, 100, 100), "Start Round")) {
				betweenRounds = false;
				startRound();
			}
		}
		
		GUI.skin = TDSkin;
		GUI.Box (new Rect (0,0,200,Screen.height), "");
		GUI.Label (new Rect (0,0,100,20), "Wave Number:");
		GUI.Label (new Rect (0,20,100,20), "Base Health:");
		GUI.Label (new Rect (0,40,100,20), "Gold:");
		GUI.Label (new Rect (120,0,80,20), waveCount.ToString());
		GUI.Label (new Rect (120,20,80,20), baseHealth.ToString());
		GUI.Label (new Rect (120,40,80,20), gold.ToString());
		selectionGridInt = GUI.SelectionGrid(new Rect (0, 60, 200, 60), selectionGridInt, selectionStrings, 2);
		
		/* Used to determine which tower to display in the tower preview area */
		switch(selectionGridInt) {
			case 0:
				GUI.Label (new Rect (0, Screen.height/2, 200, Screen.height/2), archerTex);
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Basic Shooting Tower");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 100 gold");	
				break;
			case 1:
				GUI.Label (new Rect (0, Screen.height/2, 200, Screen.height/2), cannonTex);
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Launches a large cannon ball");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 200 gold");
				break;
			case 2:
				GUI.Label (new Rect (0, Screen.height/2, 200, Screen.height/2), flamerTex);
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Shoots in multiple directions at once");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 300 gold");
				break;
			case 3:
				GUI.Label (new Rect (0, Screen.height/2, 200, Screen.height/2), healerTex);
				GUI.Label (new Rect (0, Screen.height - Screen.height/10, 200, Screen.height/10), "Heals towers close within a certain range");
				GUI.Label (new Rect (0, Screen.height - Screen.height/2, 200, 20), "Costs 400 gold");
				break;
		}
		
		/* Toggles GUI buttons with keyboard commands */
		Event e = Event.current;
		if (e.isKey) {
			switch (e.keyCode) {
				case KeyCode.Alpha1: 
					selectionGridInt = 0;
					break;
				case KeyCode.Alpha2:
					selectionGridInt = 1;
					break;
				case KeyCode.Alpha3:
					selectionGridInt = 2;
					break;
				case KeyCode.Alpha4:
					selectionGridInt = 3;
					break;
			}
		}
		
	}
	
	/* Called to display the tower currently selected */
	void towerDisplay(int towerType) {
		selectionGridInt = towerType;
	}
	
	void endRound() {
		waveCount++;
		Camera.mainCamera.SendMessage("zoomOut");
		betweenRounds = true;
	}

	void startRound() {
		Camera.mainCamera.SendMessage("zoomStandard");
		waveMaster.BroadcastMessage("advanceWave");
		
	}
}
