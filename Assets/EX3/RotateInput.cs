using UnityEngine;

public class RotateInput: MonoBehaviour
{
    public float RotationSpeed = 0f;
    public float RotationValue = 0f;
    public bool reverseDirection = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (reverseDirection)
        {
            RotationValue -= RotationSpeed;
        }
        else { RotationValue += RotationSpeed; }
        
        transform.rotation=Quaternion.Euler(0,0,RotationValue);
    }
}
