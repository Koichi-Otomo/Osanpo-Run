using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private TMP_Text scoreText;
    private int lastDisplayedScore = -1; // 前回表示したスコアをキャッシュ

    void Start()
    {
        score = 0;
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "score:0";
        lastDisplayedScore = 0;
    }

    void Update()
    {
        // スコアが変わった時だけテキストを更新（毎フレームの文字列生成を回避）
        if (score != lastDisplayedScore)
        {
            scoreText.text = "score:" + score.ToString();
            lastDisplayedScore = score;
        }
    }
}

