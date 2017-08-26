using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.P)){
			paused = !paused;
			
		}

		if(paused){
			GlobalVariables.playerLife += 8 * Time.deltaTime;
		}

	}



}
