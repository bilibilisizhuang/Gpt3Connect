using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.Netcode;

public class SelectModeUI : MonoBehaviour {

    [SerializeField] private Button startHost;
    [SerializeField] private Button startServer;
    [SerializeField] private Button startClient;


    private void Start() {
        startClient.onClick.AddListener(() => { GetComponent<NetworkManager>().StartClient(); });
        startHost.onClick.AddListener(() => { GetComponent<NetworkManager>().StartHost(); });
        startServer.onClick.AddListener(() => { GetComponent<NetworkManager>().StartServer(); });
    }




}