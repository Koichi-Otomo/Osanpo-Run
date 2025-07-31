using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneDirector : MonoBehaviour
{
    public void StartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TutorialButtonDown()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void RankingButtonDown()
    {
        SceneManager.LoadScene("RankingScene");
    }

}
