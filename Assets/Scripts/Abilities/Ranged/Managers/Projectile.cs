using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;       // Velocidade do proj�til
    public float maxDistance = 15f; // Dist�ncia m�xima que o proj�til pode percorrer
    private Vector3 startPosition;  // Posi��o inicial do proj�til
    private Vector3 direction;
    public bool canMove;

    private void Start()
    {
        // Salva a posi��o inicial para calcular a dist�ncia percorrida
        startPosition = transform.position;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;

        // Calcula o �ngulo para rotacionar o sprite corretamente
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void MoveProjectile()
    {
        if(canMove ==  true)
        {
            transform.position += direction * speed * Time.deltaTime;

        // Calcula a dist�ncia percorrida
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

        // Move o proj�til na dire��o em que est� apontado
        MoveProjectile();
        
    }

    
}
