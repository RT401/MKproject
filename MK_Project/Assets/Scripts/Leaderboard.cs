using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    /// <summary>
    /// required variables
    /// 3 floats to store difficulty best scores
    /// refernce to scoreHolder, difficultys, ClickOn fucntion
    /// </summary>
    public ScoreHolder SH;

    public Text easyText;
    public Text normalText;
    public Text hardText;

    /// <summary>
    /// Scores array is stored as followed
    ///     1   2
    /// 0   A   B
    /// 1   A   B
    /// 2   A   B
    /// 
    /// Vertical key
    /// 0 = easy
    /// 1 = Normal
    /// 2 = Hard
    /// A = correct
    /// B = compleated
    /// </summary>

    public float?[,] Scores;
    public float[,] newScores;

    private void Start()
    {
        SH = FindObjectOfType<ScoreHolder>();
    }

    public void UpdateDisplayScores(GameObject go)
    {
        if (go.name == "Easy" && easyText != null)
        {
            easyText.text = (Scores[0, 0].ToString() + " / " + Scores[0, 1].ToString()); 
        }
        else if (go.name == "Normal" && normalText != null)
        {
            normalText.text = (Scores[1, 0].ToString() + " / " + Scores[1, 1].ToString());
        }
        else if (go.name == "Hard" && hardText != null)
        {
            hardText.text = (Scores[2, 0].ToString() + " / " + Scores[2, 1].ToString());
        }
    }

    public void LevelComplete(GameObject go)
    {
        /// compare gameobject referenced to stored scores

        /// check if score is lower or higher, update score if higher and better correct rate
        CheckScores(go);

        /// Dispay Scores on menu
        UpdateDisplayScores(go);
    }

    void CheckScores(GameObject go)
    {
        //check the name of the gameobect to decide which score to check

        if (go.name == "Easy")
        {
            if (Scores[0,1] == null)
            {
                Scores[0, 0] = newScores[0, 0];
                Scores[0, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the amout scored is better or worse
                if (newScores[0, 0] < Scores[0, 0])
                {
                    //Now check if the percentage correct is greater than 50% to stop spamers
                    if (newScores[0, 0] / newScores[0, 1] > 0.5f)
                    {
                        Scores[0, 0] = newScores[0, 0];
                        Scores[0, 1] = newScores[0, 1];
                        ClearNewScores();
                    }
                    else
                    {
                        Debug.Log("no Change");
                        ClearNewScores();
                    }
                }
                else
                {
                    Debug.Log("no Change");
                    ClearNewScores();
                }
            }
        }
        else if (go.name == "Normal")
        {
            if (Scores[1, 1] == null)
            {
                Scores[1, 0] = newScores[0, 0];
                Scores[1, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the amout scored is better or worse
                if (newScores[0, 0] < Scores[1, 0])
                {
                    //Now check if the percentage correct is greater than 50% to stop spamers
                    if (newScores[0, 0] / newScores[0, 1] > 0.5f)
                    {
                        Scores[1, 0] = newScores[0, 0];
                        Scores[1, 1] = newScores[0, 1];
                        ClearNewScores();
                    }
                    else
                    {
                        Debug.Log("no Change");
                        ClearNewScores();
                    }
                }
                else
                {
                    Debug.Log("no Change");
                    ClearNewScores();
                }
            }
        }
        else if (go.name == "Hard")
        {
            if (Scores[2,1] == null)
            {
                Scores[2, 0] = newScores[0, 0];
                Scores[2, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the amout scored is better or worse
                if (newScores[0, 0] < Scores[2, 0])
                {
                    //Now check if the percentage correct is greater than 50% to stop spamers
                    if (newScores[0, 0] / newScores[0, 1] > 0.5f)
                    {
                        Scores[2, 0] = newScores[0, 0];
                        Scores[2, 1] = newScores[0, 1];
                        ClearNewScores();

                    }
                    else
                    {
                        Debug.Log("no Change");
                        ClearNewScores();
                    }
                }
                else
                {
                    Debug.Log("no Change");
                    ClearNewScores();

                }
            }
        }
        else
        {
            // does nothing due to not a valid level
            Debug.Log("Input Scoring gameobject not valid");
        }
    }

    void ClearNewScores()
    {
        newScores[0, 0] = 0;
        newScores[0, 1] = 0;
    }
}
