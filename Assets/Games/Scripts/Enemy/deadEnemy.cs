using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadEnemy : MonoBehaviour
{
    Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetBool("died"))
        {
            StartCoroutine(deadan());
        }

    }
    IEnumerator deadan()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
        StopCoroutine(deadan());
    }

}
