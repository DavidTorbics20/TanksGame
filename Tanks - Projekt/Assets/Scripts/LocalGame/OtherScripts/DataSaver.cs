using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public SceneTransition sceneTransition;

    private string dbName = "URI=file:D:/LocalGameScore.db";

    public void SaveData()
    {
        CreateDB();
        AddScore();

        sceneTransition.LoadScene("LocalGameLobby");
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
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

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into localgamescore (P1Name, " +
                    "P1Score, " +
                    "Time, " +
                    "P2Score, " +
                    "P2Name) values " +
                    "('" + p1Name + "', '" + 
                     p1Score + "', '" + 
                     time + "', '" + 
                     p2Score + "', '" + 
                     p2Name + "');";  
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
