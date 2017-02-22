using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{

	public string startGame;
	public string mainMenu;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void Restart()
	{
		SceneManager.LoadScene (startGame); //Loads the "startGame" scene, which in this case is the "Play Scene".
	}


	public void QuitToMainMenu()
	{
		SceneManager.LoadScene (mainMenu); //Loads the "mainMenu" scene, which in this case is the "Main Menu" scene.
	}

}
