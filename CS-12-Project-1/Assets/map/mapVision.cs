using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapVision : MonoBehaviour
{
    Transform player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && transform.tag != "Player")
        {

            Text roomstat = player.transform.Find("GUI").Find("EndScreen").Find("RoomScore").GetComponent<Text>();
            roomstat.text = "Rooms explored: " + (int.Parse(roomstat.text.Substring(roomstat.text.IndexOf(":") + 1)) + 1);

            transform.parent.GetComponent<fillMap>().enabled = true;
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
}
