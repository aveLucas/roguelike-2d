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

    public float baseDamage = 10f;
    public float cooldownTime = 0.5f;
    public float cooldownTimer = 0f;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (cooldownTimer <= 0)
        //{
            if (Input.GetMouseButtonDown(0))
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
        
        animator.SetTrigger("Attack");

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRange, enemyLayer);
        //Collider2D[] enemiesInLine = Physics2D.OverlapAreaAll(attackOrigin.position, attackEnd.position, enemyLayer);

        foreach (var enemy in enemiesInRange)
        {
            enemy.GetComponent<NPCStatus>().TakeDamage(baseDamage);
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
