using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform ball;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (ball == null)
            return;
        transform.position = new Vector3(transform.position.x, ball.position.y, -10);
        if (transform.position.y < 4)
        {
            transform.position = new Vector3(transform.position.x, 4, -10);
        }
    }
}
