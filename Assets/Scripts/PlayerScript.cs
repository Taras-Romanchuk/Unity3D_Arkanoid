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
	public AudioClip pointSound;
	public AudioClip lifeSound;

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

		WinLose();
    }

	void AddPoints(int points)
	{
		playerPoints += points;
		GetComponent<AudioSource>().PlayOneShot(pointSound, 1.0F);
	}

	void TakeLife()
	{
		playerLives--;
		GetComponent<AudioSource>().PlayOneShot(lifeSound, 1.0F);
	}

	void OnGUI()
	{
		GUI.Label(new Rect(5.0f,3.0f,200.0f,200.0f),"Live's: " + playerLives + "  Score: " + playerPoints);
	}

	void WinLose()
	{		
		if (playerLives == 0)
		{
			Application.LoadLevel("Level1");        
		}

		if ((GameObject.FindGameObjectsWithTag ("Block")).Length == 0)
		{
			if (Application.loadedLevelName == "Level1")
			{
				Application.LoadLevel("Level2");
			}
			else
			{
				Application.Quit();
			}
		}
	}
}
