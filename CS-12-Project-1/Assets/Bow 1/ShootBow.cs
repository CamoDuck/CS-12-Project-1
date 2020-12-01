using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour {
    int reloadTime = 1;
    float angle;
    Vector3 mousePos;

    void Start() {
       // Debug.Log(Vector3.Normalize(new Vector3(1.5f, 0.72f, 0)));
    }

    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(Vector3.forward + " + " + (mousePos - transform.position));
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        
        /*
        if (Input.GetMouseButtonDown(0)) {
            Object clone = Instantiate(transform.Find("Arrow"));
            while (!((clone as GameObject).GetComponent<ArrowMove>())) {
                yeild return null;
            }
            (clone as GameObject).GetComponent<ArrowMove>().enabled = true;
            transform.Find("Arrow").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        */


    }
}
