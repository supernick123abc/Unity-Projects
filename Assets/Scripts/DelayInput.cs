using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerControls>().enabled = false;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while(true) 
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<PlayerControls>().enabled = true;
        }
    }

}
