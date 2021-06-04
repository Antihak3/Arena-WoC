using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
  
    public FloatingJoystick joystick;
    public CharacterController controller;
   
    Animator anim;
    public float speed;
    public float gravity;
    Vector3 moveDirection;
    public bool IsPanch = false;
    public bool IsPanch2 = false;
    public Transform curTarget;
    NavMeshAgent agentt;
    public float CD1 = 0;
    public Button CD_icon;

    public float CD2 = 0;
    public Button CD_icon2;

    public float CD3 = 0;
    public Button CD_icon3;

    public float CD4 = 0;
    public Button CD_icon4;

    PlayerStats stats;
    Vector2 joy;
    Vector2 joy2;

    void Start()
    {

        stats = GetComponent<PlayerStats>();
        agentt = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        curTarget = null;

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
                    curTarget = null;
                    anim.SetBool("forward", direction != Vector2.zero);
                   
                }

            CD1 -= Time.deltaTime;

            CD2 -= Time.deltaTime;

            CD3 -= Time.deltaTime;

            CD4 -= Time.deltaTime;


            if (CD1 > 0)
            {
                CD_icon.gameObject.SetActive(false);

            }
            else if (stats.Energy > 0.2f)
            {
                CD_icon.gameObject.SetActive(true);
            }

            if (CD2 > 0)
            {
                CD_icon2.gameObject.SetActive(false);

            }
            else if (stats.Energy > 0.4f)
            {
                CD_icon2.gameObject.SetActive(true);
            }

            if (CD3 > 0)
            {
                CD_icon3.gameObject.SetActive(false);

            }
            else if (stats.Energy > 0.6f)
            {
                CD_icon3.gameObject.SetActive(true);
            }

            if (CD4 > 0)
            {
                CD_icon4.gameObject.SetActive(false);

            }
            else if (stats.Energy > 0.9f)
            {
                CD_icon4.gameObject.SetActive(true);
            }
        }


        if (anim.GetBool("diedPl"))
        {
            StopCoroutine(FireAttack());
            StopCoroutine(shootAttack());
            StopCoroutine(shootAttack2());
            StopCoroutine(shootAttack3());
        }

    }

    public void attack1()
    {
        if (!IsPanch && !anim.GetBool("diedPl"))
        {

            if (CD1 < 0 && stats.Energy > 0.2f)
            {

                IsPanch2 = true;

                StartCoroutine(FireAttack());
                StopCoroutine(FireAttack());
                
            }
        }
    }


    IEnumerator FireAttack()
    {

        transform.LookAt(curTarget);
        stats.Energy = stats.Energy - 0.2f;
        CD1 = 1f;
        CD2 = 0.8f;
        CD3 = 0.8f;
        CD4 = 0.8f;

        anim.SetTrigger("attack1");
       
        yield return new WaitForSeconds(0.3f);
      
        transform.LookAt(curTarget);
        gameObject.GetComponentInChildren<tochkaFiree>().Attack1();

        
        StopCoroutine(FireAttack());
        IsPanch2 = false;
    }



    public void attack2()
    {
        if (!IsPanch && !anim.GetBool("diedPl"))
        {

            if (CD2 < 0 && stats.Energy > 0.4f)
            {

                IsPanch = true;

                StartCoroutine(shootAttack());
                StopCoroutine(shootAttack());
                
            }
        }
    }

    IEnumerator shootAttack()
    {
        transform.LookAt(curTarget);

        stats.Energy = stats.Energy - 0.4f;
        CD1 = 1.2f;
        CD2 = 1.2f;
        CD3 = 1.2f;
        CD4 = 1.2f;

        anim.SetTrigger("attack2");

        yield return new WaitForSeconds(0.7f);
        
       
        gameObject.GetComponentInChildren<tochkaFiree>().Attack2();

        yield return new WaitForSeconds(0.2f);
        IsPanch = false;

        StopCoroutine(shootAttack());

    }



    public void attack3()
    {
        if (!IsPanch && !anim.GetBool("diedPl"))
        {

            if (CD3 < 0 && stats.Energy > 0.6f)
            {

                IsPanch = true;

                StartCoroutine(shootAttack2());
                StopCoroutine(shootAttack2());
               
            }
        }
    }

    IEnumerator shootAttack2()
    {

        transform.LookAt(curTarget);
        stats.Energy = stats.Energy - 0.6f;
        CD1 = 2f;
        CD2 = 2f;
        CD3 = 2f;
        CD4 = 2f;

        anim.SetTrigger("attack3");
        yield return new WaitForSeconds(0.2f);
       
      
        gameObject.GetComponentInChildren<tochkaFiree>().UrFireBall31();
       yield return new WaitForSeconds(0.7f);
      
       
        gameObject.GetComponentInChildren<tochkaFiree>().Attack3();

        yield return new WaitForSeconds(0.2f);
        IsPanch = false;

        StopCoroutine(shootAttack2());

    }


    public void attack4()
    {
        if (!IsPanch && !anim.GetBool("diedPl"))
        {
            if (CD4 < 0 && stats.Energy > 0.9f)
            {
                IsPanch = true;
                StartCoroutine(shootAttack3());
                StopCoroutine(shootAttack3());

            }
        }
    }

    IEnumerator shootAttack3()
    {
        stats.Energy = stats.Energy - 0.9f;
        CD1 = 2f;
        CD2 = 2f;
        CD3 = 2f;
        CD4 = 5f;

        anim.SetTrigger("attack4");

        yield return new WaitForSeconds(0.8f);


        gameObject.GetComponentInChildren<tochkaFiree1>().Attack4();

        yield return new WaitForSeconds(0.4f);
        IsPanch = false;

        StopCoroutine(shootAttack3());

    }

}
