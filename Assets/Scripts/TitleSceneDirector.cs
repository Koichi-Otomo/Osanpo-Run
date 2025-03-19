using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneDirector : MonoBehaviour
{
    public void StartButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}
