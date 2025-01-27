using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject player;
    public float damage;
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint;         // Ponto de origem do projétil

   
    public void Fire()
    {
        player = GameObject.Find("Player");
        firePoint = player.transform;
        // Instancia o projétil no ponto de origem
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
    
