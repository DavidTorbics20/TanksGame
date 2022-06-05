using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//manages the UI elements in LocalGame
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

    //sets the player names into the player name fields
    //sets the sprite of the spinning image to player sprite
    void Start()
    {
        animation.Play("PanelEnd");
        GameTime.isPaused = false;
        canvas2.SetActive(false);
        playerOneName.text = PlayerPrefs.GetString("playerOneName");
        playerTwoName.text = PlayerPrefs.GetString("playerTwoName");
        playerOneSprite.sprite = sprites[PlayerPrefs.GetInt("playerOneSprite")];
        playerTwoSprite.sprite = sprites[PlayerPrefs.GetInt("playerTwoSprite")];
    }

    //if ESCAPE is pressed a menu popps up
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

    //shows pause menu
    public void Pause()
    {
        animation.Play("PanelStart");
        canvas2.SetActive(true);
        //Time.timeScale = 0f;
        gameIsPaused = true;
        GameTime.isPaused = true;
    }

    //hides pause menu
    public void Resume()
    {
        animation.Play("PanelEnd");
        canvas2.SetActive(false);
        //Time.timeScale = 1f;
        gameIsPaused = false;
        GameTime.isPaused = false;
    }
}
