using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatus : MonoBehaviour
{
    [Header("-HealthBar-")]
    [SerializeField] private NPCHealthBar HealthBarPrefab;
    private NPCHealthBar healthBar;
    private float maxHealth = 100f;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        // Instanciar barra de vida
        healthBar = Instantiate(HealthBarPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("DummyCanvas").transform, false);
        healthBar.Initialize(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {

            Destroy(gameObject);

            Debug.Log("Personagem morreu!");
        }
    }
}
