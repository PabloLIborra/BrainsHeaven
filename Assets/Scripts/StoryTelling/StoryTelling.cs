using UnityEngine;
using UnityEngine.UI;

public class StoryTelling : MonoBehaviour {
	
	// Time for the tutorial to show up
	public float timeTillActivation;
	public float timeOnScreen;
	public float fade_duration;

	//Fading times
	private float fade_in = 0.0f;
	private float fade_out = 1.0f;
	private float alphaValueOfPicture;

	// Use this for initialization
	void Start () {
		//Set photo to invisible
		gameObject.GetComponent<Image>().color = new Color(1.0f,1.0f,1.0f,0.001f);
	}
	
	void Update () {

		timeTillActivation -= Time.deltaTime;
		if (timeTillActivation >= 0.0f)
			return;

		FadeIn();
	}

	void FadeIn()
    {
		//Do it while screen time not activated
		if (gameObject.GetComponent<Image>().color.a <= 1.0 && timeOnScreen >= 0.0f)
		{
			gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, fade_in += Time.deltaTime / fade_duration);

			//Reasure the color
			if (fade_in >= 1.0f)
			{
				gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			}
		}

		//Screening time
		timeOnScreen -= Time.deltaTime;
		if (timeOnScreen <= 0.0f)
		{
			//Do it while it is positive
			if (gameObject.GetComponent<Image>().color.a <= 1.0f)
			{

				gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, fade_out -= Time.deltaTime / fade_duration);

				//Reasure the color
				if (fade_out <= 0.0f)
				{
					gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
				}
			}
		}
	}
}
