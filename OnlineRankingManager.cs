using TMPro;
using UnityEngine;

public class OnlineRankingManager : MonoBehaviour
{
    [SerializeField] private TMP_Text rankingText;
    [SerializeField] private TMP_Text statusText;
    private ApiClient apiClient;

    void Start()
    {
        apiClient = GetComponent<ApiClient>();
        if (apiClient == null)
            apiClient = gameObject.AddComponent<ApiClient>();

        LoadOnlineRanking();
    }

    void LoadOnlineRanking()
    {
        statusText.text = "Loading...";
        StartCoroutine(apiClient.GetRanking(OnRankingLoaded));
    }

    void OnRankingLoaded(RankingEntry[] rankings)
    {
        if (rankings != null && rankings.Length > 0)
        {
            DisplayRanking(rankings);
            statusText.text = "";
        }
        else
        {
            rankingText.text = "オンラインランキングの取得に失敗しました";
            statusText.text = "Error: Failed to load ranking";
        }
    }

    void DisplayRanking(RankingEntry[] rankings)
    {
        string displayText = "~Online Ranking~\n";
        
        for (int i = 0; i < rankings.Length && i < 5; i++)
        {
            displayText += $"{i + 1}位：{rankings[i].playerName} - {rankings[i].score}\n";
        }

        rankingText.text = displayText;
    }

    public void RefreshRanking()
    {
        AdManager adManager = FindFirstObjectByType<AdManager>();
        if (adManager != null)
        {
            adManager.ShowInterstitialAd(() => {
                LoadOnlineRanking();
            });
        }
        else
        {
            LoadOnlineRanking();
        }
    }
}