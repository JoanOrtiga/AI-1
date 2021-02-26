using UnityEngine;
using FSM;

/*
[RequireComponent(typeof(BATCAT_Blackboard))]
//[RequireComponent(typeof(BATCAT_Blackboard))]

public class FSM_BATCAT_DAILY : FiniteStateMachine
{

    public enum State { INITIAL, JAILING, FEEDING };

    public State currentState = State.INITIAL;

    // the FSM for the jailing behaviour in the jailing state
    private FSM_BATCAT_JAILING jailing;

    // the FSM for the feeding behaviour in the feeding state
    private FSM_BATCAT_FEED feeding;

    private BATCAT_Blackboard blackboard;

    void Start()
    {
        // get the machines that are states
        jailing = gameObject.GetComponent<FSM_BATCAT_JAILING>();
        feeding = gameObject.GetComponent<FSM_BATCAT_FEED>();

        jailing.enabled = false;
        feeding.enabled = false;

        // get the blackboard
        blackboard = GetComponent<BATCAT_Blackboard>();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void ReEnter()
    {
        base.ReEnter();
    }


    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.INITIAL:
                ChangeState(State.JAILING);
                break;
            case State.JAILING:
                if (blackboard.hunger >= blackboard.hungerTooHigh && !Busy())
                {
                    ChangeState(State.FEEDING);
                    break;
                }
                // do nothing in particular. Let the Jailing FSM do the job
                break;
            case State.FEEDING:
                if (blackboard.hunger <= blackboard.hungerLowEnough)
                {
                    ChangeState(State.JAILING);
                }
                // do nothing in particular. Let the feeding FSM do the job
                break;
        }
    }

    void ChangeState(State newState)
    {
        // exit logic
        switch (currentState)
        {
            case State.JAILING:
                jailing.Exit(); // exit (stop) the jailing FSM
                break;
            case State.FEEDING:
                feeding.Exit(); // exit (stop) the feeding FMS
                break;
        }

        // enter logic
        switch (newState)
        {
            case State.JAILING:
                jailing.ReEnter();  // (Re)Enter the jailing FSM
                break;
            case State.FEEDING:
                feeding.ReEnter();  // (Re)Enter the feeding FSM
                break;
        }

        currentState = newState;
    }

    // the Busy condition used in the transition from JAILING TO FEEDING
    private bool Busy()
    {
        return jailing.currentState == FSM_BATCAT_JAILING.State.TRANSPORTING;
    }
}

    */