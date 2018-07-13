using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideManager : MonoBehaviour {
    public List<string> guide = new List<string>();

    bool clockwise = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string GetNext(string s)
    {
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
    }
}
