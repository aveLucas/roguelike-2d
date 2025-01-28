using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offSet;

    private void Awake()
    {
        camera = FindObjectOfType<Camera>();
        target = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void Initialize(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.transform.position + offSet;
    }
}
