using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStart : MonoBehaviour
{
    Transform player;
    private void Start()
    {
       player = GameObject.Find("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            transform.GetComponent<BoxCollider2D>().enabled = false;
            player.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

            for (int i = 0; i < 2; i++)
            {
                GameObject boss = Instantiate(Resources.Load("BoarRider")) as GameObject;
                if (transform.GetChild(0).name == "wall+x")
                {
                    boss.transform.position = transform.position + new Vector3(-transform.GetComponent<SpriteRenderer>().bounds.extents.x * 4, 0, -2);

                }
                else if (transform.GetChild(0).name == "wall-x")
                {
                    boss.transform.position = transform.position + new Vector3(transform.GetComponent<SpriteRenderer>().bounds.extents.x * 4, 0, -2);

                }
                else if (transform.GetChild(0).name == "wall+y")
                {
                    boss.transform.position = transform.position + new Vector3(0, -transform.GetComponent<SpriteRenderer>().bounds.extents.x * 4, -2);

                }
                else if (transform.GetChild(0).name == "wall-y")
                {
                    boss.transform.position = transform.position + new Vector3(0, transform.GetComponent<SpriteRenderer>().bounds.extents.x * 4, -2);

                }
            }

        }
    }
}
