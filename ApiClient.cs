using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    private const string BASE_URL = "https://h4xwcu7od3.execute-api.ap-northeast-1.amazonaws.com/dev";

    public IEnumerator SubmitScore(string playerName, int score, System.Action<bool> callback)
    {
        var entry = new RankingEntry(playerName, score, System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        string jsonData = JsonUtility.ToJson(entry);

        using (UnityWebRequest request = new UnityWebRequest($"{BASE_URL}/submit-score", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            callback?.Invoke(request.result == UnityWebRequest.Result.Success);
        }
    }

    public IEnumerator GetRanking(System.Action<RankingEntry[]> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{BASE_URL}/get-ranking"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                // JSON配列をオブジェクトでラップ
                string wrappedJson = "{\"rankings\":" + jsonResponse + "}";
                RankingResponse response = JsonUtility.FromJson<RankingResponse>(wrappedJson);
                callback?.Invoke(response.rankings);
            }
            else
            {
                callback?.Invoke(null);
            }
        }
    }
}