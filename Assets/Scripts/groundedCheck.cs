using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedCheck : MonoBehaviour {

	PlayerController pc;

	// Use this for initialization
	void Awake () {
		pc = GetComponentInParent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D c){
		pc.grounded = true;
	}

	void OnCollisionExit2D(Collision2D c){
		pc.grounded = false;
	}
}
