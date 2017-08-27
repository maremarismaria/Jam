using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//
		//SceneManager.LoadScene("Control");
		//SceneManager..LoadScene("Team");
	}

	public void openScene(string scene){
		SceneManager.LoadScene(scene);
	}

	

}
