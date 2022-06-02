using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror;

public class CustomNetworkMenu : MonoBehaviour
{
    //public GameObject[] playerPrefabs;

    public Text ipServer;
    public Text portServer;

    // use this instead of assigning the functions to the buttons
    //public void ButtonSetup()
    //{
    //    GameObject.Find("CreateButton").GetComponent<Button>().onClick.RemoveAllListeners();
    //    GameObject.Find("CreateButton").GetComponent<Button>().onClick.AddListener(StartServer);
    //}

    void Start()
    {
        //portServer.text = "7777";
    }

    public void StartServer()
    {
        NetworkManager.singleton.StartHost();
    }

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

    public void DisconnectButton()
    {
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("DisconnectButton").GetComponent<Button>().onClick.AddListener(Disconnect);
    }

    public void Disconnect()
    {
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
    }
}
