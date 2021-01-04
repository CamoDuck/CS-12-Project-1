using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestItems : MonoBehaviour
{
    Dictionary<string, int> spawns = new Dictionary<string, int>();
    Transform playerInv;
    float width;
    float height;
    Vector3 mousePos;



    void createRandom()
    {
        foreach (KeyValuePair<string, int> item in spawns)
        {
            while (Random.Range(0, item.Value) == 0)
            {
                GameObject clone = Instantiate(Resources.Load("Chest Items/" + item.Key)) as GameObject;
                clone.transform.parent = transform;
                clone.transform.GetComponent<SpriteRenderer>().enabled = false;
                for (int i=0; i<clone.transform.childCount; i++) {
                    clone.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }

    void Start()
    {
        spawns["SwordRot"] = 2;
        spawns["Bowrot"] = 2;
        spawns["iceSwordRot"] = 3;
        spawns["iceBowRot"] = 3;
        spawns["fireSwordRot"] = 3;
        spawns["fireBowRot"] = 3;



        playerInv = GameObject.Find("Player").transform.Find("Inventory");
        width = transform.GetComponent<Renderer>().bounds.extents.x;
        height = transform.GetComponent<Renderer>().bounds.extents.y;

        createRandom();
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Transform clone = Instantiate(transform.Find("Canvas").Find("default"));
            clone.GetComponent<Image>().sprite = transform.GetChild(1).GetChild(0).GetComponent<SpriteRenderer>().sprite;
            clone.localScale = new Vector3(0.2f, 0.3f, 1);
            clone.position = transform.Find("Canvas").Find("itemUI").position + new Vector3(-130 + (40 * ((i-1) % 7)), 80 - (40 * (((i-1) - ((i-1) % 7)) / 7)), 0);
            clone.SetParent(transform.Find("Canvas").Find("itemUI"));
            clone.GetComponent<Image>().enabled = true;
            transform.GetChild(1).SetParent(clone);
        }
        transform.Find("Canvas").GetComponent<Canvas>().enabled = false;
    }


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (playerInv.GetComponent<Canvas>().enabled == false & Input.GetMouseButtonDown(0)  & transform.position.x+width > mousePos.x & transform.position.x - width < mousePos.x & transform.position.y + height > mousePos.y & transform.position.y - height < mousePos.y) {
            transform.Find("Canvas").GetComponent<Canvas>().enabled = !transform.Find("Canvas").GetComponent<Canvas>().enabled;
            playerInv.GetComponent<Canvas>().enabled = !playerInv.GetComponent<Canvas>().enabled;
            playerInv.Find("itemEquip").GetComponent<Image>().enabled = !playerInv.Find("itemEquip").GetComponent<Image>().enabled;
            for (int i = 0; i < playerInv.Find("itemEquip").childCount; i++)
            {
                playerInv.Find("itemEquip").GetChild(i).GetComponent<Image>().enabled = !playerInv.Find("itemEquip").GetChild(i).GetComponent<Image>().enabled;

            }

        }
        if (Input.GetKeyUp(KeyCode.E) & transform.Find("Canvas").GetComponent<Canvas>().enabled == true) {
            transform.Find("Canvas").GetComponent<Canvas>().enabled = !transform.Find("Canvas").GetComponent<Canvas>().enabled;
            playerInv.GetComponent<Canvas>().enabled = !playerInv.GetComponent<Canvas>().enabled;
            playerInv.Find("itemEquip").GetComponent<Image>().enabled = !playerInv.Find("itemEquip").GetComponent<Image>().enabled;
            for (int i = 0; i < playerInv.Find("itemEquip").childCount; i++)
            {
                playerInv.Find("itemEquip").GetChild(i).GetComponent<Image>().enabled = !playerInv.Find("itemEquip").GetChild(i).GetComponent<Image>().enabled;

            }
            playerInv.GetComponent<Canvas>().enabled = !playerInv.GetComponent<Canvas>().enabled;
        }
    }
}
