using System.Collections;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AttackAgent : Agent
{
    [SerializeField] Transform[] attackpoints;
    [SerializeField] GameObject Target;
    [SerializeField] GameObject AttackZone;
    [SerializeField] float AttackCoolDown=0.7f;
    [SerializeField] Animator anim;
    [SerializeField] float movespeed=1f;
    [SerializeField] CheckAttack check_attack;
    private Rigidbody2D rb;
    private bool Facing_Right = true;
    private bool ReadyAttack = true;
    private bool penalty = false;

    public override void OnEpisodeBegin()
    {
        transform.localPosition=new Vector2(Random.Range(-6.5f, 11.7f), -1.0011f);
        Target.transform.localPosition = new Vector2(Random.Range(-6.5f, 11.7f), -1.0011f);
    }
    public override void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        float minimumAttackDistance =100;
        foreach(var attackpoint in attackpoints)
        {
            minimumAttackDistance=Mathf.Min(Vector2.Distance(AttackZone.transform.position, attackpoint.position), minimumAttackDistance);
        }
        sensor.AddObservation(minimumAttackDistance);//1
        sensor.AddObservation(transform.position);//3
        sensor.AddObservation(Target.transform.position);//3
        sensor.AddObservation(Facing_Right);//1
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0]==0)
        {
            rb.AddForce(new Vector2(-1, 0) * movespeed);
            if (Facing_Right) { Flip(); }
        }
        if (actions.DiscreteActions[0] == 1)
        {
            rb.AddForce(new Vector2(1, 0) * movespeed);
            if (!Facing_Right) { Flip(); }
        }
        if (actions.DiscreteActions[0] == 2)
        {

        }

        if (actions.DiscreteActions[1] == 0 && ReadyAttack)
        {
            SetReward(-0.05f);
            StartAttack();
            StartCoroutine(attackfinish());
            Invoke(nameof(ReadyForNextAttack), AttackCoolDown);
        }

        if(check_attack.reward==true)
        {
            check_attack.reward = false;
            SetReward(1f);
            EndEpisode();
            
        }
        if(penalty)
        {
            SetReward(-0.5f);
            penalty = false;
            EndEpisode();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Obstacle")
        {
            penalty = true;
        }
    }

    void Handle()
    {
        if (Input.GetMouseButtonDown(0) && ReadyAttack)
        {
            StartAttack();
            StartCoroutine(attackfinish());
            Invoke(nameof(ReadyForNextAttack), AttackCoolDown);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-1, 0) * movespeed);
            if (Facing_Right) { Flip(); }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(1, 0) * movespeed);
            if (!Facing_Right)
            {
                Flip();
            }
        }
    }
    void StartAttack()
    {
        anim.SetBool("IsAttack",true);
        ReadyAttack = false;
        AttackZone.SetActive(true);
    }

    void ReadyForNextAttack()
    {     
        ReadyAttack = true;
    }

    IEnumerator attackfinish()
    {
        yield return new WaitForSeconds(0.17f);

        anim.SetBool("IsAttack", false);
        AttackZone.SetActive(false);
        StopCoroutine(attackfinish());
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        Facing_Right =!Facing_Right;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
