using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;       // Velocidade do proj�til
    public float maxDistance = 15f; // Dist�ncia m�xima que o proj�til pode percorrer
    private Vector3 startPosition;  // Posi��o inicial do proj�til

    private void Start()
    {
        // Salva a posi��o inicial para calcular a dist�ncia percorrida
        startPosition = transform.position;
    }

    private void Update()
    {

        // Move o proj�til na dire��o em que est� apontado
        
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        // Calcula a dist�ncia percorrida
        float traveledDistance = Vector3.Distance(startPosition, transform.position);
        Debug.Log($"{traveledDistance}");
        
        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    
}
