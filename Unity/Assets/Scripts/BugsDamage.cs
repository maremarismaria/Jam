using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsDamage : MonoBehaviour {

	//On bug

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionStay2D(Collision2D collision){
		if(collision.collider.tag == "Player" || collision.collider.tag == "Computer"){
			GlobalVariables.playerLife -= 1 * Time.deltaTime;
		}
	}

}
