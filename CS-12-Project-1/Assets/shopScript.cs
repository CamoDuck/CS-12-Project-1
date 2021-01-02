using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopScript : MonoBehaviour
{
    Transform player;
    Transform item;
    float width;
    float height;
    Vector3 mousePos;
    Text gold;
    int cost;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        gold = player.Find("GUI").Find("goldImage").Find("goldAmount").GetComponent<Text>();
        item = transform.GetChild(1);

        cost = int.Parse(transform.Find("GoldCost").GetComponent<TextMesh>().text.Substring(5, transform.Find("GoldCost").GetComponent<TextMesh>().text.Length - 10) );

        if (item.childCount > 0)
        {
            width = item.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x;
            height = item.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.y;
        }
        else
        {
            width = item.GetComponent<SpriteRenderer>().bounds.extents.x;
            height = item.GetComponent<SpriteRenderer>().bounds.extents.y;
        }
    }

    void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (int.Parse(gold.text.Substring(5)) >= cost & Input.GetMouseButtonUp(0) & item.position.x + width > mousePos.x & item.position.x - width < mousePos.x & item.position.y + height > mousePos.y & item.position.y - height < mousePos.y) {
            gold.text = "Gold: " + (int.Parse(gold.text.Substring(5)) - cost);
            item.SetParent(GameObject.Find("Player").transform.Find("Inventory").Find("items"));
            item.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            transform.GetChild(0).GetComponent<TextMesh>().text = "Out Of Stock";
            transform.GetComponent<shopScript>().enabled = false;
        }

    }
}
