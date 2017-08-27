using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float boundary;
    public float playerVelocity;
    private Vector3 playerPosition;
	private int playerLives;
	private int playerPoints;

    void Start()
	{
        playerPosition = gameObject.transform.position;
		playerLives = 3;
		playerPoints = 0;
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

	void AddPoints(int points)
	{
		playerPoints += points;
	}

	void TakeLife()
	{
		playerLives--;
	}

	void OnGUI()
	{
		GUI.Label(new Rect(5.0f,3.0f,200.0f,200.0f),"Live's: " + playerLives + "  Score: " + playerPoints);
	}
}
