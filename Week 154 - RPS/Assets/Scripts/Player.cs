using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    bool canJump;

    Rigidbody2D rb;

    AudioSource source;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
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

    void VelocityCheck()
    {
        if (rb.velocity.y <= 0) { rb.gravityScale = 2; }
        else { rb.gravityScale = 1; }
    }

    void Jump()
    {
        if (transform.position.y > 0) return;
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
        PlayJumpSound();
    }

    void PlayJumpSound(){
        source.PlayOneShot(source.clip);
    }
}
