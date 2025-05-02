using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneDirector : MonoBehaviour
{
    public void TitleButtonDown()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
