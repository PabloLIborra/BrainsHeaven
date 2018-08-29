using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
==================================================================
THIS SCRIPT IS MADE BASED ON THIS TEXT:
==================================================================

Cambios:

1-Primero vamos canvas por canvas y vamos a su opcion canvas scaler y lo ponemos en Scale with screen size y le ponemos 2048*1536.
2-Una vez se haya hecho esto esto, creamos un objeto vacio con nombre "2048" (Tiene que llamarse asi si o si), y le ponemos el tag "Resolution".
3-Una vez creado el objeto, metemos todo dentro de este objeto. 
4-Copiamos y creamos el objeto entero con todo lo que tiene dentro y esta copia, tiene que tener como  nombre "1920" y el mismo tag "Resolution".
5-Ahora mismo, solo tenemos dos objetos en la escena (con todos sus correspondientes hijos), "2048" y "1920". Creamos un tercer objeto vacio al mismo nivel que los otros, no hace falta cambiarle el nombre.
6-A este objeto le añadimos el script  "ResolutionScript".
Los tres objetos deben estar activos, NO DESACTIVAR NINGUNO.

Ahora, vamos al objeto "1920" y vemos todos sus hijos. Repetimos el paso 1 pero con resolucion 1920*1080.

Procedemos a hacer todos los cambios siguientes:


NOMBRE			X , Y

STORY TELLING CANVAS

-Interrogacion:		680, 350
-Puntos:		-780, 19

SCENE MANAGER

-Form:			13, -18

-Background:	Cambiar tamaño width y height a 1920*1080 y escala a 0.93 , 0.93 , 1  y cambiar el sprite y material por background2
-Flash verde y rojo:		Cambiar tamaño width y height a 1920*1080

-Boton pausa:		-730, 440

-TimeBar:	Top a 80 y luego entramos dentro y vamos a su hijo Mask, y cambiamos su right a -75

-Actuales: 		660, -109
-Objetivo:		736, -109


PAUSE CANVAS

-Background:	Cambiar tamaño width y height a 1920*1080 y el sprite y material por pausemenu2

TUTORIAL CANVAS

-Imagen:		Cambiar tamaño a 1920*1920

VICTORY CANVAS

-Image: 	Cambiar tamaño width y height a 1920*1080
-NextLevel: 	-300, -400
-MainMenu:	300, -400
-Points:	120, -280

PARA EL DEFEAT CANVAS LO MISMO!!

==================================================================
 */
 
public class ResolutionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float width = Screen.width;
        float height = Screen.height;
        float actRes = width / height;

        //Resolution booleans
        bool is16_9 = false;
        bool is4_3  = false;

        //Activate proper checkers
        if(actRes == (float)16/9)
        {
            is16_9 = true;
        }

        if(actRes == (float)4/3)
        {
            is4_3 = true;
        }

        //=====================================================================
        //BACKGROUND
        //=====================================================================
        //Set default background color
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.GetComponent<Camera>().backgroundColor = Color.black;

        //scale image to that of the resolution
        GameObject background = GameObject.FindGameObjectWithTag("Background");
        if(background != null)
        {
            float lastW = background.GetComponent<RectTransform>().sizeDelta.x;
            float lastY = background.GetComponent<RectTransform>().sizeDelta.y;

            background.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            //Debug.Log(background.transform.localScale.y);

            float scaleX = (lastW / width) * background.transform.localScale.x;
            float scaleY = (lastY / height) * background.transform.localScale.y;

            background.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
        }

        //=====================================================================
        //CANVAS GENERAL STUFF
        //=====================================================================
        //Variables dependant on the name of the canvas (if the name changes you'll probably find the error heres)
        //HARDCODE IS BAD FOR YOUR SOUL
        GameObject tutorialCanvas     = GameObject.Find("TutorialCanvas");
        GameObject pauseCanvas        = GameObject.Find("PauseCanvas");
        GameObject victoryCanvas      = GameObject.Find("VictoryCanvas");
        GameObject defeatCanvas       = GameObject.Find("DefeatCanvas");
        GameObject storytellingCanvas = GameObject.Find("StoryTellingCanvas");
        GameObject sceneManager       = GameObject.Find("SceneManager");


        //Canvas scaler reference resolution
        if(tutorialCanvas != null) //Check if exists
        {
            tutorialCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(width, height);
        }
        
        if(storytellingCanvas != null) //Check if exists
        {
            storytellingCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(width, height);
        }

        if(pauseCanvas != null) //Check if exists
        {
            pauseCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(width, height);
        }

        if(victoryCanvas != null) //Check if exists
        {
            victoryCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(width, height);
        }

        if(defeatCanvas != null) //Check if exists
        {
            defeatCanvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(width, height);
        }

        //=====================================================================
        // 16:9
        //=====================================================================
        if(is16_9)
        {
            //Pass over each canvas and do their changes

            //TUTORIAL CANVAS
            if(tutorialCanvas != null) //Check if exists
    	    {
                //Only children with RectTransform should be tutorial_image
                tutorialCanvas.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2( width, width); 
            }

            //STORYTELLING CANVAS
            if(storytellingCanvas != null) //Check if exists
    	    {
                //Search all images
                RectTransform[] list = storytellingCanvas.GetComponentsInChildren<RectTransform>();
                foreach(RectTransform rect in list)
                {
                    //Right images
                    if(rect.transform.name.Contains("Image_1"))
                    {
                        rect.anchoredPosition = new Vector2( 640, 330);
                    }

                    //Left images
                    if(rect.transform.name.Contains("Image_2"))
                    {
                        rect.anchoredPosition = new Vector2(-735, 19);
                    }

                    //Bubble
                    if(rect.transform.name.Contains("Bubble"))
                    {
                        rect.anchoredPosition = new Vector2(632.1f, 300.1f);
                        rect.localScale = new Vector3(0.245f, 0.18f, 1.0f);
                    }
                }
            }

            //PAUSE CANVAS
            if(pauseCanvas != null) //Check if exists
            {
                Transform t = pauseCanvas.transform.Find("Background");
                t.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                t.GetComponent<Image>().sprite = Resources.Load("pausemenu2", typeof(Sprite)) as Sprite;
                float xPause = pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta.x;
                float yPause = pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta.y;
                pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta = new Vector2((width * xPause) / 1920, (height * yPause) / 1080);
                xPause = pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta.x;
                yPause = pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta.y;
                pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta = new Vector2((width * xPause) / 1920, (height * yPause) / 1080);
            }

            //VICTORY CANVAS
            if(victoryCanvas != null) //Check if exists
            {
                victoryCanvas.transform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                victoryCanvas.transform.Find("NextLevel").GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -400);
                victoryCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -400);
                victoryCanvas.transform.Find("Points").GetComponent<RectTransform>().anchoredPosition = new Vector2(120, -280);   
            }

            //DEFEAT CANVAS
            if(defeatCanvas != null) //Check if exists
            {
                defeatCanvas.transform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                defeatCanvas.transform.Find("TryAgain").GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -400);
                defeatCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -400);
                defeatCanvas.transform.Find("Points").GetComponent<RectTransform>().anchoredPosition = new Vector2(120, -280);   
            }
            
            //SCENE MANAGER
            if(sceneManager != null)
            {
                sceneManager.transform.Find("Form").GetComponent<RectTransform>().anchoredPosition = new Vector2(13, -18);
                sceneManager.transform.Find("PauseButton").GetComponent<RectTransform>().anchoredPosition = new Vector2(-730, 440);
                sceneManager.transform.Find("Actuales").GetComponent<RectTransform>().anchoredPosition = new Vector2(700, -85);
                sceneManager.transform.Find("Objetivo").GetComponent<RectTransform>().anchoredPosition = new Vector2(766, -85);

                Transform b = sceneManager.transform.Find("Background");
                b.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                float sizeScale = (1920 * 1.0f) / width;
                b.localScale = new Vector3(sizeScale, sizeScale, 1.0f);
                b.GetComponent<SpriteRenderer>().sprite = Resources.Load("background2", typeof(Sprite)) as Sprite;
                b.GetComponent<SpriteRenderer>().material = Resources.Load("background2", typeof(Material)) as Material;

                Transform f = sceneManager.transform.Find("Flash");
                RectTransform[] list = f.GetComponentsInChildren<RectTransform>();
                list[0].sizeDelta = new Vector2(width, height);
                list[1].sizeDelta = new Vector2(width, height);

                Transform t = sceneManager.transform.Find("TimeBar");
                t.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, -400.0f);
                t.transform.Find("Mask").GetComponent<RectTransform>().offsetMax = new Vector2(75.0f, 167.1f);
                //t.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 494.29f);

                sceneManager.transform.Find("Guide").transform.localPosition = new Vector2(-1022.28f, -766.7f);
            }
        }

        //=====================================================================
        // 4:3
        //=====================================================================
        if(is4_3)
        {
            //TUTORIAL CANVAS
            if(tutorialCanvas != null) //Check if exists
    	    {
                //Only children with RectTransform should be tutorial_image
                tutorialCanvas.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2( width, width); 
            }

            //STORYTELLING CANVAS
            if(storytellingCanvas != null) //Check if exists
    	    {
                //Search all images
                RectTransform[] list = storytellingCanvas.GetComponentsInChildren<RectTransform>();
                foreach(RectTransform rect in list)
                {
                    //Right images
                    if(rect.transform.name.Contains("Image_1"))
                    {
                        rect.anchoredPosition = new Vector2( 714.46f, 483.97f);
                    }

                    //Left images
                    if(rect.transform.name.Contains("Image_2"))
                    {
                        rect.anchoredPosition = new Vector2(-824.2f, 30.78f);
                    }

                    //Bubble
                    if(rect.transform.name.Contains("Bubble"))
                    {
                        rect.anchoredPosition = new Vector2(715.1f, 455.8f);
                        rect.localScale = new Vector3(0.281f, 0.277f, 1.0f);
                    }
                }
            }

            //PAUSE CANVAS
            if(pauseCanvas != null) //Check if exists
            {
                Transform t = pauseCanvas.transform.Find("Background");
                t.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                t.GetComponent<Image>().sprite = Resources.Load("pausemenu", typeof(Sprite)) as Sprite;
                float xPause = pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta.x;
                float yPause = pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta.y;
                pauseCanvas.transform.Find("ResumeGame").GetComponent<RectTransform>().sizeDelta = new Vector2((width* xPause) /2048, (height*yPause) /1536);
                xPause = pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta.x;
                yPause = pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta.y;
                pauseCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().sizeDelta = new Vector2((width * xPause) / 2048, (height * yPause) / 1536);

            }

            //VICTORY CANVAS
            if (victoryCanvas != null) //Check if exists
            {
                victoryCanvas.transform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                victoryCanvas.transform.Find("NextLevel").GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -520);
                victoryCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -520);
                victoryCanvas.transform.Find("Points").GetComponent<RectTransform>().anchoredPosition = new Vector2(120, -325);   
            }

            //DEFEAT CANVAS
            if(defeatCanvas != null) //Check if exists
            {
                defeatCanvas.transform.Find("Image").GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                defeatCanvas.transform.Find("TryAgain").GetComponent<RectTransform>().anchoredPosition = new Vector2(-300, -520);
                defeatCanvas.transform.Find("MainMenu").GetComponent<RectTransform>().anchoredPosition = new Vector2(300, -520);
                defeatCanvas.transform.Find("Points").GetComponent<RectTransform>().anchoredPosition = new Vector2(120, -325);   
            }

            //SCENE MANAGER
            if(sceneManager != null)
            {
                sceneManager.transform.Find("Form").GetComponent<RectTransform>().anchoredPosition = new Vector2(12.7f, 5.2f);
                sceneManager.transform.Find("PauseButton").GetComponent<RectTransform>().anchoredPosition = new Vector2(-808.4f, 675.6f);
                sceneManager.transform.Find("Actuales").GetComponent<RectTransform>().anchoredPosition = new Vector2(690.54f, 36.6f);
                sceneManager.transform.Find("Objetivo").GetComponent<RectTransform>().anchoredPosition = new Vector2(751.6f, 41.4f);

                Transform b = sceneManager.transform.Find("Background");
                b.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
                float sizeScale = (2048 * 0.65f) / width;
                b.localScale = new Vector3(sizeScale, sizeScale, 1.0f);
                b.GetComponent<SpriteRenderer>().sprite = Resources.Load("background", typeof(Sprite)) as Sprite;
                b.GetComponent<SpriteRenderer>().material = Resources.Load("Materials/background1", typeof(Material)) as Material;

                Transform f = sceneManager.transform.Find("Flash");
                RectTransform[] list = f.GetComponentsInChildren<RectTransform>();
                list[0].sizeDelta = new Vector2(width, height);
                list[1].sizeDelta = new Vector2(width, height);

                Transform t = sceneManager.transform.Find("TimeBar");
                t.GetComponent<RectTransform>().offsetMax = new Vector2(0.0f, -494.29f);
                t.transform.Find("Mask").GetComponent<RectTransform>().offsetMax = new Vector2(2.384f, -167.1f);
            }
        }

        //=====================================================================
        // UNIVERSAL xxd
        //=====================================================================
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
