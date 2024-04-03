using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class RelayManager : MonoBehaviour {


    [Command]
    private async void CreateRelay() {
        try {
            Allocation allocation = await RelayService.Instance.CreateAllocationAsync(3);
            string joincode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joincode);
            RelayServerData data = new RelayServerData(allocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(data);
            NetworkManager.Singleton.StartHost();
             
        }
        catch (RelayServiceException e) {
            Debug.LogException(e);
        }
    }

    [Command]
    private async void JoinRelay(string code) {
        try {
            JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(code);
            RelayServerData joinAllocationData = new RelayServerData(joinAllocation, "dtls");
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(joinAllocationData);
            NetworkManager.Singleton.StartClient();

        }
        catch (RelayServiceException e) {
            Debug.LogException(e);
        }
    }


}

