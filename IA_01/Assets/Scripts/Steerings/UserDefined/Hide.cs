using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hide : SteeringBehaviour
{
    [Header("ALGORITHM VARS")]
    public float findHideSpotRadius = 20f;
    public string hideObjectsTag = "OBSTACLES";
    public float detectEnemyRadius = 40f;
    public string enemyTag = "Enemy";
    public float hideOffset = 5f;

    [Header("ARRIVE")]
    public float closeEnoughRadius = 5f;  // also know as targetRadius
    public float slowDownRadius = 20f;    // if inside this radius, slow down
    public float timeToDesiredSpeed = 0.1f;


    [Header("OBSTACLE AVOIDANCE")]
    // parameters required by obstacle avoidance...
    public bool showWhisker = true;
    public float lookAheadLength = 10f;
    public float avoidDistance = 10f;
    public float secondaryWhiskerAngle = 30f;
    public float secondaryWhiskerRatio = 0.7f;

    public RotationalPolicy rotationalPolicy = RotationalPolicy.LWYGI;


    public override SteeringOutput GetSteering()
    {
        if (this.ownKS == null) this.ownKS = GetComponent<KinematicState>();
        SteeringOutput result = Hide.GetSteering(this.ownKS, findHideSpotRadius, hideObjectsTag, enemyTag, detectEnemyRadius, hideOffset, showWhisker, lookAheadLength, avoidDistance, secondaryWhiskerAngle, secondaryWhiskerRatio, closeEnoughRadius, slowDownRadius, timeToDesiredSpeed);
        base.applyRotationalPolicy(rotationalPolicy, result);
        return result;
    }

    public static SteeringOutput GetSteering(KinematicState ownKS, float findHideSpotRadius, string hideTag,
        string enemyTag, float detectEnemyRadius, float hideOffset, bool showWhishker, float lookAheadLength, 
        float avoidDistance, float secondaryWhiskerAngle, float secondaryWhiskerRatio, float closeEnoughRadius, 
        float slowDownRadius, float timeToDesiredSpeed)
    {
        SteeringOutput result;



        GameObject enemy = SensingUtils.FindInstanceWithinRadius(ownKS.gameObject, enemyTag, detectEnemyRadius);

        if (enemy == null)
        {
            result = new SteeringOutput();

            return result;
        }

        GameObject hideSpot = SensingUtils.FindInstanceWithinRadius(ownKS.gameObject, hideTag, findHideSpotRadius);

        if (hideSpot == null)
        {
            result = FleePlusAvoid.GetSteering(ownKS, enemy, showWhishker, lookAheadLength, avoidDistance, secondaryWhiskerAngle, secondaryWhiskerRatio);
            print("aa");
            return result;
        }

        GameObject hidingPosition = null;

        if (hideSpot.transform.childCount != 0)
        {
            for (int i = 0; i < hideSpot.transform.childCount; i++)
            {
                if (hideSpot.transform.GetChild(i).name == "hideSpot")
                {
                    hidingPosition = hideSpot.transform.GetChild(i).gameObject;

                }
            }
        }
        else
        {
            hidingPosition = new GameObject("hideSpot");
            hidingPosition.transform.SetParent(hideSpot.transform);

        }

        CircleCollider2D circle = hideSpot.GetComponent<CircleCollider2D>();

        if (circle == null)
        {
            result = FleePlusAvoid.GetSteering(ownKS, enemy, showWhishker, lookAheadLength, avoidDistance, secondaryWhiskerAngle, secondaryWhiskerRatio);

            return result;
        }


        //HIDING POINT
        float offsetDistance = circle.radius + hideOffset;
        Vector3 dir = hideSpot.transform.position - enemy.transform.position;
        dir.Normalize();
        //Set created gameobject to hide position.
        hidingPosition.transform.position = hideSpot.transform.position + dir * offsetDistance;

        result = ArrivePlusAvoid.GetSteering(ownKS, hidingPosition, closeEnoughRadius, slowDownRadius, timeToDesiredSpeed, showWhishker, lookAheadLength, avoidDistance, secondaryWhiskerAngle, secondaryWhiskerRatio);

        return result;
    }
}