using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RankingSceneDirector : MonoBehaviour
{
    public void TitleButtonDown()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnlineRankingButtonDown()
    {
        AdManager adManager = FindFirstObjectByType<AdManager>();
        if (adManager != null)
        {
            adManager.ShowInterstitialAd(() => {
                SceneManager.LoadScene("OnlineRankingScene");
            });
        }
        else
        {
            SceneManager.LoadScene("OnlineRankingScene");
        }
    }
}
