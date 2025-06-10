using UnityEngine;

public class EXPAND : MonoBehaviour
{
    float expandrate = 1f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expandrate += .01f;
        transform.localScale  = new Vector3(expandrate,expandrate, 1);
    }
}
