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
    private List<string> p2Names = new List<string>();

    private string filepath;
    public string dbName = "LocalGameScore";

    void Awake()
    {
        dbName = "LocalGameScore";
        filepath = "URI=file:" + Application.dataPath + "/" + dbName + ".db";

        CreateDB();
        GetNames();
        DisplayNames();

        //p1Names.Clear();
        //p2Names.Clear();
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

    private void GetNames()
    {
        using (var connection = new SqliteConnection(filepath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select distinct P1Name, P2Name from " + dbName.ToLower() + ";";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.Log("P1: " + reader["P1Name"] + "\t|| P2: " + reader["P2Name"]);
                        p1Names.Add(reader["P1Name"].ToString());
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
            row.p1Name.text = p1Names[i].ToString();
            row.p2Name.text = p2Names[i].ToString();
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
