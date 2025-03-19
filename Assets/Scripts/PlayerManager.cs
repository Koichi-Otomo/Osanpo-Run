using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float gamespeed = 100.0f;

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
