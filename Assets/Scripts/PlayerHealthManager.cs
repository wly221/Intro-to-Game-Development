using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour 
{
	public int startingHealth; //Declare a public variable of type "int" and name it "startingHealth". "startingHealth" is set in the inspector.
	public int currentHealth; //Declare a public variable of type "int" and name it "currentHealth".
	public Text healthText; //Declare a public variable of type "Text" and name it "healthText". "healthText" is set as "Health Text" by dragging the "Health Text" object into the inspector.

	public GameObject gameOverScreen; //Declare a public variable of type "GameObject" and name it "gameOverScreen". "gameOverScreen" is set as the "Game Over Screen" by dragging the "Game Over Screen" object into the inspector.

	public GameObject theGameManager; //Declare a public variable of type "GameObject" and name it "theGameManager". "theGameManager" is set as the "Game Manager" by dragging the "Game Manager" object into the inspector.

	public AudioSource playScreenMusic; //Declare a public variable of type "AudioSource" and name it "playScreenMusic". "playScreenMusic" is set as the "Play Screen Music" by dragging the "Play Screen Music" object into the inspector.
	public AudioSource gameOverScreenMusic; //Declare a public variable of type "AudioSource" and name it "gameOverScreenMusic". "gameOverScreenMusic" is set as the "Game Over Screen Music" by dragging the "Game Over Screen Music" object into the inspector.


	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth; //Sets the "currentHealth" to be equal to "startingHealth".
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) //Checks if the "currentHealth" is less than or equal to 0. If so, run this if-statement.
		{
			healthText.text = "Health: 0"; //This hard sets the "healthText" text to be "Health: 0" (to prevent a negative number being shown if two enemies damages the player simultaneously).

			theGameManager.GetComponent<GameManagerScript>().TimeSurvived = GameObject.Find("Player").GetComponent<PlayerController>().timeSurvivedText.text; //Sets the "TimeSurvived" string on the "GameManagerScript" script on the "Game Manager" game object to be equal to the "timeSurvivedText" string on the "PlayerController" script on the "Player" game object.

			gameOverScreen.SetActive (true); //Sets the "gameOverScreen" to active (true).
			gameObject.SetActive (false); //Sets the "gameObject" to not active (false).

			playScreenMusic.Stop (); //Stops playing the "playScreenMusic".
			gameOverScreenMusic.Play (); //Plays the "gameOverScreenMusic".
		}
	}
		

	public void HurtPlayer (int damageAmount) //Creates a new public function called "HurtPlayer". The parameter makes it a function that takes in a value.
	{
		currentHealth -= damageAmount; //Shorter version of writing "currentHealth = currentHealth - damageAmount".
		healthText.text = "Health: " + currentHealth; //Sets the "Text" textbox of the "healthText" object to display "Health: " plus the "currentHealth" value.
	}
}
