using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tochkaFiree1 : MonoBehaviour
{

    public GameObject fireBall4;
    public Vector3 FireDistance4;
    public GameObject FXfireBall4;
    public Vector3 fxFireballDistance4;

   
    void UrFireBall4()
    {
        GameObject fb = Instantiate(fireBall4, transform.position + FireDistance4, transform.rotation);

    }
    public void Attack4()
    {
        UrFireBall4();

        GameObject p = Instantiate(FXfireBall4, transform.position + fxFireballDistance4, transform.rotation) as GameObject;

        p.GetComponentInChildren<ParticleSystem>().Play();

        Destroy(p, p.GetComponentInChildren<ParticleSystem>().duration);
    }

}
