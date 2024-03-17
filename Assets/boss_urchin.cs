using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class boss_urchin : Agent
{
    [SerializeField] float JumpForce = 12000f;
    [SerializeField] float JumpCoolDown = 10f;
    [SerializeField] GameObject danger_Light;
    [SerializeField] GameObject Checkbox;
    [SerializeField] MonsterMovement monsterMovement;
    [SerializeField] CheckAttack checkattack;
    [SerializeField] CheckAttack Secondattack;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    [SerializeField] GameObject player;
    
    private bool readyjump = true;
    private bool attacking = false;
    private Rigidbody2D rb;
    public override void Initialize()
    {
        danger_Light.SetActive(false);
        Checkbox.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        monsterMovement = GetComponent<MonsterMovement>();
    }
    private void Heuris()
    {
        if(!readyjump &&rb.velocity.y<-0.1f&&!attacking)
        {
            danger_Light.SetActive(true); 
            attacking = true;
            Invoke(nameof(ActivateAttackZone), 1.2f);
        }
       
        if(Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> l = actionsOut.DiscreteActions;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            l[0] = 2;
        }
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log(actions.DiscreteActions[0]);
        if (!readyjump && rb.velocity.y < -0.1f && !attacking)
        {
            danger_Light.SetActive(true);
            attacking = true;
            Invoke(nameof(ActivateAttackZone), 1.2f);
        }
        if (actions.DiscreteActions[0]==0)
        {
            monsterMovement.Move(1);
        }
        if (actions.DiscreteActions[0]==1)
        {
            monsterMovement.Move(-1);
        }
        if (actions.DiscreteActions[0]==2 &&readyjump)
        {
            Jump();
        }
      

        if(checkattack.reward)
        {
            AddReward(1f);
            checkattack.reward = false;
            EndEpisode();
        }
        if (Secondattack.reward)
        {
            AddReward(1.5f);
            Secondattack.reward = false;
            EndEpisode();
        }
        if (GetComponent<BossCheck>().trapped)
        {
            AddReward(-0.5f);
            GetComponent<BossCheck>().trapped = false;
            EndEpisode();
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(readyjump?1:0);//1
        sensor.AddObservation(left.position.x);//1
        sensor.AddObservation(right.position.x);//1
        sensor.AddObservation(Vector3.Dot(player.transform.position,transform.position));
    }
    public override void OnEpisodeBegin()
    {
        player.transform.localPosition = new Vector2(Random.Range(-17f, 18f), -2.67f);
        transform.localPosition = new Vector3(Random.Range(-17f, 18f), -1.08f);
    }
    void Jump()
    {
        AddReward(-0.9f);
        readyjump = false ;
        rb.AddForce(new Vector2(0, JumpForce),ForceMode2D.Impulse);
        Invoke(nameof(Recover), JumpCoolDown);
    }
    private void Recover()
    {
        readyjump = true;
        attacking = false;
    }
    private void ActivateAttackZone()
    {
        CameraShake.instance.ShakeIntensity = 10f;
        CameraShake.instance.ShakeTime = 0.6f;
        CameraShake.instance.ShakeCamera();
        Debug.Log("AttackZone activated");    
        Checkbox.SetActive(true);
        danger_Light.SetActive(false);
        Invoke(nameof(DeactivateZone), 0.1f);
    }
    private void DeactivateZone()
    {
        Checkbox.SetActive(false);
    }
    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
