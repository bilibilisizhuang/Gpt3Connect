using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : MonoBehaviour {

    private Vector3 moveDir;
    private float speed = 30;

    private void Update() {
        if (!GetComponent<NetworkObject>().IsOwner) return;
        if(Input.GetKey(KeyCode.W)) {
            moveDir = new Vector3(0, 0, 1);
        }
        if(Input.GetKey(KeyCode.S)) {
            moveDir = new Vector3(0, 0, -1);
        }
        if(Input.GetKey(KeyCode.A)) {
            moveDir = new Vector3(-1, 0, 0);
        }
        if(Input.GetKey(KeyCode.D)) {
            moveDir = new Vector3(1, 0, 0);
        }

        transform.position += moveDir * speed * Time.deltaTime;
        moveDir = Vector3.zero;
    }

}
