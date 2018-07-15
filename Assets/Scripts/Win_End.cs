using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win_End : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Check if it is acctivated
		int current_done = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().countCorrectForm;
		int goal         = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>().numCorrectFormToGetRight;

		gameObject.GetComponent<Text>().text = current_done +"/"+ goal;
	}


}
