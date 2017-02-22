using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	public string startGame;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void StartGame()
	{
		SceneManager.LoadScene (startGame); //Loads the "startGame" scene, which in this case is the "Play Scene".
	}

	public void QuitGame()
	{
		Application.Quit (); //Closes the game once it is running.
	}




}
