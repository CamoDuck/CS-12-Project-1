using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap3 : MonoBehaviour {

    List<string> weaponList = new List<string> { "fireBowRot", "fireSwordRot", "iceBowRot", "iceSwordRot" };
    List<string> potionList = new List<string> {"speedPot","maxhealthPot","healthPot"};
    List<List<GameObject>> map = new List<List<GameObject>>();
    int tot = 0;
    Vector3 floorsize;


    void makeShop(Vector2 Entrance) {
        Transform shopEnter = map[(int)Entrance.x][(int)Entrance.y].transform;

        for (int i = 0; i < 3; i++)
        {
            Transform clone = (Instantiate(Resources.Load("itemDisplay")) as GameObject).transform;
            if (shopEnter.GetChild(0).name == "wall+x")
            {
                clone.position = new Vector3(shopEnter.position.x - floorsize.x * 3, shopEnter.position.y + (floorsize.y*(i-1) * 1.25f), shopEnter.position.z - 1);
            }
            else if (shopEnter.GetChild(0).name == "wall-x")
            {
                clone.position = new Vector3(shopEnter.position.x + floorsize.x * 3, shopEnter.position.y + (floorsize.y * (i - 1) * 1.25f), shopEnter.position.z - 1);
            }
            else if (shopEnter.GetChild(0).name == "wall+y")
            {
                clone.position = new Vector3(shopEnter.position.x + (floorsize.x * (i - 1)*1.25f), shopEnter.position.y - floorsize.y * 3, shopEnter.position.z - 1);
            }
            else if (shopEnter.GetChild(0).name == "wall-y")
            {
                clone.position = new Vector3(shopEnter.position.x + (floorsize.x * (i - 1) * 1.25f), shopEnter.position.y + floorsize.y * 3, shopEnter.position.z - 1);
            }
            Transform item;
            if (i == 0)
            {
                clone.GetChild(0).GetComponent<TextMesh>().text = "Cost: " + Random.Range(1000, 5001) + " Gold";
                item = (Instantiate(Resources.Load("Chest Items/" + weaponList[Random.Range(0, weaponList.Count)])) as GameObject).transform;
                item.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (i == 1)
            {
                clone.GetChild(0).GetComponent<TextMesh>().text = "Cost: " + Random.Range(500, 1001) + " Gold";
                item = (Instantiate(Resources.Load("Chest Items/" + potionList[Random.Range(0, potionList.Count)])) as GameObject).transform;
                item.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else {
                clone.GetChild(0).GetComponent<TextMesh>().text = "Cost: " + Random.Range(100, 501) + " Gold";
                item = (Instantiate(Resources.Load("Chest Items/mysteryPot") as GameObject)).transform;
                item.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            item.SetParent(clone);
            item.localPosition = new Vector3(0, 0, -1);
            
        }
    }



    Vector2 makeRoom(List<List<GameObject>> map, int lastx, int lasty, int sizeX, int sizeY) {
        Vector2 direction = rand();
        //Debug.Log("check:" + map[lastx + (int)direction.x][lasty + (int)direction.y]);
        /*
        while (map[lastx + (int)direction.x][lasty + (int)direction.y] == null)
        {
            direction = rand();
        }
        */


        Vector2 change;
        Vector2 offset;
        //Debug.Log("lastx: " + lastx + "lasty: " + lasty);
        bool check = true;
        if (direction.x == 0) {
            change = new Vector2(1, direction.y);
            offset = new Vector2(-((int)(sizeX/2)+1), 0);
            //Debug.Log(-(int)(sizeX / 2) + "xsize/2");
        }
        else
        {
            change = new Vector2(direction.x, 1);
            offset = new Vector2(0, -((int)(sizeY / 2)+1));
            //Debug.Log(-(int)(si zeY / 2) + "ysize /2");
        }
        for (int x = 1; x < sizeX+1; x++) {
            for (int y = 1; y < sizeY+1; y++) {
                //Debug.Log("gamer1");
                //Debug.Log(sizeY);
                //Debug.Log("y: " + lasty + "+(" + y + "*" + change.y + ")-" + offset.y);
                //Debug.Log("x: " + (int)(lastx + (x * change.x) - offset.x) + "y: " + (int)(lasty + (y * change.y) - offset.y));
                if (map[(int)(lastx + (x*change.x)+offset.x)] [(int)(lasty + (y*change.y)+offset.y)] != null) {
                    check = false;
                    //Debug.Log("nopers");
                    break;
                }
                //Debug.Log("gamer2");
            }
            if (check == false) {
                break;
            }
        }

        if (check == false)
        {
            while (map[lastx + (int)direction.x][lasty + (int)direction.y] == null)
            {
                direction = rand();
            }
            return makeRoom(map, lastx + (int)direction.x, lasty + (int)direction.y, sizeX, sizeY);
        }
        else
        {
           // Debug.Log("yessir x: " + lastx + "Y: " + lasty);
            for (int x = 1; x < sizeX+1; x++)
            {
                for (int y = 1; y < sizeY+1; y++)
                {
                    GameObject last = map[lastx][lasty];
                    Vector3 lastsize = last.GetComponent<Renderer>().bounds.extents;
                    map[(int)(lastx + (x * change.x) + offset.x)][(int)(lasty + (y * change.y) + offset.y)] = Instantiate(Resources.Load("Floor")) as GameObject;
                    GameObject now = map[(int)(lastx + (x * change.x) + offset.x)][(int)(lasty + (y * change.y) + offset.y)];
                    //now.name = "X: " + (int)(lastx + (x * change.x) + offset.x) + "Y: " + (int)(lasty + (y * change.y) + offset.y) + "boss x:" + x + "y: " +y;
                    now.name = "FloorC";
                    Vector3 nowsize = now.GetComponent<Renderer>().bounds.extents;
                    now.transform.position = last.transform.position + new Vector3((nowsize.x + lastsize.x) * (change.x * x + offset.x), (nowsize.y + lastsize.y) * (change.y * y + offset.y), 0);
                    if (x == 1) {
                        wall(now.transform, -floorsize.x*change.x, 0, 0, "wall+x");
                    }
                    if (x == sizeX) {
                        wall(now.transform, floorsize.x*change.x, 0, 0, "wall-x");

                    }
                    if (y == 1) {
                        wall(now.transform, 0, -floorsize.y*change.y, 90, "wall+y");

                    }
                    if (y == sizeY) {
                        wall(now.transform, 0, floorsize.y * change.y, 90, "wall+y");


                    }

                }
            }
            Transform last1 = map[lastx][lasty].transform;
            Transform now1 = map[lastx + (int)direction.x][lasty + (int)direction.y].transform;
            if (last1.position.x - now1.position.x > 0) {
                Destroy(last1.Find("wall-x").gameObject);
            
            }
            else if(last1.position.x - now1.position.x < 0) {
                Destroy(last1.Find("wall+x").gameObject);

            }
            else if (last1.position.y - now1.position.y > 0)
            {
                Destroy(last1.Find("wall-y").gameObject);

            }
            else if (last1.position.y - now1.position.y < 0)
            {
                Destroy(last1.Find("wall+y").gameObject);

            }

            map[lastx + (int)direction.x][lasty + (int)direction.y].transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            map[lastx + (int)direction.x][lasty + (int)direction.y].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            return new Vector2(lastx + direction.x, lasty + direction.y);

        }
    
    }

    /*
    void bossroom(List<List<GameObject>> map, int lastx, int lasty)
    {
        Vector2 coord = rand();
        Vector2 coordnext = coord;
        if (coord.x == 0)
        {
            coord = new Vector2(1, coord.y);
        }
        else {
            coord = new Vector2(coord.x, 1);

        }
        int sizeX = 5;
        int sizeY = 5;
        bool check = true;
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                if (map[lastx + ((int)coord.x * (x + 1))][lasty + ((int)coord.y * (y + 1))] != null)
                {
                    check = false;
                    break;
                }

            }
            if (check == false)
            {
                Debug.Log("oofers");
                break;

            }

        }
        if (check == false)
        {
            Debug.Log("nopers");
            bossroom(map, lastx + (int)coordnext.x, lasty + (int)coordnext.y);


        }
        else
        {
            Debug.Log("we in");
            for (int x = 0; x < sizeX; x++) //change for loop to negative and posative increment instead
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Debug.Log("X: " + lastx + " XI: " + ((int)coord.x * (x + 1) ) + "Y: " + lasty + " XI: " + ((int)coord.y * (y + 1)));
                    Debug.Log("X: " + (lastx +((int)coord.x * (x + 1))) + "Y: " + (lasty+ ((int)coord.y * (y + 1))));
                    GameObject last = map[lastx][lasty];
                    Vector3 lastsize = last.GetComponent<Renderer>().bounds.extents;
                    map[lastx + ((int)coord.x * (x + 1))][lasty + ((int)coord.y * (y + 1))] = Instantiate(Resources.Load("Floor")) as GameObject;
                    GameObject now = map[lastx + ((int)coord.x * (x + 1))][lasty + ((int)coord.y * (y + 1))];
                    now.name = "X: " + (lastx + ((int)coord.x * (x + 1))) + "Y: " + (lasty + ((int)coord.y * (y + 1))) + "boss";
                    //now.transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 1);
                    Vector3 nowsize = now.GetComponent<Renderer>().bounds.extents;
                    //map[xcoord][ycoord].transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20, 100), 1);
                    map[lastx + ((int)coord.x * (x + 1))][lasty + ((int)coord.y * (y + 1))].transform.position = last.transform.position + new Vector3((nowsize.x + lastsize.x) * (coord.x*x), (nowsize.y + lastsize.y) * (coord.y*y), 0);




                }
            }
        }
    }


    */

    void wall(Transform wallParent, float offsetX, float offsetY, int rot ,string wallName) {
        GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
        //wall.name = wallName;
        wall.transform.parent = wallParent;
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / floorsize.y, 1);
        wall.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        wall.transform.position = new Vector3((wallParent.transform.position.x + offsetX), (wallParent.transform.position.y + offsetY), 2);

        if (wall.transform.localPosition.x > 0)
        {
            wall.name = "wall+x";
        }
        else if (wall.transform.localPosition.x < 0)
        {
            wall.name = "wall-x";

        }
        else if (wall.transform.localPosition.y > 0)
        {
            wall.name = "wall+y";

        }
        else if (wall.transform.localPosition.y < 0) {
            wall.name = "wall-y";
        
        }


        //Debug.Log("x: " + wall.transform.localPosition.x + "Y: " + wall.transform.localPosition.y);
    }




    void makeWall(GameObject now, GameObject last, Vector3 nowsize, Vector2 coord) {
        if (coord.x == -1) {
            Transform wall = last.transform.Find("wall-x");
            if (wall) {
                Destroy(wall.gameObject);
            }
        }
        else {
            wall(now.transform, floorsize.x, 0, 0, "wall+x");
            /*
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall+x";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y/nowsize.y, 1);
            wall.transform.position = new Vector3((now.transform.position.x + nowsize.x), (now.transform.position.y), 1);
            //Debug.Log(wall.transform.localScale + "x+");
            */
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
            wall(now.transform, -floorsize.x, 0, 0, "wall-x");
            /*
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall-x";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            wall.transform.position = new Vector3((now.transform.position.x - nowsize.x), (now.transform.position.y), 1);
            //Debug.Log(wall.transform.localScale + "x-");
            */
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
            wall(now.transform, 0, floorsize.y, 90, "wall+y");
            /*
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall+y";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            //Debug.Log(wall.transform.localScale + "y+");
            wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            wall.transform.position = new Vector3((now.transform.position.x), (now.transform.position.y + nowsize.y), 1);
            */
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
            wall(now.transform, 0, -floorsize.y, 90, "wall-y");
            /*
            GameObject wall = Instantiate(Resources.Load("Wall")) as GameObject;
            wall.name = "wall-y";
            wall.transform.parent = now.transform;
            wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.GetComponent<Renderer>().bounds.extents.y / nowsize.y, 1);
            wall.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            wall.transform.position = new Vector3((now.transform.position.x), (now.transform.position.y - nowsize.y), 1);
            //Debug.Log(wall.transform.localScale + "y-");
            */
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
                //now.name = "X:"+xcoord+"Y:" + ycoord;
                //now.transform.localScale = new Vector3(Random.Range(1, 3), Random.Range(1, 3), 1);
                Vector3 nowsize = now.GetComponent<Renderer>().bounds.extents;
                //map[xcoord][ycoord].transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20, 100), 1);
                map[xcoord][ycoord].transform.position = last.transform.position + new Vector3((nowsize.x + lastsize.x) * coord.x, (nowsize.y + lastsize.y) * coord.y, 0);
                map[xcoord][ycoord].name = "Floor" + num;
                GameObject dark = Instantiate(Resources.Load("Dark")) as GameObject;
                dark.transform.parent = now.transform;
                dark.transform.position = new Vector3(now.transform.position.x, now.transform.position.y, now.transform.position.z - 2);
                makeWall(now, last, nowsize, coord);
                generate(map, 25, 25, num - 1);
            }
            else if (map[xcoord][ycoord].name != ("Floor" + num + 1) & map[xcoord][ycoord].name != "FloorC")
            {
                generate(map, xcoord, ycoord, num);
            }
            else
            {
                generate(map, lastx, lasty, num);
            }
        }
    }



    void Start() {
        for (int x = 0; x < 51; x++) {
            List<GameObject> L = new List<GameObject>();
            for (int y = 0; y < 51; y++) {

                L.Add(null);
            }
            map.Add(L);
        }

        map[25][25] = GameObject.Find("start");
        floorsize = map[25][25].transform.GetComponent<Renderer>().bounds.extents;

        generate(map, 25, 25, 20);
        makeShop(makeRoom(map, 25, 25, 3, 3));
        generate(map, 25, 25, 20);
        generate(map, 25, 25, 20);
        makeShop(makeRoom(map, 25, 25, 3, 3));
        generate(map, 25, 25, 20);
        generate(map, 25, 25, 20);
        Vector2 bossEnter = makeRoom(map, 25, 25, 5, 5);

        GameObject clone = Instantiate(Resources.Load("bossEntrance")) as GameObject;
        clone.name = "FloorC";
        clone.transform.position = map[(int)bossEnter.x][(int)bossEnter.y].transform.position;
        map[(int)bossEnter.x][(int)bossEnter.y].transform.GetChild(0).SetParent(clone.transform);
        Destroy(map[(int)bossEnter.x][(int)bossEnter.y].gameObject);
        map[(int)bossEnter.x][(int)bossEnter.y] = clone;
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