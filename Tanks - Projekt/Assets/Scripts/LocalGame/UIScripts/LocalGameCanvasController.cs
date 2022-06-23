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
        //Canvas1.SetActive(true);
    }

    //starts the game if no inputfield is empty
    public void PressToPlay()
    {
        //if both names are filled in the game transition to LocalGame scene
        //(the actual game)
        if (CheckIfFilled(inputOne.text, inputTwo.text))
        {
            sceneTransition.LoadScene("LocalGame");
            PlayerPrefs.SetFloat("startTime", 0f);
            PlayerOneScore.scoreValue = 0;
            PlayerTwoScore.scoreValue = 0;
        }
    }

    //looks if name-input-field is empty 
    //returns a bool "succ"
    public bool CheckIfFilled(string nameOne, string nameTwo)
    {
        //nameOne = inputOne.text;
        //nameTwo = inputTwo.text;

        if (!string.IsNullOrEmpty(nameOne) && !string.IsNullOrEmpty(nameTwo))
        {
            if (warningOne)
            {
                warningOne.gameObject.SetActive(false);
                warningTwo.gameObject.SetActive(false);
            }
        }

        bool succ = true;

        if (string.IsNullOrEmpty(nameOne))
        {
            succ = false;
            warningOne.text = "You need to enter a name";
            warningOne.gameObject.SetActive(true);
        }else{
            if (warningOne)
            {
                warningOne.gameObject.SetActive(false);
            }
        }
        if (string.IsNullOrEmpty(nameTwo)){
            succ = false;
            warningTwo.text = "You need to enter a name";
            warningTwo.gameObject.SetActive(true);
        }else{
            if (warningTwo) 
            { 
                warningTwo.gameObject.SetActive(false);
            }
        }

        return succ;
    }
}
