using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float gameSpeed = 0.00000000010f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (this.transform.position.y < -6.0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
