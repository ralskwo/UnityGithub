using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField] bool rotateFlag = false;
    [SerializeField] float rotateSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateFlag)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            if (period <= Mathf.Epsilon) return;

            float cycles = Time.time / period;

            const float tau = Mathf.PI * 2;
            float rawSinWave = Mathf.Sin(cycles * tau);

            movementFactor = (rawSinWave + 1f) / 2f;

            Vector3 offset = movementVector * movementFactor;
            transform.position = startingPosition + offset;
        }
    }
}
