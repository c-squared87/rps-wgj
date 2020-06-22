using UnityEngine;

public class DestroyAtPosition : MonoBehaviour
{
    [SerializeField] float x_position;

    void FixedUpdate()
    {
        if (transform.position.x <= x_position)
        {
            if (gameObject.tag == "Ground")
            {
                FindObjectOfType<EnvironmentSpawner>().SpawnGround(transform.position + new Vector3(18, 0, 0));
            }
            Destroy(gameObject);
        }
    }
}
