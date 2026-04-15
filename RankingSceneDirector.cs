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
        SceneManager.LoadScene("OnlineRankingScene");
    }
}
