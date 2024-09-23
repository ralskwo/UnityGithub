using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xValue = 1.0f;
    [SerializeField] float yValue = 1.0f;
    [SerializeField] float zValue = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xValue,yValue,zValue);
    }
}
