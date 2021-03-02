using FSM;
using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMD_Spider : FiniteStateMachine
{
    public enum State { INITIAL,SEARCHING, RETURNING, CHOOSING};
    public State currentState = State.INITIAL;

    private SpiderBlackboard blackboard;
    ArrivePlusAvoid target;
    int randomFood = 0;
    float dist = 0;


    // Start is called before the first frame update
    void Awake()
    {
        target = GetComponent<ArrivePlusAvoid>();
        blackboard = GetComponent<SpiderBlackboard>();
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

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.INITIAL:
                Choosing();
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
            
            default:
                break;
        }


    }


    public void Choosing()
    {
        blackboard.food = GameObject.FindGameObjectsWithTag("Food");

        randomFood = Random.Range(0, blackboard.food.Length);
        target.target = blackboard.food[randomFood];
        currentState = State.SEARCHING;
    }

    public void Serching()
    {
        if (target.target == null)
        {
            currentState = State.CHOOSING;
        }
        else
        {
            
            dist = Vector3.Distance(blackboard.food[randomFood].transform.position, this.gameObject.transform.position);

            if (dist < blackboard.takeFoodRadius)
            {
                currentState = State.RETURNING;
                Destroy(blackboard.food[randomFood]);
            }
        }
    }

    public void Returning()
    {
        dist = Vector3.Distance(blackboard.spiderHouse.transform.position, this.gameObject.transform.position);
        
        target.target = blackboard.spiderHouse;

        if (dist < blackboard.dropFoodRadius)
        {
            currentState = State.CHOOSING;
        }
    }

   
}
