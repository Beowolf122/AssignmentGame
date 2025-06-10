using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public GameObject Bullet;
    public float PlayerRotation;
    public float PlayerRotSpd=5;
    public float Playerhp = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, PlayerRotation);
        if (Input.GetKey(KeyCode.LeftArrow)) { PlayerRotation += PlayerRotSpd * Time.deltaTime; }
        if (Input.GetKey(KeyCode.RightArrow)) { PlayerRotation -= PlayerRotSpd * Time.deltaTime; }

        if (Playerhp <= 0) { Destroy(Player); }

        /*transform.localRotation*/

       if ((Input.GetKeyDown(KeyCode.Space)))
        {
            float ran = Random.Range(-1f, 1f);
            // up= "local up". Will go "forward" in its own direction.
            // transform.rotation will just have it equal to the player's rotation
            Instantiate(Bullet, transform.localPosition + transform.up, transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.CompareTag("Enemy"))
        {
            Playerhp -= 1;
        }
    }
}
