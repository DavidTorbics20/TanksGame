using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror;

//Mirror provides us with some premade NetworkUI elements 
//I needed something else so I made this
//the buttons on the OnlineGameLobby canvas are bound to the functions in here
public class CustomNetworkMenu : MonoBehaviour
{
    //public GameObject[] playerPrefabs;

    //input fields for the IP address and port of the host
    public Text ipServer;
    public Text portServer;

    // use this instead of assigning the functions to the buttons
    //public void ButtonSetup()
    //{
    //    GameObject.Find("CreateButton").GetComponent<Button>().onClick.RemoveAllListeners();
    //    GameObject.Find("CreateButton").GetComponent<Button>().onClick.AddListener(StartServer);
    //}

    //sets port so something static
    void Start()
    {
        //portServer.text = "7777";
    }

    //gets called if you host game
    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
    }

    //joins someone through their IP and port
    public void JoinServer()
    {
        string ip = ipServer.text;
        string port = portServer.text;
        if (ip.Length > 0 && port.Length > 0)
        {
            NetworkManager.singleton.networkAddress = ip;
            ushort x;
            ushort.TryParse(port, out x);
            kcp2k.KcpTransport.inputPort = x;
            NetworkManager.singleton.StartClient();
        }
    }

    //Binds function to the Disconnect button
    public void DisconnectButton()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(Disconnect);
    }

    //stops connection to server
    //stops server if you are host
    public void Disconnect()
    {
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
    }
}
