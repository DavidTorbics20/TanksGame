using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

//reads the .db file that has been created and prints the values into a table
//the table rows consist of multiple RowUI.cs elements 
//the values from the .db file are read and printed into the variables of RowUI.cs
public class ScoreboardManager : MonoBehaviour
{
    public RowUI rowUI;

    //these lists contain every name, score and playtime that is in the database
    private List<string> p1Names = new List<string>();
    private List<string> p1Scores = new List<string>();
    private List<string> times = new List<string>();
    private List<string> p2Scores = new List<string>();
    private List<string> p2Names = new List<string>();

    private string filepath;
    public static readonly string dbName = "LocalGameScore";

    //creates a .db file if one doesn't exist
    //if one exists it gets and prints the values 
    void Start()
    {
        filepath = "URI=file:" + Application.dataPath + "/" + dbName + ".db";

        if (!File.Exists(Application.dataPath + "/" + dbName))
        {
            SqliteConnection.CreateFile(Application.dataPath + "/" + dbName);
            CreateDB();
        }

        GetNames();
        DisplayNames();

    }

    //creates a table if one doesn't exist with some columns
    private void CreateDB()
    {
        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "create table if not exists " + dbName.ToLower() + " " +
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

    //creates a connection to the db
    //then selects everything from the .db file
    //while going through every line it reads it and inserts it into the lists created above
    private void GetNames()
    {
        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from " + dbName.ToLower() + ";";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        p1Names.Add(reader["P1Name"].ToString());
                        p1Scores.Add(reader["P1Score"].ToString());
                        times.Add(reader["Time"].ToString());
                        p2Scores.Add(reader["P2Score"].ToString());
                        p2Names.Add(reader["P2Name"].ToString());
                    }
                    reader.Close();
                }
            }
            connection.Clone();
        }
    }

    //for every row in the .db file a row is instantiated 
    //the values previously then are put into the fields of RowUI
    //the list has to be reversed to displayed the games in order
    //of the time is was played (the newer the higher up)
    private void DisplayNames()
    {
        for (int i = 0; i < p1Names.Count; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.p1Name.text = p1Names[p1Names.Count - 1 - i].ToString();
            row.p1Score.text = p1Scores[p1Names.Count - 1 - i].ToString();
            row.time.text = times[p1Names.Count - 1 - i].ToString();
            row.p2Score.text = p2Scores[p1Names.Count - 1 - i].ToString();
            row.p2Name.text = p2Names[p1Names.Count - 1 - i].ToString();

            //to make the rows in the scoreboard stand out more the background
            //igame changes every two rows to a slightly darker color
            if (i % 2 == 0)
            {
                row.image.color = new Color(1, 1, 1);
            }
            else
            {
                row.image.color = new Color(0.955f, 0.955f, 0.955f);
            }
        }
    }
}
