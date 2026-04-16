using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public float jumpForce = 600.0f;
    private bool isGrounded;

    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // タッチ・クリック両対応のジャンプ処理
        if ((Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && isGrounded)
        {
            rigid2D.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
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
