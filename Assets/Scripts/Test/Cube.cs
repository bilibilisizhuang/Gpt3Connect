using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    [ContextMenu("��������")]
    public void DeActiveSelf() {
        GameObject.Find("ManageActivity").GetComponent<ManageActivity>().RemoveOne(gameObject);
        gameObject.SetActive(false);
    }

}

