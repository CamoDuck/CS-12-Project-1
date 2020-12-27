using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerItems : MonoBehaviour
{
    Transform swordEquip;
    Transform bowEquip;
    int UIpos = 0;

    void add() {
        int count = transform.Find("items").childCount + UIpos;
        for (int i = (0 + UIpos); i < count; i++)
        {
            Transform clone = Instantiate(transform.Find("default"));
            clone.GetComponent<Image>().sprite = transform.Find("items").GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite;
            clone.localScale = new Vector3(0.2f, 0.3f, 1);
            clone.GetComponent<Image>().enabled = true;
            clone.position = transform.Find("itemUI").position + new Vector3(-130 + (40 * (i % 7)), 80 - (40 * ((i - (i % 7)) / 7)), 0);
            clone.SetParent(transform.Find("itemUI"));
            transform.Find("items").GetChild(0).SetParent(clone);
            UIpos += 1;
        }
    }

    void Start() {
        swordEquip = transform.parent.Find("SwordRot").Find("Sword");
        bowEquip = transform.parent.Find("BowRot").Find("Bow");
        //Debug.Log(swordEquip.tag);
        //Debug.Log(bowEquip.tag);


        transform.Find("itemEquip").Find("Sword").GetComponent<Image>().sprite = swordEquip.GetComponent<SpriteRenderer>().sprite;
        transform.Find("itemEquip").Find("Bow").GetComponent<Image>().sprite = bowEquip.GetComponent<SpriteRenderer>().sprite;
        
        




    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) | Input.GetMouseButtonUp(0))
        {
            add();
        }
    }
}

    


