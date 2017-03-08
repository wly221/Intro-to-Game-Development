using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject target; //Declare a public variable of type "GameObject" and name it "target". "target" is set as the "Player" by dragging the "Player" object into the inspector.

	private Vector3 targetPosition; //Declare a private variable of type "Vector3" and name it "targetPosition". "targetPosition" is the target position of the camera.

	public float smoothing; //Declare a public variable of type "float" and name it "smoothing". This is to allow for smooth transitions of the movement of the camera when the "Player" changes directions from left to right, from up to down, and so forth. "smoothing" is set in the inspector.

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		targetPosition = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z); //Sets the variable "targetPosition" to have the x-position and y-position of the "Player" (the "target"), and have the z-position of the "Main Camera".

		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime); //Sets the "transform.position" of the "Main Camera" to a "Vector3" with "Lerp" (to have the "position" of the "Main Camera" linearly interpolate between two vectors, "transform.position" [where the camera currently is] and "targetPosition" [where I want the camera to be], making there be smooth camera movement).
	}
}
