using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public PlayerController thePlayer; 

	private Rigidbody2D myRB;
	private float moveSpeed = Random.Range (1, 3);
	public Vector2 direction;


	// Use this for initialization
	void Start () 
	{
		thePlayer = GameObject.Find ("Player").GetComponent <PlayerController>(); //Assigns the inspector value for the "Enemy" prefab. Whenever an enemy is created, it will first look for the "Player" and assign it.

		myRB = GetComponent<Rigidbody2D> ();
		//thePlayer = FindObjectOfType<PlayerController> ();
	}

	void FixedUpdate ()
	{
		Vector3 direction3 = thePlayer.gameObject.transform.position - gameObject.transform.position; //This subtracts the position of the player by the position of the enemy.
		direction3.z = 0f; //Set the z-position to be 0.
		direction = new Vector2 (direction3.x, direction3.y); //Use the x-position and y-position of "direction3" as the x-position and y-position of "direction".
		direction = direction.normalized;
		//myRB.AddForce (direction * moveSpeed, ForceMode2D.Force);
		myRB.velocity = direction * moveSpeed;
	}

	// Update is called once per frame
	void Update () 
	{
		//transform.LookAt (thePlayer.transform.position);

		Vector3 p = thePlayer.gameObject.transform.position; //Assign the "p" to the player position.
		p.z = 0f; //Set the z-position to be 0.

		var dir = p - transform.position; //Finds the direction between enemy and player position.
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Finds the angle of enemy and player position based on the x-axis.
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Finds the value of rotation that this enemy needs to have.
	}
}
