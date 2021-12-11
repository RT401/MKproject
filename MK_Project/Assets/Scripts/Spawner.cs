using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
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

    void updateQuestions()
    {
        // randomises the colours enum to randomise the result
        colours cText = (colours)Random.Range(0, 9);
        questionText.text = cText.ToString();

        // randomises the background colour
        Color color = new Color(Random.value, Random.value, Random.value, 1f);
        questionText.color = color;
    }
}
