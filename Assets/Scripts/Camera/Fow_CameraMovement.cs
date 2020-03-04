using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fow_CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float smoothTime = 0.3f;

    private Vector3 goalPos;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        goalPos.x = _target.position.x;
        goalPos.z = _target.position.z;
        goalPos.y = transform.position.y;

        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
