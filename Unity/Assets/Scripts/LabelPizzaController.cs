using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelPizzaController : MonoBehaviour {

	Vector3 pos;
	public GameObject pizza;

	// Use this for initialization
	void Start () {
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("PizzaLabel").GetComponent<Text>().text = "" + GlobalVariables.numPizzas;
		GameObject.FindGameObjectWithTag("BugsLabel").GetComponent<Text>().text = "" + GlobalVariables.numBugs;
		GameObject.FindGameObjectWithTag("ComputerLabel").GetComponent<Text>().text = "" + GlobalVariables.numComputer + "/" + GameControl.Main().NumberOfComputers();

		if(Random.Range(0.0f, 5000f * Time.deltaTime) < 1 && GameControl.Main().IsStarted()){
			float x = Random.Range(0.0f, -GlobalVariables.width);
			float y = pos.y;
			float z = pos.z;

			Instantiate(pizza, new Vector3 (x, y, z), Quaternion.identity);
			//time = Time.time;
		}	
	}
}

