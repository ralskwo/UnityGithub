using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits;

    private void Start()
    {
        hits = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Hit") 
        { 
            hits++;
            Debug.Log($"dumps time: {hits}"); // , {transform.name}, {collision.transform.name}");
        } 
    }
}
