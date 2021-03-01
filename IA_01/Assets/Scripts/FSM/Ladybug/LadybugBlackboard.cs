using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugBlackboard : MonoBehaviour
{
    public float seeDistance;
    [HideInInspector] public GameObject antTarget;
    public bool transportingFood = false;

    public float distanceToInteract = 3f;
    public float distanceToKill = 3f;
    public LadybugNest nest;

    public float hunger;
    public float hungerInc;
    public float needToEatThreshold = 10f;

    public float eatingTime = 4f;
    public float eatElapsedTime;

    public float restingTime = 3f;
    public float restElapsedTime;

    private void Awake()
    {
        if(nest == null)
        {
            nest = FindObjectOfType<LadybugNest>();
        }
    }
}
