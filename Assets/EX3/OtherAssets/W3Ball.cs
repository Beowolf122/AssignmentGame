using UnityEngine;

public class W3Ball : MonoBehaviour
{
    public float speed = 3f;
    Vector3 dir;
    public void SetDir(Vector3 newDir) {
        dir = newDir.normalized;
        transform.up = newDir.normalized;
    }

    // Update is called once per frame
    void Update() {
        transform.position += dir * speed * Time.deltaTime;
        if(transform.position.magnitude > 100f) {
            Destroy(gameObject);
        }
    }
}
