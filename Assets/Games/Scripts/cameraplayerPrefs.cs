using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraplayerPrefs : MonoBehaviour
{
    public Slider MusicSlider;
    public Slider SoundSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolime"))
        {
            PlayerPrefs.SetFloat("MusicVolime", 3);
        }

        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolime");


        if (!PlayerPrefs.HasKey("SoundVolime"))
        {
            PlayerPrefs.SetFloat("SoundVolime", 3);
        }

        SoundSlider.value = PlayerPrefs.GetFloat("SoundVolime");
    }
    public void deleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

   public void MusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolime", MusicSlider.value);
        PlayerPrefs.SetFloat("SoundVolime", SoundSlider.value);
    }
}
