using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turretControl : MonoBehaviour
{
    Transform player;
    Transform playerHead;
    MovePlayer playerscript;
    LineRenderer ray;

    Transform healthbar;

    int maxrange = 10;
    int voltage = 100;
    float healthsize;


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player"& collision.gameObject.name != "Player")
        {
            healthbar.localScale -= new Vector3(0.1f, 0, 0);
            healthbar.position -= new Vector3(healthsize, 0, 0);
        }
    }

    void Start()
    {
        player = GameObject.Find("Player").transform;
        playerscript = player.GetComponent<MovePlayer>();
        ray = transform.Find("laser").GetComponent<LineRenderer>();

        healthbar = transform.Find("Healthbar").Find("Healthsize");
        healthsize = healthbar.GetComponent<SpriteRenderer>().bounds.extents.x / 10;

        ray.SetPosition(0, transform.position);
    }

    void Update()
    {
        if (healthbar.localScale.x > 0)
        {
            if (Vector3.Distance(transform.position, player.position) <= maxrange)
            {
                playerscript.damage(voltage * Time.deltaTime);
                ray.SetPosition(1, player.position);
            }
            else
            {
                ray.SetPosition(1, transform.position);

            }
        }
        else {
            Text goldtext = player.transform.Find("GUI").Find("goldImage").Find("goldAmount").GetComponent<Text>();
            int randomGold = Random.Range(50, 101);
            goldtext.text = "Gold: " + (int.Parse(goldtext.text.Substring(6)) + randomGold);

            Text enemystat = player.transform.Find("GUI").Find("EndScreen").Find("EnemyScore").GetComponent<Text>();
            enemystat.text = "Enemies killed: " + (int.Parse(enemystat.text.Substring(enemystat.text.IndexOf(":") + 1)) + 1);

            Text goldstat = player.transform.Find("GUI").Find("EndScreen").Find("GoldScore").GetComponent<Text>();
            goldstat.text = "Gold collected: " + (int.Parse(goldstat.text.Substring(goldstat.text.IndexOf(":") + 1)) + randomGold);

            Destroy(gameObject);
        
        }
    }
}
