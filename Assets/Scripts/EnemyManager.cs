using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public GameObject enemy; //Declare a public variable of type "GameObject" and name it "enemy". "enemy" is set as the "Enemy" by dragging the "Enemy" prefab into the inspector.
	public float timer = 1f; //Declare a public variable of type "float" and name it "timer". Sets a timer for 1 second.

	public float timeSurvivedTimer;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		int x = Random.Range (12, 20); //Generates the x-range for enemies to spawn in.
		int y = Random.Range (7, 15); //Generates the y-range for enemies to spawn in.
		float chanceX = Random.Range (0f, 1f); //Randomizes the chance for the x-range to be positive or negative.
		float chanceY = Random.Range (0f, 1f); //Randomizes the cnance for the y-range to be positive or negative.
		Vector3 currentPosition = new Vector3 (x, y, 0f); //Declare a variable of type "Vector3" and name it "currentPosition". Sets the "currentPosition" as a "new" "Vector3".

		if (chanceX > 0.5f) //Checks if the "chanceX" is greater than 0.5. If so, run this if-statement.
		{
			currentPosition.x *= -1; //This changes the x-value to be negative if greater than 50 percent chance.
		}

		if (chanceY > 0.5f) //Checks if the "chanceY" is greater than 0.5. If so, run this if-statement.
		{
			currentPosition.y *= -1; //This changes the y-value to be negative if greater than 50 percent chance.
		}


		timer -= Time.deltaTime; //Counts timer down per second. Counting is independent of the monitor's refresh rate.

		if (timer <= 0) //Checks if the "timer" is less than or equal to 0. If so, run this if-statement.
		{
			if (GameObject.Find ("Player") != null) //If the player can be found, run this if-statement.
			{
				timeSurvivedTimer = GameObject.Find ("Player").GetComponent<PlayerController>().timeSurvivedTimer; //Sets this script's version of "timeSurvivedTimer" by syncing up the "timeSurvivedTimer" from the "PlayerController" script.
			}

			Instantiate (enemy, currentPosition, Quaternion.identity); //This creates the "enemy". This is choosing one object ("enemy") to place, placing it in the position of the "currentPosition", and giving it the original rotation ("Quaternion.identity" just means original rotation).

			if (timeSurvivedTimer <= 20f) //Checks if the "timeSurvivedTimer" is less than or equal to 20f. If so, run this if-statement.
			{
				timer = 2f; //Sets "timer" to 2 seconds.
			}

			else if (timeSurvivedTimer <= 40f && timeSurvivedTimer > 20f) //Checks if the "timeSurvivedTimer" is less than or equal to 40f and is greater than 20f. If so, run this if-statement.
			{
				timer = 1f; //Sets "timer" to 1 second.
			}
		
			else if (timeSurvivedTimer <= 60f && timeSurvivedTimer > 40f) //Checks if the "timeSurvivedTimer" is less than or equal to 60f and is greater than 40f. If so, run this if-statement.
			{
				timer = 0.5f; //Sets "timer" to 0.5 seconds.
			}

			else if (timeSurvivedTimer > 60f) //Checks if the "timeSurvivedTimer" is greater than 60f. If so, run this if-statement.
			{
				timer = 0.25f; //Sets "timer" to 0.25 seconds.
			}
		}
	}
}
