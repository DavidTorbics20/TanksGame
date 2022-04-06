using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        PlayerPrefs.SetInt("playerOneScore", scoreValue);
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score : " + scoreValue;
        DataSaverPrototype.P1Score = scoreValue;
    }
}
