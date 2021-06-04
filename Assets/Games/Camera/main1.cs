using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main1 : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject Screen;
    public GameObject Player;
   

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Update()
    {
        if(Player.GetComponent<Animator>().GetBool("diedPl"))
        {
            StartCoroutine(DiedPlayer());
        }
    }

    public void ReloadLvl()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void PauseOn()
    {
        Time.timeScale = 0f;
       
        PauseScreen.SetActive(true);
        Screen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
       
        PauseScreen.SetActive(false);
        Screen.SetActive(false);
    }



    IEnumerator DiedPlayer()
    {
        yield return new WaitForSeconds(3f);
        PauseOn();
        StopCoroutine(DiedPlayer());
    }
}
