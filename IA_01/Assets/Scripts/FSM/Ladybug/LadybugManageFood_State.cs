using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steerings;
using FSM;

[RequireComponent(typeof(LadybugBlackboard))]
public class LadybugManageFood_State : FiniteStateMachine
{
    public enum States
    {
        INITIAL, EAT, BRINGBASE
    }

    public States currentState = States.INITIAL;

    private void Awake()
    {
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReEnter()
    {
        base.ReEnter();
    }

    private void Update()
    {
        switch (currentState)
        {
            case States.INITIAL:
                break;
            case States.EAT:
                break;
            case States.BRINGBASE:
                break;
        }
    }

    private void ChangeState(States newState)
    {
        switch (currentState)
        {
            case States.INITIAL:
                break;
            case States.EAT:
                break;
            case States.BRINGBASE:
                break;
        }

        switch (newState)
        {
            case States.INITIAL:
                break;
            case States.EAT:
                break;
            case States.BRINGBASE:
                break;
        }

        currentState = newState;
    }
}
