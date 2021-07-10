using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [SerializeField] public static bool ghostMode = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    void GhostModeOn()
    {
        if(ghostMode == true)
        {
            Material ghostMaterial = Resources.Load("Materials/GhostMaterial", typeof(Material)) as Material;
            GetComponent<Renderer>().material = ghostMaterial; 

            Physics.IgnoreLayerCollision(6, 9, true);
        }
        else
        {
            Material playerMaterial = Resources.Load("Materials/PlayerMaterial", typeof(Material)) as Material;
            GetComponent<Renderer>().material = playerMaterial; 

            Physics.IgnoreLayerCollision(6, 9, false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GhostModeOn();
    }
}
