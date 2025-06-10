using UnityEngine;
using TMPro;
public class W3ScoreKeeper : MonoBehaviour
{
    int score = 0;
    TMP_Text scoreText;

    private void Start() {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore() {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
