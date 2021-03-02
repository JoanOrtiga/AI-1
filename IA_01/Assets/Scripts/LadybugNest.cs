using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadybugNest : MonoBehaviour
{
    public GameObject storeHouse;
    public GameObject child;

    public int savedFood;

    public float hungerInc = 0.01f;
    public float childHunger = 0;

    public float needFoodThreshhold = 5f;


    private void Update()
    {
        childHunger += hungerInc * Time.deltaTime;
    }

    public bool ChildNeedFood()
    {
        if (childHunger >= needFoodThreshhold)
            return true;

        return false;
    }

    public GameObject FoodTarget()
    {
        if (ChildNeedFood())
        {
            return child;
        }
        else
        {
            return storeHouse;
        }
    }

    public void GiveFood()
    {
        childHunger = 0;
    }
}
