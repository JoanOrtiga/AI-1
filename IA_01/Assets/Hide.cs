using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Evade))]
[RequireComponent(typeof(Arrive1))]

[RequireComponent(typeof(SteeringBehaviour))]
public class Hide : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceFromBoundary = 3.0f;
    public float hidingSpotRadius = 0.5f;
    Evade evade;
    Arrive1 arrive;
    private void Awake()
    {
        evade = GetComponent<Evade>();
        arrive = GetComponent<Arrive1>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetSteering()
    {
      
        GameObject hidingSpot = GetHidingPosition();
                
        return arrive.GetSteering(hidingSpot);
    }
    GameObject GetHidingPosition()
    {
        
       GameObject whereToHide =  SensingUtils.FindInstanceWithinRadius(this.gameObject, "Escondites", hidingSpotRadius);

        
        return whereToHide;
    }


}
