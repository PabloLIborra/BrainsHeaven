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

	//Fade values
	private float fade_out = 1.0f;

	// Use this for initialization
	void Start () {
		//Set component button function
		gameObject.GetComponent<Button>().onClick.AddListener(Destruction);
		
		//Check if it has image
		GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = false;
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().gamePause = true;

        //Don't destroy this
        destroy_this = false;
		
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().storytelling = true;
    }
	
	// Update is called once per frame
	void Update () {

		remaining_time -= Time.deltaTime;

		if(remaining_time < fade_duration && !destroy_this){
			//Check if it has image
			if(gameObject.GetComponent<Image>() != null)
			{
				gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,fade_out-=Time.deltaTime/fade_duration);
			}
		}

		if(remaining_time < 0.0f){
			destroy_this = true;
		}

		//If finally set to destroy, wait a "patient" time and then destroy it
		if(destroy_this)
		{
			//Check if it has image
			GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = true;
        	GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().storytelling = false;
            GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().gamePause = false;
            Destroy(gameObject.transform.parent.gameObject);
		}
	}
	
	//Set the component to visible, fade the rest of the item
	void Destruction()
	{
			destroy_this = true;
	}
}
