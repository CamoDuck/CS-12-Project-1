using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveItem : MonoBehaviour, IPointerClickHandler
{

    MovePlayer playerClass;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
       
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (transform.root.name == "Player")
            {
                string itemType = transform.GetChild(0).tag;
                if (itemType == "Sword" | itemType == "Bow")
                {

                    Transform current = transform.root.Find(itemType + "Rot");
                    Transform swap = transform.GetChild(0);
                    swap.name = itemType + "Rot";
                    transform.GetComponent<Image>().sprite = transform.parent.parent.Find("itemEquip").Find(itemType).GetComponent<Image>().sprite;
                    transform.parent.parent.Find("itemEquip").Find(itemType).GetComponent<Image>().sprite = swap.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                    swap.position = current.position;
                    current.SetParent(transform);
                    swap.SetParent(transform.root);
                }
                else if (itemType == "Potion") {
                    if (transform.GetChild(0).GetChild(0).name == "healthPot")
                    {
                        playerClass.addHealth();

                    }
                    else if (transform.GetChild(0).GetChild(0).name == "maxhealthPot")
                    {
                        playerClass.addmaxHealth();


                    }
                    else if (transform.GetChild(0).GetChild(0).name == "speedPot")
                    {
                        playerClass.addSpeed();

                    }
                    else if (transform.GetChild(0).GetChild(0).name == "mysteryPot")
                    {
                        switch (Random.Range(0,6))
                        {
                            case 0:
                                playerClass.addSpeed();
                                break;
                            case 1:
                                playerClass.addHealth();
                                break;
                            case 2:
                                playerClass.addmaxHealth();
                                break;
                            case 3:
                                playerClass.addSpeed(-1);
                                break;
                            case 4:
                                playerClass.addHealth(-1);
                                break;
                            case 5:
                                playerClass.addmaxHealth(-1);
                                break;
                        }
                    }
                        Destroy(gameObject);
                }
            }
            else
            {
                transform.GetChild(0).SetParent(GameObject.Find("Player").transform.Find("Inventory").Find("items"));
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        playerClass = transform.root.GetComponent<MovePlayer>(); 
    }

    void Update()
    {
        
    }
}
