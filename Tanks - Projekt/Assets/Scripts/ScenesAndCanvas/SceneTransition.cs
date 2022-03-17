using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    public float delay = 3f;

    public void LoadScene(string sceneName)
    {
        //Debug.Log("Active Self: " + this.gameObject.activeSelf);
        //Debug.Log("Active in Hierarchy" + this.gameObject.activeInHierarchy);
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
