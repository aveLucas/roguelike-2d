using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    public PlayerStatus player;
    public GameObject spellPrefab;
    [SerializeField] private Transform castPosition;
    public float healingValue = 5f;
    

    public void Cast()
    {
        player = FindObjectOfType<PlayerStatus>();
        castPosition = player.transform;
        GameObject spell = Instantiate(spellPrefab, castPosition.position, castPosition.rotation);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        StartCoroutine(Heal());
    }

    IEnumerator Heal()
    {
        float seconds = 1f;

        while (player.currentHealth < player.maxHealth)
        {

            player.currentHealth = Mathf.Min(player.currentHealth + healingValue, player.maxHealth);
            player.healthBar.UpdateHealth(player.currentHealth);

            yield return new WaitForSeconds(seconds);
                
            Debug.Log($"heal: {healingValue}");            
        }
        
    }
}
