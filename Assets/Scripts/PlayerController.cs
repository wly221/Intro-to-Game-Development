using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public List<GameObject> enemiesWithinRange; //Array list, where the length of the array is flexible.

	private Rigidbody2D rb;

	//public Transform target;
	public float speed;

	public bool isKnockback;

	private float knockBackTimer = 0.3f;


	public float timeSurvivedTimer;
	public Text timeSurvivedText;






	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called every unlocked framerate frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) { //Checks if the "A" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x - 0.1f, GetComponent<Transform> ().position.y, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (Input.GetKey (KeyCode.D)) { //Checks if the "D" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x + 0.1f, GetComponent<Transform> ().position.y, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (Input.GetKey (KeyCode.W)) { //Checks if the "W" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y + 0.1f, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		if (Input.GetKey (KeyCode.S)) { //Checks if the "S" key is pressed down. If it is, run the if-statement.
			GetComponent<Transform> ().position = new Vector3 (GetComponent<Transform> ().position.x, GetComponent<Transform> ().position.y - 0.1f, 0f); //The "Transform" component of this game object has a "position" set to a newly initialized "Vector3".
		}

		Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); // Convert mouse position to world position.
		p.z = 0f;

		var dir = p - transform.position; //Finds the direction between player and mouse position.
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; //Finds the angle of player and mouse position based on the x-axis.
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //Find the value of rotation that this player needs to have.

		if (Input.GetMouseButtonDown(0)) //Checks if the "left mouse button" key is pressed down. If it is, run the if-statement.
		{
			DestroyEnemies (); //Runs the "DestroyEnemies ()" function.
		

		}

		timeSurvivedTimer += Time.deltaTime; //Counts the "timeSurvivedTimer" timer up per second. Counting is independent of the monitor's refresh rate.

		timeSurvivedText.text = "Time Survived: " + timeSurvivedTimer.ToString("F1") + "s"; //creates a timer in the UI with one decimal point.


		playerBoundaries (); //Run the "playerBoundaries ()" function.

	}

	void FixedUpdate ()
	{
		if (!isKnockback) 
		{
			rb.velocity = Vector2.zero;
		} 
		else 
		{
			knockBackTimer -= Time.fixedDeltaTime; //Counts timer down per second. Counting is independent of the monitor's refresh rate.

			if (knockBackTimer <= 0) 
			{


				knockBackTimer = 0.3f;

				isKnockback = false;

			}

		}
	}




	/*
	//void OnCollisionEnter2D (Collision2D other) //If a game object has a collider on it, it will look to see if this script also has this function. This function is automatically triggered when those game objects collide with this script.
	//"OnCollisionEnter2D" is the method/function, "Collision2D" is the parameter, "other" is the variable, so whenever something collides with this script, the variable becomes the collider. 
	//"Collision2D" is the collision of everything except this script.

	{
		if (other.gameObject.name == "Circle") //Checks if the "gameObject" colliding with this script is named "Circle". If it is, run the if-statement.
		{
			other.rigidbody.AddForce ((other.transform.position - transform.position)*10, ForceMode2D.Impulse); //Add a force to the "rigidbody" that is colliding with this script. This force is calculated by the position of the colliding game object minus the position of this game object and multiplying it by "10".
		}
	}
	*/

	/*
	public void OnCollisionEnter2D(Collision2D other) //Runs when the "Player" collides with the "other" object (in this case the "Enemy").
	{
		if (other.gameObject.tag == "Enemy") 
		{
			renderer.material.color = Color.red;
			yield return new WaitForSeconds(0.5f);
			renderer.material.color = Color.white;
		}
	}
	*/



	void DestroyEnemies ()
	{
		for (int i = 0; i < enemiesWithinRange.Count; i++) 
		{
			Destroy (enemiesWithinRange [i].transform.parent.gameObject); //This for-loop destroys everything in the array list one by one. Destroys the parent of the game objects themselves.
		}

		enemiesWithinRange.Clear (); //Clears/resets the array list.
	}


	void playerBoundaries ()
	{
		if (transform.position.x > 9.05f) 
		{
			transform.position = new Vector3 (9.05f, transform.position.y, transform.position.z);
		}

		if (transform.position.x < -9.05f) 
		{
			transform.position = new Vector3 (-9.05f, transform.position.y, transform.position.z);
		}

		if (transform.position.y > 4.05f) 
		{
			transform.position = new Vector3 (transform.position.x, 4.05f, transform.position.z);
		}

		if (transform.position.y < -4.05f) 
		{
			transform.position = new Vector3 (transform.position.x, -4.05f, transform.position.z);
		}
	}
}

