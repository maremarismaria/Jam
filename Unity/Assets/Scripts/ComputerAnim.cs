using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Player") && !GameControl.Main().IsStarted()) {
			GameControl.Main().GetPlayer().SetActive(false);
			GetComponent<Animator>().SetBool(GlobalVariables.playerSelected? "GirlAnim" : "BoyAnim", true);
			StartCoroutine(CodingAnimationCorutine());
		}

	}

	IEnumerator CodingAnimationCorutine() {
		yield return new WaitForSeconds(3);
		GameControl.Main().GetPlayer().SetActive(true);
		GetComponent<Animator>().SetBool(GlobalVariables.playerSelected? "GirlAnim" : "BoyAnim", false);
		GameControl.Main().SpawnBugs();
	}

}
