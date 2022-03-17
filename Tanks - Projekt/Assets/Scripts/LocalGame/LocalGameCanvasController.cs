using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameCanvasController : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;
    // Use this for initialization
    void Start()
    {
        Canvas1.SetActive(true);
        Canvas1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Simulate an event the canvas needs to be switched
        if (Input.GetKeyDown(KeyCode.S))
        {
            Canvas1.SetActive(!Canvas1.activeSelf);
            Canvas2.SetActive(!Canvas2.activeSelf);
        }
    }
}
