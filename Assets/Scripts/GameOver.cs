using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
	public string startGame; //Declare a public variable of type "string" and name it "startGame". "startGame" is set in the inspector.
	public string mainMenu; //Declare a public variable of type "string" and name it "mainMenu". "mainMenu" is set in the inspector.

	public GameObject theGameManager; //Declare a public variable of type "GameObject" and name it "theGameManager". "theGameManager" is set as the "Game Manager" by dragging the "Game Manager" object into the inspector.

	public Text timeSurvivedText; //Declare a public variable of type "Text" and name it "timeSurvivedText". "timeSurvivedText" is set as "Time Survived Text" by dragging the "Time Survived Text" object into the inspector.


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSurvivedText.text = theGameManager.GetComponent<GameManagerScript>().TimeSurvived; //Sets the "timeSurvivedText" text to be equal to the "TimeSurvived" string on the "GameManagerScript" script on "theGameManager" game object.
	}


	public void Restart() //Creates a new public function called "Restart".
	{
		SceneManager.LoadScene (startGame); //Loads the "startGame" scene, which in this case is the "Play Scene".
	}


	public void QuitToMainMenu() //Creates a new public function called "QuitToMainMenu".
	{
		SceneManager.LoadScene (mainMenu); //Loads the "mainMenu" scene, which in this case is the "Main Menu" scene.
	}
}
