using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertHandler : MonoBehaviour
{
    #if UNITY_ANDROID

    string gameId = "b175e92d-ecd6-46ab-94fa-b67c789afe8a";

    void Start()
    {
        Advertisement.Initialize(gameId);
    }

    public void ShowAd(int chance)
    {
        Debug.Log("Target: " + chance.ToString());
        int rand = Random.Range(1, chance + 1);
        Debug.Log("Random number: " + rand.ToString());
        if (rand == chance)
        {
            Debug.Log("Showing ad");
            Advertisement.Show();
        }
    }

    #endif
}
