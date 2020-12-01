using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour {
    Vector3 mousePos;
    float speed = 0.01f;
    void Start() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = Vector3.Normalize(mousePos - transform.position)*speed;
        mousePos.z = 0;
    }

    void Update() {
        Debug.Log(mousePos);
        transform.position += mousePos;
    }
}
