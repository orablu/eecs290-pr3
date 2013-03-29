using UnityEngine;
using System.Collections;
using System.IO;

public class loadWaves : MonoBehaviour {
	// Use this for initialization
	public int[] numberArray = new int[10];
	public string[] typeArray = new string[10];
	public GameObject prefab;
	public float spawnDelayTime;
	public int numEnemiesRemaining;
		
	private int waveNumber;
	private int numEnemies;
	private string currentType;
	private GameObject start;
	private GameObject end;
	private GameObject gameMaster;
	
	void Start () {
		waveNumber = 1;
		spawnDelayTime = 2f;
		gameMaster = GameObject.Find ("GameMaster");
		start = GameObject.Find("Start");
		end = GameObject.Find("Checkpoint 10");
		
		/*	Code to load wave list file into two arrays, one of which has the 
		 *	type of enemy spawning, the other the number of enemies spawning.
		 */
		int numberIndex = 0;
		int typeIndex = 0;
		
		StreamReader streamReader = new StreamReader("Assets\\waveList.txt");
		while(!streamReader.EndOfStream)
		{
			string line = streamReader.ReadLine();
			string[] tempArray;
			tempArray = line.Split(' ');
			numberArray[numberIndex] = int.Parse(tempArray[0]);
			typeArray[typeIndex] = tempArray[1];
			numberIndex++;
			typeIndex++;
		}
		streamReader.Close();
		
		spawnWave ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*if(isWaveOver())
		{
			advanceWave();
		}*/
	}
	
	//	Calls spawn whatever enemyObject is numEnemies times with a delay of delayTime inbetween each
	IEnumerator spawnDelay(float delayTime, int numEnemies, Object enemyObject) {
		for(int i=0; i<numEnemies; i++) {
			spawn (enemyObject);
			yield return new WaitForSeconds(delayTime);
		}
	}
	
	/*	numEnemies = number of enemies to spawn for current wave
	 * 	currentType = type of enemy to spawn for current wave
	 * 	currentEnemy = base enemy object to clone
	 */ 
	void spawnWave()
	{
		numEnemiesRemaining = 0;
		numEnemies = numberArray[waveNumber - 1];
		currentType = typeArray[waveNumber - 1];
		Object currentEnemy = Resources.Load(currentType);
		StartCoroutine (spawnDelay (spawnDelayTime, numEnemies, currentEnemy));
	}
	
	//	Clones enemyObject and spawns it
	void spawn(Object enemyObject)
	{
		GameObject clone;
		clone = Instantiate(enemyObject, start.transform.position, transform.rotation) as GameObject;
		numEnemiesRemaining++;
	}
	
	//  Call this to advance wave
	void advanceWave() {
		waveNumber++;
		//gameMaster.BroadcastMessage("advanceWave");
		spawnWave();
	}
	
	//  Call to see if current wave is over
	bool isWaveOver() {
		if(numEnemiesRemaining == 0)
			return true;
		else
			return false;
	}
	
	//  Call when an enemy is killed
	public void enemyKilled() {
		numEnemiesRemaining--;
	}
}
