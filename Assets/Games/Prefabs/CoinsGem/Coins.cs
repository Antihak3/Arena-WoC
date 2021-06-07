using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
  
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            print("Coins");
            col.GetComponent<PlayerStats>().coins += Random.Range(10, 50);
            Destroy(gameObject);
        }
    }

}
