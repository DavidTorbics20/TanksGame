using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//displayes the score for player 1
public class PlayerOneScore : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    //get the score from PlayerPrefs
    //connects to the UI element
    void Start()
    {
        PlayerPrefs.SetInt("playerOneScore", scoreValue);
        score = GetComponent<Text>();
    }

    //sets the UI element to the value
    void Update()
    {
        score.text = "Score : " + scoreValue;
    }
}
