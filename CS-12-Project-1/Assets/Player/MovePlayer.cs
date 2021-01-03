using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {
    float xSpeed;
    float ySpeed;
    float speed = 5f;
    float sprint = 1;
    int health = 10000;
    int maxHealth = 10000;
    float damagetimer = 0;

    Transform healthBar;
    float healthbarSize;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (damagetimer <= 0)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Oofers");
                health -= Random.Range(50,101);
                damagetimer = 0.5f;
                if (health <= 0) {
                    health = 0;
                    
                }
            }
        } 
    }

    void inventory() {
        Transform inventory = transform.Find("Inventory");
        inventory.GetComponent<Canvas>().enabled = !inventory.GetComponent<Canvas>().enabled;
    
    }

    void disableChild(Transform thing, bool option) {
        thing.GetComponent<SpriteRenderer>().enabled = option;
        for (int x = 0; x < thing.childCount; x++) {
            thing.GetChild(x).GetComponent<SpriteRenderer>().enabled = option;

        }
    }

    void Start() {
    }

    void Update() {

        healthBar = transform.Find("GUI").Find("healthbar");
        healthbarSize = transform.Find("GUI").GetComponent<RectTransform>().rect.width;
        healthBar.Find("healthText").GetComponent<Text>().text = "Health: " + health + "/" + maxHealth;
        healthBar.Find("health").localScale = new Vector3((health+0.0f)/maxHealth, 1, 0.99f);
        healthBar.Find("health").position = new Vector3(healthBar.position.x +(health-maxHealth)/((healthbarSize/72)*((maxHealth+0.0f)/1000)), healthBar.position.y, healthBar.position.z);

        if (Input.GetKeyDown(KeyCode.W)) {
            ySpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            ySpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            ySpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.S)) {
            ySpeed += speed;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            xSpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            xSpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            xSpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            xSpeed += speed;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Debug.Log("run1");
            disableChild(transform.Find("SwordRot"), true);
            disableChild(transform.Find("BowRot"), false);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Debug.Log("run2");
            disableChild(transform.Find("SwordRot"), false);
            disableChild(transform.Find("BowRot"), true);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = 4f;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            sprint = 1;
        
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            disableChild(transform.Find("SwordRot"), false);
            disableChild(transform.Find("BowRot"), false);
            inventory();
        }

        if (damagetimer >= 0)
        {
            damagetimer -= Time.deltaTime;

        }


            transform.position += new Vector3(xSpeed*sprint, ySpeed*sprint, 0) * Time.deltaTime; 
    }
}
