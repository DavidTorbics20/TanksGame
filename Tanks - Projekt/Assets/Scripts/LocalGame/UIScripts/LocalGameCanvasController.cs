using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocalGameCanvasController : MonoBehaviour
{
    public SceneTransition sceneTransition; 
    public GameObject Canvas1;

    public Text inputOne;
    public Text inputTwo;
    public Text warningOne;
    public Text warningTwo;

    public void Start()
    {
        Canvas1.SetActive(true);
    }

    public void PressToPlay()
    {
        //looks if name-input-field is empty / if not start game 
        if (!string.IsNullOrEmpty(inputOne.text) && !string.IsNullOrEmpty(inputTwo.text))
        {
            warningOne.gameObject.SetActive(false);
            warningTwo.gameObject.SetActive(false);
        }

        bool succ = true;

        if (string.IsNullOrEmpty(inputOne.text))
        {
            succ = false;
            warningOne.text = "You need to enter a name";
            warningOne.gameObject.SetActive(true);
        }else{
            warningOne.gameObject.SetActive(false);
        }
        if (string.IsNullOrEmpty(inputTwo.text)){
            succ = false;
            warningTwo.text = "You need to enter a name";
            warningTwo.gameObject.SetActive(true);
        }else{
            warningTwo.gameObject.SetActive(false);
        }

        if (succ)
        {
            sceneTransition.LoadScene("LocalGame");
            float startTime = 0f;
            PlayerPrefs.SetFloat("startTime", startTime);
        }
    }
}
