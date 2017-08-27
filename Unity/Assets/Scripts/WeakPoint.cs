﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private bool toDestroy = false;

	void OnTriggerEnter2D(Collider2D other) {
		if(!toDestroy && other.CompareTag("Player")) {
			toDestroy = true;
			GameControl.Main().BugDie();
			transform.parent.GetComponent<Animator>().SetBool("Die", true);
			Destroy(transform.parent.gameObject, 0.4f);
		}

	}

}
