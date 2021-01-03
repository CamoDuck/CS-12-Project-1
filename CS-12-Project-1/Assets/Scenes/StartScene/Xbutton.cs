using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Xbutton : MonoBehaviour, IPointerClickHandler
{
    void change(bool setting)
    {
        for (int i = 1; i < 5; i++)
        {
            transform.root.GetChild(i).GetComponent<Image>().enabled = setting;
            transform.root.GetChild(i).GetComponent<Button>().enabled = setting;
            transform.root.GetChild(i).GetChild(0).GetComponent<Text>().enabled = setting;
            transform.root.GetChild(i).GetChild(0).GetComponent<Text>().enabled = setting;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            change(true);
            transform.parent.Find("Image").GetComponent<Image>().enabled = false;
            transform.GetComponent<Image>().enabled = false;

        }
    }



}