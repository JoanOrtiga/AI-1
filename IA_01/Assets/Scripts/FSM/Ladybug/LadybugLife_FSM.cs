using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Steerings;

[RequireComponent(typeof(LadybugBlackboard))]
[RequireComponent(typeof(WanderPlusAvoid))]
public class LadybugLife_FSM : FiniteStateMachine
{
    public enum State
    {
        INITIAL, IDLE, WANDER, GOFORFOOD
    }

    public State currentState = State.INITIAL;

    private LadybugBlackboard lbBlackboard;

    private LadybugGoForFood_State goForFood;
    private WanderPlusAvoid wanderAvoid;

    private void Awake()
    {
        lbBlackboard = GetComponent<LadybugBlackboard>();

        goForFood = GetComponent<LadybugGoForFood_State>();
        wanderAvoid = GetComponent<WanderPlusAvoid>();
    }

    public override void Exit()
    {
        goForFood.Exit();
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
                ChangeState(State.IDLE);
                break;
            case State.IDLE:
                break;
            case State.WANDER:
                lbBlackboard.antTarget = SensingUtils.FindInstanceWithinRadius(gameObject, "ANT", lbBlackboard.seeDistance);
                if(lbBlackboard.antTarget != null)
                {
                    ChangeState(State.GOFORFOOD);
                }
                break;
            case State.GOFORFOOD:
                lbBlackboard.antTarget = SensingUtils.FindInstanceWithinRadius(gameObject, "ANT", lbBlackboard.seeDistance);
                if (lbBlackboard.antTarget == null)
                {
                    ChangeState(State.WANDER);
                }
                break;
        }
    }

    void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.INITIAL:
                break;
            case State.IDLE:
                break;
            case State.WANDER:
                wanderAvoid.enabled = false;
                break;
            case State.GOFORFOOD:
                goForFood.Exit();
                break;
        }

        switch (newState)
        {
            case State.INITIAL:
                break;
            case State.IDLE:
                break;
            case State.WANDER:
                wanderAvoid.enabled = true;
                break;
            case State.GOFORFOOD:
                goForFood.ReEnter();
                break;
        }

        currentState = newState;
    }
}
