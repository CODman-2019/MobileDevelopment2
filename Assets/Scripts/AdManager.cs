using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : Singelton<AdManager>, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{

    string gameID = "5003054";
    string rewardAdID = "Rewarded_Android";
    string InterAdID = "Interstitial_Android";
    string BannerAdID = "Banner_Android";
#if UNITY_ANDROID
#elif UNITY_IOS
    string gameID = "5003055";
    string rewardAdID = "Rewarded_iOS";
    string InterAdID = "Interstitial_iOS";
    string BannerAdID = "Banner_iOS";
#endif

    public void OnInitializationComplete()
    {
        Debug.Log("Ads Have Been Initalized");
        Advertisement.Load(InterAdID, this);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ad init failed, error message: " + message);

    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad has been loaded");
        Advertisement.Show(placementId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            
                //reward the player with something
                Debug.Log("Reward Ad completed");
                    
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID, true, this);
    }

    // Update is called once per frame
    public void LoadRewardAd()
    {
        Advertisement.Load(rewardAdID, this);
    }

    public void LoadInterAd()
    {
        Advertisement.Load(InterAdID, this);
    }
    public void LoadBannerAd()
    {
        Advertisement.Load(BannerAdID, this);
    }
}
