﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButtonsMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void select(bool sel){
		GlobalVariables.playerSelected = sel;
		SceneManager.LoadScene("World1");
	}

}
