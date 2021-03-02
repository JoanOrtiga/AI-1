using FSM;
using Steerings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMD_Spider : FiniteStateMachine
{
    public enum State { SEARCHING, RETURNING, CHOOSING};
    public State currentState = State.CHOOSING;

    private SpiderBlackboard blackboard;
    int randomFood = 0;
    float dist = 0;


    // Start is called before the first frame update
    void Start()
    {
        blackboard = GetComponent<SpiderBlackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
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
        print("Choosing");
        blackboard.food = GameObject.FindGameObjectsWithTag("Food");

        randomFood = Random.Range(0, blackboard.food.Length);
        gameObject.GetComponent<ArrivePlusAvoid>().target = blackboard.food[randomFood];
        currentState = State.SEARCHING;
    }

    public void Serching()
    {
        print("Serch");
        if (gameObject.GetComponent<ArrivePlusAvoid>().target == null)
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
        print("Return");
        dist = Vector3.Distance(blackboard.spiderHouse.transform.position, this.gameObject.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, blackboard.spiderHouse.transform.position, blackboard.speed * Time.deltaTime);
        gameObject.GetComponent<ArrivePlusAvoid>().target = blackboard.spiderHouse;

        if (dist < blackboard.dropFoodRadius)
        {
            currentState = State.CHOOSING;
        }
    }

   
}
