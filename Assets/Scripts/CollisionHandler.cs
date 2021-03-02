using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelChangeDelay = 1f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip finishAudio;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;


    AudioSource audioSource;

    bool isTransitioning = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning){ return; }

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

        void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("Fuel Collected!");
                other.GetComponent<AudioSource>().Play();
                other.GetComponent<Renderer>().enabled = false;
                other.GetComponent<SphereCollider>().enabled = false;
                break;
        }
    }

    void StartFinishSequence()
        {
            isTransitioning = true;
            audioSource.Stop();
            audioSource.PlayOneShot(finishAudio);
            finishParticles.Play();
            GetComponent<RocketMovement>().enabled = false;
            Invoke("LoadNextLevel", levelChangeDelay);
        }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
        crashParticles.Play();
        GetComponent<RocketMovement>().enabled = false;
        Invoke("ReloadLevel", levelChangeDelay);
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

