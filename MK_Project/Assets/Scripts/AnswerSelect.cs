using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSelect : MonoBehaviour
{
    Leaderboard Leaderboard;
    public Spawner gameSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // find the leaderboard object
        Leaderboard = FindObjectOfType<Leaderboard>();
    }

    public void OnSelect(GameObject go)
    {
        /// Save the question and answer to a list to check at end for score (saved in 2 different list (one for question one for answer))
        Leaderboard.Questions.Add(gameSpawner.currentQuestion.ToString());
        Leaderboard.Answers.Add(go.transform.GetComponentInChildren<Text>().text);

        gameSpawner.ContinueGame();
    }
}
