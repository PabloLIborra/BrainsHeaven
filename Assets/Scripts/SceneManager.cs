using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    string form;
    public List<string> typeForms = new List<string>();
    public List<int> percentageForm = new List<int>();
    public List<int> percentageRepetition = new List<int>();

    int countCorrectForm = 0;
    public int numCorrectFormToGetRight = 10;

    public float timeleft = 20.0f;
    public bool playing;
	// Use this for initialization
	void Start () {

		if(typeForms.Count == 0)
        {
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50);
            percentageForm.Add(50);

            percentageRepetition.Clear();
            percentageRepetition.Add(50);
            percentageRepetition.Add(50);
        }

        if (percentageForm.Count == 0 && typeForms.Count != 0)
        {
            typeForms.Clear();
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50);
            percentageForm.Add(50);

            percentageRepetition.Clear();
            percentageRepetition.Add(50);
            percentageRepetition.Add(50);
        }

        if (percentageRepetition.Count == 0 && typeForms.Count != 0)
        {
            typeForms.Clear();
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50);
            percentageForm.Add(50);

            percentageRepetition.Clear();
            percentageRepetition.Add(50);
            percentageRepetition.Add(50);
        }

        int rand = Random.Range(0, typeForms.Count);

        form = typeForms[rand];

    }
	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        if(timeleft < 0)
        {
            //Call lose event;
            playing = false;
        }
	}

    void generateNewRandomForm()
    {
        //First we get the position of the current form
        int position = -1;
        int rand;
        bool found = false;
        for(int i = 0; i < typeForms.Count && !found; i++)
        {
            if(typeForms[i].Equals(form))
            {
                position = i;
                found = true;
            }
        }
        rand = Random.Range(0, 100);
        if(rand > percentageRepetition[position])
        {
            rand = Random.Range(0, 100);
            int pointer = 0;
            bool choosen = false;
            while(!choosen && pointer < typeForms.Count)
            {
                if(rand <= percentageForm[pointer])
                {
                    choosen = true;
                    form = typeForms[pointer];
                }
                rand -= percentageForm[pointer];
                pointer++;
            }
        }
    }

    public void checkGesture(string gesture)
    {

        string formCheck = form + "Der";
        int rand;

        if(gesture == formCheck)
        {
            generateNewRandomForm();
            countCorrectForm++;
        }

        formCheck = form + "Izq";

        if (gesture == formCheck)
        {
            generateNewRandomForm();

            countCorrectForm++;
        }

        if(countCorrectForm == numCorrectFormToGetRight)
        {
            playing = false;
            //Here is your winning function
        }
        else
        {
            generateNewRandomForm();
        }
    }
}
