using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float boundary;
    public float playerVelocity;
    private Vector3 playerPosition;

    void Start()
	{
        playerPosition = gameObject.transform.position;
    }

	void Update() 
	{
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (playerPosition.x < -boundary)
        {
            playerPosition = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }

        if (playerPosition.x > boundary)
        {
            playerPosition = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }

        transform.position = playerPosition;
    }
}
