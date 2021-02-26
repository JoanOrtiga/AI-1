using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public GameObject ant;

    public void SpawnNewAnt()
    {
        Instantiate(ant, transform.position, Quaternion.identity);
    }
}
