using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class butScript : MonoBehaviour, IPointerClickHandler
{

    void change(bool setting) {
        for (int i = 1; i < 5; i++)
        {
            transform.parent.GetChild(i).GetComponent<Image>().enabled = setting;
            transform.parent.GetChild(i).GetComponent<Button>().enabled = setting;
            transform.parent.GetChild(i).GetChild(0).GetComponent<Text>().enabled = setting;
            transform.parent.GetChild(i).GetChild(0).GetComponent<Text>().enabled = setting;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if (transform.GetComponent<Image>().enabled == true)
            {

                if (transform.name == "start")
                {
                    string seedtext = transform.parent.Find("options").Find("Image").Find("seedInput").Find("Text").GetComponent<Text>().text;
                    int seed;
                    int.TryParse(seedtext, out seed);
                    if (seed != 0)
                    {
                        Random.InitState(seed);
                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if (transform.name == "options")
                {
                    change(false);
                    transform.Find("Image").GetComponent<Image>().enabled = !transform.Find("Image").GetComponent<Image>().enabled;
                    transform.Find("XButton").GetComponent<Image>().enabled = true;

                }
                else if (transform.name == "controls")
                {
                    change(false);
                    transform.Find("Image").GetComponent<Image>().enabled = !transform.Find("Image").GetComponent<Image>().enabled;
                    transform.Find("XButton").GetComponent<Image>().enabled = true;
                }
                else if (transform.name == "quit")
                {
                    Application.Quit();
                }

            }



        }
    }
}
