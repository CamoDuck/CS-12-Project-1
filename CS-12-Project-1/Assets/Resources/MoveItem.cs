using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
       
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (transform.root.name == "Player")
            {
                string itemType = transform.GetChild(0).tag;
                if (itemType == "Sword" | itemType == "Bow")
                {

                    Transform current = transform.root.Find(itemType+"Rot");
                    Transform swap = transform.GetChild(0);
                    swap.name = itemType+"Rot";
                    transform.GetComponent<Image>().sprite = transform.parent.parent.Find("itemEquip").Find(itemType).GetComponent<Image>().sprite;
                    transform.parent.parent.Find("itemEquip").Find(itemType).GetComponent<Image>().sprite = swap.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                    swap.position = current.position;
                    current.SetParent(transform);
                    swap.SetParent(transform.root);
                }
            }
            else
            {
                transform.GetChild(0).SetParent(GameObject.Find("Player").transform.Find("Inventory").Find("items"));
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
