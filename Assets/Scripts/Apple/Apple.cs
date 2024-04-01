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
            //֪ͨ��һ��ƻ������
            if (nextApple != null) {
                nextApple.Full();
            }
            else {
                Debug.Log("û�и���ƻ����");
            }
        }
    }
    /// <summary>
    /// ʹ�Լ�����
    /// </summary>
    public void Full() {
        GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log(gameObject.name + "��ʼ����");
    }
    /// <summary>
    /// �ر�����������λ��
    /// </summary>
    private void ResetSelf() {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.position = originPos;
    }

}
