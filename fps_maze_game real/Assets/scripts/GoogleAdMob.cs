using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.Events;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class GoogleAdMob : MonoBehaviour
{
    public static GoogleAdMob instance;
    private RewardedAd rewardedAd;
    private RewardedAd extraCoinsRewardedAd;
    //string addID = "ca - app - pub - 8848436300382070 / 8010617691";
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!=null)
        {
            Destroy(instance);           
        }
        instance = this;
        showads(false);

    }
    public void showads(bool otherfunctioncal)
    {
        string adUnitId;
        adUnitId = "ca-app-pub-8848436300382070/8010617691";

        //Initialize the google Mobile Ads SDK
        MobileAds.Initialize(initstatus => { });

        this.extraCoinsRewardedAd = CreateAndLoadRewardedAd(adUnitId);
        if(otherfunctioncal)
        {
            UserChoseTowatch();
        }
    }

    public RewardedAd CreateAndLoadRewardedAd(string adUnitId)
    {
        this.rewardedAd = new RewardedAd(adUnitId);

        //called when an ad request has sucessfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        //called when an ad request failed to load
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // called when an add is shown
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        //called when an Ad request failed to show
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        //called when the user should be rewarded for interacting with the ad
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        //create an empty add request
        AdRequest request = new AdRequest.Builder().Build();
        //Load the rewarded ad with request
        this.rewardedAd.LoadAd(request);
        return rewardedAd;
    }

    public void HandleRewardedAdLoaded(object sender,EventArgs arg)
    {
        print("HandleRewardedAdLoaded event recieved");
    }


    public void HandleRewardedAdFailedToLoad(object sender,AdErrorEventArgs args)
    {
        print("HandleRewardedAdFailedToLoad event recieved with message" + args.Message);
    }

    public void HandleRewardedAdOpening(object sender , EventArgs args)
    {
        //we can close sound of our game and whatever is necessary while add is playing
        print("HandleRewardedAdOpening event recieved");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        print("HandleRewardedAdFailedToShow event recieved with message: " + args.Message);
    }

    public void HandleRewardedAdClosed(object sender,EventArgs args)
    {   
        //we can open again sound of our game and whatever is necessary while add is closing
        print("HandleRewardedAdClosed event recieved");
        // this.transform.gameObject.SetActive(false);
    }


    public void HandleUserEarnedReward(object sender,Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        print("HandleUserEarnedReward event recieved for " + amount.ToString() + " " + type);
        int g = PlayerPrefs.GetInt("goldbars");
        g = g + (int)amount;
        PlayerPrefs.SetInt("goldbars",g);
    }

    public void UserChoseTowatch()
    {
        if(this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
