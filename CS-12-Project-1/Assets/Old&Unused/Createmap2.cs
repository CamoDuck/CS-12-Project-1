using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createmap2 : MonoBehaviour {
    class Node {
        public GameObject room;
        public Node up;
        public Node down;
        public Node left;
        public Node right;
    }


    // too hard & inefficient use 2d list instead 
    void updateNode(Node node) {
        try {
            if (node.up != null) {
                node.up.left.down.right = node;
                node.left = node.up.left.down;
                node.up.right.down.left = node;
                node.right = node.up.right.down;
            }
            else if (node.down != null)
            {
                node.down.left.up.right = node;
                node.left = node.down.left.up;
                node.down.right.up.left = node;
                node.right = node.down.right.up;
            }
            else if (node.right != null) {

            }
            else {

            }
        }
        catch { 
        
        }
    
    }

    Node makeRoom(Node node, Node prevNode, Vector3 direction) {
        node.room = Instantiate(Resources.Load("Floor")) as GameObject;
        node.room.transform.localScale = new Vector3(Random.Range(20, 100), Random.Range(20, 100), 1);
        node.room.transform.position = prevNode.room.transform.position + new Vector3((node.room.transform.localScale.x * direction.x), (node.room.transform.localScale.y * direction.y), (node.room.transform.localScale.z * direction.z));

        return node;
    }
    Node generate(Node node) {
        int rand = Random.Range(0, 4);
        if (rand == 0 & node.up == null) {
            node.up.down = node;
            makeRoom(node.up, node, new Vector3(1, 0, 0));
        }
        else if (rand == 1 & node.down == null) {
            node.down.up = node;
            makeRoom(node.down, node, new Vector3(-1, 0, 0));
        }
        else if (rand == 2 & node.right == null) {
            node.right.left = node;
            makeRoom(node.right, node, new Vector3(0, 1, 0));
        }
        else if (rand == 3 & node.left == null) {
            node.left.right = node;
            makeRoom(node.left, node, new Vector3(0, -1, 0));
        }
        return node; //placeholder to stop error
    }

    void Start() {
        Node head = new Node();
        head.room = GameObject.Find("start");
        head = generate(head);
    }

    void Update() {
        
    }
}
