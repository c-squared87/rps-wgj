using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.fixedDeltaTime);
    }

    public void StopThisObject()
    {
        moveSpeed = 0;
    }
}
