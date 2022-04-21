using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public Text playerOneName;
    public Text playerTwoName;
    public Text playerOneScore;
    public Text playerTwoScore;

    public Image playerOneSprite;
    public Image playerTwoSprite;
    public Sprite[] sprites;

    public new Animator animation;
    private bool gameIsPaused = false;

    void Start()
    {
        canvas2.SetActive(false);
        playerOneName.text = PlayerPrefs.GetString("playerOneName");
        playerTwoName.text = PlayerPrefs.GetString("playerTwoName");
        playerOneSprite.sprite = sprites[PlayerPrefs.GetInt("playerOneSprite")];
        playerTwoSprite.sprite = sprites[PlayerPrefs.GetInt("playerTwoSprite")];
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
        canvas2.SetActive(true);
        //Time.timeScale = 0f;
        gameIsPaused = true;
        GameTime.isPaused = true;
    }

    public void Resume()
    {
        canvas2.SetActive(false);
        //Time.timeScale = 1f;
        gameIsPaused = false;
        GameTime.isPaused = false;
    }
}
