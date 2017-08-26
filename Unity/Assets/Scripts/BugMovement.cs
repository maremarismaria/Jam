using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour {

	public float velocity = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = GameControl.main().computerPosition();
		transform.position -= Vector3.Normalize(transform.position - position) * velocity * Time.deltaTime;
	}
}

