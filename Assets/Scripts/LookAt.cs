using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    // Drag another object onto it to make the camera look at it.
    public Transform target; 

// Rotate the camera every frame so it keeps looking at the target 
    void Update() 
    {
        transform.LookAt(target);
    }
}
