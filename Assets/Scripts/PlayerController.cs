using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public float jumpForce = 600.0f; // ジャンプの強さを定義
    private bool isGrounded; // 接地判定用フラグ

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ジャンプ処理
        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            rigid2D.AddForce(transform.up * jumpForce);
            isGrounded = false; // ジャンプ後はfalseにする
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            || collision.gameObject.CompareTag("Wall")
            || collision.gameObject.CompareTag("Roof"))
        {
            isGrounded = true;
        }
    }
}
