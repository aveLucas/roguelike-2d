using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{
    [Header("-PlayerBools-")]
    public bool isGrounded;
    public bool onWall;

    [Header("-PlayerColliders-")]
    public Collider2D standingC;
    public Collider2D crouchingC;

    
    //Colisões
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        if (collision.gameObject.layer == 8)
        {
            onWall = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
        }
        if (collision.gameObject.layer == 8)
        {
            onWall = false;
        }
    }
}
