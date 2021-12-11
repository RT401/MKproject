using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // make timer appear & run
    public bool displayTimer = false;
    public bool timerRunning = false;

    // Timer values
    public float maxTimer = 60;
    public float currentTimer;

    // Timer spawn location
    public Text displayedTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentTimer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayTimer == true)
            DisplayTimer();

        if (timerRunning == true)
            currentTimer -= Time.deltaTime;
    }

    public void DisplayTimer()
    {
        displayedTimer.text = currentTimer.ToString("ss");
    }
}
