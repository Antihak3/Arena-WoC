using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController1Gorod : MonoBehaviour
{
  
    public FloatingJoystick joystick;
    public CharacterController controller;
   
    Animator anim;
    public float speed;
    public float gravity;
    Vector3 moveDirection;
    public bool IsPanch = false;
    NavMeshAgent agentt;
    Vector2 joy;
    Vector2 joy2;

    void Start()
    {
        agentt = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
       

    }

    void Update()
    {
        if (!anim.GetBool("diedPl"))
        {
            if (!IsPanch)
            {
                joy = joystick.input;
            }
            else
            {
                joy = joy2;
            }

            Vector2 direction = joy;




            if (controller.isGrounded)
                {
                    moveDirection = new Vector3(direction.x, 0, direction.y);

                    Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                    transform.rotation = targetRotation;

                    moveDirection = moveDirection * speed;
                
                }

                moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
                controller.Move(moveDirection * Time.deltaTime);

                if (anim.GetBool("forward") != (direction != Vector2.zero))
                {
                  
                    anim.SetBool("forward", direction != Vector2.zero);
                   
                }
        }
    }
}
