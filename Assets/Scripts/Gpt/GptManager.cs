using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GptManager : MonoBehaviour
{
    private string testUrl = "https://test.lllmark.com/kadou/activity/list";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Http.Get(testUrl);
        }
    }
}
