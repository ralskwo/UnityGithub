using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); 
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
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {

            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.forward);
        }
        else if ((Input.GetKey(KeyCode.D)))
        {
            ApplyRotation(Vector3.back);
        }
    }

    void ApplyRotation(Vector3 dir)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(dir * rotationThrust * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
