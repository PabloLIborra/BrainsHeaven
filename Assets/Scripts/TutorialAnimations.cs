using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class TutorialAnimations : MonoBehaviour {

	// Time for the tutorial to show up
	public float remaining_time;
	public float fade_duration;
	public float final_fade_duration = 1.0f;
	bool destroy_this;

	// Use this for initialization
	void Start () {
		//Set component button function
		gameObject.GetComponent<Button>().onClick.AddListener(Destruction);
		GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = false;

		//Don't destroy this
		destroy_this = false;
	}
	
	// Update is called once per frame
	void Update () {
		remaining_time -= Time.deltaTime;

		if(remaining_time < fade_duration){
			gameObject.GetComponent<Image>().CrossFadeColor(
				new Color(gameObject.GetComponent<Image>().color.r,
						  gameObject.GetComponent<Image>().color.g,
						  gameObject.GetComponent<Image>().color.b,
						  0)
						  , fade_duration, false, true);
		}

		if(remaining_time < 0.0f){
			Destruction();
		}

		//If finally set to destroy, wait a "patient" time and then destroy it
		if(destroy_this)
		{
			final_fade_duration -= Time.deltaTime;
			if(final_fade_duration <= 0){
				GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = true;
				GameObject.Destroy(gameObject.transform.parent.gameObject);
			}
		}
	}
	
	//Set the component to visible, fade the rest of the item
	void Destruction()
	{
			gameObject.GetComponent<Image>().CrossFadeColor(
				new Color(gameObject.GetComponent<Image>().color.r,
						  gameObject.GetComponent<Image>().color.g,
						  gameObject.GetComponent<Image>().color.b,
						  0)
						  , 0.1f, false, true);
			destroy_this = true;
	}
}
