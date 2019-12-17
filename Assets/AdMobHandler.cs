using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobHandler : MonoBehaviour
{
    public static AdMobHandler instance;

    private BannerView bannerView;
    private InterstitialAd interAd;

    string appID = "ca-app-pub-4705085475015421~9356386126";

    string bannerID = "ca-app-pub-4705085475015421/5728487521";
    string testBannerID = "ca-app-pub-3940256099942544/6300978111";

    string interstitialID = "ca-app-pub-4705085475015421/6716413367";
    string testInterstitialID = "ca-app-pub-3940256099942544/1033173712";

    bool testMode = false;

    void Start()
    {
        RequestBanner();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            MobileAds.Initialize(appID);
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RequestInterstitial()
    {
        interAd = new InterstitialAd(testMode ? testInterstitialID : interstitialID);
        AdRequest interRequest = new AdRequest.Builder().AddTestDevice("HMHQBAA0016233EE8E4NNI").Build();
        interAd.LoadAd(interRequest);
        
        if (interAd != null)
        {
            interAd.Destroy();
        }

        if (!interAd.IsLoaded())
        {
            yield return new WaitForSeconds(0.5f);
        }
        interAd.Show();
    }

    void RequestBanner()
    {
        bannerView = new BannerView(testMode ? testBannerID : bannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest bannerRequest = new AdRequest.Builder().Build();
        bannerView.LoadAd(bannerRequest);
    }

    public void ShowInterAd(int chance)
    {
        Debug.Log("Target: " + chance.ToString());
        int rand = Random.Range(1, chance + 1);
        Debug.Log("Random number: " + rand.ToString());
        if (rand == chance)
        {
            Debug.Log("Showing ad");
            StartCoroutine(RequestInterstitial());
        }
    }
}