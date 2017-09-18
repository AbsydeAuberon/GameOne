using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement: MonoBehaviour {

	//@Incomplete - Recode everything when you learn to C# and Unity, 
	//this needs to be changed. I copy-pasted from a tutorial and it 
	//uses a rigidBody, but it works for prototyping. jChue 08/2017

	private bool running = false;
	private bool lockCursor = true;
	private float speed = 5.0f;

	public float WalkSpeed = 5.0f;
	public float RunSpeed  = 10.0f;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftShift) && speed == WalkSpeed) {
			running = true;
		}else if (Input.GetKeyDown (KeyCode.LeftShift) && speed == RunSpeed){
			running = false;
		}

		if (running) {
			speed = RunSpeed;
		} else {
			speed = WalkSpeed;
		}
			

		if (Input.GetAxis ("Vertical") != 0 && Input.GetAxis ("Horizontal") != 0) {
			speed *= Mathf.Sqrt (2) / 2;
		}

		float translation;
		float straffe;

		translation = Input.GetAxis ("Vertical")   * speed * Time.deltaTime;
		straffe     = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		transform.Translate (straffe, 0, translation);


		if(Input.GetKeyDown(KeyCode.Escape))
		{
			lockCursor = !lockCursor;
		}

		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}