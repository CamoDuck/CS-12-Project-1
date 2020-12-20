using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillMap : MonoBehaviour {
    Dictionary<string, float> spawns = new Dictionary<string, float>();

    void create() {
        foreach (KeyValuePair<string, float> item in spawns) {
            
            //Debug.Log(Random.Range(0, (int)Mathf.Round(1 / item.Value))); //float gets rounded fown always when turedn to int so 9.9999 turned into 9
            while (Random.Range(0, (int)Mathf.Round(1 / item.Value)) == 0 ) {
                Debug.Log(item.Key);
                GameObject clone = Instantiate(Resources.Load(item.Key)) as GameObject;
                clone.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            }
        }
    }

    void Start() {
        spawns["BowEnemy"] = 0.25f;
        spawns["SwordEnemy"] = 0.25f;
        //spawns["NecroEnemy"] = 0.1f;
        spawns["Chest"] = 0.1f;
        spawns["Turret"] = 0.1f;

        create();
    }


}
