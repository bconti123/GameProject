using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null) return;

        Vector3 pos = target.position;
        pos.z = -10f; // keep camera distance

        transform.position = pos;
    }
}