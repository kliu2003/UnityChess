using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	CharacterController charControl = null;

	[SerializeField]
	float moveSpeed = 0.25f;

	[SerializeField]
	float jumpSpeed = 10f;

	[SerializeField]
	float gravity = 9.81f;

	float vSpeed = 0;

	Camera cam;
	Vector3 camOffset;

    Animator anim;
    Transform model;

    enum State
    {
        idle,
        running
    }

    State currentState = State.idle;

	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
		camOffset = cam.transform.position - transform.position;
        model = transform.GetChild(0);
        anim = model.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateLookDirection();

		Vector3 moveVector = GetMoveVectorFromInput();

		// Handle Jump
		if (charControl.isGrounded)
		{
			vSpeed = 0;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				vSpeed = jumpSpeed;
			}
		}

        //Rotate the player
        Vector3 facingVector = new Vector3(moveVector.x, 0, moveVector.z);
        if( facingVector != Vector3.zero ) model.transform.rotation = Quaternion.LookRotation(facingVector, Vector3.up);

        CheckState( moveVector );

		vSpeed -= gravity * Time.deltaTime;
		moveVector.y = vSpeed * Time.deltaTime;

		charControl.Move(moveVector);
	}

	// Get the movement vector based on WASD
	Vector3 GetMoveVectorFromInput()
	{
		Vector3 forwardVector = Vector3.zero;
		Vector3 rightVector = Vector3.zero;

		if (Input.GetKey(KeyCode.A))
		{
			rightVector = cam.transform.TransformDirection(Vector3.left);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			rightVector = cam.transform.TransformDirection(Vector3.right);
		}

		if (Input.GetKey(KeyCode.W))
		{
			forwardVector = cam.transform.TransformDirection(Vector3.forward);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			forwardVector = cam.transform.TransformDirection(Vector3.back);
		}

		return (forwardVector + rightVector).normalized * moveSpeed * Time.deltaTime;
	}

    void CheckState( Vector3 moveVector )
    {
        if (currentState == State.idle && moveVector != Vector3.zero)
        {
            currentState = State.running;
            anim.SetBool("Running", true);
        }
        if (currentState == State.running && moveVector == Vector3.zero)
        {
            currentState = State.idle;
            anim.SetBool("Running", false);
        }
    }

	// Handles the mouse input and updates the camera movement
	void UpdateLookDirection()
	{
		Quaternion camAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up);
		Quaternion camAngleY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), cam.transform.TransformDirection(Vector3.left));
		camOffset = camAngleY * camAngleX * camOffset;
		
		cam.transform.position = transform.position + camOffset;

		cam.transform.LookAt(transform);
	}
}
