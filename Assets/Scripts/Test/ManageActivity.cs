using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageActivity : MonoBehaviour {

    [SerializeField] private List<GameObject> objects;
    private List<GameObject> activedObjects;
    private float ActivePer3SecTimer;
    private bool inited = false;
    private void Start() {
        InitActivity();
    }

    private void InitActivity() {
        activedObjects = new List<GameObject>();
        foreach (GameObject t in objects) {
            t.SetActive(false);
        }
        for (int i = 0; i < 6; i++) {
            iImmediatelyActive();
        }
        inited = true;
    }
    private void iImmediatelyActive() {
        int index = ChooseVaildIndex();
        objects[index].SetActive(true);
        activedObjects.Add(objects[index]);
    }
    private int ChooseVaildIndex() {
        int index = Random.Range(0, objects.Count);
        if (activedObjects!=null &&  activedObjects.Contains(objects[index])) {
            return ChooseVaildIndex();
        }
        return index;
    }

    private void Update() {
        if (inited) {
            KeepActivitiesCloseToSix();
            KeepActivitiesMoreThan3();
        }
    }

    private void KeepActivitiesCloseToSix() {
        if(activedObjects.Count < 6) {
            ActivePer3SecTimer += Time.deltaTime;

            if(ActivePer3SecTimer > 3) {
                ActivePer3SecTimer = 0;
                iImmediatelyActive();
            }

        }
        else {
            ActivePer3SecTimer = 0;
        }
    }
    private void KeepActivitiesMoreThan3() {
        if(activedObjects.Count < 3) {
            for(int i = 0; i < 3 - activedObjects.Count; i++) {
                iImmediatelyActive();
            }
        }
    }

    public void RemoveOne(GameObject one) {
        if(activedObjects.Contains(one)) {
            activedObjects.Remove(one);
        }
    }

}
