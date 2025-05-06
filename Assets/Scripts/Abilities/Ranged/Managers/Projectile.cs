using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;       // Velocidade do projétil
    public float maxDistance = 15f; // Distância máxima que o projétil pode percorrer
    private Vector3 startPosition;  // Posição inicial do projétil
    private Vector3 direction;
    public bool canMove;

    private void Start()
    {
        // Salva a posição inicial para calcular a distância percorrida
        startPosition = transform.position;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;

        // Calcula o ângulo para rotacionar o sprite corretamente
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void MoveProjectile()
    {
        if(canMove ==  true)
        {
            transform.position += direction * speed * Time.deltaTime;

        // Calcula a distância percorrida
        float traveledDistance = Vector3.Distance(startPosition, transform.position);
        Debug.Log($"{traveledDistance}");

        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
        }
        
    }
    private void Update()
    {

        // Move o projétil na direção em que está apontado
        MoveProjectile();
        
    }

    
}
