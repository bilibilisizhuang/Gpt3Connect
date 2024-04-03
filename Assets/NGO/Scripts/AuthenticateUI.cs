using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using TMPro;
using UnityEngine.UI;


public class AuthenticateUI : MonoBehaviour {

    [SerializeField] private Button authenticateBtn;

    [SerializeField] private TMP_InputField playerNameInputField;

    private void Start() {
        authenticateBtn.onClick.AddListener(() => { Authenticate(); });
    }
    public async void Authenticate() {
        InitializationOptions options = new InitializationOptions();
        options.SetProfile(playerNameInputField.text);
        await UnityServices.InitializeAsync();
        Debug.Log("inited service");

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        Debug.Log("PlayerId: " + AuthenticationService.Instance.PlayerId);
        gameObject.SetActive(false);
    }
}