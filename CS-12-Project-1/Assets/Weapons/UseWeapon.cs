using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour {
    float reloadTime = 1f;
    bool ready = true;
    Vector3 mousePos;

    Transform weapon;

    IEnumerator createArrow()
    {
        if (transform.parent.tag == "Enemy")
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
        Transform clone;
        clone = Instantiate(weapon, transform.position, weapon.rotation);
        clone.tag = transform.parent.tag;
        clone.GetComponent<ArrowMove>().enabled = true;
        clone.GetComponent<BoxCollider2D>().enabled = true;
        clone.GetComponent<Rigidbody2D>().simulated = true;
        weapon.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(reloadTime);
        weapon.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        ready = true;
    }


    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "Weapon")
            {
                weapon = transform.GetChild(i);
                if (transform.parent.tag == "Enemy")
                {
                    StartCoroutine(createArrow());
                }
            }
        }
    }

    void Update()
    {
        if (transform.parent.tag == "Player")
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

            if (Input.GetMouseButtonDown(0) & ready == true)
            {
                ready = false;
                StartCoroutine(createArrow());
            }
        }
        else if (transform.parent.tag == "Enemy")
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, GameObject.Find("Player").transform.position - transform.position);
            if (ready == true)
            {
                ready = false;
                StartCoroutine(createArrow());
            }
        }
    }
}
