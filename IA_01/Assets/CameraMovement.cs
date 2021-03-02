using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;

    public Bounds bounds;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");    
        float inputY = Input.GetAxis("Vertical");

        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

        if (!bounds.Contains(transform.position))
        {
            Vector3 cp = bounds.ClosestPoint(transform.position);

            transform.position -= new Vector3(transform.position.x - cp.x, transform.position.y - cp.y);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
