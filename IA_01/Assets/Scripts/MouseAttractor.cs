using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttractor : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = (Vector2)worldPosition;
    }
}
