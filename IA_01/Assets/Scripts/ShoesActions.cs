using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesActions : MonoBehaviour
{
    public GameObject food;
    public float radius = 10f;

    private GameObject shoeL, shoeR, foodSpawn;
    private float counter = 0f;

    private void Start()
    {
        shoeL = transform.GetChild(0).gameObject;
        shoeR = transform.GetChild(1).gameObject;
        foodSpawn = transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        ShoeRKillingWithRadius();
        ShoeLKillingWithRadius();
        DropFood();
    }

    public void ShoeRKillingWithRadius()
    {
        GameObject ant = SensingUtils.FindInstanceWithinRadius(shoeR, "ANT", radius);

        if (ant != null)
        {
            Destroy(ant);
        }
    }
    public void ShoeLKillingWithRadius()
    {
        GameObject ant = SensingUtils.FindInstanceWithinRadius(shoeL, "ANT", radius);

        if (ant != null)
        {
            Destroy(ant);
        }
    }

    public void DropFood()
    {
        counter += Time.deltaTime;

        if (counter >= 10f)
        {
            Instantiate(food, foodSpawn.transform.position, foodSpawn.transform.rotation);
            counter = 0f;
        }
    }

    public void Avoidance()
    {
        
    }
}
