using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject menuStarta;
    public GameObject menu1;
    public Slider SoundVolume;

    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<AudioSource>().volume = SoundVolume.value / 10;
    }


    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
    }


    public void StartScena1()
    {
        menuStarta.SetActive(false);
        menu1.SetActive(true);
    }

    public void StartScena2()
    {
        menuStarta.SetActive(true);
        menu1.SetActive(false);
    }
}
