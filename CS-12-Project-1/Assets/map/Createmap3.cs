using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap3 : MonoBehaviour {

    List<List<GameObject>> map = new List<List<GameObject>>();
    int tot = 0;

    void makeWall(GameObject now, GameObject last, Vector3 nowsize, Vector2 coord) {
        if (coord.x == -1) {
            Transform wall = last.transform.Find("wall-x");
            if (wall) {
                Destroy(wall.gameObject);
            }
        }
        else {
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall+x";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y/nowsize.y, 1);
            wall.transform.position = new Vector3((now.transform.position.x + nowsize.x), (now.transform.position.y), 1);
            //Debug.Log(wall.transform.localScale + "x+");
        }
        if (coord.x == 1)
        {
            Transform wall = last.transform.Find("wall+x");
            if (wall)
            {
                Destroy(wall.gameObject);
            }
        }
        else
        {
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall-x";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            wall.transform.position = new Vector3((now.transform.position.x - nowsize.x), (now.transform.position.y), 1);
            //Debug.Log(wall.transform.localScale + "x-");
        }
        if (coord.y == -1)
        {
            Transform wall = last.transform.Find("wall-y");
            if (wall)
            {
                Destroy(wall.gameObject);
            }
        }
        else
        {
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall+y";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            //Debug.Log(wall.transform.localScale + "y+");
            wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            wall.transform.position = new Vector3((now.transform.position.x), (now.transform.position.y + nowsize.y), 1);
        }
        if (coord.y == 1)
        {
            Transform wall = last.transform.Find("wall+y");
            if (wall)
            {
                Destroy(wall.gameObject);
            }
        }
        else
        {
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall-y";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            wall.transform.position = new Vector3((now.transform.position.x), (now.transform.position.y - nowsize.y), 1);
            //Debug.Log(wall.transform.localScale + "y-");
        }

    }

    void printL(List<List<GameObject>> L) {
        for (int x = 0; x < L.Count; x++)
        {
            string str = "";
            for (int y = 0; y < L[x].Count; y++) {
                if (L[x][y] == null) {
                    str = str + "----|";
                }
                else {
                    str = str + L[x][y].name + "|";
                }
            }
            Debug.Log(str);
        }
    }
    //have a chance to stop a path and start over at start for walls and floors
    Vector2 rand() {
        int rand = Random.Range(0,4);
        switch (rand) {
            case 0:
                return new Vector2(1, 0);
            case 1:
                return new Vector2(-1, 0);
            case 2:
                return new Vector2(0, 1);
            default:
                return new Vector2(0, -1);
        }
    }
    //repeat starting form start to make more than one path
    void generate(List<List<GameObject>> map, int lastx, int lasty, int num) {
        tot += 1;
        //Debug.Log(tot);
        if (num != 0) {
            Vector2 coord = rand();
            int xcoord = (int)coord.x + lastx;
            int ycoord = (int)coord.y + lasty;
            GameObject last = map[lastx][lasty];
            Vector3 lastsize = last.GetComponent<Renderer>().bounds.extents;
            
            if (map[xcoord][ycoord] == null)
            {
                map[xcoord][ycoord] = Instantiate(Resources.Load("Floor")) as GameObject;
                GameObject now = map[xcoord][ycoord];
                //now.transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 1);
                Vector3 nowsize = now.GetComponent<Renderer>().bounds.extents;
                //map[xcoord][ycoord].transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20, 100), 1);
                map[xcoord][ycoord].transform.position = last.transform.position + new Vector3((nowsize.x + lastsize.x) * coord.x, (nowsize.y + lastsize.y) * coord.y, 0);
                map[xcoord][ycoord].name = "Floor" + num;
                GameObject dark = Instantiate(Resources.Load("Dark")) as GameObject;
                dark.transform.parent = now.transform;
                dark.transform.position = new Vector3(now.transform.position.x, now.transform.position.y, now.transform.position.z-2);
                makeWall(now, last, nowsize, coord);
                generate(map, 10, 10, num - 1);
            }
            else if (map[xcoord][ycoord].name != ("Floor" + num + 1)) {
                generate(map, xcoord, ycoord, num);
            }
            else
            {
                generate(map, lastx, lasty, num);
            }
        }
    }



    void Start() {
        for (int x = 0; x < 21; x++) {
            List<GameObject> L = new List<GameObject>();
            for (int y = 0; y < 21; y++) {

                L.Add(null);
            }
            map.Add(L);
        }

        map[10][10] = GameObject.Find("start");
        generate(map, 10, 10, 50);
        //printL(map);

    }



}














/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap3 : MonoBehaviour {

    List<List<GameObject>> map = new List<List<GameObject>>();
    int tot = 0;
    void printL(List<List<GameObject>> L) {
        for (int x = 0; x < L.Count; x++)
        {
            string str = "";
            for (int y = 0; y < L[x].Count; y++) {
                if (L[x][y] == null) {
                    str = str + 0 + ", ";
                }
                else {
                    str = str + L[x][y].name + ", ";
                }
            }
            Debug.Log(str);
        }
    }

    Vector2 rand() {
        int rand = Random.Range(0,4);
        switch (rand) {
            case 0:
                return new Vector2(1, 0);
            case 1:
                return new Vector2(-1, 0);
            case 2:
                return new Vector2(0, 1);
            default:
                return new Vector2(0, -1);
        }
    }
    //repeat starting form start to make more than one path
    void generate(List<List<GameObject>> map, int lastx, int lasty, int num) {
        tot += 1;
        //Debug.Log(tot);
        if (num != 0) {
            Vector2 coord = rand();
            int xcoord = (int)coord.x + lastx;
            int ycoord = (int)coord.y + lasty;
            if (map[xcoord][ycoord] == null)
            {
                map[xcoord][ycoord] = Instantiate(Resources.Load("Floor")) as GameObject;
                //map[xcoord][ycoord].transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20, 100), 1);
                map[xcoord][ycoord].transform.position = map[lastx][lasty].transform.position + new Vector3((map[xcoord][ycoord].transform.localScale.x + map[lastx][lasty].transform.localScale.x) * coord.x * 0.085f, (map[xcoord][ycoord].transform.localScale.y + map[lastx][lasty].transform.localScale.y) * coord.y * 0.085f, 0);
                map[xcoord][ycoord].name = "Floor" + num;
                generate(map, 10, 10, num - 1);
            }
            else if (map[xcoord][ycoord].name != ("Floor" + num + 1)) {
                generate(map, xcoord, ycoord, num);
            }
            else
            {
                generate(map, lastx, lasty, num);
            }
        }
    }



    void Start() {
        for (int x = 0; x < 21; x++) {
            List<GameObject> L = new List<GameObject>();
            for (int y = 0; y < 21; y++) {

                L.Add(null);
            }
            map.Add(L);
        }


        map[10][10] = GameObject.Find("start");
        generate(map, 10, 10, 20);
        //printL(map);

    }



}

*/