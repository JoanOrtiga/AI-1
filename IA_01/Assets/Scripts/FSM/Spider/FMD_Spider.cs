using FSM;
using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMD_Spider : FiniteStateMachine
{
    public enum State { INITIAL, SEARCHING, RETURNING, CHOOSING };
    public State currentState = State.INITIAL;

    private SpiderBlackboard blackboard;
    private ArrivePlusAvoid arriveAvoid;
    int randomFood = 0;
    float dist = 0;


    // Start is called before the first frame update
    void Awake()
    {
        arriveAvoid = GetComponent<ArrivePlusAvoid>();
        blackboard = GetComponent<SpiderBlackboard>();

        arriveAvoid.enabled = false;
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

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.INITIAL:
                ChangeState(State.CHOOSING);
                break;

            case State.CHOOSING:
                Choosing();
                break;

            case State.SEARCHING:
                Serching();
                break;

            case State.RETURNING:
                Returning();
                break;
        }
    }

    private void ChangeState(State newState)
    {
        switch (currentState)
        {
            case State.SEARCHING:
                arriveAvoid.enabled = false;
                break;
            case State.RETURNING:
                arriveAvoid.enabled = false;
                break;
            case State.CHOOSING:
                break;
        }

        switch (newState)
        {
            case State.SEARCHING:
                arriveAvoid.enabled = true;
                break;
            case State.RETURNING:
                arriveAvoid.target = blackboard.spiderHouse;
                arriveAvoid.enabled = true;
                break;
            case State.CHOOSING:
                break;
        }

        currentState = newState;
    }


    public void Choosing()
    {
        blackboard.food = GameObject.FindGameObjectsWithTag("Food");

        if (blackboard.food != null)
            if (blackboard.food.Length != 0)
            {
                randomFood = Random.Range(0, blackboard.food.Length);
                arriveAvoid.target = blackboard.food[randomFood];

                if(arriveAvoid.target != null)
                    ChangeState(State.SEARCHING);
            }
    }

    public void Serching()
    {
        if (arriveAvoid.target == null)
        {
            ChangeState(State.CHOOSING);
            return;
        }
          

        if (SensingUtils.DistanceToTarget(this.gameObject, arriveAvoid.target) < blackboard.takeFoodRadius)
        {
            ChangeState(State.RETURNING);
            Destroy(blackboard.food[randomFood]);
        }
    }

    public void Returning()
    {
        if (SensingUtils.DistanceToTarget(this.gameObject, blackboard.spiderHouse) < blackboard.dropFoodRadius)
        {
            ChangeState(State.CHOOSING);
        }
    }
}
