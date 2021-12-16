using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    /// <summary>
    /// required variables
    /// 3 floats to store difficulty best scores
    /// refernce to scoreHolder, difficultys, ClickOn fucntion
    /// </summary>
    public float easy = 0f;
    public float normal = 0f;
    public float hard = 0f;

    public void DisplayScores()
    { }
    public void LevelComplete(GameObject go)
    {
        /// compare gameobject referenced to stored scores
        /// check if score is lower or higher, update score if higher
    }

    void CheckScores(float prevScore, float newScore)
    { 
    
    }
}
