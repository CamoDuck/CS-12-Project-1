using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    float xSpeed;
    float ySpeed;

    void Start() {
        Debug.Log("run MovePlayer");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            ySpeed += 0.01f;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            ySpeed += -0.01f;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            ySpeed += -0.01f;
        }
        else if (Input.GetKeyUp(KeyCode.S)) {
            ySpeed += 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            xSpeed += 0.01f;
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            xSpeed += -0.01f;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            xSpeed += -0.01f;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            xSpeed += 0.01f;
        }

        gameObject.transform.position += new Vector3(xSpeed, ySpeed, 0); 
    }
}
