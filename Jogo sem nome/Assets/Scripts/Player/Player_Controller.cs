using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.TextCore.Text;
using UnityEngine.Events;

public class Player_Controller : MonoBehaviour
{
    //Variables
    [Header("-Floats-")]
    public float Speed;
    public float JumpF;
    private float Hmovement;
    public float gravityScale;
    [Header("-Bools-")] 
    private bool FacingRight;
    
    public bool Crouching;
    public bool isGrounded;
    public bool onWall;
    Rigidbody2D rigidB;
    Animator anime;
    public Collider2D standingC;
    public Collider2D crouchingC;
    

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        
        crouchingC.enabled = false;
    }

    
    void Update()
    {
        Movement();
        Jump();
        Flip();
        Crouch();
    }

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



    void Flip()
    {
        if(FacingRight && Hmovement > 0 || !FacingRight && Hmovement < 0){
            FacingRight = !FacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
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