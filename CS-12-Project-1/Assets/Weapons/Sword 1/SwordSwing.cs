using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{

    Vector3 mousePos;
    bool ready = true;
    float reload = 0.2f;
    float arc = 120;
    float change = 0;
    Quaternion temp;

    IEnumerator Swing()
    {
        arc = -arc;
        change = -arc / 2;
        yield return new WaitForSeconds(reload);
        ready = true;
        change = 0;
        transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;

    }

    private void Update()
    {
        if (transform.parent.tag == "Player")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
            

        }
        else if (transform.parent.tag == "Enemy")
        {
            temp = Quaternion.LookRotation(Vector3.forward, GameObject.Find("Player").transform.position - transform.position);


        }

        transform.rotation = Quaternion.Euler(temp.eulerAngles.x, temp.eulerAngles.y, temp.eulerAngles.z + change);
        //Debug.Log((Input.GetMouseButton(0) & transform.GetComponent<SpriteRenderer>().enabled == true) | transform.parent.tag == "Enemy");

        if (ready == false)
        {
            change += (arc / reload * Time.deltaTime);
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

        }
        else if ((Input.GetMouseButton(0) | transform.parent.tag == "Enemy") & transform.GetComponent<SpriteRenderer>().enabled == true) 
        {
            //Debug.Log("ran");
            ready = false;
            StartCoroutine(Swing());
        }
    }
}
