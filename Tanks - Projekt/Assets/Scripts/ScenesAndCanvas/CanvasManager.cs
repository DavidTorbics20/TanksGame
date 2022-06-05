using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//tried doing something I saw in a video 
//stopped right after that
//I think it holds all the canvases
public enum CanvasNames
{
    MainMenu
}

//cicles through the list or something like that
//don't ask me I didn't make this
public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllersList;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        var canvasControllersList = GetComponentsInChildren<CanvasController>();
    }
}
