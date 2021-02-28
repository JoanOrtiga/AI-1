using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesActions : MonoBehaviour
{
    public GameObject shoeL, shoeR;
    public float radius = 10f;

    private void Update()
    {
        ShoeRKillingWithRadius();
        ShoeLKillingWithRadius();
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
}
