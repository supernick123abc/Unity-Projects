using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] AudioClip engineThrustAudio;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationSpeed = 100f;

    [SerializeField] ParticleSystem rocketMainParticles;
    [SerializeField] ParticleSystem rocketLeftParticles;
    [SerializeField] ParticleSystem rocketRightParticles;

    Rigidbody rb;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineThrustAudio);
            }
            if(!rocketMainParticles.isPlaying)
            {
                rocketMainParticles.Play();            
            }
        }
        else
            {
                audioSource.Stop();
                rocketMainParticles.Stop();
            }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
            if(!rocketRightParticles.isPlaying)
            {
                rocketRightParticles.Play();            
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
            if(!rocketLeftParticles.isPlaying)
            {
                rocketLeftParticles.Play();            
            }
        }
        else
        {
            rocketRightParticles.Stop();
            rocketLeftParticles.Stop();
        }
    }


    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation to allow manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation for physics to take over
    }
}
