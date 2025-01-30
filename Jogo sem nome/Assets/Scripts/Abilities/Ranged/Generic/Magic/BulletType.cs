using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    public GameObject playerPos;
    public PlayerStatus player;
    public GameObject projectilePrefab;

    public float damage;
    public float manaCost;
    public Transform firePoint;         // Ponto de origem do projétil

    
    public void Fire()
    {

        player = FindObjectOfType<PlayerStatus>();
        if (player.currentMana >= manaCost) 
        {
            
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            playerPos = GameObject.Find("Player");
            firePoint = playerPos.transform;
            // Instancia o projétil no ponto de origem
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            
        }

        
    }
    public void DealDamage(GameObject target)
    {
        var tar = target.GetComponent<NPCStatus>();
        if (tar != null)
        {
            tar.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log($"Colidiu com: {other}");
        DealDamage(other.gameObject);
        Destroy(gameObject);

    }
}
    
