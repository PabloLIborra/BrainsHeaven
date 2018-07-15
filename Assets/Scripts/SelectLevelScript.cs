using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] levelButton = GameObject.FindGameObjectsWithTag("LevelButton");

        int maxLevel = gameObject.GetComponent<MenuManager>().checkLevelSaved();

        for (int i = 0; i < levelButton.Length; i++)
        {
            
            int level = Int32.Parse(levelButton[i].name);

            if(level <= maxLevel)
            {
                levelButton[i].GetComponent<Button>().interactable = true;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
