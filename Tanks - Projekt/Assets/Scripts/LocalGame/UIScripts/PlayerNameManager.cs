using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Saves and displays the names the players entered
public class PlayerNameManager : MonoBehaviour
{
    public string[] playerName;
    public string[] saveName;

    public Text[] inputText;
    public Text[] loadName;

    //saves both names into a list and into PlayerPrefs
    public void SaveNames()
    {
        playerName[0] = (PlayerPrefs.GetString("name1", "none"));
        PlayerPrefs.SetString("playerOneName", inputText[0].text);
        playerName[1] = PlayerPrefs.GetString("name2", "none");
        PlayerPrefs.SetString("playerTwoName", inputText[1].text);
    }
}
