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

	public static GameControl main() {
		return mainControl;
	}

	public void AddComputer() {
		Transform computerTranform = spawnPositions[Random.Range(0, spawnPositions.Count)];
		computer = Instantiate(computerPrefab, computerTranform.position, Quaternion.identity);
		for(int i = 0; i < numberOfBugs; i++) {
			Transform newTranform;
			do{
				newTranform = spawnPositions[Random.Range(0, spawnPositions.Count)];
			}while(newTranform.position == computerTranform.position);
			Instantiate(bugPrefab, newTranform.position, Quaternion.identity);
		}
	}

	public void BugDie(){
		numberOfBugs--;
		if(numberOfBugs == 0) {
			if(computersLeft == 0) {
				//win
			}else{
				computersLeft--;
				AddComputer();
			}
		}
	}

	public Vector3 computerPosition() {
		return computer.transform.position;
	}

}
