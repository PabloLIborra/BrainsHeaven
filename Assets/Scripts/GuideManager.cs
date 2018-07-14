using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideManager : MonoBehaviour {
    public List<string> guide = new List<string>();
    public List<GameObject> references = new List<GameObject>();
    public List<GameObject> arrows = new List<GameObject>();

    bool clockwise = true;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < guide.Count; i++)
        {
            string route = guide[i] + "Mini";
            references[i].GetComponent<SpriteRenderer>().sprite = Resources.Load(route, typeof(Sprite)) as Sprite;

            if(clockwise)
            {
                arrows[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Arrow", typeof(Sprite)) as Sprite;
            }
            else
            {
                arrows[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Arrowcc", typeof(Sprite)) as Sprite;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    public string GetNext(string s)
    {
        Debug.Log("Pide siguiente");
        bool found = false;
        int position = -1;
        for (int i = 0; i < guide.Count && !found; i++)
        {
            if (guide[i].Equals(s))
            {
                position = i;
                found = true;
            }
        }
        if(clockwise)
        {
            Debug.Log("Es clockwise");
            if(position == guide.Count -1)
            {
                return guide[0];
            }
            else
            {
                return guide[position + 1];
            }
        }
        else
        {
            Debug.Log("Es anticlockwise");
            if(position == 0)
            {
                return guide[guide.Count - 1];
            }
            else
            {
                return guide[position - 1];
            }
        }
    }

    public void ChangeClockwise()
    {
        clockwise = !clockwise;
        for(int i = 0; i < arrows.Count; i++)
        {
            if (clockwise)
            {
                arrows[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Arrow", typeof(Sprite)) as Sprite;
                Image guideTextBox = GameObject.FindGameObjectWithTag("GuideTextBox").GetComponent<Image>();
                if(guideTextBox.enabled == true)
                {
                    guideTextBox.enabled = false;
                }
            }
            else
            {
                arrows[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("Arrowcc", typeof(Sprite)) as Sprite;
                Image guideTextBox = GameObject.FindGameObjectWithTag("GuideTextBox").GetComponent<Image>();
                if (guideTextBox.enabled == false)
                {
                    guideTextBox.enabled = true;
                }
            }
        }
    }
}
