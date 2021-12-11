using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject question;
    public GameObject answer;

    public GameObject answerPrefab;

    public float amountOfAnswers = 0f;


    public Text questionText;

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
        Green,
        Brown
    }


}
