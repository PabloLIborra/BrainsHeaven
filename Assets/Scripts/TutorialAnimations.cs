using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class TutorialAnimations : MonoBehaviour {

	// Time for the tutorial to show up
	public float remaining_time;
	public float fade_duration;
	public float final_fade_duration = 0.6f;
	bool destroy_this;
	
	//Storytelling stops
	bool storytelling;

	// Use this for initialization
	void Start () {
		//Set component button function
		gameObject.GetComponent<Button>().onClick.AddListener(Destruction);
		GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = false;
		
		//Don't destroy this
		destroy_this = false;
		storytelling = true;
		
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().playing = false;
    }
	
	// Update is called once per frame
	void Update () {
		//If storytelling stops
		if(!storytelling)
		{

			remaining_time -= Time.deltaTime;

			if(remaining_time < fade_duration && !destroy_this){
				gameObject.GetComponent<Image>().CrossFadeAlpha(0
							, fade_duration, false);
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
                	GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().playing = true;
				}
			}
		}
	}
	
	//Set the component to visible, fade the rest of the item
	void Destruction()
	{
			gameObject.GetComponent<Image>().CrossFadeAlpha(0 , final_fade_duration, false);
			destroy_this = true;
	}
}
