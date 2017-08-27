using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GlobalVariables.playerLife <= 0){
			GlobalVariables.gameOver = true;
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.tag == "Jam" && GlobalVariables.playerLife > 0){
			GlobalVariables.win = true;
		}
	}

}
