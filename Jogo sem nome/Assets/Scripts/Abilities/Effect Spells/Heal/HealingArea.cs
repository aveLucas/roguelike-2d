using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealingArea : MonoBehaviour
{
    public GameObject player;
    public GameObject spellPrefab;
    [SerializeField] private Transform castPosition;
    public float healingValue;
    

    public void Cast()
    {
        player = GameObject.Find("Player");
        castPosition = player.transform;
        GameObject spell = Instantiate(spellPrefab, castPosition.position, castPosition.rotation);
    }
}
