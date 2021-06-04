using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject targetEnemy;
    public Vector3 positionTarget;
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerController>().curTarget != null)
        {
            targetEnemy.gameObject.SetActive(true);
        }
        else
        {
            targetEnemy.gameObject.SetActive(false);
        }
       
    }
}
