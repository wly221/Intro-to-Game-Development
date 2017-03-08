using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour 
{
	public string mainMenu; //Declare a public variable of type "string" and name it "mainMenu". "mainMenu" is set in the inspector.


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ReturnToMainMenu() //Creates a new public function called "ReturnToMainMenu".
	{
		SceneManager.LoadScene (mainMenu); //Loads the "mainMenu" scene, which in this case is the "Main Menu" scene.
	}
}
