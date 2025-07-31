[System.Serializable]
public class RankingEntry
{
    public string playerName;
    public int score;
    public string timestamp;

    public RankingEntry(string name, int playerScore, string time)
    {
        playerName = name;
        score = playerScore;
        timestamp = time;
    }
}