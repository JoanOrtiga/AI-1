using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FSM;
using Steerings;

[RequireComponent(typeof(LadybugBlackboard))]
[RequireComponent(typeof(LadybugManageFood_State))]
[RequireComponent(typeof(ArrivePlusAvoid))]
public class LadybugGoForFood_State : FiniteStateMachine
{
    public enum State
    {
        INITIAL, PURSUE, MANAGEFOOD
    }

    public State currentState = State.INITIAL;

    private LadybugBlackboard lbBlackboard;

    private ArrivePlusAvoid arriveAvoid;
    private LadybugManageFood_State manageFood;

    private void Awake()
    {
        lbBlackboard = GetComponent<LadybugBlackboard>();

        arriveAvoid = GetComponent<ArrivePlusAvoid>();
        manageFood = GetComponent<LadybugManageFood_State>();

        manageFood.enabled = false;
        arriveAvoid.enabled = false;
    }

    public override void Exit()
    {
        arriveAvoid.enabled = false;
        arriveAvoid.target = null;
        manageFood.Exit();
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
                ChangeState(State.PURSUE);
                break;
            case State.PURSUE:

                arriveAvoid.target = lbBlackboard.antTarget;

                if (arriveAvoid.target == null)
                    break;

                if (SensingUtils.DistanceToTarget(gameObject, arriveAvoid.target) < lbBlackboard.distanceToKill && !lbBlackboard.transportingFood)
                {
                    lbBlackboard.antTarget.transform.parent = transform;
                    lbBlackboard.antTarget.transform.position = transform.position;
                    lbBlackboard.antTarget.GetComponent<AntLife_FSM>().Die();
                    lbBlackboard.antTarget.tag = "ANT_DEAD";

                    lbBlackboard.transportingFood = true;
                    ChangeState(State.MANAGEFOOD);
                }
                break;
            case State.MANAGEFOOD:
                if (!lbBlackboard.transportingFood && lbBlackboard.antTarget != null)
                {
                    ChangeState(State.PURSUE);
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
            case State.PURSUE:
                arriveAvoid.enabled = false;
                break;
            case State.MANAGEFOOD:
                manageFood.Exit();
                break;
        }

        switch (newState)
        {
            case State.INITIAL:
                break;
            case State.PURSUE:
                arriveAvoid.target = lbBlackboard.antTarget;
                arriveAvoid.closeEnoughRadius = lbBlackboard.distanceToKill;
                arriveAvoid.enabled = true;
                break;
            case State.MANAGEFOOD:
                manageFood.ReEnter();                
                break;
        }

        currentState = newState;
    }
}

