using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
	public int hitsToKill;
	public int points;
	private int numberOfHits;

	void Start()
	{
		numberOfHits = 0;
	}

	void Update()
	{
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			numberOfHits++;

			if (numberOfHits == hitsToKill)
			{
				GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

				player.SendMessage("AddPoints", points);

				Destroy(this.gameObject);
			}
		}
	}
}
