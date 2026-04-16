using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private float moveSpeed = -0.020f; // オブジェクトの初期速度
    public float elapsedTime = 0.0f; // 経過時間を記録
    private float acceleration = -0.0060f; // オブジェクトの加速度
    public float objectPosition; // ObjectController.csにてオブジェクトの位置を明示する
    private ScoreManager scoreManager; // ScoreManagerをキャッシュ
    [SerializeField] TextMeshProUGUI colorText;
    public static int finalScore;

    void Start()
    {
        Application.targetFrameRate = 60;
        finalScore = 0;

        // ScoreManagerをキャッシュ（毎フレームGetComponentを避ける）
        GameObject scoreTextObj = GameObject.Find("ScoreText");
        if (scoreTextObj != null)
        {
            scoreManager = scoreTextObj.GetComponent<ScoreManager>();
        }
        else
        {
            Debug.LogError("ScoreText GameObjectが見つかりません。");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        objectPosition = moveSpeed + acceleration * elapsedTime;

        if (this.transform.position.y < -5.0f) // 地面を抜けてしまった場合
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (scoreManager != null)
            {
                finalScore = scoreManager.score;
            }
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (scoreManager == null) return;

        if (collision.gameObject.CompareTag("Wall"))
        {
            scoreManager.score += 1;
            colorText.color = Color.white;
        }
        else if (collision.gameObject.CompareTag("Roof"))
        {
            scoreManager.score += 2;
            colorText.color = Color.green;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colorText.color = Color.gray;
    }
}
