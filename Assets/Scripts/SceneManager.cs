using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    string form;
    public List<string> typeForms = new List<string>();
    public List<float> percentageForm = new List<float>();
    public List<float> percentageRepetition = new List<float>();

    int countCorrectForm = 0;
    public int numCorrectFormToGetRight = 10;

	// Use this for initialization
	void Start () {

		if(typeForms.Count == 0)
        {
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50.0f);
            percentageForm.Add(50.0f);

            percentageRepetition.Clear();
            percentageRepetition.Add(50.0f);
            percentageRepetition.Add(50.0f);
        }

        if (percentageForm.Count == 0 && typeForms.Count != 0)
        {
            typeForms.Clear();
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50.0f);
            percentageForm.Add(50.0f);

            percentageRepetition.Clear();
            percentageRepetition.Add(50.0f);
            percentageRepetition.Add(50.0f);
        }

        if (percentageRepetition.Count == 0 && typeForms.Count != 0)
        {
            typeForms.Clear();
            typeForms.Add("a");
            typeForms.Add("v");

            percentageForm.Clear();
            percentageForm.Add(50.0f);
            percentageForm.Add(50.0f);

            percentageRepetition.Clear();
            percentageRepetition.Add(50.0f);
            percentageRepetition.Add(50.0f);
        }

        int rand = Random.Range(0, typeForms.Count);

        form = typeForms[rand];
        changeImgForm();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool checkGesture(string gesture)
    {

        string formCheck = form + "Der";
        int rand;

        if(gesture == formCheck)
        {
            rand = Random.Range(0, typeForms.Count);

            form = typeForms[rand];
            changeImgForm();

            countCorrectForm++;

            return true;
        }

        formCheck = form + "Izq";

        if (gesture == formCheck)
        {
            rand = Random.Range(0, typeForms.Count);

            form = typeForms[rand];
            changeImgForm();

            countCorrectForm++;

            return true;
        }

        Debug.Log(form);

        rand = Random.Range(0, typeForms.Count);

        form = typeForms[rand];
        changeImgForm();

        return false;
    }

    public void changeImgForm()
    {
        Image imageForm = GameObject.FindGameObjectWithTag("Form").GetComponent<Image>();
        string matForm = "Materials/" + form + "Form";

        Material mat = Resources.Load(matForm, typeof(Material)) as Material;
        imageForm.material = mat;
    }
}
