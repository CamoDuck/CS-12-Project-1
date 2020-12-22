using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwordEnemy : MonoBehaviour
{
    float speed = 5f;
    GameObject player;

    void moveAway()
    {
        float Xdir = Vector3.Normalize(transform.position - player.transform.position).x;
        float Ydir = Vector3.Normalize(transform.position - player.transform.position).y;
        transform.position += Vector3.Normalize(new Vector3(Random.Range(Xdir - 1.0f, Xdir), Random.Range(Ydir - 1.0f, Ydir), 0)) * speed * Time.deltaTime;
    }
    void moveToward()
    {
        float Xdir = Vector3.Normalize(player.transform.position - transform.position).x;
        float Ydir = Vector3.Normalize(player.transform.position - transform.position).y;
        transform.position += Vector3.Normalize(new Vector3(Random.Range(Xdir - 1.0f, Xdir), Random.Range(Ydir - 1.0f, Ydir), 0)) * speed * Time.deltaTime;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            transform.Find("SwordRot").GetComponent<SpriteRenderer>().enabled = true;
            moveAway();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 3)
        {
            transform.Find("SwordRot").GetComponent<SpriteRenderer>().enabled = false;
            moveToward();
        }
        else {
            transform.Find("SwordRot").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
