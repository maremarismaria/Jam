using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour {

	public MoveAround otherside;
	public bool isTheRightSide = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") || other.CompareTag("Bug")) {
			otherside.MoveHere(other.gameObject);
		}
	}

	public void MoveHere(GameObject toMove){
		float offset = toMove.GetComponent<Collider2D>().bounds.size.x;
		Vector3 toMovePosition = toMove.transform.position;
		float x = isTheRightSide? GetComponent<BoxCollider2D>().bounds.min.x - offset : GetComponent<BoxCollider2D>().bounds.max.x + offset;
		toMove.transform.position = new Vector3(x, toMovePosition.y, toMovePosition.z);
	}

}
