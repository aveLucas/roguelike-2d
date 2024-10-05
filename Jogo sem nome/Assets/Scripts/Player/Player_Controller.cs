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
    public float Speed;
    public float JumpF;
    private float Hmovement;
    private bool isJumping;
    private bool FacingRight;
    private bool Crouching;
    Rigidbody2D rigidB;
    Animator anime;
    public Collider2D standingC;

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
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
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isJumping)
        {
            Crouching = true;
            standingC.enabled = false;
            anime.SetBool("isCrouching", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Crouching = false;
            standingC.enabled = true;
            anime.SetBool("isCrouching", false);
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3){
            isJumping = true;
        }
    }
    
}