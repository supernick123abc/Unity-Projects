using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectHit : MonoBehaviour
{
    //Public material references for editor. Set object's normal and hit materials so that they can be changed dynamically for each object in the editor
    public Material normal;
    public Material hit;
   void OnCollisionEnter(Collision other) // Check if the object this script is attached to has collided with other collsion
   {
       if(other.gameObject.tag == "Player")
       {
            GetComponent<MeshRenderer>().material = hit; // Set material to defined hit material in editor
            gameObject.tag = "Hit";
            StartCoroutine(CollisionDelay()); // Start coroutine for material revert delay
       }
       
   }

   IEnumerator CollisionDelay()
   {
       yield return new WaitForSeconds(1.5f);
       GetComponent<MeshRenderer>().material = normal; // Revert material back to normal after wait
   }

   void OnTriggerEnter(Collider other) // Check if the object this script is attached to has collided with other collsion
   {
       if(other.gameObject.tag == "Player" && this.gameObject.tag == "Finish")
       {
            // get the current scene name 
            string sceneName = SceneManager.GetActiveScene().name;

            // load the same scene
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
       }
       
   }
}
