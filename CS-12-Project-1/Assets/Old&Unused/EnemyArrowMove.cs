using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowMove : MonoBehaviour {
    GameObject player;
    float speed = 10f;
    float Xdir;
    float Ydir;


    void Start() {
        player = GameObject.Find("Player");
        Xdir = Vector3.Normalize(player.transform.position - transform.position).x;
        Ydir = Vector3.Normalize(player.transform.position - transform.position).y;
    }

    void Update() {
        transform.position += new Vector3(Xdir, Ydir, 0) * speed * Time.deltaTime;
    }
}
