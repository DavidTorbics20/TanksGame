using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    void Start()
    {
        PlayerPrefs.SetInt("playerTwoScore", scoreValue);
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score : " + scoreValue;
    }
}
