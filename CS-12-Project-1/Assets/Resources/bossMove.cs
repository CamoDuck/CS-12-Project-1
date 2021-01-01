using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMove : MonoBehaviour
{
    Vector3 direction;
    float speed = 10;
    bool ready = true;

    Transform player;
    Transform healthbar;
    float healthsize;
    float burnTime;
    float freezeTime;
    float chargeTime = 0;

    void charge() { 
        
    
    
    }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ready == true)
        {
            if (healthbar.localScale.x > 0.5f)
            {
                if (collision.gameObject.name == "wall+x" | collision.gameObject.name == "wall-x")
                {
                    direction = new Vector3(-direction.x, direction.y, 0);
                    ready = false;

                }
                else if (collision.gameObject.name == "wall+y" | collision.gameObject.name == "wall-y")
                {
                    direction = new Vector3(direction.x, -direction.y, 0);
                    ready = false;
                }
            }
            if (healthbar.localScale.x <= 0.5f) {
                if (collision.gameObject.name.Substring(0, 4) == "wall")
                {
                    freezeTime = 5;
                    chargeTime = 0;
                    transform.Find("boar").GetComponent<SpriteRenderer>().sprite = (Instantiate(Resources.Load("readImage/stunedboar")) as GameObject).transform.GetComponent<SpriteRenderer>().sprite;
                    
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        direction = Vector3.Normalize(new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), 0));

        healthbar = transform.Find("Healthbar").Find("Healthsize");
        healthsize = healthbar.GetComponent<SpriteRenderer>().bounds.extents.x / 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.localScale.x <= 0)
        {
            Destroy(gameObject);

        }
        if (freezeTime <= 0)
        {
            if (direction.x > 0)
            {
                transform.Find("boar").rotation = Quaternion.Euler(0, 0, 0);

            }
            else {
                transform.Find("boar").rotation = Quaternion.Euler(0, 180, 0);
            }
            if (healthbar.localScale.x > 0.5f)
            {
                transform.position += direction * speed * Time.deltaTime;
                ready = true;
            
            }
            if (healthbar.localScale.x <= 0.5f)
            {
                transform.Find("boar").GetComponent<SpriteRenderer>().sprite = (Instantiate(Resources.Load("readImage/boar")) as GameObject).transform.GetComponent<SpriteRenderer>().sprite;
                if (chargeTime <= 0)
                {
                    if (Vector3.Distance(transform.position, player.transform.position) > 8)
                    {
                        transform.position += Vector3.Normalize(player.transform.position - transform.position) * speed * Time.deltaTime;
                        ready = true;
                    }
                    else
                    {
                        direction = Vector3.Normalize(player.transform.position - transform.position);
                        chargeTime = 1;
                    }
                }
                else {
                    transform.position += direction * speed * Time.deltaTime * 2;
                    chargeTime -= Time.deltaTime;

                }

            }
            //transform.Find("BowRot").GetComponent<ShootBow>().enabled = true;

            
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
