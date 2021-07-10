using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer render; 
    Rigidbody rigid;
    [SerializeField] float waitTime = 5.0f;


    IEnumerator DropperDelay()
   {
        yield return new WaitForSeconds(waitTime);
        render.enabled = true;
        rigid.useGravity = true; // Revert material back to normal after wait
        GetComponentInChildren<Projector>().enabled = true;
   }

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.enabled = false;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        StartCoroutine(DropperDelay());
        GetComponentInChildren<Projector>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
            
        }
}

    

