using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Http
{
    public class WebRequestMonoBehaviour : MonoBehaviour { }
    public static WebRequestMonoBehaviour webRequestMonoBehaviour;

    public static void Init() {
        if (webRequestMonoBehaviour == null) {
            GameObject gameObject = new GameObject("WebRequests");
            webRequestMonoBehaviour = gameObject.AddComponent<WebRequestMonoBehaviour>();
        }
    }

    public static void Get(string url) {
        Init();
        webRequestMonoBehaviour.StartCoroutine(_Get(url));  
    }





    private static IEnumerator _Get(string url, Dictionary<string, string> header = null, 
            Action<bool> error = null,Action<bool> success = null
        ) {

        using(UnityWebRequest request = UnityWebRequest.Get(url)) {

            if (header != null) {
                foreach (KeyValuePair<string, string> head in header) {
                    request.SetRequestHeader(head.Key, head.Value);
                }
            }
                          


            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success) {
                Debug.Log("error: " + request.error);
            }
            else {
                Debug.Log("result: " + request.downloadHandler.text);
            }
        }
    }
}
