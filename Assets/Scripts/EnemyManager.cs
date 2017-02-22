using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public GameObject enemy;
	public float timer = 2f; //Set a timer for 2 seconds.

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		int x = Random.Range (12, 20); //Generate the x-range for enemies to spawn in.
		int y = Random.Range (7, 15); //Generate the y-range for enemies to spawn in.
		float chanceX = Random.Range (0f, 1f); //Randomizes the chance for x-range to be positive or negative.
		float chanceY = Random.Range (0f, 1f); //Randomizes the cnance for y-range to be positive or negative.
		Vector3 currentPosition = new Vector3 (x, y, 0f);

		if (chanceX > 0.5f) 
		{
			currentPosition.x *= -1; //This changes the x-value to be negative if greater than 50 percent chance.
		}

		if (chanceY > 0.5f) 
		{
			currentPosition.y *= -1; //This changes the y-value to be negative if greater than 50 percent chance.
		}


		timer -= Time.deltaTime; //Counts timer down per second. Counting is independent of the monitor's refresh rate.

		if (timer <= 0)
		{
			Instantiate (enemy, currentPosition, Quaternion.identity); // "Quaternion.identity" just means original rotation.
			timer = 2f;
		}
	}



}
