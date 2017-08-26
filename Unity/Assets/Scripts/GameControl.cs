using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public GameObject computerPrefab;
	public GameObject bugPrefab;

	public int bugWaveAmount = 4;
	public int numberOfComputers = 4;

	private int numberOfBugs;
	private int computersLeft;

	public float spawnOffset = 0.3f;

	public List<Transform> spawnPositions;

	private static GameControl mainControl;
	private GameObject computer;

	// Use this for initialization
	void Start () {
		numberOfBugs = bugWaveAmount;
		computersLeft = numberOfComputers;
		mainControl = this;
		AddComputer();
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
		for(int i = 0; i < bugWaveAmount; i++) {
			Transform newTranform;
			do{
				newTranform = spawnPositions[Random.Range(0, spawnPositions.Count)];
			}while(newTranform.position == computerTranform.position);
			Vector3 newposition = newTranform.position + new Vector3(Random.Range(spawnOffset, -spawnOffset), Random.Range(spawnOffset, -spawnOffset), 0);
			Instantiate(bugPrefab, newposition, Quaternion.identity);
		}
		numberOfBugs = bugWaveAmount;
	}

	public void BugDie(){
		numberOfBugs--;
		if(numberOfBugs == 0) {
			if(computersLeft == 0) {
				//win
			}else{
				computersLeft--;
				Destroy(computer.gameObject);
				Debug.Log(computersLeft);
				AddComputer();
			}
		}
	}

	public Vector3 ComputerPosition() {
		return computer.transform.position;
	}

}
