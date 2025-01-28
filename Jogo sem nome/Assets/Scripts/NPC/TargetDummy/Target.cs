using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private BulletType slashPrefab;

    [Header("-HealthBar-")]
    [SerializeField] private EnemyHealthBar HealthBarPrefab;
    private EnemyHealthBar healthBar;
    private float  maxHealth = 100f;
    private float currentHealth;

    
    void Start()
    {
        currentHealth = maxHealth;

        // Instanciar barra de vida
        healthBar = Instantiate(HealthBarPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("DummyCanvas").transform, false);
        healthBar.Initialize(maxHealth);
    }

    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            TakeDamage(slashPrefab.damage);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
            
            Debug.Log("Personagem morreu!");
        }
    }
}

