using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] float playerRecoverTime = 0.5f;
    [SerializeField] GameObject player;
    [SerializeField] float hitback_recover_time = 0.4f;
    public bool canAttack=false;
    private bool Hitplayer = false;
    private bool playerRecover = false;
    public bool reward = false;
    bool already_hit = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag=="Player" && canAttack)
        {
            Hitplayer = true;
            Debug.Log("Hit player");
            collision.GetComponent<Player>().ChangeHealth(0);
            if (collision.TryGetComponent<StatusMachine>(out StatusMachine statusMachine))
            {
                Invoke(nameof(PlayerRecover), playerRecoverTime);
                collision.GetComponent<StatusMachine>().ToGetHit();
                GameManager.instance.PauseForALimitedTime(40f);
                PlayerManager.instance.TakeDamage();
            }
            canAttack = false;
        }
        else
        {
            canAttack = false;
            Hitplayer = false;
        }
    }
    public bool isPlayerHit()
    {
        return Hitplayer;
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
