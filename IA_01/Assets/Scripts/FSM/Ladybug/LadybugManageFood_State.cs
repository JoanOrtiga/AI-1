using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steerings;
using FSM;

[RequireComponent(typeof(LadybugBlackboard))]
[RequireComponent(typeof(ArrivePlusAvoid))]
public class LadybugManageFood_State : FiniteStateMachine
{
    public enum State
    {
        INITIAL, EAT, BRINGBASE
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
                ChangeState(State.BRINGBASE);
                break;
            case State.EAT:
                lbBlackboard.eatElapsedTime -= Time.deltaTime;
                lbBlackboard.transportingFood = false;
                Destroy(lbBlackboard.antTarget);
                break;
            case State.BRINGBASE:
                if(lbBlackboard.hunger > lbBlackboard.needToEatThreshold)
                {
                    ChangeState(State.EAT);
                }

                arriveAvoid.target = lbBlackboard.nest.FoodTarget();

                if (SensingUtils.DistanceToTarget(gameObject, arriveAvoid.target) < lbBlackboard.distanceToInteract)
                {
                    if (lbBlackboard.nest.ChildNeedFood())
                    {
                        lbBlackboard.nest.GiveFood();
                    }
                    else
                    {
                        lbBlackboard.nest.savedFood++;
                    }

                    lbBlackboard.transportingFood = false;
                    Destroy(lbBlackboard.antTarget);
                }

                break;
        }
    }

    private void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.INITIAL:
                break;
            case State.EAT:
                break;
            case State.BRINGBASE:
                break;
        }

        switch (newState)
        {
            case State.INITIAL:
                break;
            case State.EAT:
                lbBlackboard.eatElapsedTime = lbBlackboard.eatingTime;
                break;
            case State.BRINGBASE:
                break;
        }

        currentState = newState;
    }
}
