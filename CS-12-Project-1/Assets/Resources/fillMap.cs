using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillMap : MonoBehaviour {
    Dictionary<string, int> spawns = new Dictionary<string, int>();

    void createRandom() {
        foreach (KeyValuePair<string, int> item in spawns) {
            while (Random.Range(0, item.Value) == 0 ) {  
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
        spawns["Chest"] = 10;
        spawns["Turret"] = 10;

        createRandom();
    }


}
