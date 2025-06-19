using UnityEngine;

public class ForcefieldScript : MonoBehaviour
{
    public GameObject GameManager;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.CompareTag("Enemy"))
        {
            GameManager.SendMessage("AddScore");
            //add: if target has an hp script, -2hp
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.CompareTag("Enemy"))
        {
            GameManager.SendMessage("AddScore");
            collided.SendMessage("takedmg");
            //add: if target has an hp script, -2hp
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.CompareTag("Enemy"))
        {
            GameManager.SendMessage("AddScore");
            collided.SendMessage("takedmg");
            //add: if target has an hp script, -2hp
        }
    }
}
