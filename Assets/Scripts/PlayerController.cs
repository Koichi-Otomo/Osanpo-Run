using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 500.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //  ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space) &&
            collision.gameObject.tag == "Ground")
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }
}
