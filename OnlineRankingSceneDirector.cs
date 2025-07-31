using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineRankingSceneDirector : MonoBehaviour
{
    public void OfflineRankingButtonDown()
    {
        SceneManager.LoadScene("RankingScene");
    }

    public void TitleButtonDown()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
