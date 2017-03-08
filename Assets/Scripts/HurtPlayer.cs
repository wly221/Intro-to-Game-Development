using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour 
{
	public int damageToGive; //Declare a public variable of type "int" and name it "damageToGive". "damageToGive" is set in the inspector.
	public Rigidbody2D enemyRigidBody; //Declare a public variable of type "Rigidbody2D" and name it "enemyRigidBody".

	public GameObject playerTriangleIcon; //Declare a public variable of type "GameObject" and name it "playerTriangleIcon". "playerTriangleIcon" is set as the "Player Triangle Icon" by dragging the "Player Triangle Icon" object into the inspector.
	public GameObject playerAttackZone; //Declare a public variable of type "GameObject" and name it "playerAttackZone". "playerAttackZone" is set as the "Player Attack Zone" by dragging the "Player Attack Zone" object into the inspector.
	public GameObject weaponTip; //Declare a public variable of type "GameObject" and name it "weaponTip". "weaponTip" is set as the "Weapon Tip" by dragging the "Weapon Tip" object into the inspector.

	private bool invincible = false; //Declare a private variable of type "bool" and name it "invincible". Set it to "false".

	// Use this for initialization
	void Start () 
	{
		playerTriangleIcon = GameObject.Find ("Player Triangle Icon"); //Assigns the inspector value for the "Enemy Collider" prefab. Whenever an "Enemy Collider" is created, it will first look for the "Player Triangle Icon" and assign it.
		playerAttackZone = GameObject.Find ("Player Attack Zone (Weapon)"); //Assigns the inspector value for the "Enemy Collider" prefab. Whenever an "Enemy Collider" is created, it will first look for the "Player Attack Zone (Weapon)" and assign it.
		weaponTip = GameObject.Find ("Weapon Tip"); //Assigns the inspector value for the "Enemy Collider" prefab. Whenever an "Enemy Collider" is created, it will first look for the "Weapon Tip" and assign it.
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
			player.GetComponent<SpriteRenderer>().enabled = true; //show the sprite renderer of the "player".
			playerTriangleIcon.GetComponent<SpriteRenderer>().enabled = true; //show the sprite renderer of the "playerTriangleIcon".
			playerAttackZone.GetComponent<SpriteRenderer>().enabled = true; //show the sprite renderer of the "playerAttackZone".
			weaponTip.GetComponent<SpriteRenderer>().enabled = true; //show the sprite renderer of the "weaponTip".

			yield return new WaitForSeconds(0.15f); //wait for 0.15 seconds.

			player.GetComponent<SpriteRenderer>().enabled = false; //hide the sprite renderer of the "player".
			playerTriangleIcon.GetComponent<SpriteRenderer>().enabled = false; //hide the sprite renderer of the "playerTriangleIcon".
			playerAttackZone.GetComponent<SpriteRenderer>().enabled = false; //hide the sprite renderer of the "playerAttackZone".
			weaponTip.GetComponent<SpriteRenderer>().enabled = false; //hide the sprite renderer of the "weaponTip".

			yield return new WaitForSeconds(0.15f); //wait for 0.15 seconds.
		}

		player.GetComponent<SpriteRenderer>().enabled = true; //in the end, keep showing the sprite renderer of the "player".
		playerTriangleIcon.GetComponent<SpriteRenderer>().enabled = true; //in the end, keep showing the sprite renderer of the "playerTriangleIcon".
		playerAttackZone.GetComponent<SpriteRenderer>().enabled = true; //in the end, keep showing the sprite renderer of the "playerAttackZone".
		weaponTip.GetComponent<SpriteRenderer>().enabled = true; //in the end, keep showing the sprite renderer of the "weaponTip".
	}
}
