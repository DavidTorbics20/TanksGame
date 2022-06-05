using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//displayes the score for player 2
public class PlayerTwoScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    //get the score from PlayerPrefs
    //connects to the UI element
    void Start()
    {
        PlayerPrefs.SetInt("playerTwoScore", scoreValue);
        score = GetComponent<Text>();
    }

    //sets the UI element to the value
    void Update()
    {
        score.text = "Score : " + scoreValue;
    }
}
