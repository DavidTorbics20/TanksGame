using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DataSaver : MonoBehaviour
{
    public SceneTransition sceneTransition;

    public Text filepathGUI;

    public static string dbName;
    private string filepath;

    void Start() 
    {
        filepath = "URI=file:" + Application.dataPath + "/" + dbName + ".db";
        //filepathGUI.text = filepath;
    }

    public void SaveData()
    {
        if (!File.Exists(Application.dataPath + "/" + dbName))
        {
            SqliteConnection.CreateFile(Application.dataPath + "/" + dbName);
            CreateDB();
        }
        AddScore();

        sceneTransition.LoadScene("LocalGameLobby");
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "create table if not exists localgamescore (PK integer," +
                    "P1Name text, " +
                    "P1Score integer, " +
                    "Time text, " +
                    "P2Score integer, " +
                    "P2Name text, " +
                    "primary key('PK'));";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    private void AddScore()
    {
        string p1Name = PlayerPrefs.GetString("playerOneName");
        int p1Score = PlayerPrefs.GetInt("playerOneScore");
        string time = PlayerPrefs.GetString("timePlayed");
        string p2Name = PlayerPrefs.GetString("playerTwoName");
        int p2Score = PlayerPrefs.GetInt("playerTwoScore");

        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into localgamescore (" +
                    "P1Name, " +
                    "P1Score, " +
                    "Time, " +
                    "P2Score, " +
                    "P2Name) values " +
                    "('" + p1Name + "', " +
                    "'" + p1Score + "', " +
                    "'" +  time + "', " +
                    "'" + p2Score + "', " +
                    "'" + p2Name + "');";  
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
