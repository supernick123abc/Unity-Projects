using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelChangeDelay = 1f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                StartFinishSequence();
                break;
            
            default:
                StartCrashSequence();
                break;
        }

    }

    void StartCrashSequence()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel", levelChangeDelay);
    }

    void StartFinishSequence()
    {
        GetComponent<RocketMovement>().enabled = false;
        Invoke("LoadNextLevel", levelChangeDelay);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel Collected!");
                other.gameObject.SetActive(false);
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}

