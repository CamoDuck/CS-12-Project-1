using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChestMoveItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("yett");
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            transform.GetChild(0).SetParent(GameObject.Find("Player").transform.Find("Inventory").Find("items"));
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(name + " Game Object Right Clicked!");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
