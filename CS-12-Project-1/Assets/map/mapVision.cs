using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapVision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && transform.tag != "Player")
        {
            transform.parent.GetComponent<fillMap>().enabled = true;
            Destroy(gameObject);
        }
    }
}
