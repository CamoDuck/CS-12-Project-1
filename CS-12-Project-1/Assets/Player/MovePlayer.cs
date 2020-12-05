using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    float xSpeed;
    float ySpeed;
    float speed = 5f;

    void Start() {
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            ySpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            ySpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            ySpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.S)) {
            ySpeed += speed;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            xSpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            xSpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            xSpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            xSpeed += speed;
        }

        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime; 
    }
}
