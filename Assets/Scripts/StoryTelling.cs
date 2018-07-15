using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTelling : MonoBehaviour {
	
	// Time for the tutorial to show up
	public float wait_time;
	public float screen_time;
	public float fade_duration;

	// Use this for initialization
	void Start () {
		//Set photo to invisible
		gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		
		//Time till activation
		wait_time -= Time.deltaTime;

		if(wait_time <= 0.0f){
			
			//Do it once
			if(gameObject.GetComponent<Image>().color.a == 0.0f)
				gameObject.GetComponent<Image>().CrossFadeAlpha(1.0f, fade_duration, false);
			
			//Screening time
			screen_time -= Time.deltaTime;
			if(screen_time <= 0.0f)
			{
				//Do it once
				if(gameObject.GetComponent<Image>().color.a == 1.0f)
					gameObject.GetComponent<Image>().CrossFadeAlpha(1.0f, fade_duration, false);
			}
		}
	}
}
