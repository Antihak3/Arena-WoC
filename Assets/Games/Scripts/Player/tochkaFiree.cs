using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tochkaFiree : MonoBehaviour
{

  

    public GameObject fireBall;
    public Vector3 FireDistance;
    public GameObject FXfireBall;
    public Vector3 fxFireballDistance;

    public GameObject fireBall2;
    public Vector3 FireDistance2;
    public GameObject FXfireBall2;
    public Vector3 fxFireballDistance2;

    public GameObject fireBall3;
    public Vector3 FireDistance3;
    public GameObject FXfireBall3;
    public Vector3 fxFireballDistance3;

    public GameObject FXfireBall31;
    public Vector3 fxFireballDistance31;

    void UrFireBall()
    {
        GameObject fb = Instantiate(fireBall, transform.position + FireDistance, transform.rotation);

    }

  

   public void Attack1()
    {
        UrFireBall();

        GameObject p = Instantiate(FXfireBall, transform.position + fxFireballDistance, transform.rotation) as GameObject;

        p.GetComponent<ParticleSystem>().Play();

        Destroy(p, p.GetComponent<ParticleSystem>().duration);
    }



    void UrFireBall2()
    {
        GameObject fb = Instantiate(fireBall2, transform.position + FireDistance2, transform.rotation);

    }



    public void Attack2()
    {
        UrFireBall2();

        GameObject p = Instantiate(FXfireBall2, transform.position + fxFireballDistance2, transform.rotation) as GameObject;

        p.GetComponent<ParticleSystem>().Play();

        Destroy(p, p.GetComponent<ParticleSystem>().duration);
    }



    void UrFireBall3()
    {
        GameObject fb = Instantiate(fireBall3, transform.position + FireDistance3, transform.rotation);

    }



    public void Attack3()
    {
        UrFireBall3();

        GameObject p = Instantiate(FXfireBall3, transform.position + fxFireballDistance3, transform.rotation) as GameObject;

        p.GetComponent<ParticleSystem>().Play();

        Destroy(p, p.GetComponent<ParticleSystem>().duration);
    }

    public void UrFireBall31()
    {
        GameObject p = Instantiate(FXfireBall31, transform.position + fxFireballDistance3, transform.rotation) as GameObject;

        p.GetComponent<ParticleSystem>().Play();

        Destroy(p, p.GetComponent<ParticleSystem>().duration);

    }


   

}
