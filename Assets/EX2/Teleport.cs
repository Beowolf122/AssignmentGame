using JetBrains.Annotations;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 positions =new Vector3(15, 15, 0);
        transform.position = positions;

        SpriteRenderer thiscolor;
        thiscolor =GetComponent<SpriteRenderer>();
        thiscolor.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
