using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;       // Velocidade do projétil
    public float maxDistance = 15f; // Distância máxima que o projétil pode percorrer
    private Vector3 startPosition;  // Posição inicial do projétil

    private void Start()
    {
        // Salva a posição inicial para calcular a distância percorrida
        startPosition = transform.position;
    }

    private void Update()
    {

        // Move o projétil na direção em que está apontado
        
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        // Calcula a distância percorrida
        float traveledDistance = Vector3.Distance(startPosition, transform.position);
        Debug.Log($"{traveledDistance}");
        
        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    
}
