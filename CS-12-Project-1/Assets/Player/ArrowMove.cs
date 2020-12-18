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
            //Debug.Log(collision.gameObject.name);
            active = false;
        }
        else if (collision.gameObject.name == "Enemy") {
            Debug.Log("hit Enemy!");
        
        
        }
    }

    void Start() {
        if (transform.tag == "Player")
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.z = 0;
            direction = Vector3.Normalize(direction - transform.position) * speed;
            direction.z = 0;
        }
        else if (transform.tag == "Enemy") {
            GameObject player = GameObject.Find("Player");
            direction = player.transform.position - transform.position;
            direction.z = 0;
            direction = Vector3.Normalize(direction) * speed;
            direction.z = 0;
            
        }
        Debug.Log(direction.x)
    }

    void Update() {
        if (active == true) {
            transform.position += direction * Time.deltaTime;

        }
        
    }
}
