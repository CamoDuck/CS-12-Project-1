using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    float xSpeed;
    float ySpeed;
    float speed = 5f;
    float sprint = 1;
    Transform bow;
    Transform sword;

    void inventory() {
        Transform inventory = transform.Find("Inventory");
        inventory.GetComponent<Canvas>().enabled = !inventory.GetComponent<Canvas>().enabled;
    
    }

    void disableChild(Transform thing, bool option) {
        thing.GetComponent<SpriteRenderer>().enabled = option;
        for (int x = 0; x < thing.childCount; x++) {
            thing.GetChild(x).GetComponent<SpriteRenderer>().enabled = option;

        }
    }

    void Start() {
        bow = transform.Find("BowRot");
        sword = transform.Find("SwordRot");

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            ySpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.W)) {
            ySpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            ySpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.S)) {
            ySpeed += speed;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            xSpeed += speed;
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            xSpeed += -speed;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            xSpeed += -speed;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            xSpeed += speed;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Debug.Log("run1");
            disableChild(sword, true);
            disableChild(bow, false);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Debug.Log("run2");
            disableChild(sword, false);
            disableChild(bow, true);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = 2f;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            sprint = 1;
        
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            inventory();
        }



            transform.position += new Vector3(xSpeed*sprint, ySpeed*sprint, 0) * Time.deltaTime; 
    }
}
