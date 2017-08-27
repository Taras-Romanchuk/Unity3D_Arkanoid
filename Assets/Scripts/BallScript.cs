using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	private bool ballIsActive;
	private Vector2 ballInitialForce;
    private Vector3 ballPosition;
	private Rigidbody2D ballRigidbody;
    public GameObject playerObject;

    void Start()
	{
        ballInitialForce = new Vector2(100.0f, 300.0f);
        ballIsActive = false;
		ballRigidbody = GetComponent<Rigidbody2D>();
        ballPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!ballIsActive)
            {
				ballRigidbody.velocity = new Vector2(0f, 0f);
				ballRigidbody.AddForce(ballInitialForce);
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null)
        {
            ballPosition.x = playerObject.transform.position.x;
            transform.position = ballPosition;
        }

        if (ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.84f;
            transform.position = ballPosition;
        }
    }
}
