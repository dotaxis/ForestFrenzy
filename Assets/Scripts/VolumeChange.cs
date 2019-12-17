using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour
{
    private AudioHandler audioHandler;
    // Start is called before the first frame update
    void Start()
    {
        audioHandler = gameObject.GetComponent<AudioHandler>();
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

    void Update()
    {
        audioHandler.MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        audioHandler.SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }

}