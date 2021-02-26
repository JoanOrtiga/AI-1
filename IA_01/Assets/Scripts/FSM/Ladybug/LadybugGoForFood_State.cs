using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FSM;

[RequireComponent(typeof(LadybugBlackboard))]
public class LadybugGoForFood_State : FiniteStateMachine
{
    public enum State
    {
        INITIAL, PERSUE, BRINGBASE, EAT
    }

    public State currentState = State.INITIAL;

    private LadybugBlackboard lbBlackboard;

    private void Awake()
    {
        lbBlackboard = GetComponent<LadybugBlackboard>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReEnter()
    {
        currentState = State.INITIAL;
        base.ReEnter();
    }
}

