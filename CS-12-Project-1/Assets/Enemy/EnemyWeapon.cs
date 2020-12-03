using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {
    Transform T_Arrow;
    float reloadTime = 3f;

    IEnumerator createArrow()
    {
        Transform clone;
        Debug.Log("ran");
        clone = Instantiate(T_Arrow, transform.position, T_Arrow.rotation);
        clone.GetComponent<ArrowMove>().enabled = true;
        T_Arrow.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(clone.gameObject, 3);
        yield return new WaitForSeconds(reloadTime);
        T_Arrow.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        Debug.Log("ran2");
        StartCoroutine(createArrow());
    }

    void Start() {
        T_Arrow = transform.Find("Arrow");
        Debug.Log("ran3");
        StartCoroutine(createArrow());
    }

    void Update() {
        transform.up = GameObject.Find("Player").transform.position - transform.position;
        Random.Range(3f, 7f);
    }
}
