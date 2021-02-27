using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FSM;
using Steerings;

[RequireComponent(typeof(LadybugBlackboard))]
[RequireComponent(typeof(ArrivePlusAvoid))]
public class LadybugGoForFood_State : FiniteStateMachine
{
    public enum State
    {
        INITIAL, PERSUE, BRINGBASE, EAT
    }

    public State currentState = State.INITIAL;

    private LadybugBlackboard lbBlackboard;

    private ArrivePlusAvoid arriveAvoid;

    private void Awake()
    {
        lbBlackboard = GetComponent<LadybugBlackboard>();

        arriveAvoid = GetComponent<ArrivePlusAvoid>();
    }

    public override void Exit()
    {
        arriveAvoid.enabled = false;
        arriveAvoid.target = null;

        base.Exit();
    }

    public override void ReEnter()
    {
        currentState = State.INITIAL;

        base.ReEnter();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.INITIAL:
                ChangeState(State.PERSUE);
                break;
            case State.PERSUE:
                if (SensingUtils.DistanceToTarget(gameObject, lbBlackboard.antTarget) < lbBlackboard.distanceToKill)
                {
                    lbBlackboard.antTarget.transform.parent = transform;
                    if (lbBlackboard.hunger > lbBlackboard.needToEatThreshold)
                    {
                        ChangeState(State.EAT);
                    }
                    else
                    {
                        ChangeState(State.BRINGBASE);
                    }

                }
                break;
            case State.BRINGBASE:
                if (lbBlackboard.hunger > lbBlackboard.needToEatThreshold)
                {
                    ChangeState(State.EAT);
                }

                arriveAvoid.target = lbBlackboard.nest.FoodTarget();

                if(SensingUtils.DistanceToTarget(gameObject, arriveAvoid.target) < lbBlackboard.distanceToInteract)
                {

                }

                break;
            case State.EAT:
                break;
        }
    }

    private void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.INITIAL:
                break;
            case State.PERSUE:
                arriveAvoid.enabled = false;
                break;
            case State.BRINGBASE:
                arriveAvoid.enabled = false;
                break;
            case State.EAT:
                break;
        }

        switch (newState)
        {
            case State.INITIAL:
                break;
            case State.PERSUE:
                arriveAvoid.enabled = true;
                arriveAvoid.target = lbBlackboard.antTarget;
                break;
            case State.BRINGBASE:
                arriveAvoid.enabled = true;
                arriveAvoid.target = lbBlackboard.nest.FoodTarget();
                break;
            case State.EAT:
                break;
        }

        currentState = newState;
    }
}

