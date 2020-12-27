using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    float xSpeed;
    float ySpeed;
    float speed = 5f;
    float sprint = 1;

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
            disableChild(transform.Find("SwordRot"), true);
            disableChild(transform.Find("BowRot"), false);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Debug.Log("run2");
            disableChild(transform.Find("SwordRot"), false);
            disableChild(transform.Find("BowRot"), true);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint = 4f;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            sprint = 1;
        
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            disableChild(transform.Find("SwordRot"), false);
            disableChild(transform.Find("BowRot"), false);
            inventory();
        }



            transform.position += new Vector3(xSpeed*sprint, ySpeed*sprint, 0) * Time.deltaTime; 
    }
}
