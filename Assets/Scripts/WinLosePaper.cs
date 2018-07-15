using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLosePaper : MonoBehaviour {

	public float fade_speed;
	public Sprite image_win;
	public Sprite image_lose;
	public bool chosen; //Means an answer was given

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Image>().color.a >= 0.99f)
		{
			gameObject.GetComponent<Image>().CrossFadeAlpha(0.0f, fade_speed* 0.5f, false);
		}

		/*if(chosen && gameObject.GetComponent<Image>().color.a == 0.0f)
		{
			gameObject.GetComponent<Image>().sprite = null;
			chosen = false;

		}*/
	}

	public void GenerateGreenCard()
	{
		Image a = gameObject.GetComponent<Image>();
		a.sprite = image_win;
		a.CrossFadeAlpha(1.0f, fade_speed * 0.5f, false);
		
	}

	public void GenerateRedCard()
	{
		Image a = gameObject.GetComponent<Image>();
		a.sprite = image_lose;
		a.CrossFadeAlpha(1.0f, fade_speed * 0.5f, false);
	}

}
