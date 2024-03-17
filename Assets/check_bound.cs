using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_bound : MonoBehaviour
{
    public bool end = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            end= true;  
        }
    }
}
