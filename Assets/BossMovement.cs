using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class BossMovement : Agent
{
    [SerializeField] Animator anim;
    [SerializeField] float HeavyAttackCoolDown = 5f;
    [SerializeField] float LightAttackCoolDown = 1f;
    [SerializeField] CheckPlayer check;
    [SerializeField] CheckPlayer attack1;
    [SerializeField] bool heavy_attack_ready = true;
    [SerializeField] bool light_attack_ready = true;
    [SerializeField] AudioSource AU_atk02;
    [SerializeField] AudioSource AU_atk01;
    [SerializeField] GameObject player;
    private bool attack01 = false;
    private bool attack02 = false;
    public float attack02_duration = 0.3f;
    public float attack01_duration = 0.4f;

    /*
    private void Update()
    {
       return;
       if(GetComponent<Monster>().GetHealth()<=0)
        {
            Debug.Log("Boss died");
            anim.SetBool("isDead", true);
            Invoke(nameof(Disappear), 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.P)&&heavy_attack_ready)
        {
            anim.SetBool("attack02", true);
            Heavy_attack();
        }
        if(Input.GetKeyDown(KeyCode.O) && light_attack_ready)
        {
            anim.SetBool("attack01", true);
            LightAttack();
        }
    }
    */
    public override void OnEpisodeBegin()
    {
        GetComponent<check_bound>().end = false;
        //GetComponent<Reset>().SceneReset();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        if(GetComponent<check_bound>().end)
        {
            AddReward(-1f);
            //EndEpisode();
        }
        if(check.isPlayerHit())
        {
            AddReward(1.2f);
           // EndEpisode();
        }
        if(attack1.isPlayerHit())
        {
            AddReward(0.8f);
           // EndEpisode();
        }
        Train(actions.DiscreteActions[0]);

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
        sensor.AddObservation(player.transform.position);
        sensor.AddObservation(Vector2.Distance(this.transform.position, player.transform.position));
        sensor.AddObservation(this.transform.position.x - player.transform.position.x > 0 ? 1 : -1);
    }
    private void Train(int action)
    {
        Debug.Log(action);
        if (GetComponent<Monster>().GetHealth() <= 0)
        {
            Debug.Log("Boss died");
            anim.SetBool("isDead", true);
            Invoke(nameof(Disappear), 0.5f);
        }
        if (action==0 && heavy_attack_ready)
        {
            AddReward(-0.9f);
            anim.SetBool("attack02", true);
            Heavy_attack();
        }
        if (action==1 && light_attack_ready)
        {
            AddReward(-0.8f);
            anim.SetBool("attack01", true);
            LightAttack();
        }
        if(action==2)
        {
            GetComponent<MonsterMovement>().Move(1);
        }
        if(action==3)
        {
            GetComponent<MonsterMovement>().Move(-1);
        }
    }
    void Heavy_attack()
    {
        AU_atk02.Play();
        attack02 = true;
        heavy_attack_ready = false;
        Invoke(nameof(StopAttack02), attack02_duration);
        Invoke(nameof(HeavyAttackAct),0.8f);
    }
    void LightAttack()
    {
        attack01 = true;
        light_attack_ready = false;
        Invoke(nameof(StopAttack01), attack01_duration);
        Invoke(nameof(LightAttackAct), attack01_duration - 0.2f);
    }
    void HeavyAttackAct()
    {
       
        Invoke(nameof(Ready), HeavyAttackCoolDown);
        check.canAttack = true;
        Invoke(nameof(DisableAttack02), 0.2f);
        check.gameObject.transform.position = new Vector2(check.gameObject.transform.position.x + 0.1f, check.gameObject.transform.position.y);
    }
    void LightAttackAct()
    {
        AU_atk01.Play();
        Invoke(nameof(ReadyAttack1), LightAttackCoolDown);
        attack1.canAttack = true;
        Invoke(nameof(DisableAttack01), 0.2f);
        attack1.gameObject.transform.position = new Vector2(attack1.gameObject.transform.position.x + 0.1f, attack1.gameObject.transform.position.y);
    }
    private void StopAttack01()
    {
        AU_atk01.Stop();
        anim.SetBool("attack01", false);
    }
    private void StopAttack02()
    {
        AU_atk02.Stop();
        anim.SetBool("attack02", false);
    }
    void Ready()
    {
        heavy_attack_ready=true;
    }
    void ReadyAttack1()
    {
        light_attack_ready = true;
    }
    void Disappear()
    {
        this.gameObject.SetActive(false);
    }
    private void DisableAttack01()
    {
       attack1.canAttack=false;
    }
    private void DisableAttack02()
    {
        check.canAttack = false;
    }
   
}
