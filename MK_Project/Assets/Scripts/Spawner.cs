using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public enum colours
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

    public void startGame()
    {
        Leaderboard leaderboard = FindObjectOfType<Leaderboard>();
        // emptys last games score ready for the new game
        leaderboard.Answers.Clear();
        leaderboard.Questions.Clear();

        updateQuestions();
        updateAnswers();

        // setup timer to start
        Timer timer = FindObjectOfType<Timer>();
        timer.displayTimer = true;
        timer.timerRunning = true;
        timer.displayedTimer.gameObject.SetActive(true);
    }

    public void continueGame()
    {
        /// Goes through each of the answers children and destroys the objects to reset the game
        int answersChildCount = answer.transform.childCount;
        for (int i = 0; i < answersChildCount; i++)
        {
            // destroys all previous answers
            Destroy(answer.transform.GetChild(i).gameObject);
        }

        /// update question then update answer
        /// to ensure that the answers will work with the question
        updateQuestions();
        updateAnswers();
    }

    /// Questions
    public Text questionText;
    public colours currentQuestion;
    Color currentColour;

    /// Answers
    public GameObject answer;
    public GameObject answerPrefab;
    public int amountOfAnswers = 0;

    public void updateQuestions()
    {
        // randomises the colours enum to randomise the result
        currentQuestion = (colours)Random.Range(0, 10);
        questionText.text = currentQuestion.ToString();

        // randomises the background colour
        currentColour = new Color(Random.value, Random.value, Random.value, 1f);
        questionText.color = currentColour;
    }

    public void updateAnswers()
    {
        /// randomise which instanciated object spawns the correct answer
        /// requires the +1 because of Random.Range going from the first value to -1 of second value
        int randomAnswerLocation = Random.Range(1, (amountOfAnswers + 1));

        /// Instanciate the correct amount of answers with differnt colours in each one
        for (int i = 1; i <= amountOfAnswers; i++)
        {
            /// randomise the text that appears in each answer box & ensure that one is always the correct answer
            if (i == randomAnswerLocation)
                answerPrefab.transform.GetComponentInChildren<Text>().text = (currentQuestion.ToString());
            else
            {
                colours randomAnswer = (colours)Random.Range(0, 9);
                answerPrefab.transform.GetComponentInChildren<Text>().text = randomAnswer.ToString();
            }

            // lets the instantiated object know what spawner it belongs to
            answerPrefab.GetComponent<AnswerSelect>().gameSpawner = this;

            //instantiate the object
            Instantiate(answerPrefab, answer.transform);
        }
    }
}   
