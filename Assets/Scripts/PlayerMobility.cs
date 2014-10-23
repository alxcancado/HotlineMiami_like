using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed = 400.0f; //just a test

	// last part
	Animator anim;

	void Start(){
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger("Attack");	
		}
	}
	//end last part 

	// Fixed Update because we are using Physics
	void FixedUpdate(){ 
		// capture mouse position. We need to convert between pixels and World Unities
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		// Basicly it's looking to the mouse position. And rotating.
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition,
		                                         Vector3.forward);

		// LOOKING AT MOUSE
		// set our gameobject rotation to the calculated one rotation
		transform.rotation = rot;
		// doesnt changerotation angles for x, y.
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		// prevents from "slide"
		rigidbody2D.angularVelocity = 0;

		// MOVEMENT
		// this because moving foward means moving in the Z axis, but this is a topdown game!
		// obs.: we still need to press up/down arrows to move!
		float input = Input.GetAxis ("Vertical"); //Input.GetAxis ("Mouse X");
		rigidbody2D.AddForce (gameObject.transform.up * speed  * input );

	}
}
