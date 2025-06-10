using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class BlockControls : MonoBehaviour
{
    float rotateposition = 0f;
    float rotatespeed = 1f;
    float Hexpand = 1f;
    float Hexpandrate = .4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)))
        {
            rotateposition -= rotatespeed;

            transform.rotation = Quaternion.Euler(0f, 0f, rotateposition);
        }
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)))
        { rotateposition += rotatespeed;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateposition);
        }
        if (( Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)))
            { Hexpand += Hexpandrate;
            transform.localScale = new Vector3(Hexpand, 1f, 1f);
        }

        if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)))
        {
           Hexpand-=Hexpandrate;
            transform.localScale = new Vector3(Hexpand, 1f, 1f);
        }
        if (Hexpand > 10) { Hexpand = 10; }
        if (Hexpand < 1) {  Hexpand = 1; }
            
    }
}
