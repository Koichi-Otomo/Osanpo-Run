using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneDirector : MonoBehaviour
{

    public void ContinueButtonDown()
    {
        SceneManager.LoadScene("GameScene");
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
