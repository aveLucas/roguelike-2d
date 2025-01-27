using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject player;
    public float damage;
    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform firePoint;         // Ponto de origem do proj�til

   
    public void Fire()
    {
        player = GameObject.Find("Player");
        firePoint = player.transform;
        // Instancia o proj�til no ponto de origem
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
    
