using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject GameManager;
    public float timer;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime; //makes it unaffected by frame rate
        timer += Time.deltaTime;
        if (timer>= 5) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag("Enemy"))
        {
            GameManager.SendMessage("AddScore");
            Destroy(gameObject);

        }
        
    }

}
