using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class MenuManager : MonoBehaviour {
	//Save data class

	
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}

[System.Serializable]
class SaveData
{
	public int scene;
}