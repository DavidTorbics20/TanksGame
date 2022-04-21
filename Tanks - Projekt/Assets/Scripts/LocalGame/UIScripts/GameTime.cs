using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    Text timeText;

    private float elapsedTime;
    public static bool isPaused;

    void Start()
    {
        timeText = GameObject.Find("Time").GetComponent<Text>();
        elapsedTime = PlayerPrefs.GetFloat("startTime");
    }

    void Update()
    {
        if (!isPaused)
        {
            PrintTime();
        }
    }

    public void PrintTime()
    {
        elapsedTime += Time.deltaTime;
        var timeSpan = System.TimeSpan.FromSeconds(elapsedTime);
        timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        PlayerPrefs.SetFloat("startTime", elapsedTime);
        PlayerPrefs.SetString("timePlayed", timeText.text);
    }
}
