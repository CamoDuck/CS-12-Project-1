using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {

    Vector3 mousePos;
    bool ready = true;
    float reload = 0.2f;
    float arc = 120;
    float change = 0;

    IEnumerator Swing() {
        arc = -arc;
        change = -arc / 2;
        yield return new WaitForSeconds(reload);
        ready = true;
        change = 0;
        
    }

    private void Update() {
        if (transform.parent.tag == "Player")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion temp = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            transform.rotation = Quaternion.Euler(temp.eulerAngles.x, temp.eulerAngles.y, temp.eulerAngles.z + change);

            if (ready == false)
            {
                change += (arc/reload * Time.deltaTime);
                
            }
            else if (Input.GetMouseButton(0) & transform.GetComponent<SpriteRenderer>().enabled == true)
            {
                ready = false;
                StartCoroutine(Swing());
            }
        }


    }
}
