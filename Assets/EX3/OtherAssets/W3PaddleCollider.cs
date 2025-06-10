using UnityEngine;

public class W3PaddleCollider : MonoBehaviour
{
    public GameObject loseScreen; 
    W3ScoreKeeper scoreKeeper;
    bool lost = false;
    private void Start() {
        scoreKeeper = FindFirstObjectByType<W3ScoreKeeper>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ball") {
            loseScreen.SetActive(true); // Show lose screen
            Destroy(collision.gameObject); // Destroying ball
            lost = true; // Setting lose bolean for coin collisions
        }

        // Collected coin
        if(collision.gameObject.tag == "Coin" && !lost) {
            scoreKeeper.AddScore(); // Add to score
            Destroy(collision.gameObject); // Destroy coin
        }
    }
}