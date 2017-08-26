using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWalkMovement : MonoBehaviour {

	public float velocity = 2;
	public float jumpForce = 100;
	public float jumpCheck = 10000;
	private bool jumping = false;
	private float jumpRandomness;

	// Use this for initialization
	void Start () {
		jumpRandomness = Random.Range(3, 12) * 1000;
		jumpCheck = jumpForce / 10;

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
			GetComponent<Collider2D>().enabled = false;
		}else{
			GetComponent<Collider2D>().enabled = true;
		}

		if(!jumping) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(
				-Mathf.Sign(transform.position.x - position.x) * velocity,
				 GetComponent<Rigidbody2D>().velocity.y);

			if(Random.Range(0, jumpRandomness * Time.deltaTime) < 1) 
				Jump();

		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log(collision.otherCollider.gameObject.LayerMask);
		if(jumping && GetComponent<Rigidbody2D>().velocity.y <= 0
		 && collision.otherCollider.gameObject.tagName != "Player") {
			jumping = false;
		}
	}

	private void Jump() {
		jumping = true;
		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
	}

}


