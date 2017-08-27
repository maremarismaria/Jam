using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public GameObject computerPrefab;
	public float mainBugPercentage;
	public GameObject bugPrefab;
	public GameObject bug2Prefab;
	public GameObject playerGirl;
	public GameObject playerBoy;
	public GameObject victoryJam;

	private GameObject player;

	public int bugWaveAmount = 4;
	public int numberOfComputers = 4;

	private bool init = false;

	private int numberOfBugs{
		get{
			return GlobalVariables.numBugs;			
		}

		set{
			GlobalVariables.numBugs = value;
		}
	}
	private int computersLeft{
		get{
			return numberOfComputers - GlobalVariables.numComputer;			
		}

		set{
			GlobalVariables.numComputer = numberOfComputers - value;
		}
	}

	public float spawnOffset = 0.3f;

	public List<Transform> spawnPositions;

	private static GameControl mainControl;
	private GameObject computer;

	// Use this for initialization
	void Start () {
		GlobalVariables.playerLife = 100;
		numberOfBugs = bugWaveAmount;
		computersLeft = numberOfComputers;
		mainControl = this;
		AddComputer();
		player = Instantiate(GlobalVariables.playerSelected? playerGirl : playerBoy, FindPositionWithoutPc(), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static GameControl Main() {
		return mainControl;
	}

	public void AddComputer() {
		Transform computerTranform = spawnPositions[Random.Range(0, spawnPositions.Count)];
		computer = Instantiate(computerPrefab, computerTranform.position, Quaternion.identity);	
	}

	public void SpawnBugs() {
		init = true;
		for(int i = 0; i < bugWaveAmount; i++) {
			Vector3 newposition = FindPositionWithoutPc() + new Vector3(Random.Range(spawnOffset, -spawnOffset), Random.Range(spawnOffset, -spawnOffset), 0);
			Instantiate( Random.Range(0, 100) < mainBugPercentage? bugPrefab : bug2Prefab, newposition, Quaternion.identity);
		}
		numberOfBugs = bugWaveAmount;
	}

	private Vector3 FindPositionWithoutPc(){
		Transform newTranform;
		do{
			newTranform = spawnPositions[Random.Range(0, spawnPositions.Count)];
		}while(newTranform.position == computer.transform.position);
		return newTranform.position;
	}

	private bool end = false;
	public void BugDie(){
		numberOfBugs--;
		Debug.Log(numberOfBugs+" " + numberOfComputers);
		if(numberOfBugs == 0) {
			if(!end && computersLeft == 1) {
				end = true;
				Instantiate(victoryJam, spawnPositions[Random.Range(0, spawnPositions.Count)].position, Quaternion.identity);
			}else{
				computersLeft--;
				Destroy(computer.gameObject);
				Debug.Log(computersLeft);
				AddComputer();
				SpawnBugs();
			}
		}

	}

	public bool IsStarted() {
		return init;
	}

	public Vector3 ComputerPosition() {
		return computer.transform.position;
	}

	public GameObject GetPlayer() {
		return player;
	}

	public int NumberOfComputers() {
		return numberOfComputers;
	}

}
