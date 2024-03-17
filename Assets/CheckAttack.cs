using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float monsterStrength = 1000f;
    [SerializeField] float playerStrength = 200f;
    [SerializeField] float playerRecoverTime = 0.5f;
    [SerializeField] GameObject player;
    [SerializeField] float hitback_recover_time = 0.4f;
    private bool playerRecover = false;
    public bool reward = false;
    bool already_hit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter attack zone");
        if(collision.tag=="Monster" && gameObject.tag=="PlayerAttack")
        {
            if(!already_hit)
            {
                already_hit = true;
                Invoke(nameof(alreadyhitRecover), 0.5f);
                collision.gameObject.GetComponent<Monster>().ChangeHealth(-damage);
                collision.gameObject.GetComponent<Monster>().isHit = true;
                Debug.Log("Hit monster" + collision.gameObject.GetComponent<Monster>().GetHealth());
            }
           
        }
        if (collision.tag == "Player" && gameObject.tag == "Monster")
        {
            Reward();
            if(!playerRecover)
            {
                playerRecover = true;
                PlayerManager.instance.TakeDamage();
                
                collision.GetComponentInParent<Player>().ChangeHealth(-damage);
                if(collision.TryGetComponent<StatusMachine>(out StatusMachine statusMachine))
                {
                    Invoke(nameof(PlayerRecover), playerRecoverTime);
                    collision.GetComponent<StatusMachine>().ToGetHit();
                    GameManager.instance.PauseForALimitedTime(40f);
                }
                
               
                InputManager.instance.Disable();
                Invoke(nameof(RecoverInput), 0.4f);
            }
            
        }

                    
        
    }
    void alreadyhitRecover()
    {
        already_hit = false;
    }
    void Reward()
    {
       
        reward = true;
        Debug.Log("Boss hit a player!");
    }
    void RecoverInput()
    {
        InputManager.instance.SetAble();
    }
    void PlayerRecover()
    {
        player.GetComponent<StatusMachine>().HitRecover();
        playerRecover = false;
        player.GetComponent<StatusMachine>().BeHitBack();
        Invoke(nameof(HitbackRecover), hitback_recover_time);
       
    }
    void HitbackRecover()
    {
        player.GetComponent<StatusMachine>().CeaseHitBack();
    }
}
