using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float camDistance = -64.12f;
    // Update is called once per frame
    void LateUpdate()
    {
        
        Vector3 movepos=new Vector3(player.position.x,player.position.y,camDistance);
        transform.position = movepos;
        
    }
}
