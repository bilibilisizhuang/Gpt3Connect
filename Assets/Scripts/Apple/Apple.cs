using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [NonSerialized]
    public Apple nextApple;
    private Vector3 originPos;
    
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.01f) {
            ResetSelf();
            //通知下一个苹果掉落
            if (nextApple != null) {
                nextApple.Full();
            }
            else {
                Debug.Log("没有更多苹果了");
            }
        }
    }
    /// <summary>
    /// 使自己下落
    /// </summary>
    public void Full() {
        GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log(gameObject.name + "开始下落");
    }
    /// <summary>
    /// 关闭受力并重置位置
    /// </summary>
    private void ResetSelf() {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = originPos;
    }

}
