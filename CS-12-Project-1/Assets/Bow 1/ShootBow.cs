using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour {
    int reloadTime = 1;
    float arrowSpeed = 0.1f;
    float angle;
    Vector3 mousePos = Input.mousePosition;
    Vector3 bowPos;

    void Start() {
        
    }

    void Update() {
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        bowPos = transform.Find("Bow1_loaded").position;



    }
}
