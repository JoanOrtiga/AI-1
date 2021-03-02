using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float foodNumber;

    [SerializeField] private Text totalFood;
    [SerializeField] private Text totalAnts;

    private void Update()
    {
        totalFood.text = "Total Food: " + foodNumber;
        totalAnts.text = "Total Ants: " + GameObject.FindGameObjectsWithTag("ANT").Length;
    }
}
