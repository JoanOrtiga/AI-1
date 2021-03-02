using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
using Steerings;
using System;

[RequireComponent(typeof(WanderPlusAvoid))]
[RequireComponent(typeof(Hide))]
[RequireComponent(typeof(Rat_BlackBoard))]

public class Rats_FSM : FiniteStateMachine
{
    public enum State
    {
        INITIAL, WANDER, HIDE
    }

    public State currentState = State.INITIAL;
    private Rat_BlackBoard ratBlackboard;
    private WanderPlusAvoid wanderPlusAvoid;
    private Hide hide;
    private GameObject enemy;

    private void Awake()
    {
        hide = GetComponent<Hide>();
        ratBlackboard = GetComponent<Rat_BlackBoard>();
        wanderPlusAvoid = GetComponent<WanderPlusAvoid>();
        wanderPlusAvoid.enabled = false;
        hide.enabled = false;
        hide.detectEnemyRadius = ratBlackboard.enemyRadius;
        hide.hideOffset = ratBlackboard.hideOffset;
        hide.findHideSpotRadius = ratBlackboard.HideSpotRadius;
        hide.enemyTag = ratBlackboard.enemyTag;
        hide.hideObjectsTag = ratBlackboard.obstacleTag;
    }

    public override void Exit()
    {
        wanderPlusAvoid.enabled = false;
        hide.enabled = false;
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
                ChangeState(State.WANDER);
                break;
            case State.WANDER:
                enemy = SensingUtils.FindInstanceWithinRadius(this.gameObject, ratBlackboard.enemyTag, ratBlackboard.enemyRadius);
                if (enemy != null)
                {
                    ChangeState(State.HIDE);
                }
                break;
            case State.HIDE:
                enemy = SensingUtils.FindInstanceWithinRadius(this.gameObject, ratBlackboard.enemyTag, ratBlackboard.enemyRadius);
                if (enemy == null)
                {
                    ChangeState(State.WANDER);
                }
                break;
            default:
                break;
        }
    }

    void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.INITIAL:
                break;
            case State.WANDER:
                wanderPlusAvoid.enabled = false;
                break;
            case State.HIDE:
                hide.enabled = false;
                break;
        }

        switch (newState)
        {
             
            case State.WANDER:
                wanderPlusAvoid.enabled = true;
                break;
            case State.HIDE:
                hide.enabled = true;
                break;
        }

        currentState = newState;
    }

 

     
}
