using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    
    [SerializeField] private float maxDuration;
    [SerializeField] private float activeDuration;

    private void Update()
    {
        for (activeDuration = 0; activeDuration < maxDuration; activeDuration++)
        {
            
            //Destroy(gameObject);
        }
    }
}
