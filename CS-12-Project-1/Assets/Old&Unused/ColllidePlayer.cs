using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColllidePlayer : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("enter");
    }

    void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("exit");
    }
}
