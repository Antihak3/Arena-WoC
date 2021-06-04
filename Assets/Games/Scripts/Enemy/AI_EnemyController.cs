using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_EnemyController : MonoBehaviour
{
    public float DistanceToWalk2;
    public float DistanceToFire;
    public float DistanceToWalk;
    public float DistanceToBite;
    public GameObject Player;
    NavMeshAgent agent;
    Animator anim;
    public float Fire_Attack;
    public float Bite_Attack;
    public float DelayBetweenAnim;

    public bool isFire;
   
    public bool isBite;

    public float curDistance;

    public GameObject enenmyHP;

    public EnemyHP HPslider;


    public float maxHP;
    public float curHP;
    public Vector3 offset;

    public GameObject BodyBloodFX;

    public Vector3 FXdistance;

    public int DamageG = 25;

   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject hp = Instantiate(enenmyHP, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(GameObject.Find("Canvas").transform);
        hp.transform.SetAsFirstSibling();
        hp.GetComponent<EnemyHP>().maxHP = maxHP;
        hp.GetComponent<EnemyHP>().curHP = curHP;
        hp.GetComponent<EnemyHP>().Enemy = gameObject;
        hp.GetComponent<EnemyHP>().offset = offset;
        HPslider = hp.GetComponent<EnemyHP>();
       
}


    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        curDistance = distance;

        if (20 > distance && Player.GetComponent<PlayerController>().curTarget == null)
        {
            Player.GetComponent<PlayerController>().curTarget = gameObject.transform;
        }



        if (!anim.GetBool("died"))
        {


            if (distance > DistanceToWalk2)
            {
                anim.SetBool("fire", false);
                anim.SetBool("walk", false);
                StopCoroutine(FireAttack());
                return;
            }


            if (distance < DistanceToWalk2 && distance > DistanceToFire)
            {
                anim.SetBool("walk", true);
                agent.SetDestination(Player.transform.position);
              
            }

            if (distance < DistanceToFire && distance > DistanceToWalk)
            {

                
                transform.LookAt(Player.transform);
                if (!isFire)
                {

                    StartCoroutine(FireAttack());

                }

            }


            if (distance < DistanceToWalk && distance > DistanceToBite)
            {

                anim.SetBool("walk", true);
                anim.SetBool("bite", false);
                anim.SetBool("fire", false);

                //Приследовать
                agent.SetDestination(Player.transform.position);

                //Кусать

                if (agent.transform.position == Player.transform.position)
                {
                    anim.SetBool("walk", false);
                }



            }

            if (distance < DistanceToWalk && distance < DistanceToBite)
            {


                //Приследовать 

                agent.SetDestination(Player.transform.position);

                transform.LookAt(Player.transform);
                if (agent.transform.position == Player.transform.position)
                {
                    anim.SetBool("walk", false);
                }

                if (!isBite)
                {
                    anim.SetBool("walk", false);
                    if (!anim.GetBool("walk"))
                    {
                        StartCoroutine(BiteAttack());
                    }
                    else
                    {
                        StopCoroutine(BiteAttack());
                    }

                }


            }



        }

        if (anim.GetBool("died"))
        {
            agent.GetComponent<NavMeshAgent>().stoppingDistance += 30f;

        }
    }

   

    IEnumerator FireAttack()
    {
        isFire = true;
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(0.2f);


        gameObject.GetComponentInChildren<tochkaFiree>().Attack1();


        yield return new WaitForSeconds(Fire_Attack);
        anim.SetBool("fire", false);
       
        yield return new WaitForSeconds(DelayBetweenAnim);
        isFire = false;
    }

    IEnumerator BiteAttack()
    {
        if (!anim.GetBool("walk"))
        {
            isBite = true;
            anim.SetBool("bite", true);
            yield return new WaitForSeconds(0.5f);
            Player.GetComponent<PlayerStats>().curLife -= DamageG;
            yield return new WaitForSeconds(Bite_Attack);
            anim.SetBool("bite", false);

            yield return new WaitForSeconds(DelayBetweenAnim);
            isBite = false;
        }
        else
        {
            StopCoroutine(BiteAttack());
        }
    }

    
  

    public void Damage(float dmg)
    {
        HPslider.curHP = HPslider.curHP - dmg;
        anim.SetBool("attdied", true);
        GameObject p = Instantiate(BodyBloodFX, transform.position + FXdistance , Quaternion.identity) as GameObject;

        p.GetComponent<ParticleSystem>().Play();
        Destroy(p, p.GetComponent<ParticleSystem>().duration);

        StartCoroutine(animattdied());
    }

    IEnumerator animattdied()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("attdied", false);
        StopCoroutine(animattdied());
    }
}

