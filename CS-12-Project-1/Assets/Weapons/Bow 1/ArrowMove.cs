using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {
    Vector3 direction;
    float speed = 10f;
    bool active = true;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name.Substring(0, 4) == "wall")
        {
            Destroy(transform.gameObject);
            active = false;
        }
        else if (collision.gameObject.name == "Enemy" && transform.tag != "Enemy")
        {
            //Debug.Log("hit Enemy!");


        }
        else if (collision.gameObject.name == "Player" && transform.tag != "Player") {
            //Debug.Log("hit Player!");
        }
    }

    void Start() {
        if (transform.tag == "Player")
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        else if (transform.tag == "Enemy") {
            GameObject player = GameObject.Find("Player");
            direction = player.transform.position - transform.position;
            
        }
        direction.z = 0;
        direction = Vector3.Normalize(direction) * speed;
        //Debug.Log(direction.z);
    }

    void Update() {
        if (active == true) {
            transform.position += direction * Time.deltaTime;

        }
        
    }
}
