using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelPizzaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("PizzaLabel").GetComponent<Text>().text = "" + GlobalVariables.numPizzas;
	}
}
