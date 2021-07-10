using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bumpCount >= 2)
        {
            bumpCount = 0;
            // get the current scene name 
            string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
        }
    }

    int bumpCount = 0;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Scenery" && other.gameObject.tag != "Hit")
        {
            bumpCount++;
        }
        Debug.Log("You've Bumped into a thing " + bumpCount + " times.");
    }
}
