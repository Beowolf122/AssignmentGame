using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject Player;
    public GameObject Bullet;
    public float Timer;
    public float enemyspd = 0.5f;
    public Vector3 enemyposition = new Vector3(0, 0, 0);
    public Vector3 playerposition = new Vector3(0, 0, 0);
    public Vector3 Distance = new Vector3(0, 0, 0);
    public int enemyhp = 2;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // add movement. Then if have time, add unique pathing, or enemy speed
        // Use a rigidbody to add force instead of transform.position. Or use a transform.up

        playerposition = Player.transform.position;
        enemyposition = gameObject.transform.position;
        Distance = (playerposition - enemyposition) / 10;
        if (Distance.x < 1 && Distance.x > 0) { Distance.x = 1; }
        if (Distance.x > -1 && Distance.x < 0) { Distance.x = -1; }
        if (Distance.y < 1 && Distance.y > 0) { Distance.y = 1; }
        if (Distance.y > -1 && Distance.y < 0) { Distance.y = -1; }
        transform.position += Distance * Time.deltaTime;

        float X = Mathf.Atan2(-Distance.y, -Distance.x);
        float Y = X * Mathf.Rad2Deg;

        if (enemyhp <= 0) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
        if (collidedObject.CompareTag("Bullet"))
        {
            enemyhp -= 1;
        }
        if (collidedObject.CompareTag("Blade"))
        {
            enemyhp -= 2;
        }
        if (collidedObject.CompareTag("Forcefield"))
        {
            enemyhp -= 1;
            collidedObject.transform.position = new Vector3(Random.Range(8,10), Random.Range(-1,1), 0 );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //code for blade or other trigger objects goes here
        if (collision.gameObject.CompareTag("Blade"))
        {
            enemyhp -= 2;
        }
        if (collision.CompareTag("Forcefield"))
        {
            enemyhp -= 1;
            collision.transform.position = new Vector3(Random.Range(8, 10), Random.Range(-1, 1), 0);
        }
    }
    private void takedmg()
    {
        enemyhp -= 1;
    }
}
