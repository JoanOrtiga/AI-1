using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBlackboard : MonoBehaviour
{
    public float seeDistance;
    [HideInInspector] public GameObject antTarget;

    public float distanceToKill = 3f;
    public GameObject nest;
}
