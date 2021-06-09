using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TParena : MonoBehaviour
{
    public Button arena;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arena.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            arena.gameObject.SetActive(false);
        }
    }
}
