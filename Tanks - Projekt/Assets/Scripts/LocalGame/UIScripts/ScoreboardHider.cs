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

    public bool showScoreboard;
    public bool showScoreboardBtn;

    //makes sure the scoreboard is hidden when starting lobby
    void Start()
    {
        if (scoreboard)
        {
            panelAnim.Play("PanelEnd");
            scoreboardAnim.Play("ScoreboardEnd");
        }
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
        RevertBool(showScoreboard, showScoreboardBtn);
    }

    //plays animation that closes scoreboard
    public void Resume()
    {
        panelAnim.Play("PanelEnd");
        scoreboardAnim.Play("ScoreboardEnd");
        //Time.timeScale = 1f;
        RevertBool(showScoreboard, showScoreboardBtn);
    }

    //reverses some bools
    public void RevertBool(bool bool1, bool bool2)
    {
        showScoreboard = !bool1;
        showScoreboardBtn = !bool2;
    }
}
