using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
    }

    void FixedUpdate()
    {
        VelocityCheck();
        ScoreManager.AddToScore(1);
    }

    private void VelocityCheck()
    {
        if (rb.velocity.y <= 0) { rb.gravityScale = 2; }
        else { rb.gravityScale = 1; }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
