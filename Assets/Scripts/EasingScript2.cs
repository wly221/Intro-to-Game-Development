using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class EasingScript2 : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		//This is for moving the UI's Time Survived Text from outside the right side of the screen (camera) to the right side of the screen (camera).
		HOTween.To(this.gameObject.GetComponent<RectTransform>(), //Component that I want to modify.
		1f, //Duration.
		new TweenParms()
		.Prop("anchoredPosition", //Property name.
		new Vector2(-270f, -70f), //Target value.
		false) //Set as not relative.
		.Ease(EaseType.EaseOutQuad) //Ease.
		);
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
