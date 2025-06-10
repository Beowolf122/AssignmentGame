using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float currentHealth = 50f;
    public float healthRegen = .1f;
    public float poisonDmg = .5f;
    public float maxHealth = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = currentHealth - poisonDmg + healthRegen;
        if (currentHealth < 0) {currentHealth = 0;}
        if (currentHealth > maxHealth)
        {currentHealth = maxHealth;}
        Debug.Log(currentHealth);
    }
}
