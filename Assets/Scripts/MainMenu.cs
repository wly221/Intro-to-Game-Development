using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public string startGame; //Declare a public variable of type "string" and name it "startGame". "startGame" is set in the inspector.
	public string story; //Declare a public variable of type "string" and name it "story". "story" is set in the inspector.
	public string instructions; //Declare a public variable of type "string" and name it "instructions". "instructions" is set in the inspector.


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void StartGame() //Creates a new public function called "StartGame".
	{
		SceneManager.LoadScene (startGame); //Loads the "startGame" scene, which in this case is the "Play Scene".
	}

	public void Story() //Creates a new public function called "Story".
	{
		SceneManager.LoadScene (story); //Loads the "story" scene, which in this case is the "Story".
	}

	public void Instructions() //Creates a new public function called "Instructions".
	{
		SceneManager.LoadScene (instructions); //Loads the "instructions" scene, which in this case is the "Instructions".
	}

	public void QuitGame() //Creates a new public function called "QuitGame".
	{
		Application.Quit (); //Closes the game once it is running.
	}
}
