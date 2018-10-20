using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAsteroidMovement : MonoBehaviour {

    public float speed;

    //Vector2 startPosition;
    //Transform currentTransform;
    //Vector2 randomDir;
    public Vector2 downwardRandomDir;
    Rigidbody2D currentRigidbody;

	// Use this for initialization
	void Start () {

        //currentTransform = GetComponent<Transform>();
        currentRigidbody = GetComponent<Rigidbody2D>();

        //startPosition = new Vector2(
        //    currentTransform.position.x, currentTransform.position.y);

        //randomDir = new Vector2(
        //    Random.Range(0f, 1f), Random.Range(0f, 1f));

        //downwardRandomDir = randomDir;
        //downwardRandomDir.y *= -1;

        //if (randomDir.x > 0.5)
        //    downwardRandomDir.x -= 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        currentRigidbody.AddForce(downwardRandomDir * speed);
	}
}
