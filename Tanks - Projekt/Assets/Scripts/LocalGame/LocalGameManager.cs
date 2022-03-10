using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour
{
    public Canvas[] canvas;

    private int canvasCount;
    private int currentCanvas;

    void Start()
    {
        canvasCount = canvas.Length;
    }


    void Update()
    {
        Debug.Log(canvasCount);
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SwitchCanvas();
        }
    }

    private void SwitchCanvas()
    {
        if (currentCanvas == 0){
            canvas[currentCanvas].enabled = true;
            currentCanvas += 1;
        }if (currentCanvas == 1){
            canvas[currentCanvas].enabled = true;
            currentCanvas -= 1;
        }
    }
}
