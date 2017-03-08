using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour 
{
	public float lifeTime; //Declare a public variable of type "float" and name it "lifeTime". This variable will become how long an object will last for before it gets destroyed.

	// Use this for initialization
	void Start () 
	{
		lifeTime = 1.1f; //Set "lifeTime" to equal "1.1f".
	}

	// Update is called once per frame
	void Update () 
	{
		lifeTime = lifeTime - Time.deltaTime; //During every "Update" loop, "Time.deltaTime" is the amount of time needed for a particular frame to take place.

		if (lifeTime <= 0f) //Checks if "lifeTime" is less than or equal to "0f". If so, run this if-statement.
		{
			Destroy (gameObject); //If "lifeTime" becomes a float of less than or equal to 0, then destroy the "gameObject" that this script is attached to.
		}
	}
}
