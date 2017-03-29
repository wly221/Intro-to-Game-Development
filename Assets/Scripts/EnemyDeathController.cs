using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour 
{
	public GameObject thePlayer; //Declare a public variable of type "GameObject" and name it "thePlayer".
	private bool allowRotate; //Declare a private variable of type "bool" and name it "allowRotate".

	// Use this for initialization
	void Start () 
	{
		thePlayer = GameObject.Find ("Player"); //Assigns the inspector value for the "Enemy Death Spritesheet" prefab. Whenever an "Enemy Death Spritesheet" is created, it will first look for the "Player" and assign it.
		allowRotate = true; //Set "allowRotate" to "true".
	}

	// Update is called once per frame
	void Update () 
	{
		if (thePlayer != null && allowRotate == true) //If the player exists and "allowRotate" is set to true, run this if-statement.
		{
			Vector3 p = thePlayer.gameObject.transform.position; //Assigns the "p" to the player position.
			p.z = 0f; //Sets the z-position to be 0.

			var dir = p - transform.position; //Finds the direction between this "Enemy Death Spritesheet" gameobject and player position.
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Finds the angle of this "Enemy Death Spritesheet" gameobject and player position based on the x-axis.
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Finds the value of rotation that this "Enemy Death Spritesheet" gameobject needs to have.
			allowRotate = false; //Setting "allowRotate" to "false" here ultimately makes it so that this "Enemy Death Spritesheet" gameobject won't keep rotating with the player.
		}
	}
}
