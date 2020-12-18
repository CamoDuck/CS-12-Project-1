using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBow : MonoBehaviour {
    float reloadTime = 1f;
    bool ready = true;
    Vector3 mousePos;

    Transform T_Arrow;

    IEnumerator createArrow() {
        ready = false;
        Transform clone; 
        clone = Instantiate(T_Arrow, transform.position, T_Arrow.rotation);
        clone.tag = transform.parent.tag;
        clone.GetComponent<ArrowMove>().enabled = true;
        clone.GetComponent<BoxCollider2D>().enabled = true;
        T_Arrow.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //Destroy(clone.gameObject, 3);
        yield return new WaitForSeconds(reloadTime);
        T_Arrow.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ready = true;
    }


    void Start() {
        T_Arrow = transform.Find("Arrow");
    }

    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        if (Input.GetMouseButtonDown(0) & ready == true) {
            StartCoroutine(createArrow());
        }


    }
}
