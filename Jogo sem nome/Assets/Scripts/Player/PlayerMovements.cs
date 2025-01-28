using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovements : MonoBehaviour
{
    [Header("-PlayerFloats-")]
    public float Speed;
    public float JumpF;
    private float Hmovement;
    public float gravityScale;

    [Header("-PlayerBools-")]
    private bool FacingRight;
    public bool Crouching;


    [Header("-References-")]
    PlayerCollisions collisions;
    PlayerAbilities abilities;
    Rigidbody2D rigidB;
    Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        abilities = GetComponent<PlayerAbilities>();
        collisions = GetComponent<PlayerCollisions>();
        rigidB = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        collisions.crouchingC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Crouch();

        Flip();

        testAttack();
    }

    //Ataque
    void testAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilities.rangedAttack.Fire();
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && collisions.isGrounded && !Crouching)
        {

            rigidB.AddForce(new Vector2(0, JumpF) * JumpF);
        }
        if (Input.GetKeyDown(KeyCode.Space) && collisions.onWall)
        {
            transform.position += new Vector3(0, gravityScale, 0) / 2 * Time.deltaTime;
            rigidB.AddForce(new Vector2(0, JumpF) * JumpF);
        }

    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && collisions.isGrounded)
        {
            Crouching = true;
            collisions.standingC.enabled = false;
            collisions.crouchingC.enabled = true;
            anime.SetBool("isCrouching", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Crouching = false;
            collisions.standingC.enabled = true;
            collisions.crouchingC.enabled = false;
            anime.SetBool("isCrouching", false);
        }
    }

    //Funções
    void Flip()
    {
        if (FacingRight && Hmovement > 0 || !FacingRight && Hmovement < 0)
        {
            FacingRight = !FacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1;
            transform.localScale = ls;
        }
    }
}
