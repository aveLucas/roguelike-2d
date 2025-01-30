using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.TextCore.Text;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{

    [Header("-PlayerBools-")]
    public bool isAlive;

    [Header("-HealthBar-")]
    [SerializeField] private StatusBar HealthBarPrefab;
    public StatusBar healthBar; 
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("-ManaBar-")]
    [SerializeField] private StatusBar ManaBarPrefab;
    public StatusBar manaBar;
    public float maxMana = 100f;
    public float currentMana;

    void Start()
    {
        // Instanciar barra de vida
        currentHealth = maxHealth;
        healthBar = Instantiate(HealthBarPrefab, transform.position + new Vector3(215, -50, 0), Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("PlayerUI").transform, false);
        healthBar.Initialize(maxHealth);

        //Instanciar barra de mana
        currentMana = maxMana;
        manaBar = Instantiate(ManaBarPrefab, transform.position + new Vector3(215, -136, 0), Quaternion.identity);
        manaBar.transform.SetParent(GameObject.Find("PlayerUI").transform, false);
        manaBar.Initialize(maxMana);

    }

    
    void Update()
    {
        IsAliveVerification();
        TestDmg();

    }
    void IsAliveVerification()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
            //Debug.Log($"{currentHealth}");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateStatus(currentHealth);

        if (currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Personagem morreu!");
        }
    }

    void TestDmg()
    {
        
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(isAlive)
                {
                    TakeDamage(10);
                }
            }

    }

}