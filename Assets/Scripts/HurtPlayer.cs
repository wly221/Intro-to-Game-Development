using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour 
{
	public int damageToGive;
	public Rigidbody2D enemyRigidBody;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnCollisionEnter2D(Collision2D other) //Runs when the "Enemy" collides with the "other" object (in this case the "Player").
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive); //The "HurtPlayer" in this case is the function in the "PlayerHealthManager" script ("HurtPlayer" is not referring to the name of this script).


			Debug.Log ("Collision");
			//other.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1f;

			other.gameObject.GetComponent<PlayerController> ().isKnockback = true;

			Debug.Log ("EnemyVelocity" + enemyRigidBody.velocity.normalized);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (enemyRigidBody.velocity.normalized*50f, ForceMode2D.Impulse);
		







			/*
			renderer.material.color = Color.red;
			yield return new WaitForSeconds(0.5f);
			renderer.material.color = Color.white;
			*/

			/*
			for(var n = 0; n < 5; n++)
			{
				renderer.enabled = true;
				yield WaitForSeconds(.1);
				renderer.enabled = false;
				yield WaitForSeconds(.1);
			}
			renderer.enabled = true;
			*/



		}
	}





}
