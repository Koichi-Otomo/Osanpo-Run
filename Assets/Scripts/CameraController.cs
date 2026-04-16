using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player; // インスペクターで設定（GameObject.Find回避）
    private Transform playerTransform; // Transformキャッシュ

    void Start()
    {
        // SerializeFieldで設定されていない場合のフォールバック
        if (player == null)
        {
            player = GameObject.Find("cat");
        }

        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("プレイヤー(cat)が見つかりません。");
        }
    }

    void LateUpdate() // カメラ追従はLateUpdateで行う（Update後の最終位置を使う）
    {
        if (playerTransform == null) return;

        Vector3 pos = transform.position;
        pos.x = playerTransform.position.x;
        transform.position = pos;
    }
}
