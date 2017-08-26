using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRefillZone : MonoBehaviour {

	//On Home

	Vector3 scale;

	// Use this for initialization
	void Start () {
		scale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			GlobalVariables.playerLife += 1 * Time.deltaTime;
		}
	}

}
