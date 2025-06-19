using UnityEngine;
using TMPro;

public class GameManagerAssignment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public GameObject Player;
    public GameObject Enemy;
    PlayerControls playercontrols;
    public float playerhp;
    public float spawnradius;
    public float CD;
    public float Timer=0f;
    public float anglerad;
    public float enemyx;
    public float enemyy;
    public Vector3 enemyposition;

    public float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HpText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        HpText = GameObject.Find("Hptext").GetComponent<TextMeshProUGUI>();
        playercontrols=GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        //instantiate objects in a sphere
        Timer -= Time.deltaTime;
        anglerad = Random.Range(0, 360) * Mathf.PI / 180;
        enemyx= Mathf.Cos(anglerad)*spawnradius;
        enemyy= Mathf.Sin(anglerad)*spawnradius;

         enemyposition= new Vector3 (enemyx,enemyy,0f);

        if (Timer<=CD) { 

            //Instantiate is a function that runs no matter what
            //here we're simply declaring an address to save the enemy so we can reference it in code
            GameObject obj = Object.Instantiate(Enemy, enemyposition ,Quaternion.Euler(0,0,anglerad));
            EnemyScript tempE = obj.GetComponent<EnemyScript>();
            tempE.Player = Player;
            Timer= 0;
        }
        scoreText.text = "Score:"+ score.ToString();

        HpText.text = "HP:" + playercontrols.Playerhp.ToString();

    }

    void EnemySpawner(GameObject prefab)
    {
        //set all the variables I need to for a correct enemy spawn
    }
    void AddScore()
    {
        score++;
    }
}
