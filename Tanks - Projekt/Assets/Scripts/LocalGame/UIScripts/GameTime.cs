using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//shows the time for how long you have been playing a round
public class GameTime : MonoBehaviour
{
    Text timeText;

    private float elapsedTime;
    public static bool isPaused;

    //gets the Text element 
    //start counting time
    void Start()
    {
        isPaused = false;
        timeText = GameObject.Find("Time").GetComponent<Text>();
        elapsedTime = PlayerPrefs.GetFloat("startTime");
    }

    //if the game is paused, the timer is paused...duh
    void Update()
    {
        if (!isPaused)
        {
            PrintTime();
        }
    }

    //saves the played time into timeText textcomponent
    //then saves the time as a float and string in PlayerPrefs
    public void PrintTime()
    {
        elapsedTime += Time.deltaTime;
        var timeSpan = System.TimeSpan.FromSeconds(elapsedTime);
        timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        PlayerPrefs.SetFloat("startTime", elapsedTime);
        PlayerPrefs.SetString("timePlayed", timeText.text);
    }
}
