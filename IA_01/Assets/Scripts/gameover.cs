using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject gameoverCanvas;
    private void Awake()
    {
        gameoverCanvas.SetActive(false);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ANT").Length <= 0)
        {
            gameoverCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
