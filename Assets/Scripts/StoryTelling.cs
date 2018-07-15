using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTelling : MonoBehaviour {
	
	// Time for the tutorial to show up
	public float wait_time;
	public float screen_time;
	public float fade_duration;
	public bool activated;

	//Fading times
	private float fade_in = 0.0f;
	private float fade_out = 1.0f;

	// Use this for initialization
	void Start () {
		//Set photo to invisible
		gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.001f);

	}
	
	// Update is called once per frame
	void Update () {
		
		//Wait till activated
		if(activated){

			//Time till activation
			wait_time -= Time.deltaTime;

			if(wait_time <= 0.0f){
				
				//Do it while screen time not activated
				if(gameObject.GetComponent<Image>().color.a <=1.0 && screen_time >= 0.0f)
				{
					gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,fade_in+=Time.deltaTime/fade_duration);
					
					//Reasure the color
					if(fade_in >= 1.0f)
					{
						gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,1.0f);
					}
				}
				
				//Screening time
				screen_time -= Time.deltaTime;
				if(screen_time <= 0.0f)
				{
					//Do it while it is positive
					if(gameObject.GetComponent<Image>().color.a <= 1.0f)
					{
						
						gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f, fade_out -= Time.deltaTime/fade_duration);
						
						//Reasure the color
						if(fade_out <= 0.0f)
						{
							gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.0f);
							activated = false;
						}
					}
				}
			}
		}
	}
}
