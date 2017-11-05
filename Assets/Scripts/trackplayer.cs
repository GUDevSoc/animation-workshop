using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackplayer : MonoBehaviour {

	Vector3 playerPosition;
	float cameraspeed = 2;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		transform.position = Vector3.Lerp(transform.position, new Vector3 (playerPosition.x, transform.position.y, transform.position.z), Time.fixedDeltaTime * cameraspeed);
	}
}
