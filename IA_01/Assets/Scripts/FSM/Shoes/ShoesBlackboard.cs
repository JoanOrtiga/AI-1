using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesBlackboard : MonoBehaviour
{
    public GameObject food;
    public float radius = 10f;

    [HideInInspector]
    public GameObject[] shoes;
    public GameObject foodSpawn;
    public float counter = 0f;

    private void Awake()
    {
        shoes = new GameObject[6];

        shoes[0] = transform.GetChild(0).gameObject;
        shoes[1] = transform.GetChild(1).gameObject;
        shoes[2] = transform.GetChild(3).gameObject;
        shoes[3] = transform.GetChild(4).gameObject;
        shoes[4] = transform.GetChild(5).gameObject;
        shoes[5] = transform.GetChild(6).gameObject;
        foodSpawn = transform.GetChild(2).gameObject;
    }
}
