using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    /// holds the ability to check scores when game is over
    public List<string> Questions;
    public List<string> Answers;

    /// End game score and completed
    public int amountCompleated;
    public int amountCorrect;

    public void CheckQA()
    {
        for (int i = 0; i < Questions.Count; i++)
        {
            amountCompleated++;
            if (Questions[i] == Answers[i])
            {
                amountCorrect++;
            }
        }
    }

    public void ResetScores()
    {
        Answers.Clear();
        Questions.Clear();
        amountCompleated = 0;
        amountCorrect = 0;
    }
}