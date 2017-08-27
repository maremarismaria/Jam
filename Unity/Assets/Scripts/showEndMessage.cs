using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showEndMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag("EndText").GetComponent<Text>().text = GlobalVariables.message;
		GlobalVariables.win = false;
		GlobalVariables.gameOver = false;
	}
}
