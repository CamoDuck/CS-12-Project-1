using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateMap : MonoBehaviour {

    int negplus1() {
        if (Random.Range(0, 2) == 0) {
            return -1;
        }
        return 1;
    } 
    GameObject generate(GameObject lastRoom=null) {
        GameObject clone = Instantiate(Resources.Load("Floor")) as GameObject;
        clone.transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20,100), 1);
        Debug.Log(clone.transform.localScale.x + lastRoom.transform.localScale.x);
        clone.transform.position = lastRoom.transform.position + new Vector3((clone.transform.localScale.x+lastRoom.transform.localScale.x)*negplus1()*0.05f, (clone.transform.localScale.y + lastRoom.transform.localScale.y) * negplus1()*0.05f,0);
        return clone;
    }

    //linked list to solve stacking problem =)

    void Start() {
        GameObject room = generate(GameObject.Find("start"));
        for (int i=0; i < 100; i++) {
            room = generate(room);
        }

    }
}
