using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRespawner : MonoBehaviour {

    Vector3 startPosition;
    Transform currentTransform;
    Vector2 randomDir;
    Vector2 downwardRandomDir;
    //Rigidbody2D currentRigidbody;

    void Respawn() {

        

        randomDir = new Vector2(
            Random.Range(0f, 1f), Random.Range(0f, 1f));

        downwardRandomDir = randomDir;
        downwardRandomDir.y = -1;

        if (randomDir.x > 0.5)
            downwardRandomDir.x -= 1;

        
        currentTransform.position = startPosition;

        GetComponent<DirectionalAsteroidMovement>().
            downwardRandomDir = downwardRandomDir;

    }

    void Start()
    {

        currentTransform = GetComponent<Transform>();
        //currentRigidbody = GetComponent<Rigidbody2D>();

        startPosition = currentTransform.position;

        Respawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triger");
        if (other.name == "AsteroidsDeadZone") {
            Debug.Log("dead zone");
            Respawn();

        }
    }
}
