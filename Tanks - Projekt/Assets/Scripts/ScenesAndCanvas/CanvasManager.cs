using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasNames
{
    MainMenu
}

public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllersList;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        var canvasControllersList = GetComponentsInChildren<CanvasController>();
    }
}
