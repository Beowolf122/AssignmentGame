using JetBrains.Annotations;
using UnityEngine;

public class Rotation : MonoBehaviour {
    float rotateposition = 0f;
    float rotatespeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        rotateposition -= rotatespeed;
        
        transform.rotation=Quaternion.Euler(0f, 0f, rotateposition);
    }
}

