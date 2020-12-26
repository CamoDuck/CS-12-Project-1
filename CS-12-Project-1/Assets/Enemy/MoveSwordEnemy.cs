using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwordEnemy : MonoBehaviour
{
    float speed = 5f;
    GameObject player;

    Transform healthbar;
    float healthsize;
    float burnTime;
    float freezeTime;



    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            healthbar.localScale -= new Vector3(0.1f, 0, 0);
            healthbar.position -= new Vector3(healthsize, 0, 0);
            if (collision.gameObject.name == "ice" & Random.Range(0, 5) == 0)
            {
                freezeTime = 5;
                burnTime = 0;
                transform.Find("SwordRot").GetComponent<SwordSwing>().enabled = false;
                Debug.Log("Freeze");

            }
            else if (collision.gameObject.name == "fire" & Random.Range(0, 5) == 0)
            {
                burnTime = 5;
                freezeTime = 0;
                Debug.Log("burnn");

            }

        }
    }


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

        healthbar = transform.Find("Healthbar").Find("Healthsize");
        healthsize = healthbar.GetComponent<SpriteRenderer>().bounds.extents.x / 10;
    }

    void Update()
    {
        if (healthbar.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
        if (freezeTime <= 0)
        {
            transform.Find("SwordRot").GetComponent<SwordSwing>().enabled = true;
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
            else
            {
                transform.Find("SwordRot").GetComponent<SpriteRenderer>().enabled = true;
            }
            if (burnTime >= 0)
            {
                healthbar.localScale -= new Vector3(Time.deltaTime * 0.1f, 0, 0);
                healthbar.position -= new Vector3(healthsize * Time.deltaTime, 0, 0);
                burnTime -= Time.deltaTime;
                Debug.Log(burnTime);

            }
        }
        else {
            freezeTime -= Time.deltaTime;

        }
    }


}
