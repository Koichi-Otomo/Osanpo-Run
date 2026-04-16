using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private float moveSpeed = -0.020f; //オブジェクトの初期速度
    public float elapsedTime = 0.0f; //経過時間を記録
    private float acceleration = -0.0060f; //オブジェクトの加速度、ゲーム全体の難易度に影響する
    public float objectPosition; //ObjectController.csにてオブジェクトの位置を明示する
    private GameObject scoreText; // スコア表示の GameObject
    [SerializeField] TextMeshProUGUI colorText; // Textコンポーネントを受け止める
    public static int finalScore; // 静的変数で最終スコアを保持

    void Start()
    {
        Application.targetFrameRate = 60;
        scoreText = GameObject.Find("ScoreText");
        finalScore = 0;

        if (scoreText == null)
        {
            Debug.LogError(" ScoreText GameObject が見つかりません。");
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        objectPosition = moveSpeed + acceleration * elapsedTime; //経過時間に応じてオブジェクトの位置を左へ動かす

        if (this.transform.position.y < -5.0) //地面を抜けてしまった場合の処理
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //地面に接触した場合ゲームオーバー
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager scoreManager = scoreText.GetComponent<ScoreManager>();
            finalScore = scoreManager.score;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
            ScoreManager scoreManager = scoreText.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                if (collision.gameObject.CompareTag("Wall")) //壁に乗っている間は通常スコア
                {
                    scoreManager.score += 1;
                    colorText.color = Color.white; // 壁に乗っている間は白で表示
                }
                else if (collision.gameObject.CompareTag("Roof")) //屋根に乗っている間は倍のスコア
                {
                    scoreManager.score += 2;
                    colorText.color = Color.green; // 屋根接触時は緑で強調表示
                }
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        colorText.color = Color.gray; //スコアが止まっている間は灰
    }
}