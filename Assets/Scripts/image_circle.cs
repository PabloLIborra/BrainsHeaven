using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image_circle : MonoBehaviour {

	//List of images
	public List<Sprite> lista_de_imagenes;
	public float transition_speed = 0.1f;
	private float remaining_time = 0.1f;
	private int index = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		remaining_time -= Time.deltaTime;
		if(remaining_time <= 0)
		{
			remaining_time = transition_speed;
			gameObject.GetComponent<Image>().sprite = lista_de_imagenes[index];
			index++;
			if(index >= lista_de_imagenes.Count)
			{
				index = 0;
			}
		}
	}
}
