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
		Vector3 computerPosition = GameControl.Main().ComputerPosition();
		Vector3 position = Vector3.Normalize(transform.position - computerPosition) * velocity * Time.deltaTime;
		transform.position -= position;
	}
}

