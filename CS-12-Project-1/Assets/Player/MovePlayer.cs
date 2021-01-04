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
    float timePlayed = 0;
    Text bossstat;

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
        bossstat = transform.Find("GUI").Find("EndScreen").Find("BossScore").GetComponent<Text>();
    }

    void Update() {

        if (health > 0 & int.Parse(bossstat.text.Substring(bossstat.text.IndexOf(":") + 1)) != 2)
        {

            healthBar = transform.Find("GUI").Find("healthbar");
            healthbarSize = transform.Find("GUI").GetComponent<RectTransform>().rect.width;
            healthBar.Find("healthText").GetComponent<Text>().text = "Health: " + health + "/" + maxHealth;
            healthBar.Find("health").localScale = new Vector3((health + 0.0f) / maxHealth, 1, 0.99f);
            healthBar.Find("health").position = new Vector3(healthBar.position.x + (health - maxHealth) / ((healthbarSize / 72) * ((maxHealth + 0.0f) / 1000)), healthBar.position.y, healthBar.position.z);

            if (Input.GetKeyDown(KeyCode.W))
            {
                ySpeed += speed;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                ySpeed += -speed;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ySpeed += -speed;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                ySpeed += speed;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                xSpeed += speed;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                xSpeed += -speed;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                xSpeed += -speed;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                xSpeed += speed;
            }

            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Debug.Log("run1");
                disableChild(transform.Find("SwordRot"), true);
                disableChild(transform.Find("BowRot"), false);
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Debug.Log("run2");
                disableChild(transform.Find("SwordRot"), false);
                disableChild(transform.Find("BowRot"), true);

            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sprint = 4f;

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprint = 1;

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                disableChild(transform.Find("SwordRot"), false);
                disableChild(transform.Find("BowRot"), false);
                inventory();
            }

            if (damagetimer >= 0)
            {
                damagetimer -= Time.deltaTime;

            }

            timePlayed += Time.deltaTime;
           

            transform.position += new Vector3(xSpeed * sprint, ySpeed * sprint, 0) * Time.deltaTime;
        }
        else
        {
            Transform gameScreen = transform.Find("GUI").Find("EndScreen");

            Text timestat = gameScreen.Find("TimeScore").GetComponent<Text>();
            timestat.text = ("Time played(sec): " + Mathf.Round(timePlayed));

            int totalScore = 0;
            totalScore += GetNum(gameScreen.Find("EnemyScore").GetComponent<Text>().text) * 50;
            totalScore += GetNum(gameScreen.Find("BossScore").GetComponent<Text>().text) * 500;
            totalScore += GetNum(gameScreen.Find("GoldScore").GetComponent<Text>().text);
            totalScore += GetNum(gameScreen.Find("ItemsScore").GetComponent<Text>().text) * 50;
            totalScore += GetNum(gameScreen.Find("RoomScore").GetComponent<Text>().text) * 10;
            totalScore += 1800 - (int)Mathf.Round(timePlayed);

            gameScreen.Find("TotalScore").GetComponent<Text>().text = "Total Score: " + (totalScore);

            transform.Find("GUI").Find("EndScreen").GetComponent<Image>().enabled = true;
            for (int x = 0; x < gameScreen.childCount; x++)
            {
                gameScreen.GetChild(x).GetComponent<Text>().enabled = true;
                
            }
        }
    }

    int GetNum(string s) {
        return int.Parse(s.Substring(s.IndexOf(":") + 1));


    }

}
