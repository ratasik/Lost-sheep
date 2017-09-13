using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float predkoscPoruszania = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float predkoscBiegania = 7.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public float verticalVelocity;
    private bool isGrounded = true;
    public float turningRate = 30f;
    
   
   
    
   
    

    void Update()
    {



        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            verticalVelocity = -1;
              moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= predkoscPoruszania;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            verticalVelocity = jumpSpeed;
        }
        if (Input.GetKeyDown("left shift"))
        {

            predkoscPoruszania += predkoscBiegania;
        }

        else if (Input.GetKeyUp("left shift"))
        {

            predkoscPoruszania -= predkoscBiegania;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(controller.isGrounded && hit.normal.y < 0.7f)
        {
            jumpSpeed = 0.0F;
        }else if (controller.isGrounded && hit.normal.y > 0.7f)
        {
            jumpSpeed = 11.0F;
        }
    }
}








