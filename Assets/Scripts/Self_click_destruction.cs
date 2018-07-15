using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Self_click_destruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//Listener of destruction
		gameObject.GetComponent<Button>().onClick.AddListener(Destruction);
		GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = false;
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().playing = false;
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().gamePause = true;	
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().storytelling = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Destruction()
	{
		//get the game playing
		GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().storytelling = false;
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().gamePause = false;	
        GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().playing = true;	
		GameObject.FindGameObjectWithTag("Form").GetComponent<Image>().enabled = true;

		//Destroy parent
		GameObject.Destroy(gameObject);

	}
}
