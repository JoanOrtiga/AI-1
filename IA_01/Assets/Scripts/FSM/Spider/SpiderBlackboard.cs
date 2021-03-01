using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBlackboard : MonoBehaviour
{


    public GameObject spiderHouse;
    public float speed = 50;
    public float takeFoodRadius = 1f;
    public float dropFoodRadius = 1f;
    public GameObject[] food;

    private void Awake()
    {
        if (spiderHouse == null)
        {
            spiderHouse = GameObject.FindObjectOfType<SpiderHouse>().gameObject;
            if (spiderHouse == null)
            {
                Debug.LogError("No spider house found");
            }
        }
    }
}
