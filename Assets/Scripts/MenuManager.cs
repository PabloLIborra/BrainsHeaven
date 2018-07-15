using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	
	public string firstLevel; 	//First level
	public string selectLevel;  //Screen of level selection

	//Init Game
	public void StartGame()
	{
		//Load the first level
		UnityEngine.SceneManagement.SceneManager.LoadScene( firstLevel );

	}

	//Go back to main menu
	public void MainMenu()
	{
		//Load the main menu
		UnityEngine.SceneManagement.SceneManager.LoadScene( 0 );
        Time.timeScale = 1.0f;
    }

	//Load selection level
	public void LoadSelectScene()
	{
		//Load the main menu
		UnityEngine.SceneManagement.SceneManager.LoadScene( selectLevel );
	}

	//Load fixed level
	public void LoadLevel()
	{
		//Load the main menu
		Transform t = transform.Find("Text");
		UnityEngine.UI.Text text_canvas = t.GetComponent<UnityEngine.UI.Text>();
		string inner_text = text_canvas.text;
		UnityEngine.SceneManagement.SceneManager.LoadScene( int.Parse(inner_text) );
	}

    //Try Again level
    public void TryAgainLevel()
    {
        //Load the next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
                            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                            );
    }

    //Next level
    public void NextLevel()
	{
		//Load the next scene
		UnityEngine.SceneManagement.SceneManager.LoadScene(
							UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex +1
							);
    }

	//Exit game
	public void QuitGame()
	{
		//Quit the scene
		Application.Quit();
	}


	//Save the game
	public void SaveGame(){
		//Open File
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "save.dat");
		
		//Create save data
		SaveData s = new SaveData();
		s.scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

		//Save && close file
		bf.Serialize(file, s);
		file.Close();

	}

	//Load the game
	public void loadGame()
	{
		//Check if file exists
		if(File.Exists(Application.persistentDataPath + "save.dat"))
		{
			//Read save file
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "save.dat", FileMode.Open);

			//Load data
			SaveData data = (SaveData)bf.Deserialize(file);
			int scene_to_load = data.scene + 1;

			//Load scene
			UnityEngine.SceneManagement.SceneManager.LoadScene(scene_to_load);

			//Close file
			file.Close();
		}
	}

    //Pause Menu
    public void PauseGame()
    {
        SceneManager scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<SceneManager>();

        if(Time.timeScale > 0.0f)
        {
            scene.gamePause = true;
            Time.timeScale = 0.0f;

            Canvas pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<Canvas>();
            pauseCanvas.enabled = true;

        }
        else if(Time.timeScale == 0.0f)
        {
            scene.gamePause = false;
            Time.timeScale = 1.0f;

            Canvas pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas").GetComponent<Canvas>();
            pauseCanvas.enabled = false;
        }
        
    }

    public void loadLevelSelect(string lvl)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvl);
    }

    public void NextCanvasLevelSelect()
    {
        GameObject[] gameLevel = GameObject.FindGameObjectsWithTag("SelectCanvas");
        int canvasEnable = 0;

        for (int i = 0; i < gameLevel.Length; i++)
        {
            if (gameLevel[i].GetComponent<Canvas>().enabled)
            {
                canvasEnable = i;
                gameLevel[i].GetComponent<Canvas>().enabled = false;
            }
        }
        gameLevel[canvasEnable-1].GetComponent<Canvas>().enabled = true;

        Button next = GameObject.Find("Next").GetComponent<Button>();
        Button back = GameObject.Find("Back").GetComponent<Button>();
        
        if (canvasEnable == 1)
        {
            next.interactable = false;
            back.interactable = true;
        }
        else
        {
            next.interactable = true;
            back.interactable = true;
        }
    }

    public void BackCanvasLevelSelect()
    {
        GameObject[] gameLevel = GameObject.FindGameObjectsWithTag("SelectCanvas");
        int canvasEnable = 0;

        for (int i = 0; i < gameLevel.Length; i++)
        {
            if (gameLevel[i].GetComponent<Canvas>().enabled)
            {
                canvasEnable = i;
                gameLevel[i].GetComponent<Canvas>().enabled = false;
            }
        }
        gameLevel[canvasEnable + 1].GetComponent<Canvas>().enabled = true;

        Button next = GameObject.Find("Next").GetComponent<Button>();
        Button back = GameObject.Find("Back").GetComponent<Button>();

        Debug.Log(gameLevel.Length);
        Debug.Log(canvasEnable);
        if (canvasEnable == gameLevel.Length - 2)
        {
            next.interactable = true;
            back.interactable = false;
        }
        else
        {
            next.interactable = true;
            back.interactable = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}

//Save data class
[System.Serializable]
class SaveData
{
	public int scene;
}