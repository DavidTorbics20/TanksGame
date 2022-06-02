using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

//every time I add values to the table a connection is created and then closed
public class DataSaver : MonoBehaviour
{
    public SceneTransition sceneTransition;

    public Text filepathGUI;

    private string dbName;
    private string filepath;

    //gets the name of the database 
    //optionally outputs the file path 
    void Start() 
    {
        dbName = ScoreboardManager.dbName;
        Debug.Log(dbName);
        filepath = "URI=file:" + Application.dataPath + "/" + dbName + ".db";
        //filepathGUI.text = filepath;
    }

    //check if a .db file exists 
    //if no --> creates one if yes --> adds values to existing file
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

    //creates a table if one doesn't exist with some columns
    private void CreateDB()
    {
        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "create table if not exists " + dbName.ToLower() + 
                    "(PK integer," +
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

    //reads game values from Unitys PlayerPrefs
    //then insert these values into the table 
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
                command.CommandText = "insert into " + dbName.ToLower() + " (" +
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
