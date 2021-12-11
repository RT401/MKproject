using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    ///  Levels
    public GameObject Startmenu;
    public GameObject Easy;
    public GameObject Normal;
    public GameObject Hard;
    public GameObject CurrentLevel;

    private void Start()
    {
        if (Startmenu == null)
        {
            GameObject[] listOfObjects = FindObjectsOfType<GameObject>();

            foreach(GameObject go in listOfObjects)
            {
                if (go.name == "Startmenu")
                    Startmenu = go;
            }
        }

        if (Easy == null)
        {
            GameObject[] listOfObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject go in listOfObjects)
            {
                if (go.name == "Easy")
                    Easy = go;
            }
        }

        if (Normal == null)
        {
            GameObject[] listOfObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject go in listOfObjects)
            {
                if (go.name == "Normal")
                    Normal = go;
            }
        }

        if (Hard == null)
        {
            GameObject[] listOfObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject go in listOfObjects)
            {
                if (go.name == "Hard")
                    Hard = go;
            }
        }
    }

    /// Setup to find and start chosen level
    public void FindLevel(string chosenLevel)
    {
        if (chosenLevel == Easy.name)
        {
            Startlevel(Easy);
            Easy.GetComponent<Spawner>().amountOfAnswers = 2f;
        }

        if (chosenLevel == Normal.name)
        {
            Startlevel(Normal);
            Normal.GetComponent<Spawner>().amountOfAnswers = 3f;
        }


        if (chosenLevel == Hard.name)
        {
            Startlevel(Hard);
            Hard.GetComponent<Spawner>().amountOfAnswers = 4f;
        }
    }


    void Startlevel(GameObject Level)
    {
        /// Turns off start menu
        /// turns on whatever level was selected
        /// saves current level for later to turn off
        Startmenu.SetActive(false);
        Level.SetActive(true);
        CurrentLevel = Level;
    }

    void EndLevel()
    {
        /// turns off current level
        /// turns on start menu
        CurrentLevel.SetActive(false);
        Startmenu.SetActive(true);
    }
}
