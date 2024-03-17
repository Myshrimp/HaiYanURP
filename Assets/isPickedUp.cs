using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPickedUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ReturnShipEvent.instance.EnergyBlock += 1;
            ReturnShipEvent.instance.ReturnShip();
        }
    }
}
