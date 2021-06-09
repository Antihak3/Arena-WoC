using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject Screen;
    public GameObject Player;
    public GameObject Enemy;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void Update()
    {
        if(Player.GetComponent<PlayerStats>().curLife <= 0)
        {
            StartCoroutine(DiedPlayer());
            print("update");
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
        print("PaueOn");

        if (PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + Player.GetComponent<PlayerStats>().GetCoins());
        }
        else
        {
            PlayerPrefs.SetInt("coins", Player.GetComponent<PlayerStats>().GetCoins());
        }

        if (PlayerPrefs.HasKey("stars"))
        {
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") + Player.GetComponent<PlayerStats>().Getstars());
        }
        else
        {
            PlayerPrefs.SetInt("stars", Player.GetComponent<PlayerStats>().Getstars());
        }

        PlayerPrefs.SetFloat("HP", Player.GetComponent<PlayerStats>().GetHP());
        PlayerPrefs.SetInt("lvl", Player.GetComponent<PlayerStats>().GetLevel());
        PlayerPrefs.SetFloat("EXP", Player.GetComponent<PlayerStats>().GetEXP());
        PlayerPrefs.SetFloat("nextLvl", Player.GetComponent<PlayerStats>().GetNextLvlEXP());
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
        print("corutine1");
        StopCoroutine(DiedPlayer());
        print("corutine2");
    }


    public void WinOn()
    {
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
        Screen.SetActive(true);
        print("WinOn");

        if (PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + Player.GetComponent<PlayerStats>().GetCoins());
        }
        else
        {
            PlayerPrefs.SetInt("coins", Player.GetComponent<PlayerStats>().GetCoins());
        }


        if (PlayerPrefs.HasKey("stars"))
        {
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") + Player.GetComponent<PlayerStats>().Getstars());
        }
        else
        {
            PlayerPrefs.SetInt("stars", Player.GetComponent<PlayerStats>().Getstars());
        }


        PlayerPrefs.SetFloat("HP", Player.GetComponent<PlayerStats>().GetHP());
        PlayerPrefs.SetInt("lvl", Player.GetComponent<PlayerStats>().GetLevel());
        PlayerPrefs.SetFloat("EXP", Player.GetComponent<PlayerStats>().GetEXP());
        PlayerPrefs.SetFloat("nextLvl", Player.GetComponent<PlayerStats>().GetNextLvlEXP());
    }

}
