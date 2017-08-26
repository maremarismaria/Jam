using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBehaviour : MonoBehaviour {

	//float time;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			GlobalVariables.numPizzas += 1;
			Destroy(gameObject);
		}

		if(collider.gameObject.tag == "Bug" || collider.gameObject.tag == "Underground"){
			Destroy(gameObject);
		}
		
	}

}
