using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    string form;
    public List<string> typeForms = new List<string>();
    public List<int> percentageForm = new List<int>();
    public List<int> percentageRepetition = new List<int>();

    public int countCorrectForm = 0;
    public int numCorrectFormToGetRight = 10;

    public float timeleft = 20.0f;
    public bool playing;

    //Flash Image
    float flashTime = 0.0f;
    bool flashActive = false;
    public float transitionFlash = 0.2f;

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
        changeImgForm();

        playing = true;
        
    }
	
	// Update is called once per frame
	void Update () {

        if(playing == true)
        {
            timeleft -= Time.deltaTime;
        }
        if(timeleft < 0 && playing == true)
        {
            playing = false;

            GameObject imageForm = GameObject.FindGameObjectWithTag("Form");
            imageForm.SetActive(false);

            Canvas defeat = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Canvas>();
            defeat.enabled = true;
        }

        //Check Time Flash Image
        if(flashActive)
        {
            if(flashTime - timeleft >= transitionFlash)
            {
                Image flashImg;
                flashImg = GameObject.FindGameObjectWithTag("FlashGreen").GetComponent<Image>();
                if(flashImg.enabled == true)
                {
                    flashImg.enabled = false;
                }

                flashImg = GameObject.FindGameObjectWithTag("FlashRed").GetComponent<Image>();
                if (flashImg.enabled == true)
                {
                    flashImg.enabled = false;
                }
            }
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
            changeImgForm();
            flashImage(true);
            countCorrectForm++;
        }

        formCheck = form + "Izq";

        if (gesture == formCheck)
        {
            generateNewRandomForm();
            changeImgForm();
            flashImage(true);
            countCorrectForm++;
        }

        if(countCorrectForm == numCorrectFormToGetRight)
        {
            playing = false;

            GameObject imageForm = GameObject.FindGameObjectWithTag("Form");
            imageForm.SetActive(false);
          
            Canvas victory = GameObject.FindGameObjectWithTag("VictoryCanvas").GetComponent<Canvas>();
            victory.enabled = true;
        }
        else
        {
            generateNewRandomForm();
            changeImgForm();
            flashImage(false);
        }
    }

    public void changeImgForm()
    {
        Image imageForm = GameObject.FindGameObjectWithTag("Form").GetComponent<Image>();
        string matForm = "Materials/" + form + "Form";

        Material mat = Resources.Load(matForm, typeof(Material)) as Material;
        imageForm.material = mat;

    }

    public void flashImage(bool flash)
    {
        Image flashImg;
        if (flash)
        {
            flashImg = GameObject.FindGameObjectWithTag("FlashGreen").GetComponent<Image>();
            flashImg.enabled = true;
            flashTime = timeleft;
            flashActive = true;
        }
        else
        {
            flashImg = GameObject.FindGameObjectWithTag("FlashRed").GetComponent<Image>();
            flashImg.enabled = true;
            flashTime = timeleft;
            flashActive = true;
        }
    }

}
