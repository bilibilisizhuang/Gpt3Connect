using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{

    [SerializeField] private List<Apple> appleList;




    // Start is called before the first frame update
    void Start()
    {
        if (appleList != null) {
            appleList.Reverse();
            Apple temp = null;
            foreach (Apple apple in appleList) {
                if (temp != null) {
                    apple.nextApple = temp;
                }
                temp = apple;
            }
            appleList.Reverse ();

            foreach (Apple apple in appleList) {
                Debug.Log("当前苹果的下一个苹果： " + apple.nextApple);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (appleList != null) {
                appleList[0].Full();
            }
        }
    }
}
