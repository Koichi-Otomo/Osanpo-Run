using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private PlayerManager playerManager;
    private Transform cachedTransform; // Transformをキャッシュ
    private float randomiser;

    void Start()
    {
        cachedTransform = transform;
        playerManager = FindFirstObjectByType<PlayerManager>();

        if (playerManager == null)
        {
            Debug.LogError("PlayerManagerが見つかりません。");
        }
    }

    void Update()
    {
        if (playerManager == null) return;

        Vector3 pos = cachedTransform.position;

        if (pos.x < -13.0f) // オブジェクトが画面外に出た場合、反対側へ移動
        {
            randomiser = Random.Range(0.0f, 1.50f);
            pos.x = 13.0f + randomiser;
            cachedTransform.position = pos;
        }

        // PlayerManagerから速度を取得してオブジェクトを移動
        cachedTransform.Translate(playerManager.objectPosition * Time.deltaTime * 60f, 0f, 0f, Space.World);
    }
}
