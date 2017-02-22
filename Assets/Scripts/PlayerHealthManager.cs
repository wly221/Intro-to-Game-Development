using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour 
{
	public int startingHealth;
	public int currentHealth;
	public Text healthText;

	public GameObject gameOverScreen;



	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) 
		{
			//gameObject.SetActive (false);
			Destroy (gameObject); //Destroys the "Player" game object.
			gameOverScreen.SetActive (true);

		}
	}
		

	public void HurtPlayer (int damageAmount)
	{
		currentHealth -= damageAmount;
		healthText.text = "Health: " + currentHealth;
			
	}


}
