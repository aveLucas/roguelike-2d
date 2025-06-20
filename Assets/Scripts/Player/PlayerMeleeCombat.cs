using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackOrigin;
    //public Transform attackEnd;
    public float attackRange;
    public LayerMask enemyLayer;

    public bool canAttack = true;

    public float baseDamage = 10f;
    public float cooldownTime = 0.5f;
    public float cooldownTimer = 0f;

    public InventoryManager inventoryManager;

    public GameObject weaponObj;

    void Start()
    {
        animator = GetComponent<Animator>();
        inventoryManager = GameObject.FindAnyObjectByType<InventoryManager>();


    }

    // Update is called once per frame
    void Update()
    {
        //if (cooldownTimer <= 0)
        //{
        if (Input.GetMouseButtonDown(0) && canAttack)
            {
                Attack();
            }
        //    cooldownTimer = cooldownTime;
        //}
        //else
        //{
        //    cooldownTimer -= Time.deltaTime;
        //}
    }


    void Attack()
    {
        Weapon equipedWeapon = inventoryManager.GetEquipedWeapon(true);
        animator.SetTrigger("Attack");

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRange, enemyLayer);
        //Collider2D[] enemiesInLine = Physics2D.OverlapAreaAll(attackOrigin.position, attackEnd.position, enemyLayer);
        if (equipedWeapon != null)
        {
            Debug.Log($"Item usado: {equipedWeapon.name}");
            SpriteRenderer weaponSr = weaponObj.GetComponent<SpriteRenderer>();
            weaponSr.sprite = equipedWeapon.image;
            foreach (var enemy in enemiesInRange)
            {

                enemy.GetComponent<NPCStatus>().TakeDamage(baseDamage + equipedWeapon.damage);  
            }
        }
        else
        {
            SpriteRenderer weaponSr = weaponObj.GetComponent<SpriteRenderer>();
            weaponSr.sprite = null;
            foreach (var enemy in enemiesInRange)
            {

                enemy.GetComponent<NPCStatus>().TakeDamage(baseDamage);
            }
            
        }

    }

    private void OnDrawGizmos()
    {
        if (attackOrigin == null) return;
        //if (attackEnd == null) return;

        Gizmos.DrawWireSphere(attackOrigin.position, attackRange);
        //Gizmos.DrawLine(attackOrigin.position, attackEnd.position);
    }
}
