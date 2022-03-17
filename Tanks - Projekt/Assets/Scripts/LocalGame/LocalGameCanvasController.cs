using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalGameCanvasController : MonoBehaviour
{
    public GameObject Canvas1;
    public GameObject Canvas2;

    public Text inputOne;
    public Text inputTwo;
    public Text warningOne;
    public Text warningTwo;

    void Start()
    {
        Canvas1.SetActive(true);
        Canvas2.SetActive(false);
    }

    public void SwitchCavas()
    {
        //Simulate an event the canvas needs to be switched
        if (!string.IsNullOrEmpty(inputOne.text) && !string.IsNullOrEmpty(inputTwo.text))
        {
            Canvas1.SetActive(!Canvas1.activeSelf);
            Canvas2.SetActive(!Canvas2.activeSelf);
            warningOne.gameObject.SetActive(false);
            warningTwo.gameObject.SetActive(false);
        }

        if (string.IsNullOrEmpty(inputOne.text))
        {
            warningOne.text = "You need to enter a name";
            warningOne.gameObject.SetActive(true);
        }else{
            warningOne.gameObject.SetActive(false);
        }
        if (string.IsNullOrEmpty(inputTwo.text)){
            warningTwo.text = "You need to enter a name";
            warningTwo.gameObject.SetActive(true);
        }else{
            warningTwo.gameObject.SetActive(false);
        }
    }
}
