using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YandexMobileAds;
using YandexMobileAds.Base;

public class YandexMobileAdsInterstitialDemoScript : MonoBehaviour
{
    private InterstitialAdLoader interstitialAdLoader;
    private Interstitial interstitial;

    private int lvlName;

    private void Awake()
    {
        SetupLoader();
        RequestInterstitial();
        DontDestroyOnLoad(gameObject);
    }

    private void SetupLoader()
    {
        interstitialAdLoader = new InterstitialAdLoader();
        interstitialAdLoader.OnAdLoaded += HandleInterstitialLoaded;
        interstitialAdLoader.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
    }

    private void RequestInterstitial()
    {
        string adUnitId = "R-M-4146202-1"; // замените на "R-M-XXXXXX-Y" "R-M-4146202-1"  "demo-interstitial-yandex"
        AdRequestConfiguration adRequestConfiguration = new AdRequestConfiguration.Builder(adUnitId).Build();
        interstitialAdLoader.LoadAd(adRequestConfiguration);
    }

    public void ShowInterstitial(int lvlnum)
    {
        lvlName = lvlnum;
        if (interstitial != null)
        {
            interstitial.Show();
            
            //DestroyInterstitial();
        }else
        {

            lvlSwitch();
        }
    }

    public void HandleInterstitialLoaded(object sender, InterstitialAdLoadedEventArgs args)
    {
        // The ad was loaded successfully. Now you can handle it.
        interstitial = args.Interstitial;
        //Debug.Log("загруз");
        // Add events handlers for ad actions
        interstitial.OnAdClicked += HandleAdClicked;
        interstitial.OnAdShown += HandleInterstitialShown;
        interstitial.OnAdFailedToShow += HandleInterstitialFailedToShow;
        interstitial.OnAdImpression += HandleImpression;
        interstitial.OnAdDismissed += HandleInterstitialDismissed;

    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Алярм"); 
        // Ad {args.AdUnitId} failed for to load with {args.Message}
        // Attempting to load a new ad from the OnAdFailedToLoad event is strongly discouraged.
    }

    public void HandleInterstitialDismissed(object sender, EventArgs args)
    {
        // Called when ad is dismissed.
        // Clear resources after Ad dismissed.
        DestroyInterstitial();

        // Now you can preload the next interstitial ad.
        RequestInterstitial();
        //lvlSwitch();
    }

    public void HandleInterstitialFailedToShow(object sender, EventArgs args)
    {
        // Called when an InterstitialAd failed to show.
        // Clear resources after Ad dismissed.
        DestroyInterstitial();

        // Now you can preload the next interstitial ad.
        RequestInterstitial();
        lvlSwitch();
    }

    public void HandleAdClicked(object sender, EventArgs args)
    {
        // Called when a click is recorded for an ad.
        lvlSwitch();
    }

    public void HandleInterstitialShown(object sender, EventArgs args)
    {
        // Called when ad is shown.
        lvlSwitch();
    }

    public void HandleImpression(object sender, ImpressionData impressionData)
    {
        // Called when an impression is recorded for an ad.

        lvlSwitch();
    }

    public void DestroyInterstitial()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
            interstitial = null;
        }
    }

    public void lvlSwitch()
    {
        SceneManager.LoadScene(lvlName);

        DestroyInterstitial();
    }
}
