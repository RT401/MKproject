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
    [SerializeField]
    public float?[,] Scores;
    
    /// <summary>
    /// stored as 
    ///     0   1
    /// 0   a   b
    /// 
    /// key
    /// A = amount correct
    /// b = amount completed
    /// </summary>
    [SerializeField]
    public float[,] newScores;

    private void Start()
    {
        SH = FindObjectOfType<ScoreHolder>();
        Scores = new float?[3, 2];
    }             

    public void UpdateDisplayScores(string name)
    {
        if (name == "Easy" && easyText != null && Scores[0,0] != 0)
        {
            easyText.text = (Scores[0, 0].ToString() + " / " + Scores[0, 1].ToString()); 
        }


        if (name == "Normal" && normalText != null && Scores[1, 0] != 0)
        {
            normalText.text = (Scores[1, 0].ToString() + " / " + Scores[1, 1].ToString());
        }


        if (name == "Hard" && hardText != null && Scores[2, 0] != 0)
        {
            hardText.text = (Scores[2, 0].ToString() + " / " + Scores[2, 1].ToString());
        }
    }

    public void LevelComplete(Spawner spwner)
    {

        string tempName = spwner.gameObject.name;
        /// compare gameobject referenced to stored scores

        /// check if score is lower or higher, update score if higher and better correct rate
        CheckScores(tempName);

        /// Dispay Scores on menu
        UpdateDisplayScores(tempName);
    }

    void CheckScores(string name)
    {
        /*
        /// Scoped back for first lot of major tests, will expand if time permits 
        if (name == "Easy")
        {
            Scores[0, 0] = newScores[0, 0];
            Scores[0, 1] = newScores[0, 1];
            ClearNewScores();
        }
        else if (name == "Normal")
        {
            Scores[1, 0] = newScores[0, 0];
            Scores[1, 1] = newScores[0, 1];
            ClearNewScores();
        }
        else if (name == "Hard")
        {
            Scores[2, 0] = newScores[0, 0];
            Scores[2, 1] = newScores[0, 1];
            ClearNewScores();
        }
        */

        
        //check the name of the gameobect to decide which score to check
        if (name == "Easy")
        {
            // checks if the array is either null or 0's
            if (Scores[0,0] == null && Scores[0, 1] == null || Scores[0, 0] == 0 && Scores[0, 1] == 0 )
            {
                Scores[0, 0] = newScores[0, 0];
                Scores[0, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the new scores amount completed then amount correct was higher than the old scores
                // first checks if the new amount correct is greater than old amount correct
                // if that is true and the amount completed is higher or the same then will go into this if statement
                if (newScores[0, 0] > Scores[0, 0] && newScores[0, 1] >= Scores[0, 1])
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
        /*
        else if (name == "Normal")
        {
            if (Scores[1, 0] == 0 && Scores[0, 1] == 0)
            {
                Scores[1, 0] = newScores[0, 0];
                Scores[1, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the amout scored is better or worse
                if (newScores[0, 0] > Scores[1, 0])
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
        else if (name == "Hard")
        {
            if (Scores[2,0] == 0 && Scores[0, 1] == 0)
            {
                Scores[2, 0] = newScores[0, 0];
                Scores[2, 1] = newScores[0, 1];
                ClearNewScores();
            }
            else
            {
                //check if the amout scored is better or worse
                if (newScores[0, 0] > Scores[2, 0])
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
        */
    }

    void ClearNewScores()
    {
        newScores[0, 0] = 0;
        newScores[0, 1] = 0;
    }
}
