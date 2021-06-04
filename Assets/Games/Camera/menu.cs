using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject menuStarta;
    public GameObject menu1;
    public GameObject camera;

    void Start()
    {
        
    }

    
    void Update()
    {
        
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
        camera.transform.position = new Vector3(25, 2, -62);
    }
}
