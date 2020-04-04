using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private float startTime;
    private GManager gManager;

    bool started = false;
    bool worldStarted = false;

    
    private float worldStartTime;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GManager>();
    }

    public void InitializeTimer()
    {
        startTime = Time.time;
        started = true;
    }

    public void InitializeWorldTimer()
    {
        worldStartTime = Time.time;
        worldStarted = true;
    }

    void Update()
    {
        if (started == true)
        {
            gManager.Time = Time.time - startTime;
        }
        if (worldStarted == true)
        {
            gManager.WorldTime = Time.time - worldStartTime;
        }

        int seconds = (int)(gManager.Time % 60);
        int minutes = (int)(gManager.Time / 60) % 60;
        int hours = (int)(gManager.Time / 3600) % 24;

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
