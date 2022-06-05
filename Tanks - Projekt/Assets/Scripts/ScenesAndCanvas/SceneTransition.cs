using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//SceneTransition is responsible for a cool scene transition effect
public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    public float delay = 3f;

    //inside the editor I give it a scene name 
    //this scene will then be loaded
    public void LoadScene(string sceneName)
    {
        //Debug.Log("Active Self: " + this.gameObject.activeSelf);
        //Debug.Log("Active in Hierarchy" + this.gameObject.activeInHierarchy);
        StartCoroutine(LoadLevel(sceneName));
    }

    //starts the animation
    //after animation has ended changes scene
    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    //only in main menu
    //if the gascan is pressed the player quits the game
    //why a gascan? because it indicates that you have to go recharge
    public void ExitGame()
    {
        Application.Quit();
    }
}
