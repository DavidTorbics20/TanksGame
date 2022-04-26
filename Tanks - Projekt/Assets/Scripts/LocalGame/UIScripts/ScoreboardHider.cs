using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardHider : MonoBehaviour
{
    public GameObject scoreboard;

    public Animator scoreboardAnim;
    public Animator panelAnim;

    private bool showScoreboard;
    private bool showScoreboardBtn;

    void Start()
    {
        panelAnim.Play("PanelEnd");
        scoreboardAnim.Play("ScoreboardEnd");
        //scoreboard.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !showScoreboard)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && showScoreboard)
        {
            Resume();
        }
    }

    public void SetToTrue()
    {
        if (!showScoreboardBtn)
        {
            Pause();
        }
        else if (showScoreboardBtn)
        {
            Resume();
        }
    }

    public void Pause()
    {
        //scoreboard.SetActive(true);
        panelAnim.Play("PanelStart");
        scoreboardAnim.Play("ScoreboardStart");
        //Time.timeScale = 0f;
        showScoreboard = true;
        showScoreboardBtn = true;
    }

    public void Resume()
    {
        panelAnim.Play("PanelEnd");
        scoreboardAnim.Play("ScoreboardEnd");
        //Time.timeScale = 1f;
        showScoreboard = false;
        showScoreboardBtn = false;
    }
}
