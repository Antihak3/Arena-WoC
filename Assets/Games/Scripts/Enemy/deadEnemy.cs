using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadEnemy : MonoBehaviour
{
    Animator anim;
    public GameObject Coins;
    bool isDied = true;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetBool("died") && isDied)
        {
            GetComponent<CharacterController>().enabled = false;
            SpawnCoin();
            StartCoroutine(deadan());
            isDied = false;
            
        }

    }
    IEnumerator deadan()
    {
       
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
        StopCoroutine(deadan());
    }


    void SpawnCoin()
    {
        GameObject c = Instantiate(Coins, transform.position, Quaternion.identity) as GameObject;
    }
}
