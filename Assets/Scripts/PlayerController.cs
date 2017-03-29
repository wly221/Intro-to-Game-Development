using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public List<GameObject> enemiesWithinRange; //Declare a public variable of type array list and name it "enemiesWithinRange". This is an array list, where the length of the array is flexible.

	private Rigidbody2D rb; //Declare a private variable of type "Rigidbody2D" and name it "rb".

	public float speed; //Declare a public variable of type "float" and name it "speed". "speed" is set in the inspector.

	public bool isKnockback; //Declare a public variable of type "bool" and name it "isKnockback".

	private float knockBackTimer = 0.3f; //Declare a private variable of type "float" and name it "knockBackTimer". Sets for 0.3 seconds.


	public float timeSurvivedTimer; //Declare a public variable of type "float" and name it "timeSurvivedTimer".
	public Text timeSurvivedText; //Declare a public variable of type "Text" and name it "timeSurvivedText". "timeSurvivedText" is set as "Time Survived Text" by dragging the "Time Survived Text" object into the inspector.


	public GameObject enemies; //Declare a public variable of type "GameObject" and name it "enemies". "enemies" is set as the "Enemy" by dragging the "Enemy" prefab into the inspector.

	public GameObject bloodParticles; //Declare a public variable of type "GameObject" and name it "bloodParticles". "bloodParticles" is set as the "Blood Particles" by dragging the "Blood Particles" prefab into the inspector.

	public GameObject deadBodies; //Declare a public variable of type "GameObject" and name it "deadBodies". "deadBodies" is set as the "Dead Body" by dragging the "Dead Body" prefab into the inspector.

	public GameObject weaponParticles; //Declare a public variable of type "GameObject" and name it "weaponParticles". "weaponParticles" is set as the "Weapon Particles" by dragging the "Weapon Particles" prefab into the inspector.

	public GameObject weaponTip; //Declare a public variable of type "GameObject" and name it "weaponTip". "weaponTip" is set as the "Weapon Tip" by dragging the "Weapon Tip" object into the inspector.

	public Animator playerAnimator; //Declare a public variable of type "Animator" and name it "playerAnimator". "playerAnimator" is set as the "Player Art" by dragging the "Player Art" object into the inspector.


	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> (); //Sets the "rb" variable to be the "Rigidbody2D" component in this game object.
	}

	// Update is called every unlocked framerate frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) { //Checks if the "A" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x - 0.1f, GetComponent<Transform> ().position.y, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
			playerAnimator.Play("Walking Animation"); //Plays the "Walking Animation".
		}

		if (Input.GetKey (KeyCode.D)) { //Checks if the "D" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x + 0.1f, GetComponent<Transform> ().position.y, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
			playerAnimator.Play("Walking Animation"); //Plays the "Walking Animation".
		}

		if (Input.GetKey (KeyCode.W)) { //Checks if the "W" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y + 0.1f, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
			playerAnimator.Play("Walking Animation"); //Plays the "Walking Animation".
		}

		if (Input.GetKey (KeyCode.S)) { //Checks if the "S" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y - 0.1f, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
			playerAnimator.Play("Walking Animation"); //Plays the "Walking Animation".
		}

		if (Input.GetKey (KeyCode.A) == false && Input.GetKey (KeyCode.D) == false && Input.GetKey (KeyCode.W) == false && Input.GetKey (KeyCode.S) == false) //Checks if the "W", "A", "S", "D" keys are not pressed down. If so, run the if-statement.
		{
			playerAnimator.Play("Idle"); //Plays the "Idle" animation, which is currently no animation.
		}
			

		Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); //Convert mouse position to world position.
		p.z = 0f; //Sets z-value of "p" as 0.

		var dir = p - transform.position; //Finds the direction between player and mouse position.
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Finds the angle of player and mouse position based on the x-axis.
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Find the value of rotation that this player needs to have.

		if (Input.GetMouseButtonDown(0)) //Checks if the "left mouse button" key is pressed down. If it is, run the if-statement.
		{
			DestroyEnemies (); //Runs the "DestroyEnemies ()" function.
			Instantiate (weaponParticles, weaponTip.transform.position, Quaternion.identity); //This creates the "weaponParticles". This is choosing one object ("weaponParticles") to place, placing it in the position of the "weaponTip", and giving it the original rotation ("Quaternion.identity" just means original rotation).
		}

		timeSurvivedTimer += Time.deltaTime; //Counts the "timeSurvivedTimer" timer up per second. Counting is independent of the monitor's refresh rate.

		timeSurvivedText.text = "Time Survived: " + timeSurvivedTimer.ToString("F1") + "s"; //creates a timer in the UI with one decimal point.

		PlayerBoundaries (); //Runs the "PlayerBoundaries ()" function.
	}

	void FixedUpdate ()
	{
		if (!isKnockback) //Checks if "isKnockback" is set to "false". If so, run this if-statement.
		{
			rb.velocity = Vector2.zero; //Sets the "velocity" of "rb" to be a "Vector2" of "zero".
		} 
		else //Checks if "isKnockback" is set to "true". If so, run this else-statement.
		{
			knockBackTimer -= Time.fixedDeltaTime; //Counts timer down per second. Counting is independent of the monitor's refresh rate.

			if (knockBackTimer <= 0) //Checks if "knockBackTimer" is less than or equal to 0. If so, run this if-statement.
			{
				knockBackTimer = 0.3f; //Sets "knockBackTimer" to be 0.3 seconds.

				isKnockback = false; //Sets "isKnockback" to be false.
			}
		}
	}


	void DestroyEnemies () //Creates a new function called "DestroyEnemies".
	{
		for (int i = 0; i < enemiesWithinRange.Count; i++) //Creates a for-loop.
		{
			enemies = enemiesWithinRange [i].transform.parent.gameObject; //Stores the enemies as a temporary variable before they get destroyed.

			StartCoroutine("DestroyEnemiesCo"); //Runs the coroutine named "DestroyEnemiesCo" in this script. 


			Destroy (enemiesWithinRange [i].transform.parent.gameObject); //This for-loop destroys everything in the array list one by one. Destroys the parent of the game objects themselves.
		}

		enemiesWithinRange.Clear (); //Clears/resets the array list.
	}


	public IEnumerator DestroyEnemiesCo() //Creates a coroutine named "DestroyEnemiesCo" that runs separate from the other functions of this script, in other words it runs in a different "timeline", so that the game does not encounter any game-breaking issues when the game waits for a certain amount of time (seconds).
	{
		Instantiate (bloodParticles, enemies.transform.position, Quaternion.identity); //This creates the "bloodParticles". This is choosing one object ("bloodParticles") to place, placing it in the position of the "enemies", and giving it the original rotation ("Quaternion.identity" just means original rotation).
		Instantiate (deadBodies, enemies.transform.position, Quaternion.identity); //This creates the "deadBodies". This is choosing one object ("deadBodies") to place, placing it in the position of the "enemies", and giving it the original rotation ("Quaternion.identity" just means original rotation).
		yield return new WaitForSeconds(0.5f); //Holds the execution of the next line for "0.5f" seconds. In other words, waits "0.5f" seconds before the coroutine stops.
	}
		

	void PlayerBoundaries () //Creates a new function called "PlayerBoundaries".
	{
		if (transform.position.x > 9.05f) //Checks if the x-position is greater than 9.05. If so, run this if-statement.
		{
			transform.position = new Vector3 (9.05f, transform.position.y, transform.position.z); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (transform.position.x < -9.05f) //Checks if the x-position is less than -9.05. If so, run this if-statement.
		{
			transform.position = new Vector3 (-9.05f, transform.position.y, transform.position.z); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (transform.position.y > 4.05f) //Checks if the y-position is greater than 4.05. If so, run this if-statement.
		{
			transform.position = new Vector3 (transform.position.x, 4.05f, transform.position.z); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (transform.position.y < -4.05f) //Checks if the y-position is less than -4.05. If so, run this if-statement.
		{
			transform.position = new Vector3 (transform.position.x, -4.05f, transform.position.z); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}
	}
}

