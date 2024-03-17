using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    private bool isDead = false;
    public bool isBoss = false;
    public bool isHit;
    public float recover_time = .5f;
    void Die()
    {
        isDead = true;
    }
    void Diminish()
    {
        gameObject.SetActive(false);
    }
    public void ChangeHealth(int diff)
    {
        health += diff;
    }
    public bool IsDead()
    {
        return isDead;
    }
    public int GetHealth()
    {
        return health;
    }
    private void Update()
    {
        if(health<=0)
        {
            Die();
        }
        if (isDead)
        {
            animator.SetBool("isDead", true);
            if(!isBoss) { Invoke(nameof(Diminish), 0.6f); }
            
        }
        if(isHit &&!isBoss)
        {
            animator.SetBool("isHit", true);
            Invoke(nameof(Recover), recover_time);
        }

    }
    void Recover()
    {
        isHit = false;
        animator.SetBool("isHit", false);
    }
}
