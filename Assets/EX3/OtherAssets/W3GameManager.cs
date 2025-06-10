using UnityEngine;

public class W3GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject coin;
    public GameObject player;
    public Vector2 coinSpawnRate = new Vector2(2f, 3f);

    public float maxSpawnRate = 5f;
    public float minSpawnRate = 1f;
    public float timeForMaxSpawn = 60f;

    public float cameraX = 10;
    public float cameraY = 5;
    public float angleOffset = 20f;

    float timer = 0;
    float spawnTimer;
    float coinTimer = 0;
    



    private void Update() {
        timer += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0) {
            SpawnBall();

            float calculatedSpawnRate = Mathf.Lerp(maxSpawnRate, minSpawnRate, timer / timeForMaxSpawn);
            spawnTimer = calculatedSpawnRate;
        }

        coinTimer -= Time.deltaTime;
        if(coinTimer <= 0) {
            SpawnCoin();
            coinTimer = Random.Range(coinSpawnRate.x, coinSpawnRate.y);
        }
    }

    void SpawnBall() {
        float xPos = 0;
        float yPos = 0;
        if(Random.value < 0.5f) {
            if (Random.value < 0.5f) {
                xPos = cameraX;
            }
            else {
                xPos = -cameraX;
            }
            yPos = Random.Range(-cameraY, cameraY);
        }
        else {
            if (Random.value < 0.5f) {
                yPos = cameraY;
            }
            else {
                yPos = -cameraY;
            }
            xPos = Random.Range(-cameraX, cameraX);
        }

        Vector3 pos = new Vector3(xPos, yPos, 0);
        Vector3 dirToPlayer = player.transform.position - pos;
        Vector3 moveDir = Quaternion.Euler(0, 0, Random.Range(-angleOffset, angleOffset)) * dirToPlayer;
        Instantiate(ball, pos, Quaternion.identity).GetComponent<W3Ball>().SetDir(moveDir);
    }
    void SpawnCoin() {
        float xPos = Random.Range(-cameraX+5, cameraX-5);
        float yPos = Random.Range(-cameraY+2, cameraY-2);
        Vector3 pos = new Vector3(xPos, yPos, 0);
        Instantiate(coin, pos, Quaternion.identity);
    }
}
