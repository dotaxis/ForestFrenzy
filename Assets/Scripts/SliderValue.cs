using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        GameObject.Find("SFXSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

    public void UpdateMusic(float vol)
    {
        PlayerPrefs.SetFloat("MusicVolume", vol);
        Debug.Log("Called VolumeChange.cs UpdateMusic()");
    }

    public void UpdateSFX(float vol)
    {
        PlayerPrefs.SetFloat("SFXVolume", vol);
        Debug.Log("Called VolumeChange.cs UpdateSFX()");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", GameObject.Find("MusicSlider").GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("SFXVolume", GameObject.Find("SFXSlider").GetComponent<Slider>().value);
    }
}
