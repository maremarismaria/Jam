﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWalkMovement : MonoBehaviour {

	public float velocity = 2;
	public float jumpForce = 100;
	public float jumpCheck = 10;
	private bool jumping = false;
	private float jumpRandomness;

	public float airMoveCoefficient = 0.3f;

	// Use this for initialization
	void Start () {
		jumpRandomness = Random.Range(3, 12) * 1000;
		//jumpCheck = (jumpForce / GetComponent<Rigidbody2D>().mass) / (2.0f * -Physics2D.gravity.y *  GetComponent<Rigidbody2D>().gravityScale);

		Debug.Log(jumpCheck);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = GameControl.Main().ComputerPosition();
		
		if(position.y < jumpCheck && jumping == false) {
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, jumpCheck*2.0f, LayerMask.GetMask("Plataform"));
			if (hit.collider != null) 
				Jump();
		}

		if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			GetComponent<Animator>().SetBool("Falling", false);
			GetComponent<Collider2D>().enabled = false;
		}else{
			GetComponent<Animator>().SetBool("Falling", true);
			GetComponent<Collider2D>().enabled = true;
		}

		if(!jumping) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(
				-Mathf.Sign(transform.position.x - position.x) * velocity,
				 GetComponent<Rigidbody2D>().velocity.y);

			if(Random.Range(0, jumpRandomness * Time.deltaTime) < 1) 
				Jump();

		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(
					Mathf.Lerp(-Mathf.Sign(transform.position.x - position.x) * velocity,
					GetComponent<Rigidbody2D>().velocity.x,
					airMoveCoefficient
				)
				,
				 GetComponent<Rigidbody2D>().velocity.y);
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log(collision.otherCollider.gameObject.LayerMask);
		if(jumping && GetComponent<Rigidbody2D>().velocity.y <= 0
		 && !collision.otherCollider.gameObject.CompareTag("Player")) {
			jumping = false;
			GetComponent<Animator>().SetBool("Jumping", false);
		}
	}

	private void Jump() {
		GetComponent<Animator>().SetBool("Jumping", true);
		jumping = true;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
	}

}


