using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    ScoreHolder scoreHolder;
    public LeaderBoard LB;
    Timer timer;
    public Text thisTimer;
    public enum colours
    {
        Black,
        Blue,
        Cyan,
        Gray,
        Green,
        Magenta,
        Red,
        White,
        Yellow
    }

    /// Questions
    public Text questionText;
    public colours currentQuestion;
    Color currentColour;

    /// Answers
    public colours currentAnswer;
    public GameObject answer;
    public GameObject answerPrefab;
    public int amountOfAnswers = 0;

    /// End Screne
    public GameObject endScreen;
    public Text correctText;
    public Text compleatedText;

    private void Start()
    {
        scoreHolder = FindObjectOfType<ScoreHolder>();
        timer = FindObjectOfType<Timer>();
        LB = FindObjectOfType<LeaderBoard>();
    }

    public void StartGame()
    {
        // emptys last games score ready for the new game
        scoreHolder.ResetScores();

        UpdatedQuestion();
        UpdatedAnswer();

        // setup timer to start
        timer.ActivateTimer(thisTimer, true);
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
        currentQuestion = (colours)Random.Range(0, 9);
        questionText.text = currentQuestion.ToString();

        // randomises the background colour
        SwitchBackgroundColour(Random.Range(0, 9));
    }

    public void SwitchBackgroundColour(int randomNumber)
    {
        /// this function will switch the background colour of the answer to one of the selected colours and will save the current answer as it
        switch (randomNumber)
        {
            case 0:
                questionText.color = Color.black;
                currentAnswer = colours.Black;
                break;
            case 1:
                questionText.color = Color.blue;
                currentAnswer = colours.Black;
                break;
            case 2:
                questionText.color = Color.cyan;
                currentAnswer = colours.Black;
                break;
            case 3:
                questionText.color = Color.grey;
                currentAnswer = colours.Black;
                break;
            case 4:
                questionText.color = Color.green;
                currentAnswer = colours.Black;
                break;
            case 5:
                questionText.color = Color.magenta;
                currentAnswer = colours.Black;
                break;
            case 6:
                questionText.color = Color.red;
                currentAnswer = colours.Black;
                break;
            case 7:
                questionText.color = Color.white;
                currentAnswer = colours.Black; 
                break;
            case 8:
                questionText.color = Color.yellow;
                currentAnswer = colours.Black;
                break;
        }
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
                answerPrefab.transform.GetComponentInChildren<Text>().text = (currentAnswer.ToString());
            else
            {
                /// Failsafe to ensure that both answers are not the same
                colours randomAnswer = currentAnswer;
                while (randomAnswer == currentAnswer) 
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
        timer.ActivateTimer(thisTimer, false);

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

        scoreHolder.CheckQA();

        /// Sets the Ending screen to active
        endScreen.SetActive(true);

        compleatedText.text = ("You completed " + scoreHolder.amountCompleated.ToString());
        correctText.text = ("You got " + scoreHolder.amountCorrect.ToString() + " correct");

        /// Currently causing errors will require break point testing
        LB.LevelComplete(this);
    }
}   
