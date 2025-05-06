using DG.Tweening;
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
    public Transform firePoint;         // Ponto de origem do proj�til

    
    public void Fire()
    {
        
        player = FindObjectOfType<PlayerStatus>();

        if (player.currentMana >= manaCost) 
        {
            
            player.currentMana -= manaCost;
            player.manaBar.UpdateStatus(player.currentMana);
            playerPos = GameObject.Find("Player");
            firePoint = playerPos.transform;

            
            // Obt�m a posi��o do mouse no mundo 2D
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Garante que fique no mesmo plano

            // Calcula a dire��o do disparo
            Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

            // Instancia o proj�til
            
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Define a dire��o do proj�til
            projectile.GetComponent<Projectile>().SetDirection(shootDirection);
            projectile.GetComponent<Projectile>().canMove = true;
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
    
