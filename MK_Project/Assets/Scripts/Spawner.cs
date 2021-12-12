using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    Leaderboard leaderboard;
    Timer timer;
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

    /// Questions
    public Text questionText;
    public colours currentQuestion;
    Color currentColour;

    /// Answers
    public GameObject answer;
    public GameObject answerPrefab;
    public int amountOfAnswers = 0;

    /// End Screne
    public GameObject endScreen;
    public Text correctText;
    public Text compleatedText;

    private void Start()
    {
        leaderboard = FindObjectOfType<Leaderboard>();
        timer = FindObjectOfType<Timer>();
    }

    public void StartGame()
    {
        // emptys last games score ready for the new game
        leaderboard.Answers.Clear();
        leaderboard.Questions.Clear();

        UpdatedQuestion();
        UpdatedAnswer();

        // setup timer to start
        timer.ActivateTimer(true);
    }

    public void ContinueGame()
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
        UpdatedQuestion();
        UpdatedAnswer();
    }

    public void UpdatedQuestion()
    {
        // randomises the colours enum to randomise the result
        currentQuestion = (colours)Random.Range(0, 10);
        questionText.text = currentQuestion.ToString();

        // randomises the background colour
        currentColour = new Color(Random.value, Random.value, Random.value, 1f);
        questionText.color = currentColour;
    }

    public void UpdatedAnswer()
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
                /// Failsafe to ensure that both answers are not the same
                colours randomAnswer = currentQuestion;
                while (randomAnswer == currentQuestion) 
                    randomAnswer = (colours)Random.Range(0, 9);
                answerPrefab.transform.GetComponentInChildren<Text>().text = randomAnswer.ToString();
            }

            // lets the instantiated object know what spawner it belongs to
            answerPrefab.GetComponent<AnswerSelect>().gameSpawner = this;

            //instantiate the object
            Instantiate(answerPrefab, answer.transform);
        }
    }

    public void EndOfGame()
    {
        /// turns timer off and resets for next game
        timer.ActivateTimer(false);

        /// Sets the parent of QuestionText to inactive
        questionText.gameObject.transform.parent.gameObject.SetActive(false);

        /// Removes all children from answer
        int answersChildCount = answer.transform.childCount;
        for (int i = 0; i < answersChildCount; i++)
        {
            // destroys all previous answers
            Destroy(answer.transform.GetChild(i).gameObject);
        }

        /// Sets the answer gameobject to inactive 
        answer.SetActive(false);

        leaderboard.CheckQA();

        /// Sets the Ending screen to active
        endScreen.SetActive(true);

        compleatedText.text = ("You completed " + leaderboard.amountCompleated.ToString());
        correctText.text = ("You got " + leaderboard.amountCorrect.ToString() + " correct");
    }
}   
