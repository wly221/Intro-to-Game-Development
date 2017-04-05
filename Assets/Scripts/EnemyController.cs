using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public PlayerController thePlayer; //Declare a public variable of type "PlayerController" and name it "thePlayer". Making a reference to the "PlayerController" script attached to the "Player" game object.

	private Rigidbody2D myRB; //Declare a private variable of type "Rigidbody2D" and name it "myRB".
	private float moveSpeed; //Declare a private variable of type "float" and name it "moveSpeed". 
	public Vector2 direction; //Declare a public variable of type "Vector2" and name it "direction".


	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find ("Player") != null) //If the player can be found, run this if-statement.
		{
			thePlayer = GameObject.Find ("Player").GetComponent <PlayerController>(); //Assigns the inspector value for the "Enemy" prefab. Whenever an enemy is created, it will first look for the "Player" and assign it.
		}

		myRB = GetComponent<Rigidbody2D> (); //Sets the "myRB" variable to be the "Rigidbody2D" component in this game object.

		moveSpeed = Random.Range (1, 3); //Sets "moveSpeed" for a range that is random between 1 and 3.
	}

	void FixedUpdate ()
	{
		if (thePlayer != null) //If the player exists, run this if-statement.
		{
			Vector3 direction3 = thePlayer.gameObject.transform.position - gameObject.transform.position; //This subtracts the position of the player by the position of the enemy.
			direction3.z = 0f; //Sets the z-position to be 0.
			direction = new Vector2 (direction3.x, direction3.y); //Use the x-position and y-position of "direction3" as the x-position and y-position of "direction".
			direction = direction.normalized; //Sets "direction" as equal to "direction.normalized"
			myRB.velocity = direction * moveSpeed; //Sets the "velocity" of "myRB" as equal to "direction" multiplied by "moveSpeed".
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (thePlayer != null) //If the player exists, run this if-statement.
		{
			Vector3 p = thePlayer.gameObject.transform.position; //Assigns the "p" to the player position.
			p.z = 0f; //Sets the z-position to be 0.

			var dir = p - transform.position; //Finds the direction between enemy and player position.
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Finds the angle of enemy and player position based on the x-axis.
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Finds the value of rotation that this enemy needs to have.
		}
	}
}
