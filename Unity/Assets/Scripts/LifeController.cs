using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {

	//On Life bar

	Vector3 scale;
	
	// Use this for initialization
	void Start () {
		scale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		float x = Mathf.Max(scale.x * GlobalVariables.playerLife / 100.0f, 0.0f);
		float y = scale.y;
		float z = scale.z;

		Debug.Log(GlobalVariables.playerLife);

		gameObject.transform.localScale = new Vector3(x, y, z);
		
	}
}
