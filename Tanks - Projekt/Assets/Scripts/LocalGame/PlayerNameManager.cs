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

    void Update()
    {
        playerName[0] = (PlayerPrefs.GetString("name1", "none"));
        loadName[0].text = playerName[0];
        playerName[1] = PlayerPrefs.GetString("name2", "none");
        loadName[1].text = playerName[1];
    }

    public void SaveNames()
    {
        saveName[0] = inputText[0].text;
        PlayerPrefs.SetString("name1", saveName[0]);

        saveName[1] = inputText[1].text;
        PlayerPrefs.SetString("name2", saveName[1]);
    }
}
