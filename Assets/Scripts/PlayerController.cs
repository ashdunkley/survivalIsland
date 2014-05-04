using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//variables
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity;
	private Vector3 moveDirection = Vector3.zero;
	public float runSpeed = 10.0f;
	public float swimSpeed = 6.0f;
	public float swimUpSpeed = 2.0f;
	public float waterGravity = 7.5f;
	public float waterSpeed = 4.0f;

	
	private void FixedUpdate () 
	{
		CharacterController controller = GetComponent<CharacterController>();

		// Character on the ground?
		if (controller.isGrounded) {

		
						
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			gravity = 20.0f;

			

			if (Input.GetButton ("Sprint"))
				moveDirection *= runSpeed;

			else moveDirection *= speed;


			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;


		}

		//water movement
		else if (transform.position.y < 75) 
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			gravity = waterGravity;

			//Swimming across
			if (Input.GetButton ("Sprint"))
				moveDirection *= swimSpeed;
			
			else moveDirection *= waterSpeed;
			
			
			//Swimming up
			if (Input.GetButton("Jump"))
			{		
			    moveDirection.y += swimUpSpeed;

			}
		}				

	
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

}