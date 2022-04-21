using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

public class ScoreboardManager : MonoBehaviour
{
    public RowUI rowUI;

    private List<string> p1Names = new List<string>();
    private List<string> p1Scores = new List<string>();
    private List<string> times = new List<string>();
    private List<string> p2Scores = new List<string>();
    private List<string> p2Names = new List<string>();

    private string filepath;
    public static readonly string dbName = "LocalGameScore";

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
