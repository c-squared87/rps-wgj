
using UnityEngine;

public class DestroyAtPosition : MonoBehaviour
{
    [SerializeField] float x_position;

    void FixedUpdate()
    {
        if (transform.position.x <= x_position)
        {
            Destroy(gameObject);
        }
    }
}
