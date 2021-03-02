using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttractor : MonoBehaviour
{
    Camera cam;

    float deathZoneHeight;
    float deathZoneWidth;

    private Vector3 lastPos;

    private void Awake()
    {

        cam = Camera.main;

        deathZoneHeight = Camera.main.orthographicSize;
        deathZoneWidth = Camera.main.aspect * deathZoneHeight;
    }

    void Update()
    {
        Vector3 worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = (Vector2)worldPosition;

        Bounds cameraBounds;

        cameraBounds = new Bounds(cam.transform.position, new Vector3(2f * deathZoneWidth, 2f * deathZoneHeight, 100f));

        if (!cameraBounds.Contains(transform.position))
        {
            Vector3 cp = cameraBounds.ClosestPoint(transform.position);

           

            transform.position -= new Vector3(transform.position.x - cp.x, transform.position.y - cp.y);
          
        }
    }

    private void OnDrawGizmosSelected()
    {
        deathZoneHeight = Camera.main.orthographicSize;
        deathZoneWidth = Camera.main.aspect * deathZoneHeight;

        Gizmos.color = Color.cyan;

        Gizmos.DrawWireCube(Camera.main.transform.position, new Vector3(2 * deathZoneWidth, 2 * deathZoneHeight, 5));
    }
}