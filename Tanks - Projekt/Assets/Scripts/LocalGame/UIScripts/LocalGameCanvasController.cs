using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LocalGameCanvasController : MonoBehaviour
{
    private MazeManager mazeManager;
    public PlayerSpawner playerSpawner;

    public GameObject pauseMenuCanvas;
    public GameObject Canvas1;
    public GameObject Canvas2;

    public Text inputOne;
    public Text inputTwo;
    public Text warningOne;
    public Text warningTwo;

    public Animator animation;

    private bool gameIsPaused = false;

    public void Start()
    {
        mazeManager = GetComponent<MazeManager>();

        Canvas1.SetActive(true);
        Canvas2.SetActive(false);
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused)
        {
            Resume();
        }
    }

    public void SwitchCavas()
    {
        //looks if name-input-field is empty / if not start game 
        if (!string.IsNullOrEmpty(inputOne.text) && !string.IsNullOrEmpty(inputTwo.text))
        {
            Canvas1.SetActive(!Canvas1.activeSelf);
            Canvas2.SetActive(!Canvas2.activeSelf);
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
            mazeManager.StartGenerating();
            playerSpawner.SpawnPlayers();
        }
    }

    public void Pause()
    {
        animation.Play("PauseMenuStart");
        pauseMenuCanvas.SetActive(true);
        //Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        //Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
