using UnityEngine;
using System.Collections;

public class PlayerAttackCone : MonoBehaviour 
{
	public PlayerController playerControllerScript; //Declare a public variable of type "PlayerController" and name it "playerControllerScript". Making a reference to the "PlayerController" script attached to the "Player" game object.

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other) //Runs when the "other" enters the trigger.
	{
		Debug.Log ("Triggered");

		if (other.tag == "Enemy") //Checks if the "tag" of the "other" game object entering this trigger is set to "Enemy". If so, run this if-statement.
		{

			//The code below is commented out because I am no longer intending to "Destroy" this "gameObject".
			//Destroy (other.gameObject); //"Destroy" other "gameObject" (gameObjects with "Enemy" tag)


			playerControllerScript.enemiesWithinRange.Add(other.gameObject); //Add "other" gameObject to the "enemiesWithinRange" Array List in the "PlayerController" script

			//gameObject.SetActive(false); //Sets the entire game object that this script is in, to not active (false).
		}
	}


	void OnTriggerExit2D(Collider2D other) //Runs when the "other" exits the trigger.
	{
		if (other.tag == "Enemy") //Checks if the "tag" of the "other" game object exiting this trigger is set to "Enemy". If so, run this if-statement.
		{ 
			playerControllerScript.enemiesWithinRange.Remove(other.gameObject); //Remove "other" gameObject from the "enemiesWithinRange" Array List in the "PlayerController" script
		}
	}
}
