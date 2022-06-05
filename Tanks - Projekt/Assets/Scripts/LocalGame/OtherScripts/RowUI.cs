using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//RowUI is a preset for the ScoreboardManager.cs to insert values from the database
//it gets cloned and inserted new values into
public class RowUI : MonoBehaviour
{
    public Text p1Name;
    public Text p1Score;
    public Text time;
    public Text p2Score;
    public Text p2Name;
    public Image image;

    //gets the Image component to set the background of the row in the scoreboard
    void Start()
    {
        image.GetComponent<Image>();
    }
}
