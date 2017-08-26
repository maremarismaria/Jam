using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBehaviour : MonoBehaviour {

	Vector3 pos;
	//float time;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		if(Random.Range(0.0f, 5000f * Time.deltaTime) < 1){
			float x = Random.Range(0.0f, GlobalVariables.width);
			float y = pos.y;
			float z = pos.z;

			Instantiate(gameObject, new Vector3 (x, y, z), Quaternion.identity);
			//time = Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if(collider.gameObject.tag == "Player"){
			GlobalVariables.numPizzas += 1;
			Destroy(gameObject);
		}

		if(collider.gameObject.tag == "Bug"){
			Destroy(gameObject);
		}

		
	}

}
