using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public float boundRight;
    private void Awake()
    {
        instance = this;
        Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));

        boundRight = rightBound.x;
    }
}
