using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public LeaderBoard LB;

    /// holds the ability to check scores when game is over
    public List<string> Questions;
    public List<string> Answers;

    /// End game score and completed
    public int amountCompleated;
    public int amountCorrect;

    private void Start()
    {
        LB = FindObjectOfType<LeaderBoard>();
    }

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

        LB.newScores = new float[1, 2];
        /// Stores values with [0,0] as amount correct and [0,1] as completed to match the leaderboard scores
        LB.newScores[0, 0] = amountCorrect;
        LB.newScores[0, 1] = amountCompleated;
    }

    public void ResetScores()
    {
        Answers.Clear();
        Questions.Clear();
        amountCompleated = 0;
        amountCorrect = 0;
    }
}
