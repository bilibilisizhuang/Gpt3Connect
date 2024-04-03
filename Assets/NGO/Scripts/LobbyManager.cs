using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Relay;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using System;

public class LobbyManager : MonoBehaviour {
    private Lobby joinedLobby;
    private float UpdatePlayersTimer;
    private float lobbyHeartBeatTimer;
    private bool isCreatedLobby;
    private void Update() {
        HandleHeartBeat();
        UpdateLobbyPlayers();
    }

    private async void HandleHeartBeat() {
        try {
            if (isCreatedLobby) {
                lobbyHeartBeatTimer += Time.deltaTime;
                if (lobbyHeartBeatTimer > 15) {
                    lobbyHeartBeatTimer = 0;
                    await LobbyService.Instance.SendHeartbeatPingAsync(joinedLobby.Id);
                }
            }
        }catch (LobbyServiceException e) {
            Debug.LogException(e);
        }
    }

    private async void UpdateLobbyPlayers() {
        if (joinedLobby != null) {
            UpdatePlayersTimer -= Time.deltaTime;
            if (UpdatePlayersTimer < 0) {
                UpdatePlayersTimer = 1.2f;
                joinedLobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);

            }
        }
    }


    [Command]
    private async void CreateLobby() {
        try {
            string lobbyName = "MyLobby";
            int maxPlayers = 4;
            CreateLobbyOptions options = new CreateLobbyOptions();
            options.IsPrivate = false;
            options.Player = new Player(AuthenticationService.Instance.PlayerId);
            options.Data = new Dictionary<string, DataObject>() {
                {"GameMode", new DataObject(DataObject.VisibilityOptions.Public) },
                {"Map", new DataObject(DataObject.VisibilityOptions.Member) }
            };
            joinedLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
            isCreatedLobby = true;
            Debug.Log("code: "+ joinedLobby.LobbyCode +" ; id : "+ joinedLobby.Id); 

        }catch(LobbyServiceException e) {
            Debug.LogError(e);
        }
    }
    [Command]
    private async void JoinLobbyByCode(string code) {
        try {
            joinedLobby = await LobbyService.Instance.JoinLobbyByCodeAsync(code);

            Debug.Log("joined Lobby Id: " + joinedLobby.Id);
        }catch (LobbyServiceException e) {
            Debug.LogError(e);
        }
    }
    [Command]
    private async void JoinLobby() {
        try {
            QueryResponse respon = await LobbyService.Instance.QueryLobbiesAsync();

            joinedLobby = await LobbyService.Instance.JoinLobbyByIdAsync(respon.Results[0].Id);

        }catch (LobbyServiceException e) {
            Debug.LogError(e);
        }
    }
    [Command]
    private void ListPlayers() {
        if(joinedLobby.Players.Count > 0) {
            Debug.Log("Player id list:");
            foreach(var player in joinedLobby.Players) {
                Debug.Log(player.Id);
            }
        }
    }
    [Command]
    private async void KickPlayer() {
        try {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, joinedLobby.Players[1].Id);
            Debug.Log("Kick player successfully");
        }
        catch (LobbyServiceException e) {
            Debug.Log(e);
        }
    }

}