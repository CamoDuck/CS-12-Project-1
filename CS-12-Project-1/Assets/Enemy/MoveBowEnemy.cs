using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBowEnemy : MonoBehaviour
{
    float speed = 5f;
    GameObject player;

    Transform healthbar;
    float healthsize;
    float burnTime;
    float freezeTime;



    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            healthbar.localScale -= new Vector3(0.1f, 0, 0);
            healthbar.position -= new Vector3(healthsize, 0, 0);
            if (collision.gameObject.name == "ice" & Random.Range(0, 5) == 0) {
                freezeTime = 5;
                burnTime = 0;
                transform.Find("BowRot").GetComponent<ShootBow>().enabled = false;
                //Debug.Log("Freeze");

            }
            else if (collision.gameObject.name == "fire" & Random.Range(0, 5) == 0)
            {
                burnTime = 5;
                freezeTime = 0;
                //Debug.Log("burnn");

            }

        }
    }



    void moveAway() {
        float Xdir = Vector3.Normalize(transform.position - player.transform.position).x;
        float Ydir = Vector3.Normalize(transform.position - player.transform.position).y;
        transform.position += Vector3.Normalize(new Vector3(Random.Range(Xdir - 1.0f, Xdir), Random.Range(Ydir - 1.0f, Ydir), 0)) * speed * Time.deltaTime;
    }
    void moveToward() {
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
            Text goldtext = player.transform.Find("GUI").Find("goldImage").Find("goldAmount").GetComponent<Text>();
            goldtext.text = "Gold: "+ (int.Parse(goldtext.text.Substring(6)) + Random.Range(20,51));
            Destroy(gameObject);
        }
        if (freezeTime <= 0)
        {
            transform.Find("BowRot").GetComponent<ShootBow>().enabled = true;
            //Debug.Log("running2");
            if (Vector3.Distance(transform.position, player.transform.position) < 4)
            {
                moveAway();
            }
            else if (Vector3.Distance(transform.position, player.transform.position) > 8)
            {
                moveToward();
            }
            if (burnTime >= 0)
            {
                healthbar.localScale -= new Vector3(Time.deltaTime * 0.1f, 0, 0);
                healthbar.position -= new Vector3(healthsize * Time.deltaTime, 0, 0);
                burnTime -= Time.deltaTime;
                //Debug.Log(burnTime);

            } 

        }
        else
        {
            freezeTime -= Time.deltaTime;
        }
    }
}