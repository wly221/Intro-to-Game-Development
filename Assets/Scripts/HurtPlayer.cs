using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour 
{
	public int damageToGive; //Declare a public variable of type "int" and name it "damageToGive". "damageToGive" is set in the inspector.

	public Rigidbody2D enemyRigidBody; //Declare a public variable of type "Rigidbody2D" and name it "enemyRigidBody".

	public PlayerController thePlayerController; //Declare a public variable of type "PlayerController" and name it "thePlayerController". Making a reference to the "PlayerController" script attached to the "Player" game object.

	public AudioSource enemyAttackSoundEffect; //Declare a public variable of type "AudioSource" and name it "enemyAttackSoundEffect". "enemyAttackSoundEffect" is set as the "Enemy Attack Sound Effect" by dragging the "Enemy Attack Sound Effect" object into the inspector.

	// Use this for initialization
	void Start ()
	{
		if (GameObject.Find ("Player") != null) //If the player can be found, run this if-statement.
		{ 
			thePlayerController = GameObject.Find ("Player").GetComponent <PlayerController> (); //Assigns the inspector value for the "Enemy Collider" prefab. Whenever an "Enemy Collider" is created, it will first look for the "Player" and assign the "PlayerController" script.
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnCollisionEnter2D(Collision2D other) //Runs when the "Enemy" collides with the "other" object (in this case the "Player").
	{
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().isKnockback == false) //Checks if the "tag" of the "other" game object entering this collision is set to "Player", and if "isKnockback" is set to be "false" in the "PlayerController" script. If so, run this if-statement.
		{
			if (!thePlayerController.invincible) //Checks if "invincible" from "thePlayerController" script is set to "false". If so, run this if-statement.
			{
				other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); //The "HurtPlayer" in this case is the function in the "PlayerHealthManager" script ("HurtPlayer" is not referring to the name of this script).

				enemyAttackSoundEffect.Play (); //Plays the "enemyAttackSoundEffect".

				other.gameObject.GetComponent<Rigidbody2D> ().AddForce (enemyRigidBody.velocity.normalized*50f, ForceMode2D.Impulse); //Adds a force to the "other" game object.

				if (other.gameObject.GetComponent<PlayerController>().isKnockback == false) //Checks if "isKnockback" is set to be "false" in the "PlayerController" script. If so, run this if-statement.
				{
					thePlayerController.StartCoroutine (thePlayerController.MakeBlink (other.gameObject)); //This starts the coroutine function that makes the player blink (from "thePlayerController" script).
				}

				other.gameObject.GetComponent<PlayerController> ().isKnockback = true; //Sets "isKnockback" to be "true" in the "PlayerController" script.

				thePlayerController.invincible = true; //Set "invincible" from "thePlayerController" script to be "true".
				thePlayerController.Invoke("resetInvulnerability", 0.9f); //"Invoke" the "resetInvulnerability" function from "thePlayerController" script in 0.9 seconds.
			}
		}
	}
}
