using System;
using UnityEngine;
using Unity.Services.LevelPlay;
using UnityEngine.Events;

public class AdManager : MonoBehaviour
{
    
    private LevelPlayInterstitialAd interstitialAd;
    private UnityAction onCompleteAd = null;
    private UnityAction onFailedAd = null;

    void Start()
    {
        InitializeInterstitialAd();
    }
    
    void InitializeInterstitialAd()
    {
        interstitialAd = new LevelPlayInterstitialAd("interstitialAdUnitId");
        //Subscribe InterstitialAd events
        interstitialAd.OnAdLoaded += InterstitialOnAdLoadedEvent;
        interstitialAd.OnAdLoadFailed += InterstitialOnAdLoadFailedEvent;
        interstitialAd.OnAdDisplayed += InterstitialOnAdDisplayedEvent;
        interstitialAd.OnAdDisplayFailed += InterstitialOnAdDisplayFailedEvent;
        interstitialAd.OnAdClicked += InterstitialOnAdClickedEvent;
        interstitialAd.OnAdClosed += InterstitialOnAdClosedEvent;
        
        Debug.Log("Interstitial Ad初期化完了");
        
        // 初期ロード
        interstitialAd.LoadAd();
    }

    public void ShowInterstitialAd(UnityAction onCompleteAdCallback, UnityAction onFailedAd)
    {
        this.onCompleteAd = onCompleteAdCallback;
        this.onFailedAd = onFailedAd;
        
        if (interstitialAd != null && interstitialAd.IsAdReady())
        {
            interstitialAd.ShowAd();
        }
        else
        {
            Debug.Log("Interstitial Adが準備できていません。ロード中...");
            onFailedAd?.Invoke();
        }
    }

    public void ShowInterstitialAd(System.Action onCompleted = null)
    {
        ShowInterstitialAd(() => onCompleted?.Invoke(), () => onCompleted?.Invoke());
    }

    void InterstitialOnAdLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"Interstitial Ad読み込み完了: {adInfo.ToString()}");
    }
    
    void InterstitialOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.LogError($"Interstitial Ad読み込み失敗: {error.ErrorMessage}");
        // リトライロジックを追加できます
    }
    
    void InterstitialOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"Interstitial Ad表示開始: {adInfo.ToString()}");
    }
    
    void InterstitialOnAdClosedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"Interstitial Ad終了: {adInfo.ToString()}");
        onCompleteAd?.Invoke();
        onCompleteAd = null;
        
        // 次の広告をロード
        interstitialAd?.LoadAd();
    }
    
    void InterstitialOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"Interstitial Adクリック: {adInfo.ToString()}");
    }
    
void InterstitialOnAdDisplayFailedEvent(LevelPlayAdDisplayInfoError adInfoError) { }    

    void OnDestroy()
    {
        if (interstitialAd != null)
        {
            interstitialAd.OnAdLoaded -= InterstitialOnAdLoadedEvent;
            interstitialAd.OnAdLoadFailed -= InterstitialOnAdLoadFailedEvent;
            interstitialAd.OnAdDisplayed -= InterstitialOnAdDisplayedEvent;
            interstitialAd.OnAdClosed -= InterstitialOnAdClosedEvent;
            interstitialAd.OnAdClicked -= InterstitialOnAdClickedEvent;
            interstitialAd.OnAdDisplayFailed -= InterstitialOnAdDisplayFailedEvent;
        }
    }
}
