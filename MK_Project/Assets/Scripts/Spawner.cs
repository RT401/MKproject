using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject answerPrefab;
    public GameObject Startmenu;

    enum colours
    {
        Red,
        Blue,
        Yellow,
        Orange,
        Black,
        White,
        Pink,
        Purple,
        Green
    }

    void FindLevel(string chosenLevel)
    {
        //search scene to find gameobject with enum chosens name
        //then set that object as active and disable main menu object

        Canvas[] allCanvasArray;
        Canvas LevelCanvas;

        allCanvasArray = FindObjectsOfType<Canvas>();

        foreach(Canvas cv in allCanvasArray)
        {
            if (cv.gameObject.name == chosenLevel)
                LevelCanvas = cv;
        }

        //Ensure that the level was found before try to start playing
        if (LevelCanvas != null)
            Startlevel(LevelCanvas);
    }

    void Startlevel(Canvas Level)
    {
        Startmenu.SetActive(false);
        Level.gameObject.SetActive(true);
    }

}
