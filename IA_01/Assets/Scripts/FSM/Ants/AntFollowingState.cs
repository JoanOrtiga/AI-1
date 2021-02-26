using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Steerings;


[RequireComponent(typeof(FlockingAroundPlusAvoid))]
public class AntFollowingState : FiniteStateMachine
{
    FlockingAroundPlusAvoid flockingAroundPlusAvoid;

    private void Awake()
    {
        flockingAroundPlusAvoid = GetComponent<FlockingAroundPlusAvoid>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReEnter()
    {
        base.ReEnter();
    }
}
