
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float x_offset;
    public float y_offset;


    void LateUpdate()
    {
        Vector3 _newPos = target.position;

        _newPos.x += x_offset;
        _newPos.y += y_offset;
        _newPos.z = -10;

        transform.position = _newPos;
    }
}
