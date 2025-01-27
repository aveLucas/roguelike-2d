using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject Player;
    public float smoothSpeed;
    public Vector3 offset;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer(){
        if(Player){
        // Calculate the target position with the desired z-axis value.
            Vector3 targetPos = new Vector3(Player.transform.position.x + offset.x, Player.transform.position.y + offset.y, -10);

        // Use Vector3.Lerp to smoothly move the camera.
            transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
        }
    }
}
