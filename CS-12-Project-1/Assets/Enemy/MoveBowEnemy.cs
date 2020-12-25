using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBowEnemy : MonoBehaviour
{
    float speed = 5f;
    GameObject player;

    Transform healthbar;
    float healthsize;
    

    void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Player") {
            healthbar.localScale -= new Vector3(0.1f,0,0);
            healthbar.position -= new Vector3(healthsize, 0, 0);

            if (healthbar.localScale.x <= 0) {
                Destroy(gameObject);
            }
        }
    }



        void moveAway() {
        float Xdir = Vector3.Normalize(transform.position - player.transform.position).x;
        float Ydir = Vector3.Normalize(transform.position - player.transform.position).y;
        transform.position += Vector3.Normalize(new Vector3(Random.Range(Xdir-1.0f, Xdir), Random.Range(Ydir-1.0f, Ydir), 0)) * speed * Time.deltaTime;
    }
    void moveToward() {
        float Xdir = Vector3.Normalize(player.transform.position - transform.position).x;
        float Ydir = Vector3.Normalize(player.transform.position - transform.position).y;
        transform.position += Vector3.Normalize(new Vector3(Random.Range(Xdir-1.0f, Xdir), Random.Range(Ydir-1.0f, Ydir), 0)) * speed * Time.deltaTime;
    }

    void Start()
    {
        player = GameObject.Find("Player");

        healthbar = transform.Find("Healthbar").Find("Healthsize");
        healthsize = healthbar.GetComponent<SpriteRenderer>().bounds.extents.x / 10;
    }

    void Update()
    {
        //Debug.Log("running2");
        if (Vector3.Distance(transform.position, player.transform.position) < 4)
        {
            moveAway();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 8)
        {
            moveToward();
        }

    }
}