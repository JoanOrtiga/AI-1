using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Steerings;

[RequireComponent(typeof(AntBlackboard))]
[RequireComponent(typeof(FlockingAroundPlusAvoid))]

public class AntLife_FSM : FiniteStateMachine
{
    public enum State
    {
        INITIAL, FOLLOWING, DEAD
    }

    public State currentState = State.INITIAL;

    private AntBlackboard antBlackBoard;

    private FlockingAroundPlusAvoid flockingAroundPlusAvoid;

    private void Awake()
    {
        antBlackBoard = GetComponent<AntBlackboard>();

        flockingAroundPlusAvoid = GetComponent<FlockingAroundPlusAvoid>();

        flockingAroundPlusAvoid.enabled = false;
    }

    public override void Exit()
    {
        flockingAroundPlusAvoid.enabled = false;
        base.Exit();
    }

    public override void ReEnter()
    {
        currentState = State.INITIAL;
        base.ReEnter();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.INITIAL:
                ChangeState(State.FOLLOWING);
                break;
            case State.FOLLOWING:
                Follow();
                break;
            default:
                break;
        }
    }

    void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.FOLLOWING:
                flockingAroundPlusAvoid.enabled = false;
                break;
            case State.DEAD:
                break;
        }

        // enter logic
        switch (newState)
        {
            case State.FOLLOWING:
                flockingAroundPlusAvoid.attractor = antBlackBoard.mouseAttractor;
                flockingAroundPlusAvoid.enabled = true;
                break;
            case State.DEAD:

                break;
        }

        currentState = newState;
    }

    public void Follow()
    {
        GameObject food = SensingUtils.FindInstanceWithinRadius(gameObject, "Food", antBlackBoard.takeFoodRadius);

        if (food != null)
        {
            antBlackBoard.antSpawner.SpawnNewAnt();
            Destroy(food);
        }
    }
}
