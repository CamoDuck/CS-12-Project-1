using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerItems : MonoBehaviour
{
    Transform swordEquip;
    Transform bowEquip;

    void Start() {
        swordEquip = transform.parent.Find("SwordRot").Find("Sword");
        bowEquip = transform.parent.Find("BowRot").Find("Bow");
        Debug.Log(swordEquip.tag);
        Debug.Log(bowEquip.tag);


        transform.Find("itemEquip").Find("Sword").GetComponent<Image>().sprite = swordEquip.GetComponent<SpriteRenderer>().sprite;
        transform.Find("itemEquip").Find("Bow").GetComponent<Image>().sprite = bowEquip.GetComponent<SpriteRenderer>().sprite;

        for (int i=0; i<transform.Find("items").childCount; i++) {
                Transform clone = Instantiate(transform.Find("itemEquip").Find("Sword"));
                clone.GetComponent<Image>().sprite = transform.Find("items").GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite;
                clone.localScale = new Vector3(0.2f, 0.3f, 1);
                clone.position = transform.Find("itemUI").position + new Vector3(-130 + (40 * (i%7)), 80 - (40*((i-(i%7))/7)), 0);
                clone.SetParent(transform.Find("itemUI"));
        }




    }
}

    


