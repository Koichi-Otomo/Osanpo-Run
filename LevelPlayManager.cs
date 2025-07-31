using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.LevelPlay;
public class LevelPlayManager : MonoBehaviour
{
    [SerializeField] private string appKey = "22a2f29e5";
    
    private static LevelPlayManager instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeLevelPlay();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
async void InitializeLevelPlay() // async キーワードを追加
{
    try
    {
        Debug.Log("Unity Services 初期化開始"); // ログを追加
        await UnityServices.InitializeAsync(); // await で完了を待つ
        Debug.Log("Unity Services 初期化完了"); // ログを追加

        LevelPlay.OnInitSuccess += SdkInitializationSuccessEvent;
        LevelPlay.OnInitFailed += SdkInitializationFailedEvent;

        LevelPlay.Init(appKey);

        Debug.Log("LevelPlay SDK初期化リクエスト送信"); // ログメッセージの微調整
    }
    catch (Exception e)
    {
        // Unity Services 初期化失敗時のエラーハンドリング
        Debug.LogError($"Unity Services 初期化失敗: {e.Message}");
    }
}    

    void SdkInitializationSuccessEvent(LevelPlayConfiguration configuration)
    {
        Debug.Log("LevelPlay SDK初期化成功");
    }
    
    void SdkInitializationFailedEvent(LevelPlayInitError error)
    {
        Debug.LogError($"LevelPlay SDK初期化失敗: {error}");
    }
    
    void OnDestroy()
    {
        LevelPlay.OnInitSuccess -= SdkInitializationSuccessEvent;
        LevelPlay.OnInitFailed -= SdkInitializationFailedEvent;
    }
}
