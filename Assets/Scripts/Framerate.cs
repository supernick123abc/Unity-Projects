using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    [SerializeField] bool fpsLock = false;
    [SerializeField] int fps = 60;
    // Start is called before the first frame update
    
    void Awake () {
     if(fpsLock == true)
     {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = fps;
     }   
     else{
         Application.targetFrameRate = 0;
     }
     
 }
}
