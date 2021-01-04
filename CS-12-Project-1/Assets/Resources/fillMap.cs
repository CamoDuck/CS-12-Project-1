using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillMap : MonoBehaviour {
    Dictionary<string, int> spawns = new Dictionary<string, int>();

    void createRandom() {
        foreach (KeyValuePair<string, int> item in spawns) {
            
            //Debug.Log(Random.Range(0, (int)Mathf.Round(1 / item.Value))); //float gets rounded fown always when turedn to int so 9.9999 turned into 9
            while (Random.Range(0, item.Value) == 0 ) {
                //Debug.Log(item.Key);  
                GameObject clone = Instantiate(Resources.Load(item.Key)) as GameObject;
                Vector3 tranSize = transform.GetComponent<SpriteRenderer>().bounds.extents;
                Vector3 cloneSize = clone.GetComponent<SpriteRenderer>().bounds.extents;
                clone.transform.position = new Vector3(transform.position.x - tranSize.x + Random.Range(cloneSize.x*2, (tranSize.x*2)-cloneSize.x), transform.position.y - tranSize.y + Random.Range(cloneSize.y*2, (tranSize.y*2)-cloneSize.y), 1);
            }
        }
    }

    void Start() {
        spawns["BowEnemy"] = 4;
        spawns["SwordEnemy"] = 4;
        //spawns["NecroEnemy"] = 10;
        spawns["Chest"] = 10;
        spawns["Turret"] = 10;

        createRandom();
    }


}
