using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour 
{
	public int damageToGive; //Declare a public variable of type "int" and name it "damageToGive". "damageToGive" is set in the inspector.
	public Rigidbody2D enemyRigidBody; //Declare a public variable of type "Rigidbody2D" and name it "enemyRigidBody".

	public GameObject playerArt; //Declare a public variable of type "GameObject" and name it "playerArt".

	private bool invincible = false; //Declare a private variable of type "bool" and name it "invincible". Set it to "false".

	public AudioSource enemyAttackSoundEffect; //Declare a public variable of type "AudioSource" and name it "enemyAttackSoundEffect". "enemyAttackSoundEffect" is set as the "Enemy Attack Sound Effect" by dragging the "Enemy Attack Sound Effect" object into the inspector.

	// Use this for initialization
	void Start () 
	{
		playerArt = GameObject.Find ("Player Art"); //Assigns the inspector value for the "Enemy Collider" prefab. Whenever an "Enemy Collider" is created, it will first look for the "Player Art" and assign it.
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnCollisionEnter2D(Collision2D other) //Runs when the "Enemy" collides with the "other" object (in this case the "Player").
	{
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().isKnockback == false) //Checks if the "tag" of the "other" game object entering this collision is set to "Player", and if "isKnockback" is set to be "false" in the "PlayerController" script. If so, run this if-statement.
		{
			if (!invincible) //Checks if "invincible" is set to "false". If so, run this if-statement.
			{
				other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); //The "HurtPlayer" in this case is the function in the "PlayerHealthManager" script ("HurtPlayer" is not referring to the name of this script).

				enemyAttackSoundEffect.Play (); //Plays the "enemyAttackSoundEffect".

				other.gameObject.GetComponent<Rigidbody2D> ().AddForce (enemyRigidBody.velocity.normalized*50f, ForceMode2D.Impulse); //Adds a force to the "other" game object.

				if (other.gameObject.GetComponent<PlayerController>().isKnockback == false) //Checks if "isKnockback" is set to be "false" in the "PlayerController" script. If so, run this if-statement.
				{
					StartCoroutine (MakeBlink (other.gameObject)); //This starts the coroutine function that makes the player blink.
				}

				other.gameObject.GetComponent<PlayerController> ().isKnockback = true; //Sets "isKnockback" to be "true" in the "PlayerController" script.

				invincible = true; //Set "invincible" to be "true".
				Invoke("resetInvulnerability", 0.9f); //"Invoke" the "resetInvulnerability" function in 0.9 seconds.
			}
		}
	}

	void resetInvulnerability () //Creates a new function called "resetInvulnerability".
	{
		invincible = false; //Set "invincible" to be "false".
	}


	public IEnumerator MakeBlink (GameObject player) //Creates a coroutine named "MakeBlink" that runs separate from the other functions of this script, in other words it runs in a different "timeline", so that the game does not encounter any game-breaking issues when the game waits for a certain amount of time (seconds).
	{
		for(var n = 0; n < 3; n++) //Creates a for-loop. Iterates for 2 times, so in total the duration will be 0.4 seconds (0.1 * 2 * 2 = 0.4)
		{
			playerArt.GetComponent<SpriteRenderer>().enabled = true; //show the sprite renderer of the "playerArt".

			yield return new WaitForSeconds(0.15f); //wait for 0.15 seconds.

			playerArt.GetComponent<SpriteRenderer>().enabled = false; //hide the sprite renderer of the "playerArt".

			yield return new WaitForSeconds(0.15f); //wait for 0.15 seconds.
		}

		playerArt.GetComponent<SpriteRenderer>().enabled = true; //in the end, keep showing the sprite renderer of the "playerArt".
	}
}
