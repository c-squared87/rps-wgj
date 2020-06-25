using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    bool canJump;

    Rigidbody2D rb;

    AudioSource source;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { Jump(); }
    }

    void FixedUpdate()
    {
        VelocityCheck();
        ScoreManager.AddToScore(0.25f);
    }

    void VelocityCheck()
    {
        if (rb.velocity.y <= 0)
        {
            rb.gravityScale = 6;
        }
        else
        {
            rb.gravityScale = 4;
            animator.enabled = true;
        }
    }

    void Jump()
    {
        if (transform.position.y > 0) return;
        animator.enabled = false;
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
        PlayJumpSound();
    }

    void PlayJumpSound()
    {
        source.PlayOneShot(source.clip);
    }
}
