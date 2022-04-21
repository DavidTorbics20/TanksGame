using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardHider : MonoBehaviour
{
    public GameObject scoreboard;

    public new Animator animation;

    private bool gameIsPaused;

    void Start()
    {
        scoreboard.SetActive(false);
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

    public void Pause()
    {
        animation.Play("PauseMenuStart");
        scoreboard.SetActive(true);
        //Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        scoreboard.SetActive(false);
        //Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
