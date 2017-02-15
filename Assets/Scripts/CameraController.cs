using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject target; //Declare a public variable of type "GameObject" and name it "target".
	//public float followAhead; //Declare a public variable of type "float" and name it "followAhead". "followAhead" is the amount I want the camera to follow ahead of the player.

	private Vector3 targetPosition; //Declare a private variable of type "Vector3" and name it "targetPosition". "targetPosition" is the target position of the camera.

	public float smoothing; //Declare a public variable of type "float" and name it "smoothing". This is to allow for smooth transitions of the movement of the camera when the "Player" changes directions from the left to the right, and vice versa.

	// Use this for initialization
	void Start () 
	{
		//followAhead = 0f; //Sets the public variable "followAhead" to be equal to a float of 0.

		smoothing = 3f; //Sets the public variable "smoothing" to be equal to a float of 3.
	}

	// Update is called once per frame
	void Update () 
	{
		targetPosition = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z); //Sets the variable "targetPosition" to have the x-position and y-positiion of the "Player" (the "target"), and have the z-position of the "Main Camera".

		/*

		//This moves the target position of the camera ahead of the "Player".
		if (target.transform.localScale.x > 0f) //Checks if the "Player" (the "target") is facing to the right. If so, run this if-statement.
		{ 
			targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z); //Sets the variable "targetPosition" to have the x-position of the "Player" (the "target") plus the "followAhead", and have the y-position and z-position of the "Main Camera".
		} 

		else //Or else if the "Player" (the "target") is facing to the left, run this else-statement.
		{
			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z); //Sets the variable "targetPosition" to have the x-position of the "Player" (the "target") minus the "followAhead", and have the y-position and z-position of the "Main Camera".
		}

		*/


		//The code below is commented out because I am no longer intending that.
		//transform.position = targetPosition; //Sets the "transform.position" of the "Main Camera" to equal to the "targetPosition". Makes it so that the "Main Camera" will follow the x-position of the "Player" plus or minus the "followAhead" depending on whether the "Player" is facing right or left respectively, and follow the y-position and z-position of itself (which doesn't change).

		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime); //Sets the "transform.position" of the "Main Camera" to a "Vector3" with "Lerp" (to have the "position" of the "Main Camera" linearly interpolate between two vectors, "transform.position" [where the camera currently is] and "targetPosition" [where I want the camera to be], making there be smooth camera movement).
	}
}
