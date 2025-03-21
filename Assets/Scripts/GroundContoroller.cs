using UnityEngine;

public class GroundController : MonoBehaviour
{
    private PlayerManager playerManager;
    public float moveSpeed = -0.010f;
    private float elapsedTime = 0f;
    public float acceleration = -0.01f; // 加速度

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManagerが見つかりません。");
        }
    }

    void Update()
    {
        if (playerManager != null)
        {
            elapsedTime += Time.deltaTime;
            float currentSpeed = moveSpeed + acceleration * elapsedTime;
            transform.Translate(currentSpeed * playerManager.gameSpeed * Time.deltaTime, 0, 0);
        }
    }
}