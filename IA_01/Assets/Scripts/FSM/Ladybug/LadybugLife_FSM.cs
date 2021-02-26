using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[RequireComponent(typeof(LadybugBlackboard))]
public class LadybugLife_FSM : FiniteStateMachine
{
    public enum State
    {
        INITIAL, IDLE, GOFORFOOD
    }

    public State currentState = State.INITIAL;

    private LadybugBlackboard lbBlackboard;

    private LadybugGoForFood_State goForFood;

    private void Awake()
    {
        lbBlackboard = GetComponent<LadybugBlackboard>();

        goForFood = GetComponent<LadybugGoForFood_State>();
    }

    public override void Exit()
    {
        goForFood.enabled = false;
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
            case State.GOFORFOOD:
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
            case State.GOFORFOOD:
                break;
        }

        switch (newState)
        {
            case State.INITIAL:
                break;
            case State.IDLE:
                break;
            case State.GOFORFOOD:
                goForFood.enabled = true;
                break;
        }

        currentState = newState;
    }
}
