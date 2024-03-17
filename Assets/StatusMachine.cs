using TMPro;
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class StatusMachine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask m_WhatIsGround;
    [SerializeField] float GroundCheckRadius = 0.2f;  
    private bool isOnland = true;
    private bool isHit = false;
    private bool isAttack=false;
    private bool isHitback = false;
    public enum statusList
    {
        Ascending,Falling,Attacking,Walking,Idling,GetHit
    }
    private string status;
    private void Start()
    {
        status = statusList.Idling.ToString();
    }
    private void Update()
    {
        if(display!=null)display.text = status+" "+isOnland.ToString();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position,GroundCheckRadius, m_WhatIsGround);     
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isOnland = true;
            }
        }

        isAttack = GetComponent<PlayerMovement>().IsPlayerAttack();
        if (GetComponent<Rigidbody2D>() != null && !isHit &&!isAttack)
        {
            if (GetComponent<Rigidbody2D>().velocity.y>0.9f && isOnland)
            {
                ToAscending();
            }
            if(GetComponent<Rigidbody2D>().velocity.y<-0.9f)
            {
                ToFalling();
            }
            if(GetComponent<Rigidbody2D>().velocity.x==0 && isOnland)
            {
                ToIdling();
            }
            if(GetComponent<Rigidbody2D>().velocity.x != 0 && isOnland)
            {
                ToWalking();
            }
        }
        if(isHit)
        {
            ToGetHit();
        }
        else
        {
            if(isAttack)
            {
                ToAttacking();
            }
        }
    }
    private void ToAscending()
    {
        status = statusList.Ascending.ToString();
        isOnland = false;
    }
    private void ToFalling()
    {
        status = statusList.Falling.ToString();
        isOnland = false;
    }
    private void ToAttacking()
    {
        status = statusList.Attacking.ToString();
    }
    private void ToWalking()
    {
        status = statusList.Walking.ToString();
        isOnland = true;
    }
    private void ToIdling()
    {
        status = statusList.Idling.ToString();
        isOnland = true;
    }
    public void ToGetHit()
    {
        isHit = true;
        status=statusList.GetHit.ToString();
    }
    public bool IsPlayerOnland()
    {
        return isOnland;
    }
    public void PlayerLanded()
    {
        isOnland=true;
    }
    public void PlayerOnAir()
    {
        isOnland=false;
    }
    public void HitRecover()
    {
        isHit=false;
    }
    public string GetStatus()
    {
        return status;
    }
    public void BeHitBack()
    {
        isHitback = true;
    }
    public void CeaseHitBack()
    {
       
        isHitback = false;
    }
    public bool isHitBack()
    {
        return isHitback;
    }
    
}
