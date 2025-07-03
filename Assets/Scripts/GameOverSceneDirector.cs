using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneDirector : MonoBehaviour
{

    public void RankingButtonDown()
    {
        SceneManager.LoadScene("RankingScene");
    }

    public void RestartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TitleButtonDown()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
