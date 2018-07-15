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
		
		if(chosen && gameObject.GetComponent<Image>().color.a == 0.0f)
		{
			gameObject.GetComponent<Image>().sprite = null;
			chosen = false;
		}
	}

	public void GenerateGreenCard()
	{
		Image a = gameObject.GetComponent<Image>();
		a.sprite = image_win;
		/*a.CrossFadeAlpha(0.0f, fade_speed, false);
		chosen = true;*/
	}

	public void GenerateRedCard()
	{
		Image a = gameObject.GetComponent<Image>();
		a.sprite = image_win;
		/*a.CrossFadeAlpha(0.0f, fade_speed, false);
		chosen = true;*/
	}

}
