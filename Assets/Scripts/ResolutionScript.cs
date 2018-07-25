using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject[] resolution = GameObject.FindGameObjectsWithTag("Resolution");

        float width = Screen.width;
        float height = Screen.height;
        float actRes = width / height;

        bool change = false;

        for (int i = 0; i < resolution.Length; i++)
        {
            if(actRes == (float)16/9)
            {
                if(resolution[i].name == "1920")
                {
                    resolution[i].SetActive(true);
                    change = true;
                }
                else
                {
                    resolution[i].SetActive(false);
                }
            }
            else if (actRes == (float)4/3)
            {
                if (resolution[i].name == "2048")
                {
                    resolution[i].SetActive(true);
                    change = true;
                }
                else
                {
                    resolution[i].SetActive(false);
                }
            }
        }

        if(change == false)
        {
            for (int i = 0; i < resolution.Length; i++)
            {
                if (resolution[i].name == "1920")
                {
                    resolution[i].SetActive(true);
                    change = true;
                }
                else
                {
                    resolution[i].SetActive(false);
                }
            }
        }

        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<Camera>().backgroundColor = Color.black;


        GameObject background = GameObject.FindGameObjectWithTag("Background");

        if(background != null)
        {
            float lastW = background.GetComponent<RectTransform>().sizeDelta.x;
            float lastY = background.GetComponent<RectTransform>().sizeDelta.y;

            background.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            Debug.Log(background.transform.localScale.y);

            float scaleX = (lastW / width) * background.transform.localScale.x;
            float scaleY = (lastY / height) * background.transform.localScale.y;

            background.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
