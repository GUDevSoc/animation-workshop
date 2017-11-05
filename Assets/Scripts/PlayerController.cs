using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	public bool grounded = true;
	bool isjump;
	bool flipped;

	public float speed=0.5f;
	public float jumpForce = 2f;
	public float jumpLimit = 1f;

	float jumpTime = 0f;
	Rigidbody2D rb2d;
	Animator anim;
	Vector2 playerVelocity;


	//animator flags
	bool isMove;
	bool isRoll;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		playerVelocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, rb2d.velocity.y);


		//set anim bools here
		 
		JumpBehaviour ();
		FlipBehaviour ();

	}

	void FixedUpdate(){
		if (grounded) {
			jumpTime = 0f;
		}
		rb2d.velocity = playerVelocity;
	}

	void JumpBehaviour(){
		if (Input.GetButtonDown ("Jump")&& grounded) { //initial jump needs to be on ground
			startJump ();
		} else if (Input.GetButton ("Jump") && isMidJump ()) { //while holding button + during jump, continue jumping
			midJump ();
		} else if (Input.GetButtonUp ("Jump")) {
			//jumpTime = 0f;
			isjump = false;

		}

	}

	void FlipBehaviour(){
		if (playerVelocity.x < 0 && !flipped && grounded) {
			Flip ();

		} else if (playerVelocity.x > 0 && flipped && grounded) {
			Flip ();
		}

	}

	bool isMidJump ()
	{
		return isjump && jumpTime < jumpLimit;
	}

	void startJump () //mario style jump - starts jump and informs game we're jumping
	{
		isjump = true;
		playerVelocity = (new Vector2 (rb2d.velocity.x, jumpForce));
	}

	void midJump () //mario style jump - repeatedly adds to jumptime while called
	{
		jumpTime += Time.fixedDeltaTime;
		playerVelocity = (new Vector2 (rb2d.velocity.x, jumpForce));
	}

	void Flip ()
	{
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y);
		flipped = !flipped;
	}
		
}
