using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    Rigidbody2D curentRigidBody;

	// Use this for initialization
	void Start () {

        curentRigidBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = 
            new Vector2(horizontalInput, verticalInput);

        curentRigidBody.AddForce(
            movement * speed
            );



    }
}
