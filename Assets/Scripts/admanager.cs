using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class admanager : MonoBehaviour
{
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    public UIManager uimanager;

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void RequestRewarded()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif 
            this.rewardedAd = new RewardedAd(adUnitId);
            // Called when an ad request has successfully loaded.
            this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;

            // Called when an ad is shown.
            this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            
            // Called when the user should be rewarded for interacting with the ad.
            this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded ad with the request.
            this.rewardedAd.LoadAd(request);
    }

    public void showinterstitial()
    {
            if (this.interstitial.IsLoaded()) {
                    this.interstitial.Show();
            }
    }
    public void ShowrewardedAd()
    {
            if (this.rewardedAd.IsLoaded())
            {
                    this.rewardedAd.Show();
            }
    }
    public void HandleRewardedAdLoaded(object sender, System.EventArgs args)
    {
            MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

   

    public void HandleRewardedAdOpening(object sender, System.EventArgs args)
    {
            MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
            MonoBehaviour.print(
                    "HandleRewardedAdFailedToShow event received with message: "
                    + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {
            MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
          CoinCalculator(400);
          uimanager.StartCoroutine("afterRewardedButton");
    }
    public void CoinCalculator(int money)
    {
            if (PlayerPrefs.HasKey("moneyy"))
            {
                    int oldscore = PlayerPrefs.GetInt("moneyy");
                    PlayerPrefs.SetInt("moneyy",oldscore+money);// eger yoksa 0 ataması yapsın.
            }
            else
                    PlayerPrefs.SetInt("moneyy",0);
        
        
    }
}
