using TMPro;
using UnityEngine;

public class FinishScoreManager : MonoBehaviour
{
    private string keyName = "scoreRanking";
    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "score:" + PlayerManager.finalScore.ToString();
        RankingUpdate(keyName, PlayerManager.finalScore);
    }

    void RankingUpdate(string rankingKey, int newScore)
    {
        int topNScores = 5; // ランキングに表示する上位人数

        // rankingText にランキングデータを代入する
        // データが無い場合、初期値として "500,400,300,200,100" を代入する
        string rankingText = PlayerPrefs.GetString(rankingKey, "500,400,300,200,100");

        // splitメソッドを使い、"," で区切られている値を rankingArr 配列に代入する
        // rankingArrの中身：["500","400","300","200","100"]
        string[] rankingTextArr = rankingText.Split(',');

        // ランキングより 1 大きいランキング配列を作成する
        int[] rankingIntArr = new int[rankingTextArr.Length + 1];

        // rankingIntArr 配列に int 変換したスコアを代入する
        for (int i = 0; i < rankingTextArr.Length; i++)
        {
            if (int.TryParse(rankingTextArr[i], out int parsedScore))
            {
                rankingIntArr[i] = parsedScore;
            }
            else
            {
                Debug.LogError("ランキングデータのパースエラー: " + rankingTextArr[i]);
                return; // パースエラーが発生したら処理を中断
            }
        }

        // rankingIntArrの一番後ろに新しいスコアを代入する
        rankingIntArr[rankingTextArr.Length] = newScore;

        // rankingIntArrを昇順ソート
        System.Array.Sort(rankingIntArr);
        // rankingIntArrの順序を反転させる (降順のランキングを作る場合は Array.Reverse(); は不要)
        System.Array.Reverse(rankingIntArr);

        // ランキング保存用テキストの初期化
        string uploadRankingText = "";

        // ランキング保存用テキストの作成
        for (int i = 0; i < Mathf.Min(topNScores, rankingIntArr.Length); i++)
        {
            uploadRankingText += rankingIntArr[i].ToString();
            if (i < Mathf.Min(topNScores, rankingIntArr.Length) - 1)
            {
                uploadRankingText += ",";
            }
        }

        // ランキングの保存
        PlayerPrefs.SetString(rankingKey, uploadRankingText);
    }

}

