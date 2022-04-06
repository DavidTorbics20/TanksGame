﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaverPrototype : MonoBehaviour
{
    public SceneTransition sceneTransition;

    public static string P1Name;
    public static string P2Name;
    public static int P1Score;
    public static int P2Score;

    public void PrintData()
    {
        Debug.Log("" + P1Name + ": " + P1Score + " | " + P2Name + ": " + P2Score);
        sceneTransition.LoadScene("LocalGameLobby");
    }
}
