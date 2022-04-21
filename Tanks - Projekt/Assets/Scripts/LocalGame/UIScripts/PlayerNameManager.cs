using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public string[] playerName;
    public string[] saveName;

    public Text[] inputText;
    public Text[] loadName;

    public void SaveNames()
    {
        playerName[0] = (PlayerPrefs.GetString("name1", "none"));
        PlayerPrefs.SetString("playerOneName", inputText[0].text);
        playerName[1] = PlayerPrefs.GetString("name2", "none");
        PlayerPrefs.SetString("playerTwoName", inputText[1].text);
    }
}
