using UnityEngine;

public class AdManager : MonoBehaviour
{
    [SerializeField] private string gameId = "9ec87949-3c6b-4e48-83cb-fd39f6363cfa";
    [SerializeField] private string interstitialAdUnitId = "0ri0c3pbzi4j25u5";
    
    private System.Action onAdCompleted;

    void Start()
    {
        Debug.Log("AdManager初期化完了（広告パッケージ未インストール）");
    }

    public void ShowInterstitialAd(System.Action onCompleted = null)
    {
        onAdCompleted = onCompleted;
        
        // 広告パッケージがない場合は即座にコールバック実行
        Debug.Log("広告表示をスキップ（パッケージ未インストール）");
        onAdCompleted?.Invoke();
    }
}