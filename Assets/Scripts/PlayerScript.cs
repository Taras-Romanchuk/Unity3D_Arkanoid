using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float playerVelocity;
    public float boundary;
    private Vector3 playerPosition;

    // Use this for initialization
    void Start () {
        playerPosition = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        // горизонтальное движение
        playerPosition.x += Input.GetAxis("Horizontal") * playerVelocity;

        // выход из игры
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // проверка выхода за границы
        if (playerPosition.x < -boundary)
        {
            playerPosition = new Vector3(-boundary, playerPosition.y, playerPosition.z);
        }
        if (playerPosition.x > boundary)
        {
            playerPosition = new Vector3(boundary, playerPosition.y, playerPosition.z);
        }

        // обновим позицию платформы
        transform.position = playerPosition;
    }
}
