using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//hides and shows the scoreboard
public class ScoreboardHider : MonoBehaviour
{
    public GameObject scoreboard;

    public Animator scoreboardAnim;
    public Animator panelAnim;

    private bool showScoreboard;
    private bool showScoreboardBtn;

    //makes sure the scoreboard is hidden when starting lobby
    void Start()
    {
        panelAnim.Play("PanelEnd");
        scoreboardAnim.Play("ScoreboardEnd");
        //scoreboard.SetActive(false);
    }

    //by pressing TAB the scoreboard appears or disappears
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

    //reverses scoreboard state
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

    //plays animation that opens scoreboard
    public void Pause()
    {
        //scoreboard.SetActive(true);
        panelAnim.Play("PanelStart");
        scoreboardAnim.Play("ScoreboardStart");
        //Time.timeScale = 0f;
        showScoreboard = true;
        showScoreboardBtn = true;
    }

    //plays animation that closes scoreboard
    public void Resume()
    {
        panelAnim.Play("PanelEnd");
        scoreboardAnim.Play("ScoreboardEnd");
        //Time.timeScale = 1f;
        showScoreboard = false;
        showScoreboardBtn = false;
    }
}
