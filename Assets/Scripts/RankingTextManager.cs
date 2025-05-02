using TMPro;
using UnityEngine;

public class RankingTextManager : MonoBehaviour
{
    private TMP_Text scoreText;
    private string rankingKey = "scoreRanking"; // ランキングのキー

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        DisplayRanking(); // Start時にランキングを表示
    }

    void DisplayRanking()
    {
        string rankingText = PlayerPrefs.GetString(rankingKey, "500,400,300,200,100");
        string[] rankingTextArr = rankingText.Split(',');
        string displayText = "~Score Ranking~\n";

        for (int i = 0; i < rankingTextArr.Length; i++)
        {
            displayText += $"{i + 1}位：{rankingTextArr[i]}\n";
        }

        scoreText.text = displayText;
    }
}