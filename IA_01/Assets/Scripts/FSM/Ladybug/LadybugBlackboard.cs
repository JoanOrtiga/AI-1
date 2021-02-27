using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBlackboard : MonoBehaviour
{
    public float seeDistance;
    [HideInInspector] public GameObject antTarget;

    public float distanceToInteract = 3f;
    public float distanceToKill = 3f;
    public LadybugNest nest;

    public float hunger;
    public float hungerInc;
    public float needToEatThreshold = 10f;

    private void Awake()
    {
        if(nest == null)
        {
            nest = FindObjectOfType<LadybugNest>();
        }
    }
}
