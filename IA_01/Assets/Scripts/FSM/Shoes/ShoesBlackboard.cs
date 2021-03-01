using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesBlackboard : MonoBehaviour
{
    public GameObject food;
    public float radius = 10f;

    [HideInInspector]
    public GameObject shoeL, shoeR, foodSpawn;
    public float counter = 0f;

    private void Awake()
    {
        shoeL = transform.GetChild(0).gameObject;
        shoeR = transform.GetChild(1).gameObject;
        foodSpawn = transform.GetChild(2).gameObject;
    }
}
