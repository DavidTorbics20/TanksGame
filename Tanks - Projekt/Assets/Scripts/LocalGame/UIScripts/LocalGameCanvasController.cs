using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//the name should be more like InputChecker
//doesn't let you start the game if a name input field is empty
public class LocalGameCanvasController : MonoBehaviour
{
    public SceneTransition sceneTransition; 
    public GameObject Canvas1;

    public Text inputOne;
    public Text inputTwo;
    public Text warningOne;
    public Text warningTwo;

    //sets Canvas1 to true 
    //which is outdated because I now manage the scoreboard in a different way
    public void Start()
    {
        Canvas1.SetActive(true);
    }

    //looks if name-input-field is empty 
    // if not start game 
    public void PressToPlay()
    {
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
            PlayerPrefs.SetFloat("startTime", 0f);
            PlayerOneScore.scoreValue = 0;
            PlayerTwoScore.scoreValue = 0;
        }
    }
}
