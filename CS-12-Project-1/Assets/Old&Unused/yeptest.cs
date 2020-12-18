using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeptest : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Draws a wireframe sphere in the Scene view, fully enclosing
    // the object.
    void OnDrawGizmosSelected()
    {
        // A sphere that fully encloses the bounding box.
        Vector3 center = rend.bounds.center;
        float radius = rend.bounds.extents.magnitude;
        Debug.Log(rend.bounds.extents + " rad:" + radius);
        Debug.Log("print");

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(center, radius);
    }
}
