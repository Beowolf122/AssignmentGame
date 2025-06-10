using UnityEngine;

public class W2GoalCollider : MonoBehaviour {
    [SerializeField] GameObject winText;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ball") {
            winText.SetActive(true);
        }
    }
}
