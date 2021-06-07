using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraplayerPrefs : MonoBehaviour
{
    public Slider MusicSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolime"))
        {
            PlayerPrefs.SetFloat("MusicVolime", 3);
        }

        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolime");
    }
    public void deleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

   public void MusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolime", MusicSlider.value);
    }
}
