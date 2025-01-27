using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.TextCore.Text;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("-PlayerFloats-")]
    public float Speed;
    public float JumpF;
    private float Hmovement;
    public float gravityScale;

    [Header("-PlayerBools-")]
    public bool isAlive;
    private bool FacingRight;
    public bool Crouching;
    public bool isGrounded;
    public bool onWall;

    [Header("-HealthBar-")]
    [SerializeField] private HealthBar HealthBarPrefab;
    private HealthBar healthBar;
    private float maxHealth = 100f;
    private float currentHealth;


    [Header("-References-")]
    public RangedAttack rangedAttack;
    Rigidbody2D rigidB;
    Animator anime;
    public Collider2D standingC;
    public Collider2D crouchingC;
    

    void Start()
    {
        
        currentHealth = maxHealth;

        // Instanciar barra de vida
        healthBar = Instantiate(HealthBarPrefab, transform.position + new Vector3(-340, 210, 0), Quaternion.identity);
        healthBar.transform.SetParent(GameObject.Find("PlayerUI").transform, false);
        healthBar.Initialize(maxHealth);

        rigidB = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        
        crouchingC.enabled = false;
    }

    
    void Update()
    {
        IsAliveVerification();

        Movement();
        Jump();
        Crouch();

        Flip();
        
        TestDmg();
        testAttack();
    }

    //Movimentação
    void Movement()
    {
        Hmovement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(Hmovement, 0, 0) * Speed * Time.deltaTime;
        anime.SetFloat("Walk", Math.Abs(Hmovement));

    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !Crouching)
        {
            
            rigidB.AddForce(new Vector2(0, JumpF) * JumpF);
        }
        if(Input.GetKeyDown(KeyCode.Space) && onWall){
            transform.position += new Vector3(0, gravityScale, 0) / 2 * Time.deltaTime;
            rigidB.AddForce(new Vector2(0, JumpF) * JumpF);
        }
        
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            Crouching = true;
            standingC.enabled = false;
            crouchingC.enabled = true;
            anime.SetBool("isCrouching", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Crouching = false;
            standingC.enabled = true;
            crouchingC.enabled = false;
            anime.SetBool("isCrouching", false);
        }
    }

    //Funções
    void Flip()
    {
        if(FacingRight && Hmovement > 0 || !FacingRight && Hmovement < 0){
            FacingRight = !FacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }

    void TestDmg()
    {
        
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(isAlive)
                {
                    TakeDamage(10);
                }
            }

    }
    void IsAliveVerification()
    {
        if(currentHealth > 0)
        {
            isAlive = true;
            //Debug.Log($"{currentHealth}");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Personagem morreu!");
        }
    }

    void testAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rangedAttack.Fire();
        }
    }

    //Colisões
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isGrounded = true;
        }
        if(collision.gameObject.layer == 7){
            onWall = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isGrounded = false;
        }
        if(collision.gameObject.layer == 7){
            onWall = false;
        }
    }
    
}