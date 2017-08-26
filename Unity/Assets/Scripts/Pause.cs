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

		if(Input.GetKeyDown(KeyCode.P)){
			paused = !paused;
			GetComponent<Animator>().SetBool("Rest", paused);
			
		}

		if(paused){
			if(GetComponent<Rigidbody2D>().velocity.magnitude != 0) {
				paused = false;
				GetComponent<Animator>().SetBool("Rest", false);
			}
			GlobalVariables.playerLife += 8 * Time.deltaTime;
		}

	}



}
