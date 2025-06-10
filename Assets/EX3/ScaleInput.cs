using System.Xml.Schema;
using UnityEngine;

public class ScaleW3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float scaleSpeed = .1f;
    public float xValue = 0;
    public bool reverseScale=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reverseScale)
        { xValue += scaleSpeed; }
        else { xValue -= scaleSpeed; }
        transform.localScale = new Vector3(xValue, 1, 1);


    }
}
