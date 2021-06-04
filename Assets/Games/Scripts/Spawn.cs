using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] Enemy;

    private void Start()
    {
        GameObject fb = Instantiate(Enemy[Random.Range(0, Enemy.Length)], transform.position, transform.rotation);
    }

    public void SpawnEnemy()
    {
        GameObject fb = Instantiate( Enemy[Random.Range(0, Enemy.Length)], transform.position, transform.rotation);
    }
}
