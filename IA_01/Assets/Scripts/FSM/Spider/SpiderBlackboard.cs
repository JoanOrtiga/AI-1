using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBlackboard : MonoBehaviour
{


    public GameObject spiderHouse;

    public float takeFoodRadius = 1f;


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
