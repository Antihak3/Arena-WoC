using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy2 : MonoBehaviour
{
    public float DistanceToFire;
    public float DistanceToWalk;
    public bool isFire;
    public float DelayBetweenAnim;
 
    public GameObject Player;
    NavMeshAgent agent;
    
    Animator anim;
    public float curDistance;


    public float maxHP = 100;
    public float curHP = 100;
    public Vector3 offset;
    

    public GameObject enemyHP;
    public EnemyHP HPslider;
    public soundMeneger sm;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        curHP = maxHP;
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject hp = Instantiate(enemyHP, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(GameObject.Find("Canvas").transform);
        HPslider = hp.GetComponentInChildren<EnemyHP>();
        hp.transform.SetAsFirstSibling();
        hp.GetComponentInChildren<EnemyHP>().maxHP = maxHP;
        hp.GetComponentInChildren<EnemyHP>().curHP = curHP;
        hp.GetComponentInChildren<EnemyHP>().Enemy = gameObject;
        hp.GetComponentInChildren<EnemyHP>().offset = offset;

       
    }


    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        curDistance = distance;

        if (10 > distance && Player.GetComponent<PlayerController>().curTarget == null)
        {
            Player.GetComponent<PlayerController>().curTarget = gameObject.transform;
        }
        

        if (!anim.GetBool("died"))
        {
            if (distance > DistanceToWalk)
            {
              
                anim.SetBool("fire", false);
                StopCoroutine(FireAttack());
                anim.SetBool("walk", false);
                return;

            }

            if (distance < DistanceToFire && distance < DistanceToWalk)
            {
                anim.SetBool("walk", false);
                transform.LookAt(Player.transform);
                if (!anim.GetBool("walk"))
                {
                    if (!isFire)
                    {

                        StartCoroutine(FireAttack());
                    }
                }
            }


            

            if (distance < DistanceToWalk && distance > DistanceToFire)
            {
                if (!anim.GetBool("fire"))
                {
                    anim.SetBool("walk", true);
                    agent.SetDestination(Player.transform.position);
                }
                    StopCoroutine(FireAttack());
                
            }


            if (anim.GetBool("walk"))
            {
                StopCoroutine(FireAttack());
            }


            }


    }


    public IEnumerator FireAttack()
    {
        if (!anim.GetBool("walk"))
        {
            isFire = true;
            anim.GetComponent<Animator>().SetBool("fire", true); 
            yield return new WaitForSeconds(0.3f);
            sm.PlaySound(4);
            yield return new WaitForSeconds(0.3f);

            gameObject.GetComponentInChildren<tochkaFiree>().Attack1();
            anim.SetBool("fire", false);
            yield return new WaitForSeconds(DelayBetweenAnim);
           
            isFire = false;
        }
    }


    public void Damage(float dmg)
    {
        HPslider.curHP = HPslider.curHP - dmg;
        sm.PlaySound(5);
    }


 }
