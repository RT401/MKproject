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
    public float maxTimer = 15;
    public float currentTimer;

    // Timer spawn location
    public Text displayedTimer;

    // Current level spawner
    Spawner currentSpawner;

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

        if(currentTimer <= 0)
        {
            Spawner[] spawner = FindObjectsOfType<Spawner>();

            foreach(Spawner sp in spawner)
            {
                if(sp.isActiveAndEnabled == true)
                {
                    currentSpawner = sp;
                }
            }
            
            // stop gameplay loop and display endscreen
            currentSpawner.EndOfGame();
        }
    }

    public void DisplayTimer()
    {
        displayedTimer.text = currentTimer.ToString("00" + " Seconds");
    }

    public void ActivateTimer(Text thisTimer, bool insertedBool)
    {
        displayedTimer = thisTimer;
        displayTimer = insertedBool;
        timerRunning = insertedBool;
        displayedTimer.gameObject.SetActive(insertedBool);
        currentTimer = maxTimer;
    }
}
