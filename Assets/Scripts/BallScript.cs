using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    public GameObject playerObject;

    // Use this for initialization
    void Start () {
        ballInitialForce = new Vector2(100.0f, 300.0f);

        // переводим в неактивное состояние
        ballIsActive = false;

        // запоминаем положение
        ballPosition = transform.position;
    }
	
	// Update is called once per frame
    private void Update()
    {
        // проверка нажатия на пробел
        if (Input.GetButtonDown("Jump"))
        {
            // проверка состояния
            if (!ballIsActive)
            {
                // сброс всех сил
                //GetComponent<Rigidbody2D>().isKinematic = false;
                // применим силу
                GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
                // зададим активное состояние
                ballIsActive = !ballIsActive;
            }
        }

        if (!ballIsActive && playerObject != null)
        {
            // задаем новую позицию шарика
            ballPosition.x = playerObject.transform.position.x;

            // устанавливаем позицию шара
            transform.position = ballPosition;
        }

        if (ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPosition.x = playerObject.transform.position.x;
            ballPosition.y = -3.84f;
            transform.position = ballPosition;

            //GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
