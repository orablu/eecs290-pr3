using UnityEngine;
using System.Collections;
using System.IO;

public class loadWaves : MonoBehaviour {
	// Use this for initialization
	public int[] numberArray = new int[10];
	public string[] typeArray = new string[10];
	
	private int waveNumber;
	private int enemiesRemaining;
	private string currentType;
	
	void Start () {
		int waveNumber = 1;
		
		/********************************************************************
		 * Code to load wave list file into two arrays, one of which has the 
		 * type of enemy spawning, the other the number of enemies spawning.
		 ********************************************************************/
		int numberIndex = 0;
		int typeIndex = 0;
		
		StreamReader streamReader = new StreamReader("Assets\\scenes\\Enemy Testing\\waveList.txt");
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
		/********************************************************************/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	bool spawnWave()
	{
		enemiesRemaining = numberArray[waveNumber - 1];
		currentType = typeArray[waveNumber - 1];
		//GameObject baseEnemy = GameObject.FindSceneObjectsOfType("Square");
		return true;
	}
}
