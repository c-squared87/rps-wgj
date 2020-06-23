using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float speedMultiplier;

    void FixedUpdate()
    {
        if (speedMultiplier == 0) speedMultiplier = FindObjectOfType<GameManager>().SpeedMultiplier;

        transform.Translate(Vector2.left * moveSpeed * speedMultiplier * Time.fixedDeltaTime);
    }

    public void StopThisObject()
    {
        moveSpeed = 0;
    }
}
